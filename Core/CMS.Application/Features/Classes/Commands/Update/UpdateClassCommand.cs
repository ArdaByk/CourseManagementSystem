using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Courses.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Classes.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class UpdateClassCommand : IRequest<UpdateClassResponse>
{
    public Guid Id { get; set; }
    public string ClassName { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }

    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, UpdateClassResponse>
    {
        private readonly IClassService classService;
        private readonly IMapper mapper;

        public UpdateClassCommandHandler(IClassService classService, IMapper mapper)
        {
            this.classService = classService;
            this.mapper = mapper;
        }

        public async Task<UpdateClassResponse> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            Class myClass = await classService.GetAsync(c => c.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, myClass);

            Class result = await classService.UpdateAsync(myClass);

            UpdateClassResponse response = mapper.Map<UpdateClassResponse>(result);

            return response;
        }
    }
}
