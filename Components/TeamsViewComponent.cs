using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Views.Shared.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent (IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            //var cats = repo.Books
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x);
            var teams = repo.Teams
                .Select(x => x.TeamName)
                //.Distinct()
                .OrderBy(x => x);

            //IEnumerable<Team> teams = repo.Teams.ToList();


            return View(teams);
        }
    }
}
