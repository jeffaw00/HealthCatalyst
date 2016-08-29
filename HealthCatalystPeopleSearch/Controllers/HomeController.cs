using System;
using System.IO;
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

        public PartialViewResult LoadPerson(string name)
        {
            System.Threading.Thread.Sleep(3000);
            return PartialView(_manager.GetPerson(name));
        }

        [HttpPost]
        public PartialViewResult AddPerson(Models.Person person, HttpPostedFileBase file1)
        {
            if(file1 != null)
            {
                string filename = string.Empty;
                byte[] bytes;
                int bytesToRead;
                int numBytesRead;
                filename = Path.GetFileName(file1.FileName);
                bytes = new byte[file1.ContentLength];
                bytesToRead = (int)file1.ContentLength;
                numBytesRead = 0;

                while(bytesToRead > 0)
                {
                    int n = file1.InputStream.Read(bytes, numBytesRead, bytesToRead);
                    if (n == 0)
                        break;
                    numBytesRead += n;
                    bytesToRead -= n;
                }

                person.Photo = bytes;
            }
            _manager.AddPerson(person);
            return PartialView("PeopleGrid", _manager.GetAllPeople());
        }

        public FileContentResult GetPhoto(int id)
        {
            var image = _manager.GetPhoto(id);
            if(image != null)
            {
                return new FileContentResult(image, "image/png");
            }
            else
            {
                byte[] buffer;
                string fileName = Server.MapPath(Url.Content("~/Content/Images/NoImageAvailable.jpg"));
                using (FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(filestream))
                    {
                        long totalBytes = new FileInfo(fileName).Length;

                        buffer = reader.ReadBytes((Int32)totalBytes);
                    }
                }
                return new FileContentResult(buffer, "image/jpg");
            }
        }

        [HttpDelete]
        public PartialViewResult DeletePerson(int PersonId)
        {
            _manager.DeletePerson(PersonId);
            return PartialView("PeopleGrid", _manager.GetAllPeople());
        }

        public ContentResult Reseed()
        {
            string result = string.Empty;
            try
            {
                _manager.Reseed();
                return Content("success");
            }
            catch(Exception ex)
            {
                // would normally log failure to mongo or other log db, then return
                return Content("failed");
            }
        }
    }
}