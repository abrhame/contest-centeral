using Application.DTOs;
using Application.Features.Questions.Requests;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Handlers;

public class GetQuestionHandler : IRequestHandler<GetQuestionByTitleRequest,GetQuestionByTitleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetQuestionByTitleDto> Handle(GetQuestionByTitleRequest request, CancellationToken cancellationToken)
    {
        var question = await _unitOfWork.QuestionRepository.GetQuestionByTitle(request.Title);

        return _mapper.Map<GetQuestionByTitleDto>(question);
    }
}
