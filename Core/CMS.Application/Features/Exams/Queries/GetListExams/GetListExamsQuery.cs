using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Queries.GetListExams;

public class GetListExamsQuery : IRequest<ICollection<GetListExamsResponse>>
{

    public class GetListExamsQueryHandler : IRequestHandler<GetListExamsQuery,ICollection<GetListExamsResponse>>
    {
        private readonly IExamService examService;
        private readonly IMapper mapper;

        public GetListExamsQueryHandler(IExamService examService, IMapper mapper)
        {
            this.examService = examService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListExamsResponse>> Handle(GetListExamsQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListExamsResponse> exams = mapper.Map<ICollection<GetListExamsResponse>>(await examService.GetListAsync(enableTracking: false, include: e => e.Include(e => e.Course) ,cancellationToken: cancellationToken));

            return exams;
        }
    }
}
