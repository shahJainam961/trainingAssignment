using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            { 
                return RedirectToAction("Message");
            }
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}