using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public class LessonService
    {
        public Lesson LvmToLesson(LessonViewModel lvm)
        {

            DateTime startDt = DateTime.Parse(lvm.LessonDate + " " + lvm.StartTime);
            DateTime endDt = DateTime.Parse(lvm.LessonDate + " " + lvm.EndTime);

            Lesson lesson = new Lesson();
            lesson.Id = lvm.LessonId;
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
            lvm.LessonDate = lesson.StartDate.Date.ToString();
            lvm.StartTime = lesson.StartDate.TimeOfDay.ToString();
            lvm.EndTime = lesson.EndDate.TimeOfDay.ToString();
            lvm.Ordered = lesson.Ordered;
            lvm.Agenda = lesson.Agenda;

            return lvm;
        }
    }
}
