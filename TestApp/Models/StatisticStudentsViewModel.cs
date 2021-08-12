using System.Collections;
using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Models
{
    //todo : Remove
    public class StatisticStudentsViewModel
    {
        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }

        
        public StatisticStudentsViewModel(IEnumerable lessons, IEnumerable students)
        {
            this.Students = (IEnumerable<Student>)students;
            this.Lessons = (IEnumerable<Lesson>)lessons;
        }
    }
}