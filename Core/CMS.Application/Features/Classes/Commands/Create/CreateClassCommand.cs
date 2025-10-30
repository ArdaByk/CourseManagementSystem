using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.Classes.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Classes.Commands.Create;

public class CreateClassCommand : IRequest<CreateClassResponse>
{
    public string ClassName { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }

    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, CreateClassResponse>
    {
        private readonly IClassService classService;
        private readonly IMapper mapper;
        private readonly ClassBusinessRules _classBusinessRules;

        public CreateClassCommandHandler(IClassService classService, IMapper mapper, ClassBusinessRules classBusinessRules)
        {
            this.classService = classService;
            this.mapper = mapper;
            _classBusinessRules = classBusinessRules;
        }

        public async Task<CreateClassResponse> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            await _classBusinessRules.EnsureClassNameIsUniqueAsync(request.ClassName);
            _classBusinessRules.EnsureCapacityInLimit(request.Capacity);
            Class myClass = mapper.Map<Class>(request);
            myClass = await classService.AddAsync(myClass);
            return mapper.Map<CreateClassResponse>(myClass);
        }
    }
}
