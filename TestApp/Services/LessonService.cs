using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public class LessonService : ILessonService
    {
        AppDbContext _dbContext;

        public LessonService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Lesson LvmToLesson(LessonViewModel lvm)
        {

            DateTime startDt = DateTime.ParseExact(lvm.LessonDate + " " + lvm.StartTime, "MM/dd/yyyy HH:mm", null);
            DateTime endDt = DateTime.ParseExact(lvm.LessonDate + " " + lvm.EndTime, "MM/dd/yyyy HH:mm", null);

            Lesson lesson = new Lesson();
            lesson.Id = lvm.LessonId;
            lesson.StudentId = Int16.Parse(lvm.StudentNameAndId.Split(":")[1].Trim());
            lesson.StartDate = startDt;
            lesson.EndDate = endDt;
            lesson.Ordered = lvm.Ordered;
            lesson.Agenda = lvm.Agenda;

            return lesson;
        }


        public LessonViewModel LessonToLvm(Lesson lesson)
        {
            LessonViewModel lvm = new LessonViewModel();
            lvm.LessonId = lesson.Id;

            Student stud = _dbContext.Students.Where(x => x.Id == lesson.StudentId).FirstOrDefault();
            lvm.StudentNameAndId = $"{stud.FirstName} {stud.LastName} : {stud.Id}";
            

            lvm.LessonDate = $"{lesson.StartDate.Month.ToString("d2")}/{lesson.StartDate.Day.ToString("d2")}/{lesson.StartDate.Year}";
            lvm.StartTime = lesson.StartDate.TimeOfDay.Hours.ToString("d2") + ":" + lesson.StartDate.TimeOfDay.Minutes.ToString("d2");
            lvm.EndTime = lesson.EndDate.TimeOfDay.Hours.ToString("d2") + ":" + lesson.EndDate.TimeOfDay.Minutes.ToString("d2");
            lvm.Ordered = lesson.Ordered;
            lvm.Agenda = lesson.Agenda;

            return lvm;
        }

        public string GetStudentNameById(int id)
        {
            Student stud = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();

            return $"{stud.FirstName} {stud.LastName}";
        }

        public string GetPaymentColorById(int id)
        {
            Lesson lesson = _dbContext.Lessons.Where(x => x.Id == id).FirstOrDefault();
            string result = lesson.Ordered ? "white" : "#FFC0CB";

            return result;
        }

    }
}
