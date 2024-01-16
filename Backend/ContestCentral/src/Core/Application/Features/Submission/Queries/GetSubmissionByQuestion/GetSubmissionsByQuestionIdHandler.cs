using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Submission.Queries.GetSubmissionByQuestion
{
    public class GetSubmissionsByQuestionIdHandler : IRequestHandler<GetSubmissionsByQuestionIdQuery, IEnumerable<SubmissionDTO>>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public GetSubmissionsByQuestionIdHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmissionDTO>> Handle(GetSubmissionsByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var submissions = await _submissionRepository.GetSubmissionsByQuestionIdAsync(request.QuestionId);

            var submissionDTOs = _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);

            return submissionDTOs;
        }
    }
}
