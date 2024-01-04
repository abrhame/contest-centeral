using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Submission.Commands.CreateSubmission
{
    public class CreateSubmissionHandler : IRequestHandler<CreateSubmissionCommand, SubmissionDTO>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public CreateSubmissionHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmissionDTO> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
        {
            var newSubmission = new SubmissionDTO
            {
                QuestionId = request.QuestionId,
                Trial = request.Trial,
                Points = request.Points,
                TeamId = request.TeamId,
                UserId = request.UserId,
                ContestId = request.ContestId
            };

            await _submissionRepository.AddSubmissionAsync(newSubmission);

            var createdSubmissionDTO = _mapper.Map<SubmissionDTO>(newSubmission);

            return createdSubmissionDTO;
        }
    }
}
