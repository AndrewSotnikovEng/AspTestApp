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

        public string LessonDateUniversal { get 
            {
                DateTime dt = DateTime.Parse(LessonDate);

                return $"{dt.Year}-{dt.Month.ToString("d2")}-{dt.Day.ToString("d2")}";
            } }

        public string LessonDateUniversalMin 
        {
            get
            {
                DateTime dt = DateTime.Today.AddMonths(-1);
                return $"{dt.Year}-{dt.Month.ToString("d2")}-{dt.Day.ToString("d2")}";
            }
        }

        public string LessonDateUniversalMax
        {
            get
            {
                DateTime dt = DateTime.Today.AddMonths(1);
                return $"{dt.Year}-{dt.Month.ToString("d2")}-{dt.Day.ToString("d2")}";
            }
        }


    }
}
