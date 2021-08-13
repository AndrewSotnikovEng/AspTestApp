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


        public double GetStudentAverageLessons(int studentId);
        public int GetStudentToltalLessons(int studentId);
        public int GetStudentCurrentWeekLessons(int studentId);
        public int GetStudentPreviousWeekLessons(int studentId);
    }
}
