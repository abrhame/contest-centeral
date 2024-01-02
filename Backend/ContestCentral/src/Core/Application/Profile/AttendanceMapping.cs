using AutoMapper;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Features.Attendances.Request.Commands;
using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Entities;


namespace ContestCentral.Application.Profiles
{
    public class AttendanceMapping : Profile
    {
        public AttendanceMapping()
        {
            CreateMap<Attendance, CreateAttendanceRequestDto>().ReverseMap();
            CreateMap<Attendance, GetAttendanceResponseDto>().ReverseMap();
            CreateMap<Attendance, CreateAttendanceCommand>().ReverseMap();
            CreateMap<CreateAttendanceRequestDto, CreateAttendanceCommand>().ReverseMap();

        }
    }
}