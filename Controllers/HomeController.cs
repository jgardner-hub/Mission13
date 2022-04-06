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

            ViewBag.header = teamName;
            ViewBag.tester = "test";
            var blah = _repo.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamName == teamName || teamName == null)
                //Use && for and || is or
                //.FromSqlRaw("SELECT * FROM bowlers")
                .ToList();


            return View(blah);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {

            int maxID = _repo.Bowlers.Max(u => u.BowlerID);
            b.BowlerID = maxID + 1;
            _repo.AddBowler(b);
            return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View(b);
            }




        }

        [HttpGet]
        public IActionResult Edit(int BowlerID)
        {
            ViewBag.Teams = _repo.Teams.ToList();
            Bowler bowler = _repo.Bowlers
                .Single(x => x.BowlerID == BowlerID);

            return View("AddBowler", bowler);
        }

        [HttpPost]

        public IActionResult Edit(Bowler b)
        {
            _repo.SaveBowler(b);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int BowlerID)
        {
            Bowler bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);

            _repo.DeleteBowler(bowler);
            return RedirectToAction("Index");

        }

    }
}
