using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.CourseGroups.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class UpdateCourseGroupCommand : IRequest<UpdateCourseGroupResponse>
{
    public Guid Id { get; set; }
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

    public class UpdateCourseGroupCommandHandler : IRequestHandler<UpdateCourseGroupCommand, UpdateCourseGroupResponse>
    {
        private readonly ICourseGroupService courseGroupService;
        private readonly IMapper mapper;
        public UpdateCourseGroupCommandHandler(ICourseGroupService courseGroupService, IMapper mapper)
        {
            this.courseGroupService = courseGroupService;
            this.mapper = mapper;
        }

        public async Task<UpdateCourseGroupResponse> Handle(UpdateCourseGroupCommand request, CancellationToken cancellationToken)
        {
            CourseGroup courseGroup = await courseGroupService.GetAsync(
                c => c.Id == request.Id,
                include: x => x.Include(x => x.CourseSchedules),
                enableTracking: true,
                cancellationToken: cancellationToken);

            mapper.Map(request, courseGroup);

            var currentDays = courseGroup.CourseSchedules.Select(cs => cs.DayOfWeek).ToList();

            var toAdd = request.DaysOfWeek
                .Where(day => !currentDays.Contains(day))
                .Select(day => new CourseSchedule
                {
                    DayOfWeek = day,
                    CourseGroupId = courseGroup.Id,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime
                })
                .ToList();

            var toRemove = courseGroup.CourseSchedules
                .Where(cs => !request.DaysOfWeek.Contains(cs.DayOfWeek))
                .ToList();

            foreach (var item in toRemove)
                courseGroup.CourseSchedules.Remove(item);

            foreach (var item in toAdd)
                courseGroup.CourseSchedules.Add(item);

            CourseGroup result = await courseGroupService.UpdateAsync(courseGroup);

            UpdateCourseGroupResponse response = mapper.Map<UpdateCourseGroupResponse>(result);

            return response;
        }
    }
}
