using CredaData.Client;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Web.WebPages.Html;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DIActionController : Controller
    {
        private IFacade<DistrictModel> distIFacade;
        private IFacade<BlockModel> blockIFacade;
        private IFacade<RoleModel> roleIFacade;
        private IWritableFacade<UserModel> userWFacade;
        private IFacade<UserModel> userIFacade;
        private IFacade<VwUserModel> vwUserIFacade;
        private IFacade<VillageModel> villageIFacade;
        private IFacade<SiteModel> siteIFacade;
        private IFacade<VwSiteModel> vwSiteIFacade;
        private IWritableFacade<SiteModel> siteWFacade;
        public DIActionController(IFacade<DistrictModel> distIFacade, IFacade<SiteModel> siteIFacade, IFacade<BlockModel> blockIFacade, IFacade<RoleModel> roleIFacade, IWritableFacade<UserModel> userWFacade, IFacade<UserModel> userIFacade, IFacade<VwUserModel> vwUserIFacade, IFacade<VillageModel> villageIFacade, IWritableFacade<SiteModel> siteWFacade, IFacade<VwSiteModel> vwSiteIFacade)
        {
            this.distIFacade = distIFacade;
            this.siteIFacade = siteIFacade;
            this.blockIFacade = blockIFacade;
            this.roleIFacade = roleIFacade;
            this.userWFacade = userWFacade;
            this.userIFacade = userIFacade;
            this.vwUserIFacade = vwUserIFacade;
            this.villageIFacade = villageIFacade;
            this.siteWFacade = siteWFacade;
            this.vwSiteIFacade = vwSiteIFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NWork()
        {
            List<VwNotWokingModel> data = new();
            return View(data);
        }
        public IActionResult Test()
        {
            List<VwTestModel> data = new();
            return View(data);
        }
        public IActionResult TestAbc()
        {
            List<VwTestModel> model = new();
            return View("AbcList",model);
        }
    }
}
