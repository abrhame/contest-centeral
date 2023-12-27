using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ContestCentral.Application.Common.DTOs;


 
namespace ContestCentral.Application.Common.Features.Attendances.Request.Queries
{
    public class GetUsersByContestIdRequest : IRequest<List<GetAttendanceResponseDto>>
    {
        public Guid ContestId { get; set; }
    }
}