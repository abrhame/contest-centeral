using ContestCentral.Application.Common.DTOs;
using ContestCentral.Domain.Common.Entity;

using AutoMapper;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, RegisterUserRequestDto>().ReverseMap();
    }
}
