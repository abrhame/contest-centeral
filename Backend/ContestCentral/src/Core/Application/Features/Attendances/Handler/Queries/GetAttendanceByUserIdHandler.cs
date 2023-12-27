using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Features.Attendances.Request.Commands;
using ContestCentral.Application.Common.Interfaces;
using AutoMapper;
using ContestCentral.Domain.Entities;
using ContestCentral.Application.Common.Features.Attendances.Request.Queries;

namespace Galacticos.Application.Features.Attendances.Handler.Queries
{
    public class GetAttendanceByUserIdHandler : IRequestHandler<GetAttendanceByUserIdRequest,List<GetAttendanceResponseDto>>
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IMapper _mapper;

    

        public GetAttendanceByUserIdHandler(IAttendanceRepository attendanceRepo,IMapper mapper)
        {
            _attendanceRepo = attendanceRepo;
            _mapper = mapper;
        }

        public async Task<List<GetAttendanceResponseDto>> Handle(GetAttendanceByUserIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _attendanceRepo.userExists(request.UserId);
            if(!user){
                throw new Exception("user not found");
            }

            List<Attendance> result =  await _attendanceRepo.GetContestsForUser(request.UserId);
            var response = _mapper.Map<List<GetAttendanceResponseDto>>(result);
            return response;

        }



    }
}