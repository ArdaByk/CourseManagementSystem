using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class DeleteSpecializationCommand : IRequest<DeleteSpecializationResponse>
{
    public Guid Id { get; set; }

    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand, DeleteSpecializationResponse>
    {
        private readonly ISpecializationService specializationService;
        private readonly IMapper mapper;
        public DeleteSpecializationCommandHandler(ISpecializationService specializationService, IMapper mapper)
        {
            this.specializationService = specializationService;
            this.mapper = mapper;
        }

        public async Task<DeleteSpecializationResponse> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            Specialization specialization = await specializationService.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            Specialization result = await specializationService.DeleteAsync(specialization);

            DeleteSpecializationResponse response = mapper.Map<DeleteSpecializationResponse>(result);

            return response;
        }
    }
}
