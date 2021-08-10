using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using TestApp.Models;

namespace TestApp.Controllers
{
    [EnableCors(origins: "http://localhost:5000", headers: "*", methods: "*")]
    [Route("[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private AppDbContext _dbContext;
        public StudentApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<string> GetStudents()
        {
            IEnumerable<string> students =  _dbContext.Students.Select(x => $"{x.FirstName} {x.LastName} : {x.Id}");
            return students;
        }
    }
}
