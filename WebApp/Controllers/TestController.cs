using CredaData.Client;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        IWritableFacade<otherthanjjmalreadycompleted> ojjmfacade;
        IWritableFacade<biogasalreadycompleted> biofacade;
        public TestController(IWritableFacade<otherthanjjmalreadycompleted> ojjmfacade, IWritableFacade<biogasalreadycompleted> biofacade)
        {
            this.ojjmfacade = ojjmfacade;
            this.biofacade = biofacade;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddBio()
        {
            return View();
        }
        public IActionResult Save(otherthanjjmalreadycompleted model)
        {
            var res= ojjmfacade.InsertAsync(model, "System");
            return View("Index");
        } 
        public IActionResult SaveBio(biogasalreadycompleted model)
        {
            var res= biofacade.InsertAsync(model, "System");
            return View("Index");
        }
    }
}
