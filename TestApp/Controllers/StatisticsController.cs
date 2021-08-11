using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class StatisticsController : Controller
    {
        private AppDbContext _dbContext;
        public StatisticsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Students()
        {

            StatisticStudentsViewModel vm = new StatisticStudentsViewModel(_dbContext.Lessons);

            return View(vm);
        }
    }
}
