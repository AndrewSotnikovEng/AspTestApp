using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class EventDto
    {
        public string Name { get; set; }
        public string Date { get; set; }

        public EventDto(string name, string date)
        {
            Name = name;
            Date = date;
        }
    }
}
