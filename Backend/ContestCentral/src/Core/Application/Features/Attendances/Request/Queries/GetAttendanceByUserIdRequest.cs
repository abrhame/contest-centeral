using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ContestCentral.Application.Common.DTOs;


 
namespace ContestCentral.Application.Common.Features.Attendances.Request.Queries
{
    public class GetAttendanceByUserIdRequest : IRequest<List<GetAttendanceResponseDto>>
    {
        public Guid UserId { get; set; }
    }
}