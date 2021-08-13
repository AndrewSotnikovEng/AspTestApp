
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

            int currentWeek = cul.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            foreach (var lesson in _dbContext.Lessons)
            {
                int lessonWeek = cul.Calendar.GetWeekOfYear(
                                lesson.StartDate,
                                CalendarWeekRule.FirstDay,
                                DayOfWeek.Monday);

                if (lessonWeek == currentWeek)
                {
                    curWeekLessonCounter++;
                }
            }

            return curWeekLessonCounter;
        }

        public int GetTeachePreviousWeekLessons()
        {
            int prevWeekLessonCounter = 0;

            CultureInfo cul = CultureInfo.CurrentCulture;

            int previousWeek = cul.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday) - 1;

            foreach (var lesson in _dbContext.Lessons)
            {
                int lessonWeek = cul.Calendar.GetWeekOfYear(
                                lesson.StartDate,
                                CalendarWeekRule.FirstDay,
                                DayOfWeek.Monday);

                if (lessonWeek == previousWeek)
                {
                    prevWeekLessonCounter++;
                }
            }

            return prevWeekLessonCounter;
        }

        public int GetTeacherToltalLessons()
        {
            return _dbContext.Lessons.Count();
        }

        /*  1. Sort dates in descending order for the student
         *  2. Get first week and get last week, measure interval between them
         *  3. Divide amount of lessons by weeks interval
         */
        public double GetStudentAverageLessons(int studentId)
        {
            List<Lesson> lessons = _dbContext.Lessons.Where(x => x.StudentId == studentId).OrderBy(y => y.StartDate).ToList();
            int totalLessons = lessons.Count();
            if (totalLessons == 0) return 0;

            DateTime studentFirstLesson = lessons.First().StartDate;
            DateTime studentLastLesson = lessons.Last().StartDate;

            int weekInterval = (int)(studentLastLesson - studentFirstLesson).TotalDays;
            if (weekInterval == 0) return 0;

            int weeks = (int)Math.Ceiling((double)weekInterval / 7);
            double averageLessons = Math.Round((double)totalLessons / weeks,
                                               2);

            return averageLessons;
        }

        public int GetStudentToltalLessons(int studentId)
        {
            int counter = 0;

            foreach (var l in _dbContext.Lessons)
            {
                if (l.StudentId == studentId)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int GetStudentCurrentWeekLessons(int studentId)
        {
            int curWeekLessonCounter = 0;

            CultureInfo cul = CultureInfo.CurrentCulture;

            int currentWeek = cul.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            foreach (var lesson in _dbContext.Lessons.Where(x => x.StudentId == studentId).ToList())
            {
                int lessonWeek = cul.Calendar.GetWeekOfYear(
                                lesson.StartDate,
                                CalendarWeekRule.FirstDay,
                                DayOfWeek.Monday);

                if (lessonWeek == currentWeek)
                {
                    curWeekLessonCounter++;
                }
            }

            return curWeekLessonCounter;
        }

        public int GetStudentPreviousWeekLessons(int studentId)
        {
            int prevWeekLessonCounter = 0;

            CultureInfo cul = CultureInfo.CurrentCulture;

            int previousWeek = cul.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday) - 1;

            foreach (var lesson in _dbContext.Lessons.Where(x => x.StudentId == studentId).ToList())
            {
                int lessonWeek = cul.Calendar.GetWeekOfYear(
                                lesson.StartDate,
                                CalendarWeekRule.FirstDay,
                                DayOfWeek.Monday);

                if (lessonWeek == previousWeek)
                {
                    prevWeekLessonCounter++;
                }
            }

            return prevWeekLessonCounter;
        }
    }
}
