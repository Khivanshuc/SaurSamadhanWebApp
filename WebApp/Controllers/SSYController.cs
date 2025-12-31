using CredaData.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class SSYController : Controller
    {
        private IFacade<DistrictModel> distIFacade;
        private IFacade<BlockModel> blockIFacade;
        private IFacade<RoleModel> roleIFacade;
        private IWritableFacade<UserModel> userWFacade;
        private IFacade<UserModel> userIFacade;
        private IFacade<VillageModel> villageIFacade;
        private IFacade<SiteModel> siteIFacade;
        private IWritableFacade<SiteModel> siteWFacade;
        private IWritableFacade<SSYRegistrationModel> ssyRWFacade;
        private IFacade<SSYRegistrationModel> ssyRWIFacade;
        private IWritableFacade<SSYPaymentMasterModel> ssyPMFacade;
        private IWritableFacade<BankDetailModel> bankIWFacade;
        private IFacade<GrievanceGlanceCountModel> gGCIFacade;
        private IFacade<VwSSYRegistrationFormModel> ssyDetailIFacade;
        private IFacade<GrievanceGlanceListModel> grievanceGlanceListIFacade;
        private readonly IFacade<VwGrievanceModel> vwGrievanceIfacade;

        public SSYController(IFacade<DistrictModel> distIFacade,
            IFacade<BlockModel> blockIFacade,
            IFacade<VillageModel> villageIFacade,
            IWritableFacade<SiteModel> siteWFacade,
            IWritableFacade<SSYRegistrationModel> ssyRWFacade,
            IWritableFacade<SSYPaymentMasterModel> ssyPMFacade,
            IFacade<SSYRegistrationModel> ssyRWIFacade,
            IWritableFacade<BankDetailModel> bankIWFacade,
            IFacade<GrievanceGlanceCountModel> gGCIFacade,
            IFacade<VwSSYRegistrationFormModel> ssyDetailIFacade,
            IFacade<GrievanceGlanceListModel> grievanceGlanceListIFacade,
            IFacade<VwGrievanceModel> vwGrievanceIfacade)
        {
            this.distIFacade = distIFacade;
            this.blockIFacade = blockIFacade;
            this.villageIFacade = villageIFacade;
            this.siteWFacade = siteWFacade;
            this.ssyRWFacade = ssyRWFacade;
            this.ssyPMFacade = ssyPMFacade;
            this.ssyRWIFacade = ssyRWIFacade;
            this.bankIWFacade = bankIWFacade;
            this.gGCIFacade = gGCIFacade;
            this.ssyDetailIFacade = ssyDetailIFacade;
            this.grievanceGlanceListIFacade = grievanceGlanceListIFacade;
            this.vwGrievanceIfacade = vwGrievanceIfacade;
        }
        public IActionResult Index()
        {
            return RedirectToAction("SSY_Registration");
        }

        public IActionResult SSY_Registration()
        {
            return View();
        }

        public IActionResult SSY_Check_Status()
        {
            return View();
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
        public async Task<IActionResult> SaveSSYRegistrationData(SSYRegistrationModel data)
        {
            if (data != null)
            {
                bool insertResult = await ssyRWFacade.InsertAsync(data, "System");
                if (insertResult)
                {
                    // After successful insertion, retrieve the last saved data
                    var lastSavedData = await ssyRWIFacade.GetSSYRegLastData();

                    // Return success response with the last saved data
                    return Ok(new { success = true, lastData = lastSavedData });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Data insertion failed" });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        public async Task<IActionResult> SaveBankDetail(BankDetailModel data)
        {
            // After successful insertion, retrieve the last saved data
            var lastSavedData = await ssyRWIFacade.GetSSYRegLastData();

            if (data != null)
            {
                data.RegistrationId = lastSavedData[0].Id;
                bool insertResult = await bankIWFacade.InsertAsync(data, "System");
                if (insertResult)
                {
                    // Return success response with the last saved data
                    return Ok(new { success = true, lastData = lastSavedData });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Data insertion failed" });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        [HttpGet]
        public JsonResult GetPaymentData(long Category, long PumpCapacity, long SolarPumpType, long PumpType)
        {

            var ssyPaymentList = ssyPMFacade.ListAllAsync().Result
        .Where(p => p.CasteId == Category
                    && p.PumpCapacityId == PumpCapacity
                    && p.SolarPumpId == SolarPumpType
                    && p.PumpChoiceId == PumpType)
        .ToList();

            return Json(ssyPaymentList);
        }

        public IActionResult GrievanceGlance()
        {
            return View();
        }

        public async Task<IActionResult> GrievanceGlanceList()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await gGCIFacade.GetGrievanceGlanceCount();
            return PartialView(data);
        }
        public async Task<IActionResult> GrievanceGlanceListDetail(long DistrictId, long TotalComplaint, long ResolvedComplaint,
            long ComplaintLess30Days, long PendingDOLessThan30Days, long PendingZOLessThan30Days, long PendingHOLessThan30Days,
            long ComplaintMore30Days,long PendingDOMoreThan30Days, long PendingZOMoreThan30Days, long PendingHOMoreThan30Days, long TotalPendingComplaint)
        {
            var data = await grievanceGlanceListIFacade.GetGrievanceGlanceList(DistrictId, TotalComplaint, ResolvedComplaint,
                ComplaintLess30Days, PendingDOLessThan30Days, PendingZOLessThan30Days, PendingHOLessThan30Days,
                ComplaintMore30Days, PendingDOMoreThan30Days, PendingZOMoreThan30Days, PendingHOMoreThan30Days,
                TotalPendingComplaint);
            if (data == null || !data.Any())
            {
                return PartialView("GrievanceGlanceListDetail", new List<GrievanceGlanceListModel>());
            }

            return PartialView("GrievanceGlanceListDetail", data);
        }
        public async Task<IActionResult> SSY_Check_Status_PartialView(long AdharNo, long MobileNo)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await ssyDetailIFacade.GetSSYRegistrationDetail(AdharNo, MobileNo);
            return PartialView(data);
        }

        public IActionResult GrievancesDetails(long Id)
        {
            var data = vwGrievanceIfacade.GetAsync(Id).Result;
            // Check if the data is null or empty
            if (data == null)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView("GrievanceGlanceDetails", data);
        }
    }
}
