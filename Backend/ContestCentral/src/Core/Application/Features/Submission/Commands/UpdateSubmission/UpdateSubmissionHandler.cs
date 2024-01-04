using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Submission.Commands.UpdateSubmission
{
    public class UpdateSubmissionHandler : IRequestHandler<UpdateSubmissionCommand, SubmissionDTO>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public UpdateSubmissionHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmissionDTO> Handle(UpdateSubmissionCommand request, CancellationToken cancellationToken)
        {
            var existingSubmission = await _submissionRepository.GetSubmissionByIdAsync(request.SubmissionId);

            if (existingSubmission == null)
            {
                return null;
            }

            existingSubmission.Trial = request.UpdatedTrial;
            existingSubmission.Points = request.UpdatedPoints;

            await _submissionRepository.UpdateSubmissionAsync(existingSubmission);

            var updatedSubmissionDTO = _mapper.Map<SubmissionDTO>(existingSubmission);

            return updatedSubmissionDTO;
        }
    }
}
