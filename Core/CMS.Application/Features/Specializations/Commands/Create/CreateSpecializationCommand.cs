using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Specializations.Rules;
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
        private readonly SpecializationBusinessRules _specializationBusinessRules;

        public CreateSpecializationCommandHandler(ISpecializationService specializationService, IMapper mapper, SpecializationBusinessRules specializationBusinessRules)
        {
            this.specializationService = specializationService;
            this.mapper = mapper;
            _specializationBusinessRules = specializationBusinessRules;
        }

        public async Task<CreateSpecializationResponse> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            await _specializationBusinessRules.EnsureSpecializationNameIsUniqueAsync(request.SpecializationName);
            Specialization specialization = mapper.Map<Specialization>(request);
            specialization = await specializationService.AddAsync(specialization);
            return mapper.Map<CreateSpecializationResponse>(specialization);
        }
    }
}
