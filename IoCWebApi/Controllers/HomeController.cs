using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IoCWebApi.Services;
using IoCWebApi.ViewModels;

namespace IoCWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository repository;

        public HomeController(IDataRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(new IndexViewModel
            {
                Persons = repository.GetAllPersons()
            });
        }
    }
}
