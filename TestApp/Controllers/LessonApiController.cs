using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using TestApp.Models;

namespace TestApp.Controllers
{
    [EnableCors(origins: "http://localhost:5000", headers: "*", methods: "*")]
    [Route("[controller]")]
    [ApiController]
    public class LessonApiController : ControllerBase
    {
        private AppDbContext _dbContext;
        public LessonApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> GetLessons()
        {
            List<object> lessons = new List<object>();
            foreach (var item in _dbContext.Lessons)
            {
                Student student = _dbContext.Students.Where(s => s.Id == item.StudentId).FirstOrDefault();
                string date = $"{item.StartDate.ToString("dd_MM_yyyy")}";

                EventDto lesson = new EventDto(student.FirstName + " " + student.LastName, date);
                
                lessons.Add(lesson);
            }

            return lessons;
        }
    }
}
