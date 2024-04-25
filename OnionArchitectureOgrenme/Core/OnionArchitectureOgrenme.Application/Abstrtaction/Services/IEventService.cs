using OnionArchitectureOgrenme.Application.DTOs;
using OnionArchitectureOgrenme.Application.RequestParameters;
using OnionArchitectureOgrenme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Application.Abstrtaction.Services
{
    public interface IEventService
    {
        Task createEventAsync(CreateEventDto createEventDTO);
        Task<IEnumerable<EventDTO>> GetAllEventAsync(Pagination pagination);
    }
}
