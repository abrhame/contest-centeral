using Application.Interfaces;
using AutoMapper;
using Application.DTOs;
using MediatR;

namespace Application.Features.Submission.Queries.GetSubmissionByContest
{
    public class GetSubmissionsByContestIdHandler : IRequestHandler<GetSubmissionsByContestIdQuery, IEnumerable<SubmissionDTO>>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public GetSubmissionsByContestIdHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmissionDTO>> Handle(GetSubmissionsByContestIdQuery request, CancellationToken cancellationToken)
        {
            var submissions = await _submissionRepository.GetSubmissionsByContestIdAsync(request.ContestId);

            var submissionDTOs = _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);

            return submissionDTOs;
        }
    }
}
