using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Agenda { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Ordered { get; set; }
        public string NextLessonAgenda { get; set; }

        public override string ToString()
        {
            
            string output = $"{StartDate.ToString("dd/MM/yyyy")} --- {StartDate.ToString("HH:mm")} - {EndDate.ToString("HH:mm")} --- Оплачено: {Ordered}";
            return output;
        }

    }
}
