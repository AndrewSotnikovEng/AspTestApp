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
        public LessonController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
            LessonService service = new LessonService();

            _dbContext.Lessons.Add(service.LvmToLesson(lvm));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Lesson lessonToEdit = _dbContext.Lessons.Where(l => l.Id == id).FirstOrDefault();
            LessonService service = new LessonService();

            return View(service.LessonToLvm(lessonToEdit));
        }

        [HttpPost]
        public IActionResult Edit(LessonViewModel lvm)
        {
            Lesson lessonToEdit = _dbContext.Lessons.Where(l => l.Id == lvm.LessonId).FirstOrDefault();
            LessonService service = new LessonService();
            Lesson updatedLesson = service.LvmToLesson(lvm);

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
