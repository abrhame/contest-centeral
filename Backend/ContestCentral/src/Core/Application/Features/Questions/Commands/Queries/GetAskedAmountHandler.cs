using System.Runtime.CompilerServices;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Requests;

public class GetAskedAmountHandler : IRequestHandler<GetAskedAmountRequest, int>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;
    public GetAskedAmountHandler(IQuestionRepository questionRepository,IMapper mapper)
    {
        _questionRepository = questionRepository; 
        _mapper =  mapper;
    }

    public async Task<int> Handle(GetAskedAmountRequest request, CancellationToken cancellationToken)
    {
        var amount = await _questionRepository.GetAskedAmount(request.Title);
        return amount;
    }

}