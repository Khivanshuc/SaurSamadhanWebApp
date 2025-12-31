using CredaData.Client;
using CredaData.Common.Model;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Web.WebPages.Html;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdminController : Controller
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
        private IFacade<OfficeLevelModel> officeLevelIFacade;
        private IFacade<ZonalModel> zonalIFacade;
        private IFacade<SystemIntegratorModel> sysIntegratorIFacade;
        private IFacade<ProjectModel> projectFacade;
        private IFacade<VwAdminPanelUserModel> VwadminPanelIfacade;
        private IFacade<UserListByZonalModel> userByZonalIfacade;
        private IWritableFacade<AdminPanelUserModel> adminPanelWFacade;
        private IFacade<AdminPanelUserModel> adminPanelIFacade;
        private IWritableFacade<SIUserModel> SIUserWFacade;


        public AdminController(IFacade<DistrictModel> distIFacade,
            IFacade<SiteModel> siteIFacade,
            IFacade<BlockModel> blockIFacade,
            IFacade<RoleModel> roleIFacade,
            IWritableFacade<UserModel> userWFacade,
            IFacade<UserModel> userIFacade,
            IFacade<VwUserModel> vwUserIFacade,
            IFacade<VillageModel> villageIFacade,
            IWritableFacade<SiteModel> siteWFacade,
            IFacade<VwSiteModel> vwSiteIFacade,
            IFacade<OfficeLevelModel> officeLevelIFacade,
            IFacade<ZonalModel> zonalIFacade,
            IFacade<SystemIntegratorModel> sysIntegratorIFacade,
            IFacade<ProjectModel> projectFacade,
            IFacade<VwAdminPanelUserModel> VwadminPanelIfacade,
            IFacade<UserListByZonalModel> userByZonalIfacade,
            IWritableFacade<AdminPanelUserModel> adminPanelWFacade,
            IFacade<AdminPanelUserModel> adminPanelIFacade,
            IWritableFacade<SIUserModel> SIUserWFacade)
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
            this.officeLevelIFacade = officeLevelIFacade;
            this.zonalIFacade = zonalIFacade;
            this.sysIntegratorIFacade = sysIntegratorIFacade;
            this.projectFacade = projectFacade;
            this.VwadminPanelIfacade = VwadminPanelIfacade;
            this.userByZonalIfacade = userByZonalIfacade;
            this.adminPanelWFacade = adminPanelWFacade;
            this.adminPanelIFacade = adminPanelIFacade;
            this.SIUserWFacade = SIUserWFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrations() => View();
        public IActionResult ApplicantPartialView()
        {
            return PartialView("ApplicantPartialView");
        }
        [HttpGet]
        public JsonResult GetRoles()
        {
            var rolelist = roleIFacade.ListAllAsync().Result.ToList();
            var roles = new List<SelectListItem>();

            foreach (var item in rolelist)
            {
                roles.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.RoleName });
            }
            return Json(roles);
        }
        [HttpGet]
        public JsonResult GetDistricts()
        {
            var districtList = distIFacade.ListAllAsync().Result.ToList();
            var districts = new List<SelectListItem>();

            foreach (var item in districtList)
            {
                districts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.DistrictName });
            }
            return Json(districts);
        }
        [HttpGet]
        public JsonResult GetDistrictsForAdminPanel()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var districtList = distIFacade.GetDistListForAdminPanel(UserId).Result.ToList();
            var districts = new List<SelectListItem>();

            foreach (var item in districtList)
            {
                districts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.DistrictName });
            }
            return Json(districts);
        }

        [HttpGet]
        public JsonResult GetOfficeLevel()
        {
            var officeLevelList = officeLevelIFacade.ListAllAsync().Result.ToList();
            var officeLevels = new List<SelectListItem>();

            foreach (var item in officeLevelList)
            {
                officeLevels.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.OfficeName });
            }
            return Json(officeLevels);
        }
        public JsonResult GetZonal()
        {
            var zonalList = zonalIFacade.ListAllAsync().Result.ToList();
            var zonals = new List<SelectListItem>();

            foreach (var item in zonalList)
            {
                zonals.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.ZonalOffices });
            }
            return Json(zonals);
        }

        [HttpGet]
        public JsonResult GetBlockByDistricts(long districtId)
        {
            var blockList = blockIFacade.ListAllAsync().Result.ToList();
            blockList = blockList.Where(b => b.DistrictId == districtId).ToList();
            var blocks = new List<SelectListItem>();

            foreach (var item in blockList)
            {
                blocks.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.BlockName });
            }
            return Json(blocks);
        }
        public async Task<JsonResult> GetVillageByBlocks(long blockId)
        {
            if (blockId == 0)
            {
                blockId = 1;
            }
            Expression<Func<VillageModel, bool>> filter = a => a.BlockId == blockId;
            var villageList = await villageIFacade.ListAllAsync(filter);

            var villages = new List<SelectListItem>();
            if (villageList != null)
            {
                foreach (var item in villageList)
                {
                    villages.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.VillageName });
                }
                return Json(villages);
            }
            else
            {
                return Json(null);
            }
        }

        public async Task<JsonResult> GetSitesByVillage(long siteId)
        {
            if (siteId == 0)
            {
                siteId = 1;
            }
            Expression<Func<SiteModel, bool>> filter = a => a.Id == siteId;
            var siteList = await siteIFacade.ListAllAsync(filter);

            var sites = new List<SelectListItem>();
            if (siteList != null)
            {
                foreach (var item in siteList)
                {
                    sites.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SiteName });
                }
                return Json(sites);
            }
            else
            {
                return Json(null);
            }
        }

        public async Task<JsonResult> GetSitesByVillageId(long VillageId)
        {
            if (VillageId == 0)
            {
                VillageId = 1;
            }
            //Expression<Func<SiteModel, bool>> filter = a => a.Id == siteId;
            var siteList = await siteIFacade.VillageSitesList(VillageId);

            var sites = new List<SelectListItem>();
            if (siteList != null)
            {
                foreach (var item in siteList)
                {
                    sites.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SiteName });
                }
                return Json(sites);
            }
            else
            {
                return Json(null);
            }
        }
        public IActionResult AddUser(UserModel user)
        {
            if (user != null)
            {
                user.CreatedOn = DateTime.Now;
                user.UpdatedOn = DateTime.Now;
                user.IsActive = true;
                var mobileNumber = user.MobileNumber;
                Expression<Func<UserModel, bool>> filter = a => a.MobileNumber == mobileNumber;
                var userData = userWFacade.ListAllAsync(filter).Result;

                if (userData != null && userData.Any())
                {
                    return Json(new { isSuccess = false, isUserExist = true });
                }

                var res = userWFacade.InsertAsync(user, "System").Result;

                if (res)
                {
                    return Json(new { isSuccess = true, isUserExist = false });
                }
            }

            return Json(new { isSuccess = false, isUserExist = false });
        }

        public async Task<IActionResult> GetUserList(string UserName, long DistrictId = 0)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var users = await vwUserIFacade.GetUserList(UserName, DistrictId, UserId);
            return PartialView("UsersList", users);
        }

        [HttpGet]
        public JsonResult GetUserListByZonal()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var usersList = userByZonalIfacade.GetList(UserId).Result.ToList();

            var users = new List<SelectListItem>();

            foreach (var item in usersList)
            {
                users.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.UserName });
            }

            return Json(users);
        }

        public IActionResult EditUser(long Id)
        {
            var User = userIFacade.GetAsync(Id).Result;
            VwUserModel userModel = new VwUserModel();
            userModel.Id = Id;
            userModel.UserName = User.UserName;
            userModel.Email = User.Email;
            userModel.MobileNumber = User.MobileNumber;
            userModel.RoleId = User.RoleId;
            userModel.DistrictId = User.DistrictId;
            userModel.BlockId = User.BlockId;
            //userModel.OfficeLevel = User.ZonalId;
            userModel.ZonalId = User.ZonalId;
            //userModel.DistrictIncharge = User.
            if (User.IsDistrictIncharge != 0)
            {
                userModel.IsDistrictIncharge = true;
            }
            else
            {
                userModel.IsDistrictIncharge = false;
            }
            return PartialView(userModel);
        }
        public IActionResult UpdateUser(VwUserModel model)
        {
            var Usert = userIFacade.GetAsync(model.Id).Result;
            Usert.UserName = model.UserName;
            Usert.Email = model.Email;
            Usert.MobileNumber = model.MobileNumber;
            Usert.RoleId = model.RoleId;
            Usert.DistrictId = model.DistrictId;
            Usert.BlockId = model.BlockId;
            if (model.OfficeLevel == "1")
            {
                Usert.ZonalId = -1;
            }
            else if (model.OfficeLevel == "3")
            {
                Usert.ZonalId = 0;
            }
            else
            {
                Usert.ZonalId = model.ZonalId;
            }

            if (model.IsDistrictIncharge)
            {
                Usert.IsDistrictIncharge = model.DistrictId;
            }
            else
            {
                Usert.IsDistrictIncharge = 0;
            }
            Usert.UpdatedBy = "System";
            Usert.UpdatedOn = DateTime.Now;
            userWFacade.UpdateAsync(Usert.Id, Usert);
            return View("Registrations");
        }
        public IActionResult DeleteUser(long Id)
        {
            var user = userIFacade.GetAsync(Id).Result;
            user.IsActive = false;
            var res = userWFacade.UpdateAsync(user.Id, user);
            return Ok();
        }
        public IActionResult SitePartialView()
        {
            return PartialView("SitePartialView");
        }

        public async Task<IActionResult> SIUserPartialView()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var users = await SIUserWFacade.ListAllAsync();
            return PartialView("SIUserPartialView", users);
        }
        public bool AddSite(SiteModel site)
        {
            if (site != null)
            {
                site.CreatedOn = DateTime.Now;
                site.UpdatedOn = DateTime.Now;
                var res = siteWFacade.InsertAsync(site, "System");
            }
            return true;
        }
        public async Task<IActionResult> GetSiteList(long DistrictId, long BlockId, long VillageId)
        {
            var siteModel = await vwSiteIFacade.GetList(DistrictId, BlockId, VillageId);
            return PartialView("SitesList", siteModel);
        }

        [HttpGet]
        public JsonResult GetSystemIntegrator()
        {
            var SIList = sysIntegratorIFacade.ListAllAsync().Result.ToList();
            var SIs = new List<SelectListItem>();

            foreach (var item in SIList)
            {
                SIs.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SIName });
            }
            return Json(SIs);
        }

        [HttpGet]
        public JsonResult GetDistrictUserList()
        {

            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var UserList = vwUserIFacade.GetUserList("", 0, UserId).Result.ToList();
            var Users = new List<SelectListItem>();

            foreach (var item in UserList)
            {
                Users.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.UserName });
            }
            return Json(Users);
        }
        [HttpGet]
        public JsonResult GetProjectName()
        {
            var projectList = projectFacade.ListAllAsync().Result.ToList();
            var Projects = new List<SelectListItem>();

            foreach (var item in projectList)
            {
                if (item.ParentId != 0)
                {
                    Projects.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.ProjectName
                    });
                }
            }
            return Json(Projects);
        }

        public IActionResult UserProfile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public async Task<JsonResult> UserProfileDetail()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            long userId = !string.IsNullOrEmpty(userIdClaim) ? Convert.ToInt64(userIdClaim) : 0;

            // Check if the userId is valid
            if (userId == 0)
            {
                return Json(new { success = false, message = "Invalid UserId." });
            }

            // Await the GetAsync method
            var data = await VwadminPanelIfacade.GetAsync(userId);

            // Check if data is null or if data.Id is 0
            if (data == null || data.Id == 0)
            {
                return Json(new { success = false, message = "No data found." }); // Or StatusCode(204)
            }

            // Return the data
            return Json(new { success = true, data });
        }

        public async Task<JsonResult> UpdatePassword(string OldPassword, string NewPassword)
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            long userId = !string.IsNullOrEmpty(userIdClaim) ? Convert.ToInt64(userIdClaim) : 0;

            if (userId == 0)
            {
                return Json(new { success = false, message = "Invalid UserId." });
            }
            var data = await adminPanelIFacade.GetAsync(userId);

            if (data.Password == OldPassword)
            {
                data.Password = NewPassword;
                var res = await adminPanelWFacade.UpdateAsync(data.Id, data);
            }

            if (data == null || data.Id == 0)
            {
                return Json(new { success = false, message = "No data found." }); // Or StatusCode(204)
            }

            return Json(new { success = true, data });
        }
        public IActionResult AdminUser()
        {
            return View();
        }

        public async Task<IActionResult> AdminPanelUserListPartialView()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await VwadminPanelIfacade.ListAllAsync();
            return PartialView(data);
        }

        public IActionResult AddSIUser(SIUserModel user)
        {
            if (user != null)
            {
                user.CreatedOn = DateTime.Now;
                user.UpdatedOn = DateTime.Now;
                user.IsActive = true;
                var mobileNumber = user.MobileNumber;
                Expression<Func<SIUserModel, bool>> filter = a => a.MobileNumber == mobileNumber;
                var userData = SIUserWFacade.ListAllAsync(filter).Result;

                if (userData != null && userData.Any())
                {
                    return Json(new { isSuccess = false, isUserExist = true });
                }

                var res = SIUserWFacade.InsertAsync(user, "System").Result;

                if (res)
                {
                    return Json(new { isSuccess = true, isUserExist = false });
                }
            }

            return Json(new { isSuccess = false, isUserExist = false });
        }

    }


}