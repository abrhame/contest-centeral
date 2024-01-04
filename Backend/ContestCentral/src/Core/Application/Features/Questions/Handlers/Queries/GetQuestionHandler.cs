using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Application.DTOs;
using Application.Features.Questions.Requests;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Handlers;

public class GetQuestionHandler : IRequestHandler<GetQuestionByTitleRequest,GetQuestionByTitleDto>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public GetQuestionHandler(IQuestionRepository questionRepository,IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<GetQuestionByTitleDto> Handle(GetQuestionByTitleRequest request, CancellationToken cancellationToken)
    {
        var question = _questionRepository.GetQuestionByTitle(request.Title);
        return _mapper.Map<GetQuestionByTitleDto>(question);
    }
}