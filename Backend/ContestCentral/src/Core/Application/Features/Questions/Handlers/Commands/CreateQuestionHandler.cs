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
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    public CreateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper =  mapper;
    }

    public async Task<GetQuestionByTitleDto> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
    {

        var question = _mapper.Map<Question>(request);
        var result = _questionRepository.AddQuestion(question);
        return _mapper.Map<GetQuestionByTitleDto>(result);
    }
}