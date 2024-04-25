using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Application.Abstrtaction.Services
{
    public interface IFileService
    {
        Task SaveTextAsync(string text,string path);
    }
}
