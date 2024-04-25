using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services.Concrete;
using OnionArchitectureOgrenme.Application.DTOs;
using OnionArchitectureOgrenme.Application.RequestParameters;

namespace OnionArchitectureOgrenme.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ExportService _exportService;

        public EventsController(IEventService eventService, ExportService exportService)
        {
            _eventService = eventService;
            _exportService = exportService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEvents([FromQuery] Pagination pagination) 
        {
            var events=await _eventService.GetAllEventAsync(pagination);
            return Ok(events);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await _eventService.createEventAsync(createEventDto);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportEvents([FromQuery] Pagination pagination, string path)
        {
            var events =await _eventService.GetAllEventAsync(pagination);
            await _exportService.ExportEventAsync(events, path);
            return Ok();
        }
    }
}
