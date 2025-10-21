using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Classes.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Commands.Update;

public class UpdateSpecializationCommand : IRequest<UpdateSpecializationResponse>
{
    public Guid Id { get; set; }
    public string SpecializationName { get; set; }

    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, UpdateSpecializationResponse>
    {
        private readonly ISpecializationService specializationService;
        private readonly IMapper mapper;

        public UpdateSpecializationCommandHandler(ISpecializationService specializationService, IMapper mapper)
        {
            this.specializationService = specializationService;
            this.mapper = mapper;
        }

        public async Task<UpdateSpecializationResponse> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            Specialization specialization = await specializationService.GetAsync(s => s.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, specialization);

            Specialization result = await specializationService.UpdateAsync(specialization);

            UpdateSpecializationResponse response = mapper.Map<UpdateSpecializationResponse>(result);

            return response;
        }
    }
}
