using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.CourseGroups.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.CourseGroups.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class CreateCourseGroupCommand : IRequest<CreateCourseGroupResponse>
{
    public string GroupName { get; set; }
    public int Quota { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime EndedDate { get; set; }
    public Guid CourseId { get; set; }
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }
    public List<int> DaysOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public class CreateCourseGroupCommandHandler : IRequestHandler<CreateCourseGroupCommand, CreateCourseGroupResponse>
    {
        private readonly ICourseGroupService courseGroupService;
        private readonly ICourseScheduleService courseScheduleService;
        private readonly IMapper mapper;
            private readonly CourseGroupBusinessRules _courseGroupBusinessRules;

        public CreateCourseGroupCommandHandler(ICourseGroupService courseGroupService, IMapper mapper, ICourseScheduleService courseScheduleService, CourseGroupBusinessRules courseGroupBusinessRules)
        {
            this.courseGroupService = courseGroupService;
            this.mapper = mapper;
            this.courseScheduleService = courseScheduleService;
            _courseGroupBusinessRules = courseGroupBusinessRules;
        }

        public async Task<CreateCourseGroupResponse> Handle(CreateCourseGroupCommand request, CancellationToken cancellationToken)
        {
            await _courseGroupBusinessRules.EnsureCourseExistsAsync(request.CourseId);
            await _courseGroupBusinessRules.EnsureClassExistsAsync(request.ClassId);
            await _courseGroupBusinessRules.EnsureTeacherExistsAsync(request.TeacherId);
            _courseGroupBusinessRules.EnsureStartDateIsBeforeEndDate(request.StartedDate, request.EndedDate);
                _courseGroupBusinessRules.EnsureCourseDurationAtLeastOneMonth(request.StartedDate, request.EndedDate);
            _courseGroupBusinessRules.EnsureQuotaInLimits(request.Quota);
            await _courseGroupBusinessRules.EnsureGroupNameIsUniqueInCourseAsync(request.GroupName, request.CourseId);

                _courseGroupBusinessRules.EnsureLessonDurationMaxFortyMinutes(request.StartTime, request.EndTime);

            CourseGroup courseGroup = mapper.Map<CourseGroup>(request);
            courseGroup = await courseGroupService.AddAsync(courseGroup);

            foreach (var day in request.DaysOfWeek)
            {
                CourseSchedule courseSchedule = new CourseSchedule();
                courseSchedule.DayOfWeek = day;
                courseSchedule.CourseGroup = courseGroup;
                courseSchedule.CourseGroupId = courseGroup.Id;
                courseSchedule.StartTime = request.StartTime;
                courseSchedule.EndTime = request.EndTime;

                await courseScheduleService.AddAsync(courseSchedule);
            }

            return mapper.Map<CreateCourseGroupResponse>(courseGroup);
        }
    }
}
