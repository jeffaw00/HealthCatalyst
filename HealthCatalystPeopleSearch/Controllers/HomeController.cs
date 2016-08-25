using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCatalystPeopleSearch.Services;

namespace HealthCatalystPeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleManager _manager = new PeopleManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PeopleGrid()
        {
            var people = _manager.GetAllPeople();

            return PartialView(people);
        }
    }
}