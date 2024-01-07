using Application.DTOs;
using Domain.Entity;

using AutoMapper;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<User, CreateUserRequestDto>().ReverseMap();
        CreateMap<User, UpdateUserRequestDto>().ReverseMap();

        CreateMap<Location, CreateLocationRequestDto>().ReverseMap();
        CreateMap<Location, LocationResponseDto>().ReverseMap();

        CreateMap<Group, GroupResponseDto>().ReverseMap();
        CreateMap<Group, CreateGroupRequestDto>().ReverseMap();

        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<Question, GetQuestionByTitleDto>().ReverseMap();
    }
}
