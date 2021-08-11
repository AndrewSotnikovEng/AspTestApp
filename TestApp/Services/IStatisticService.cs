using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public interface IStatisticService
    {

        public int GetTeacherAverageLessons();
        public int GetTeacherToltalLessons();
        public int GetTeacherCurrentWeekLessons();
        public int GetTeachePreviousWeekLessons();


        public int GetStudentAverageLessons();
        public int GetStudentToltalLessons();
        public int GetStudentCurrentWeekLessons();
        public int GetStudentPreviousWeekLessons();
    }
}
