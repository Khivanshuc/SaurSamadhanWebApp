using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StockManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GenerateChallan()
        {
            return View();
        }

        public IActionResult ViewItems()
        {
            return View();
        }

        public IActionResult ViewItemList()
        {
            return PartialView(ViewItemList);
        }

        public IActionResult ViewItemListDetail()
        {
            return PartialView(ViewItemListDetail);
        }
        public IActionResult AtGlance()
        {
            return View();
        }
        public IActionResult AtGlancePartialView()
        {
            return PartialView(AtGlancePartialView);
        }

    }
}
