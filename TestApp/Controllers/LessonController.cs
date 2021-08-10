using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.Controllers
{
    public class LessonController : Controller
    {

        private AppDbContext _dbContext;
        ILessonService _service;
        public LessonController(AppDbContext dbContext, ILessonService service)
        {
            _dbContext = dbContext;
            _service = service;
        }

        //[Route("Student/Index")]
        public IActionResult Index()
        {
            return View(_dbContext.Lessons);
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(LessonViewModel lvm)
        {

            _dbContext.Lessons.Add(_service.LvmToLesson(lvm));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Lesson lessonToEdit = _dbContext.Lessons.Where(l => l.Id == id).FirstOrDefault();

            return View(_service.LessonToLvm(lessonToEdit));
        }

        [HttpPost]
        public IActionResult Edit(LessonViewModel lvm)
        {
            Lesson lessonToEdit = _dbContext.Lessons.Where(l => l.Id == lvm.LessonId).FirstOrDefault();
            Lesson updatedLesson = _service.LvmToLesson(lvm);

            //todo: Add replace method to model
            lessonToEdit.StudentId = updatedLesson.StudentId;
            lessonToEdit.StartDate = updatedLesson.StartDate;
            lessonToEdit.EndDate = updatedLesson.EndDate;
            lessonToEdit.Ordered = updatedLesson.Ordered;
            lessonToEdit.Agenda = updatedLesson.Agenda;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Lesson lessonToDelete = _dbContext.Lessons.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Remove(lessonToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
