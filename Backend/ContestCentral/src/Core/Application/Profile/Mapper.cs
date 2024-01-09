using Application.DTOs;
using Domain.Entity;

using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, RegisterUserRequestDto>().ReverseMap();
        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<Question, GetQuestionByTitleDto>().ReverseMap();
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<Submission, SubmissionDTO>().ReverseMap();
    }
}