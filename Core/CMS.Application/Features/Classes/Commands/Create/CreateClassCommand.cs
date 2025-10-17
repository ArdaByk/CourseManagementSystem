using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Courses.Commands.Create;
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

        public CreateClassCommandHandler(IClassService classService, IMapper mapper)
        {
            this.classService = classService;
            this.mapper = mapper;
        }

        public async Task<CreateClassResponse> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            Class myClass = mapper.Map<Class>(request);
            myClass = await classService.AddAsync(myClass);
            return mapper.Map<CreateClassResponse>(myClass);
        }
    }
}
