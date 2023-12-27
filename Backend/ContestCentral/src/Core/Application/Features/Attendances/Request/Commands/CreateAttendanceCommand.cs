using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ContestCentral.Application.Common.DTOs;


 
namespace ContestCentral.Application.Common.Features.Attendances.Request.Commands
{
    public class CreateAttendanceCommand : IRequest<CreateAttendanceRequestDto>
    {
        public Guid UserId { get; set; }
        public Guid ContestId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}