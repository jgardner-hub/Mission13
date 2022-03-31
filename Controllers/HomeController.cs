using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }
        //private BowlingDbContext _context { get; set; }
        // IBowlersRepository temp
        // _repo = temp
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            var blah = _repo.Bowlers
                .Include(x => x.Team)
                //.FromSqlRaw("SELECT * FROM bowlers")
                .ToList();


            return View(blah);
        }
    }
}
