using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Commands.Delete;

public class DeleteCourseCommand : IRequest<DeleteCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;
        public DeleteCourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = await courseService.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            Course result = await courseService.DeleteAsync(course);

            DeleteCourseResponse response = mapper.Map<DeleteCourseResponse>(result);

            return response;
        }
    }
}
