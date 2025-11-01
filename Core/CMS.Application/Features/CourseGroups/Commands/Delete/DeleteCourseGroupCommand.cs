using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.CourseGroups.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class DeleteCourseGroupCommand : IRequest<DeleteCourseGroupResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseGroupCommandHandler : IRequestHandler<DeleteCourseGroupCommand, DeleteCourseGroupResponse>
    {
        private readonly ICourseGroupService courseGroupService;
        private readonly IMapper mapper;
        public DeleteCourseGroupCommandHandler(ICourseGroupService courseGroupService, IMapper mapper)
        {
            this.courseGroupService = courseGroupService;
            this.mapper = mapper;
        }

        public async Task<DeleteCourseGroupResponse> Handle(DeleteCourseGroupCommand request, CancellationToken cancellationToken)
        {
            CourseGroup courseGroup = await courseGroupService.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            CourseGroup result = await courseGroupService.DeleteAsync(courseGroup);

            DeleteCourseGroupResponse response = mapper.Map<DeleteCourseGroupResponse>(result);

            return response;
        }
    }
}
