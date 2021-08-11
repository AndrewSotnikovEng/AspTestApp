
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public class StatisticService : IStatisticService
    {
        AppDbContext _dbContext;

        public StatisticService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetStudentAverageLessons()
        {
            throw new NotImplementedException();
        }

        public int GetStudentCurrentWeekLessons()
        {
            throw new NotImplementedException();
        }

        public int GetStudentPreviousWeekLessons()
        {
            throw new NotImplementedException();
        }

        public int GetStudentToltalLessons()
        {
            throw new NotImplementedException();
        }

        public int GetTeacherAverageLessons()
        {
            int result = 0;
            CultureInfo cul = CultureInfo.CurrentCulture;
            var firstDayWeek = cul.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            return 3;
        }

        public int GetTeacherCurrentWeekLessons()
        {
            int curWeekLessonCounter = 0;

            CultureInfo cul = CultureInfo.CurrentCulture;
            int currentWeek = DateTime.Now.DayOfYear / 7;

            foreach (var lesson in _dbContext.Lessons)
            {
                int lessonWeek = lesson.StartDate.DayOfYear / 7;
                if (lessonWeek == currentWeek)
                {
                    curWeekLessonCounter++;
                }
            }

            return curWeekLessonCounter;
        }

        public int GetTeachePreviousWeekLessons()
        {
            return 10;
        }

        public int GetTeacherToltalLessons()
        {
            return _dbContext.Lessons.Count();
        }
    }
}
