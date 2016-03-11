using System.Web.Mvc;
using App.ViewModels;

namespace App.Controllers
{
    public class FindClientController : Controller
    {
        // application start page
        [HttpGet]
        public ActionResult Index()
        {
            var ViewModel = new FindClientsViewModel();
            ViewModel.GetSearchItens();
            return View(ViewModel);
        }

        // Ajax request - send the dropDown with the city regions
        [HttpPost]
        public PartialViewResult Region(FindClientsViewModel model)
        {
            var ViewModel = model;
            model.GetRegionByCity();
            return PartialView(ViewModel);
        }

        // Ajax request -- send client table 
        [HttpPost]
        public PartialViewResult Table(FindClientsViewModel model)
        {
            var ViewModel = model;
            model.GetClientList();
            return PartialView(ViewModel);
        }
    }
}