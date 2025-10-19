using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Queries.GetSpecializationById;

public class GetSpecializationByIdQuery : IRequest<GetSpecializationByIdResponse>
{
    public Guid Id { get; set; }

    public class GetSpecializationByIdQueryHandler : IRequestHandler<GetSpecializationByIdQuery, GetSpecializationByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ISpecializationService specializationService;

        public GetSpecializationByIdQueryHandler(IMapper mapper, ISpecializationService specializationService)
        {
            this.mapper = mapper;
            this.specializationService = specializationService;
        }

        public async Task<GetSpecializationByIdResponse> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            GetSpecializationByIdResponse response = mapper.Map<GetSpecializationByIdResponse>(await specializationService.GetAsync(predicate: s => s.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
