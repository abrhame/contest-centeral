using System.Xml;
using Application.DTOs;
using Application.Features.Questions.Requests;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Questions.Handlers;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, GetQuestionByTitleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper =  mapper;
    }

    public async Task<GetQuestionByTitleDto> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<Question>(request);
        var result = await _unitOfWork.QuestionRepository.AddQuestion(question);
        return _mapper.Map<GetQuestionByTitleDto>(result);
    }
}
