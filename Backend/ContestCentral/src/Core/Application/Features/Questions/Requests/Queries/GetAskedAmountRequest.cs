using MediatR;

namespace Application.Features.Questions.Requests;

public class GetAskedAmountRequest : IRequest<int>
{
    public string Title { get; set; }
}