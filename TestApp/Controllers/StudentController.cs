using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class StudentController : Controller
    {

        private AppDbContext _dbContext;
        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[Route("Student/Index")]
        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }

        //[Route("Student/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[Route("Student/Add")]
        [HttpPost]
        public IActionResult Add(Student s)
        {
            _dbContext.Students.Add(s);
            _dbContext.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student studentToEdit = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(studentToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            Student studentToEdit = _dbContext.Students.Where(_s => _s.Id == s.Id).FirstOrDefault();
            studentToEdit.FirstName = s.FirstName;
            studentToEdit.LastName = s.LastName;
            studentToEdit.School = s.School;
            studentToEdit.DesiredUniversity = s.DesiredUniversity;
            studentToEdit.PhoneNumber = s.PhoneNumber;
            studentToEdit.UserID = s.UserID;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        //[Route("Student/Delete")]
        public IActionResult Delete(int id)
        {
            Student studentToDelete = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Remove(studentToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
