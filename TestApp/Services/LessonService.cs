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

            DateTime startDt = DateTime.Parse(lvm.LessonDate + " " + lvm.StartTime);
            DateTime endDt = DateTime.Parse(lvm.LessonDate + " " + lvm.EndTime);

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
            

            lvm.LessonDate = lesson.StartDate.Date.ToString();
            lvm.StartTime = lesson.StartDate.TimeOfDay.ToString();
            lvm.EndTime = lesson.EndDate.TimeOfDay.ToString();
            lvm.Ordered = lesson.Ordered;
            lvm.Agenda = lesson.Agenda;

            return lvm;
        }
    }
}
