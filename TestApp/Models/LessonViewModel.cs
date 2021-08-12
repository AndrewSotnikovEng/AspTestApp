using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public string StudentNameAndId { get; set; }
        public string LessonDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Agenda { get; set; }
        public bool Ordered { get; set; }
        public string NextLessonAgenda { get; set; }

        public string LessonDateUniversal { get 
            {
                DateTime dt = DateTime.ParseExact(LessonDate,"MMddYYYY",null);

                return $"{dt.Year}-{dt.Month.ToString("d2")}-{dt.Day.ToString("d2")}";
            } }
    }
}
