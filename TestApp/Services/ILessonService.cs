using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public interface ILessonService
    {
        LessonViewModel LessonToLvm(Lesson lesson);

        Lesson LvmToLesson(LessonViewModel lvm);

        public string GetStudentNameById(int id);

        public string GetPaymentColorById(int id);

    }
}
