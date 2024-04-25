using OnionArchitectureOgrenme.Domain.Common;
using OnionArchitectureOgrenme.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Domain.Entities
{
    public class Event:EntityBase
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public Location Location { get; set; }
    }
}
