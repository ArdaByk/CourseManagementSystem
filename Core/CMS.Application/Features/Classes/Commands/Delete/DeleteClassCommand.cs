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

namespace CMS.Application.Features.Classes.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class DeleteClassCommand : IRequest<DeleteClassResponse>
{
    public Guid Id { get; set; }

    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, DeleteClassResponse>
    {
        private readonly IClassService classService;
        private readonly IMapper mapper;
        public DeleteClassCommandHandler(IClassService classService, IMapper mapper)
        {
            this.classService = classService;
            this.mapper = mapper;
        }

        public async Task<DeleteClassResponse> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            Class myClass = await classService.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            Class result = await classService.DeleteAsync(myClass);

            DeleteClassResponse response = mapper.Map<DeleteClassResponse>(result);

            return response;
        }
    }
}
