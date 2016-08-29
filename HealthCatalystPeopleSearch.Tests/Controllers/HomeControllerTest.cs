using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthCatalystPeopleSearch.Controllers;

namespace HealthCatalystPeopleSearch.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PeopleGrid()
        {
            HomeController controller = new HomeController();
            PartialViewResult result = controller.PeopleGrid() as PartialViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNames()
        {
            HomeController controller = new HomeController();
            JsonResult result = controller.GetNames() as JsonResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadPerson()
        {
            HomeController controller = new HomeController();
            PartialViewResult result = controller.LoadPerson("") as PartialViewResult;

            Assert.IsNotNull(result);
        }
    }
}
