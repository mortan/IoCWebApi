using System.Web.Mvc;
using IoCWebApi.Services;
using IoCWebApi.ViewModels;
using Serilog;

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

            var indexViewModel = new IndexViewModel
            {
                Persons = repository.GetAllPersons()
            };

            Log.Debug("Returning index view with model: {@Model}", indexViewModel);

            return View(indexViewModel);
        }
    }
}
