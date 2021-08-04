using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public string LessonDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Agenda { get; set; }
        public bool Ordered { get; set; }
        public string NextLessonAgenda { get; set; }
    }
}
