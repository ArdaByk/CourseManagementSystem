using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Commands.Create;

public class CreateSpecializationCommand : IRequest<CreateSpecializationResponse>
{
    public string SpecializationName { get; set; }

    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, CreateSpecializationResponse>
    {
        private readonly ISpecializationService specializationService;
        private readonly IMapper mapper;

        public CreateSpecializationCommandHandler(ISpecializationService specializationService, IMapper mapper)
        {
            this.specializationService = specializationService;
            this.mapper = mapper;
        }

        public async Task<CreateSpecializationResponse> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            Specialization specialization = mapper.Map<Specialization>(request);
            specialization = await specializationService.AddAsync(specialization);
            return mapper.Map<CreateSpecializationResponse>(specialization);
        }
    }
}
