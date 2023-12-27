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


namespace Galacticos.Application.Features.Attendances.Handler.Commands
{
    public class CreateAttendanceHandler : IRequestHandler<CreateAttendanceCommand,CreateAttendanceRequestDto>
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IMapper _mapper;

        public CreateAttendanceHandler(IAttendanceRepository attendanceRepo,IMapper mapper)
        {
            _attendanceRepo = attendanceRepo;
            _mapper = mapper;
        }

        public async Task<CreateAttendanceRequestDto> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var obj = new Attendance
                {
                    UserId = request.UserId,
                    ContestId = request.ContestId,
                    CreatedAt = request.CreatedAt
                    
                };


            var user = await _attendanceRepo.userExists(request.UserId);

            if (!user)
            {
                throw new Exception("user not found");   
            }

            var contest = await _attendanceRepo.contestExists(request.ContestId);
            if (!contest)
            {
                throw new Exception("contest not found"); 
            }
            
            var result = await _attendanceRepo.AddAttendance(obj);
            // if(result == null)
            // {
            //     return Errors.Comment.CommentCreationFailed;
            // }
            var response = _mapper.Map<CreateAttendanceRequestDto>(result);
            return response;
            
        }

    }
}