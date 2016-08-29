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
            return View(_manager.GetHome());
        }

        public PartialViewResult PeopleGrid()
        {
            return PartialView(_manager.GetAllPeople());
        }

        public ActionResult GetNames()
        {
            return Json(_manager.GetNames(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPerson(string name)
        {
            return PartialView(_manager.GetPerson(name));
        }

        [HttpPost]
        public PartialViewResult AddPerson(Models.Person person)
        {
            _manager.AddPerson(person);
            return PartialView("PeopleGrid", _manager.GetAllPeople());
        }

        [HttpDelete]
        public PartialViewResult DeletePerson(int PersonId)
        {
            _manager.DeletePerson(PersonId);
            return PartialView("PeopleGrid", _manager.GetAllPeople());
        }
    }
}