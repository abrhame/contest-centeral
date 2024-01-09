using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Submission.Queries.GetSubmissionById
{
    public class GetSubmissionByIdHandler : IRequestHandler<GetSubmissionByIdQuery, SubmissionDTO>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public GetSubmissionByIdHandler(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubmissionDTO> Handle(GetSubmissionByIdQuery request, CancellationToken cancellationToken)
        {
            var submission = await _submissionRepository.GetSubmissionByIdAsync(request.SubmissionId);

            if (submission == null)
            {
                return null;
            }

            var submissionDTO = _mapper.Map<SubmissionDTO>(submission);

            return submissionDTO;
        }
    }
}
