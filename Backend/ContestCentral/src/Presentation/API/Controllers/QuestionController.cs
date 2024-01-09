using Application.DTOs;
using Application.Features.Questions.Requests;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]


public class QuestionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public QuestionController(IMediator mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestion([FromBody] CreateQuestionDto request)
    {
       try
       {
           var command = _mapper.Map<Question>(request);
           await _mediator.Send(command);

           return Ok();
       }
       catch (Exception ex)
       {
           return BadRequest($"Error creating Question: {ex.Message}");
       }
    }


    [HttpGet("Questions/{Title}")]
    public async Task<IActionResult> GetQuestionByTitle(string Title)
    {
        try
        {
            var res = await _mediator.Send(new GetQuestionByTitleRequest { Title = Title });
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error getting Questions: {ex.Message}");
        }
    }


    [HttpGet("GetAskedAmount/{Title}")]
    public async Task<IActionResult> GetAskedAmount(string Title)
    {
        try
        {
            var res = await _mediator.Send(new GetAskedAmountRequest { Title = Title});
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error getting Asked amount for the question: {ex.Message}");
        }
    }

}