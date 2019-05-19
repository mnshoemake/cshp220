using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult CardGenerator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CardGenerator(Models.BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("CardSent", birthdayCard); 
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CardSent()
        {
            return View("CardGenerator");
        }



    }
}