using System.Collections;
using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Models
{
    //todo : Remove
    public class StatisticStudentsViewModel
    {
        //public List<Student> Students { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }

        
        public StatisticStudentsViewModel(IEnumerable lessons)
        {
            //this.Students = (List<Student>)students;
            this.Lessons = (IEnumerable<Lesson>)lessons;
        }
    }
}