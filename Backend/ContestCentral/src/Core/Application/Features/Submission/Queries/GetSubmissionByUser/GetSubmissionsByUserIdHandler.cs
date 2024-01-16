using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Submission.Queries.GetSubmissionByUser
{
    public class GetSubmissionsByUserIdHandler : IRequestHandler<GetSubmissionsByUserIdQuery, IEnumerable<SubmissionDTO>>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public GetSubmissionsByUserIdHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmissionDTO>> Handle(GetSubmissionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var submissions = await _submissionRepository.GetSubmissionsByUserIdAsync(request.UserId);

            var submissionDTOs = _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);

            return submissionDTOs;
        }
    }
}
