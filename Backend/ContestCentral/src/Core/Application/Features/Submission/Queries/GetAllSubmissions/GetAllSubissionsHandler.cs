using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Submission.Queries.GetAllSubmissions
{
    public class GetAllSubmissionsHandler : IRequestHandler<GetAllSubmissionsQuery, IEnumerable<SubmissionDTO>>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public GetAllSubmissionsHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmissionDTO>> Handle(GetAllSubmissionsQuery request, CancellationToken cancellationToken)
        {
            var submissions = await _submissionRepository.GetAllSubmissionsAsync();

            var submissionDTOs = _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);

            return submissionDTOs;
        }
    }
}
