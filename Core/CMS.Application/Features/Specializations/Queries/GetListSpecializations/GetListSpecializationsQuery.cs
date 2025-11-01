using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.Specializations.Queries.GetListSpecializations;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class GetListSpecializationsQuery : IRequest<ICollection<GetListSpecializationsResponse>>
{

    public class GetListSpecializationsQueryHandler : IRequestHandler<GetListSpecializationsQuery, ICollection<GetListSpecializationsResponse>>
    {
        private readonly ISpecializationService specializationService;
        private readonly IMapper mapper;

        public GetListSpecializationsQueryHandler(ISpecializationService specializationService, IMapper mapper)
        {
            this.specializationService = specializationService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListSpecializationsResponse>> Handle(GetListSpecializationsQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListSpecializationsResponse> specializations = mapper.Map<ICollection<GetListSpecializationsResponse>>(await specializationService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return specializations;
        }
    }
}
