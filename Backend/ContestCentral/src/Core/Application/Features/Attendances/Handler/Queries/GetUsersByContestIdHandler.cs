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
    public class GetUsersByContestIdHandler : IRequestHandler<GetUsersByContestIdRequest,List<GetAttendanceResponseDto>>
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IMapper _mapper;

    

        public GetUsersByContestIdHandler(IAttendanceRepository attendanceRepo,IMapper mapper)
        {
            _attendanceRepo = attendanceRepo;
            _mapper = mapper;
        }

        public async Task<List<GetAttendanceResponseDto>> Handle(GetUsersByContestIdRequest request, CancellationToken cancellationToken)
        {
            var contest = await _attendanceRepo.contestExists(request.ContestId);
            if(!contest){
                throw new Exception("contest not found");
            }

            List<Attendance> result =  await _attendanceRepo.GetParticipantForContest(request.ContestId);
            var response = _mapper.Map<List<GetAttendanceResponseDto>>(result);
            return response;

        }



    }
}