using Microsoft.EntityFrameworkCore;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Application.DTOs;
using OnionArchitectureOgrenme.Application.RequestParameters;
using OnionArchitectureOgrenme.Domain.Entities;
using OnionArchitectureOgrenme.Presistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Presistence.Services
{
    public class EventService : IEventService
    {
        private readonly OnionArchDbContext _context;

        public EventService(OnionArchDbContext context)
        {
            _context = context;
        }

        public async Task createEventAsync(CreateEventDto createEventDTO)
        {
            if(createEventDTO is not null)
            {
                var newEvent = new Event()
                {
                    Title = createEventDTO.Title,
                    Date = createEventDTO.Date,
                    Location = createEventDTO.Location,
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventAsync(Pagination pagination)
        {
            return await _context.Events
                .AsNoTracking()
                .Select(x=>new EventDTO
            {
                Title = x.Title,
                Date = x.Date,
                Location = x.Location,
                //Location = new Domain.ValueObjects.Location()
                //{
                //    City=x.Location.City,
                //    District=x.Location.District,
                //    PostalCode=x.Location.PostalCode,
                //    Street=x.Location.Street,
                //},

            })  
                .Skip(pagination.PageCount*pagination.ItemCount)
                .Take(pagination.ItemCount)
                .ToListAsync();
        }
    }
}
