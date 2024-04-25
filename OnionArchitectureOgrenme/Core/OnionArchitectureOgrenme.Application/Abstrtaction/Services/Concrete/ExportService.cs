using OnionArchitectureOgrenme.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Application.Abstrtaction.Services.Concrete
{
    public class ExportService
    {
        private readonly ITextService _textService;
        private readonly IFileService _fileService;

        public ExportService(ITextService textService, IFileService fileService)
        {
            _textService = textService;
            _fileService = fileService;
        }
        //format değişikliği için
        public async Task ExportEventAsync(IEnumerable<EventDTO>eventItems,string path)
        {
            var formatedText = _textService.FormatTextForEvent(eventItems);
            //formatedText.Insert(0, "Event Name-Event Date-Event Location\n");
            await _fileService.SaveTextAsync(formatedText,path);
        }
    }
}
