using Microsoft.AspNetCore;
using CredaData.Client;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis;
using NuGet.Protocol.Plugins;
using Rotativa.AspNetCore;
using SelectPdf;
using System.Linq.Expressions;
using WebApp.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;

namespace WebApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IFacade<DistrictModel> distIFacade;
        private readonly IFacade<BlockModel> blockIFacade;
        private readonly IFacade<RoleModel> roleIFacade;
        private readonly IWritableFacade<UserModel> userWFacade;
        private readonly IFacade<UserModel> userIFacade;
        private readonly IFacade<VillageModel> villageIFacade;
        private readonly IFacade<SiteModel> siteIFacade;
        private readonly IWritableFacade<SiteModel> siteWFacade;
        private readonly IWritableFacade<GrievanceModel> grievanceWfacade;
        private readonly IFacade<GrievanceModel> grievanceIfacade;
        private readonly IFacade<ProjectModel> projectIfacade;
        private readonly IFacade<SystemIntegratorModel> SIIfacade;
        private readonly IFacade<InspectionInProgressModel> IPIfacade;
        private readonly IFacade<StageModel> stagefacade;
        private readonly IFacade<SSYInspectionInProgress> SSYIPfacade;
        private readonly IFacade<OtherThanRVEDDGMonitoringAlreadyCompleted> OTRVEDDMfacade;
        private readonly IFacade<SSYalreadyCompletedModel> SSYACfacade;
        private readonly IFacade<VwJJMAlreadyCompletedListModel> JJMListIfacade;
        private readonly IFacade<VwJJMAlreadyCompletedModel> JJMDetailIfacade;
        private readonly IFacade<VwOTJJMAlreadyCompletedListModel> OTJJMListIfacade;
        private readonly IFacade<VwOTJJMAlreadyCompletedModel> OTJJMDetailIfacade;
        private readonly IFacade<VwGrievanceListModel> vwGrievanceListIfacade;
        private readonly IFacade<VwGrievanceModel> vwGrievanceIfacade;
        private readonly IFacade<VWInspectionInProgressListModel> vwInspectionListIfacade;
        private readonly IFacade<VWInspectionInProgressModel> vwInspectionIfacade;
        private readonly IFacade<VwSSYAlreadyCompletedListModel> SSYListIfacade;
        private readonly IFacade<VwSSYalreadyCompletedDetailModel> SSYDetailIfacade;
        private readonly IFacade<VwOTRVEDDGAlreadyCompletedListModel> OTRVEDDGListIfacade;
        private readonly IFacade<VwOtherThanRVEDDGMonitoringAlreadyCompleted> OTRVEDDGDetailIfacade;
        private readonly IFacade<VwRVEDDGAlreadyCompletedListModel> RVEDDGListIfacade;
        private readonly IFacade<VwRVEDDGalreadycompletedModel> RVEDDGDetailIfacade;
        private readonly IFacade<VwHMAlreadyCompletedListModel> HMListIfacade;
        private readonly IFacade<VwHMalreadycompletedModel> HMDetailIfacade;
        private readonly IFacade<VwMMAlreadyCompletedListModel> MMListIfacade;
        private readonly IFacade<VwMMalreadycompletedModel> MMDetailIfacade;
        private readonly IFacade<VwBiogasAlreadyCompletedListModel> BiogasListIfacade;
        private readonly IFacade<VwBiogasalreadycompletedModel> BiogasDetailIfacade;
        private readonly IFacade<VwOGPPAlreadyCompletedListModel> OGPPListIfacade;
        private readonly IFacade<VwOGPPalreadycompletedModel> OGPPDetailIfacade;
        private readonly IFacade<VwCMGGYAlreadyCompletedListModel> CMGGYListIfacade;
        private readonly IFacade<VwCMGGYalreadycompletedModel> CMGGYDetailIfacade;
        private readonly IFacade<VwCIAlreadyCompletedListModel> CIListIfacade;
        private readonly IFacade<VwCIalreadycompletedModel> CIDetailIfacade;
        private readonly IFacade<VwProjectWorkingCountModel> projectDetailwithCountIfacade;
        private readonly IFacade<VwSSYInspectionInProgressListModel> SSYIPListIfacade;
        private readonly IFacade<DownloadJJMACListModel> DownloadJJMListIfacade;
        private readonly IFacade<DownloadOTJJMACListModel> DownloadOTJJMListIfacade;
        private readonly IFacade<DownloadSSYACListModel> DownloadSSYListIfacade;
        private readonly IFacade<DownloadCMGGYACListModel> DownloadCMGGYListIfacade;
        private readonly IFacade<DownloadCIACListModel> DownloadCIListIfacade;
        private readonly IFacade<DownloadRVEDDGACListModel> DownloadRVEDDGListIfacade;
        private readonly IFacade<DownloadOTRVEDDGACListModel> DownloadOTRVEDDGListIfacade;
        private readonly IFacade<DownloadOGPPACListModel> DownloadOGPPListIfacade;
        private readonly IFacade<DownloadHMACListModel> DownloadHMListIfacade;
        private readonly IFacade<DownloadMMACListModel> DownloadMMListIfacade;
        private readonly IFacade<DownloadBioGasListModel> DownloadBioGasListIfacade;
        private readonly IFacade<DownloadInspectionIPListModel> DownloadIPListIfacade;
        private readonly IFacade<DownloadSSYInspectionIPListModel> DownloadSSYIPListIfacade;
        private readonly IFacade<GrievanceAnalyticsDataModel> GrievanceAnalyticsDataIfacade;
        private readonly IFacade<DownloadGrievanceListModel> DownloadGrievanceListIfacade;
        private readonly IFacade<VwUserModel> vwUserIFacade;
        private readonly IWritableFacade<ForwardingGrievanceModel> grievanceForwardWFacade;
        private readonly IFacade<ForwardingGrievanceModel> grievanceForwardIFacade;


        public ReportsController(
            IFacade<DistrictModel> distIFacade,
            IFacade<SiteModel> siteIFacade,
            IFacade<BlockModel> blockIFacade,
            IFacade<RoleModel> roleIFacade,
            IWritableFacade<UserModel> userWFacade,
            IFacade<UserModel> userIFacade,
            IFacade<VillageModel> villageIFacade,
            IWritableFacade<SiteModel> siteWFacade,
            IFacade<GrievanceModel> grievanceIfacade,
            IFacade<ProjectModel> projectIfacade,
            IFacade<SystemIntegratorModel> sIIfacade,
            IWritableFacade<GrievanceModel> grievanceWfacade,
            IFacade<InspectionInProgressModel> IPIfacade,
            IFacade<StageModel> stagefacade,
            IFacade<SSYInspectionInProgress> sSYIPfacade,
            IFacade<OtherThanRVEDDGMonitoringAlreadyCompleted> oTRVEDDMfacade,
            IFacade<SSYalreadyCompletedModel> sSYACfacade,
            IFacade<VwJJMAlreadyCompletedListModel> JJMListIfacade,
            IFacade<VwGrievanceListModel> vwGrievanceListIfacade,
            IFacade<VwGrievanceModel> vwGrievanceIfacade,
            IFacade<VWInspectionInProgressListModel> vwInspectionIListfacade,
            IFacade<VWInspectionInProgressModel> vwInspectionIfacade,
            IFacade<VwJJMAlreadyCompletedModel> JJMDetailIfacade,
            IFacade<VwSSYAlreadyCompletedListModel> SSYListIfacade,
            IFacade<VwSSYalreadyCompletedDetailModel> SSYDetailIfacade,
            IFacade<VwOTRVEDDGAlreadyCompletedListModel> OTRVEDDGListIfacade,
            IFacade<VwOtherThanRVEDDGMonitoringAlreadyCompleted> OTRVEDDGDetailIfacade,
            IFacade<VwRVEDDGAlreadyCompletedListModel> rVEDDGListIfacade,
            IFacade<VwRVEDDGalreadycompletedModel> rVEDDGDetailIfacade,
            IFacade<VwHMAlreadyCompletedListModel> hMListIfacade,
            IFacade<VwHMalreadycompletedModel> hMDetailIfacade,
            IFacade<VwMMAlreadyCompletedListModel> mMListIfacade,
            IFacade<VwMMalreadycompletedModel> mMDetailIfacade,
            IFacade<VwBiogasAlreadyCompletedListModel> biogasListIfacade,
            IFacade<VwBiogasalreadycompletedModel> biogasDetailIfacade,
            IFacade<VwOGPPAlreadyCompletedListModel> oGPPListIfacade,
            IFacade<VwOGPPalreadycompletedModel> oGPPDetailIfacade,
            IFacade<VwCMGGYAlreadyCompletedListModel> cMGGYListIfacade,
            IFacade<VwCMGGYalreadycompletedModel> cMGGYDetailIfacade,
            IFacade<VwCIAlreadyCompletedListModel> cIListIfacade,
            IFacade<VwCIalreadycompletedModel> cIDetailIfacade,
            IFacade<VwProjectWorkingCountModel> projectDetailwithCountIfacade,
            IFacade<VwOTJJMAlreadyCompletedListModel> OTJJMListIfacade,
            IFacade<VwOTJJMAlreadyCompletedModel> OTJJMDetailIfacade,
            IFacade<VwSSYInspectionInProgressListModel> SSYIPListIfacade,
            IFacade<DownloadJJMACListModel> DownloadJJMListIfacade,
            IFacade<DownloadOTJJMACListModel> DownloadOTJJMListIfacade,
            IFacade<DownloadSSYACListModel> DownloadSSYListIfacade,
            IFacade<DownloadCMGGYACListModel> DownloadCMGGYListIfacade,
            IFacade<DownloadCIACListModel> DownloadCIListIfacade,
            IFacade<DownloadRVEDDGACListModel> DownloadRVEDDGListIfacade,
            IFacade<DownloadOTRVEDDGACListModel> DownloadOTRVEDDGListIfacade,
            IFacade<DownloadOGPPACListModel> DownloadOGPPListIfacade,
            IFacade<DownloadHMACListModel> DownloadHMListIfacade,
            IFacade<DownloadMMACListModel> DownloadMMListIfacade,
            IFacade<DownloadBioGasListModel> DownloadBioGasListIfacade,
            IFacade<DownloadInspectionIPListModel> DownloadIPListIfacade,
            IFacade<DownloadSSYInspectionIPListModel> DownloadSSYIPListIfacade,
            IFacade<GrievanceAnalyticsDataModel> GrievanceAnalyticsDataIfacade,
            IFacade<DownloadGrievanceListModel> DownloadGrievanceListIfacade,
            IFacade<VwUserModel> vwUserIFacade,
            IWritableFacade<ForwardingGrievanceModel> grievanceForwardWFacade,
            IFacade<ForwardingGrievanceModel> grievanceForwardIFacade
            )
        {
            this.distIFacade = distIFacade;
            this.siteIFacade = siteIFacade;
            this.blockIFacade = blockIFacade;
            this.roleIFacade = roleIFacade;
            this.userWFacade = userWFacade;
            this.userIFacade = userIFacade;
            this.villageIFacade = villageIFacade;
            this.siteWFacade = siteWFacade;
            this.grievanceIfacade = grievanceIfacade;
            this.projectIfacade = projectIfacade;
            this.SIIfacade = sIIfacade;
            this.grievanceWfacade = grievanceWfacade;
            this.IPIfacade = IPIfacade;
            this.stagefacade = stagefacade;
            SSYIPfacade = sSYIPfacade;
            OTRVEDDMfacade = oTRVEDDMfacade;
            SSYACfacade = sSYACfacade;
            this.JJMListIfacade = JJMListIfacade;
            this.vwGrievanceListIfacade = vwGrievanceListIfacade;
            this.vwGrievanceIfacade = vwGrievanceIfacade;
            this.vwInspectionListIfacade = vwInspectionIListfacade;
            this.vwInspectionIfacade = vwInspectionIfacade;
            this.JJMDetailIfacade = JJMDetailIfacade;
            this.SSYListIfacade = SSYListIfacade;
            this.SSYDetailIfacade = SSYDetailIfacade;
            this.OTRVEDDGListIfacade = OTRVEDDGListIfacade;
            this.OTRVEDDGDetailIfacade = OTRVEDDGDetailIfacade;
            this.RVEDDGListIfacade = rVEDDGListIfacade;
            this.RVEDDGDetailIfacade = rVEDDGDetailIfacade;
            this.HMListIfacade = hMListIfacade;
            this.HMDetailIfacade = hMDetailIfacade;
            this.MMListIfacade = mMListIfacade;
            this.MMDetailIfacade = mMDetailIfacade;
            this.BiogasListIfacade = biogasListIfacade;
            this.BiogasDetailIfacade = biogasDetailIfacade;
            this.OGPPListIfacade = oGPPListIfacade;
            this.OGPPDetailIfacade = oGPPDetailIfacade;
            this.CMGGYListIfacade = cMGGYListIfacade;
            this.CMGGYDetailIfacade = cMGGYDetailIfacade;
            this.CIListIfacade = cIListIfacade;
            this.CIDetailIfacade = cIDetailIfacade;
            this.projectDetailwithCountIfacade = projectDetailwithCountIfacade;
            this.OTJJMListIfacade = OTJJMListIfacade;
            this.OTJJMDetailIfacade = OTJJMDetailIfacade;
            this.SSYIPListIfacade = SSYIPListIfacade;
            this.DownloadJJMListIfacade = DownloadJJMListIfacade;
            this.DownloadOTJJMListIfacade = DownloadOTJJMListIfacade;
            this.DownloadSSYListIfacade = DownloadSSYListIfacade;
            this.DownloadCMGGYListIfacade = DownloadCMGGYListIfacade;
            this.DownloadCIListIfacade = DownloadCIListIfacade;
            this.DownloadRVEDDGListIfacade = DownloadRVEDDGListIfacade;
            this.DownloadOTRVEDDGListIfacade = DownloadOTRVEDDGListIfacade;
            this.DownloadOGPPListIfacade = DownloadOGPPListIfacade;
            this.DownloadHMListIfacade = DownloadHMListIfacade;
            this.DownloadMMListIfacade = DownloadMMListIfacade;
            this.DownloadBioGasListIfacade = DownloadBioGasListIfacade;
            this.DownloadIPListIfacade = DownloadIPListIfacade;
            this.DownloadSSYIPListIfacade = DownloadSSYIPListIfacade;
            this.GrievanceAnalyticsDataIfacade = GrievanceAnalyticsDataIfacade;
            this.DownloadGrievanceListIfacade = DownloadGrievanceListIfacade;
            this.vwUserIFacade = vwUserIFacade;
            this.grievanceForwardWFacade = grievanceForwardWFacade;
            this.grievanceForwardIFacade = grievanceForwardIFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SolarDrinkingWater()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 1, UserId);
            return View("Project", data);
        }
        public async Task<IActionResult> SolarIrrigation()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 2, UserId);
            return View("Project", data);
        }
        public async Task<IActionResult> SolarPowerPlant()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 3, UserId);
            return View("Project", data);
        }
        public async Task<IActionResult> LightingSystem()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 4, UserId);
            return View("Project", data);
        }
        public async Task<IActionResult> Biogas()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 5, UserId);
            return View("Project", data);
        }
        public async Task<IActionResult> ColdStorage()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            List<VwProjectWorkingCountModel> data = await projectDetailwithCountIfacade.GetListAsync("ParentId", 6, UserId);
            return View("Project", data);
        }

        public IActionResult District()
        {
            return View();
        }
        public IActionResult Village()
        {
            return View();
        }
        public IActionResult Grievances()
        {
            return View();
        }
        public async Task<IActionResult> GrievancesList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus, DateTime StartDate, DateTime EndDate, long FilterStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            //var GrievanceList = vwGrievanceListIfacade.GetList(District, Block).Result;
            var GrievanceList = vwGrievanceListIfacade.GetGrievanceList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus, FilterStatus, StartDate, EndDate).Result;

            return PartialView("GrievancesList", GrievanceList);
        }
        public IActionResult FaultSystem()
        {
            return View();
        }
        public IActionResult EditGrievances(long Id)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var model = vwGrievanceIfacade.GetAsync(Id).Result;
            if (model.OpenDate == null)
            {
                ViewBag.GrievanceStatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "InProgress", Text = "In Progress" },
                    //new SelectListItem { Value = "InProgress", Text = "Verified" },
                    //new SelectListItem { Value = "Closed", Text = "Closed" }
                };
            }
            else if (model.MobilePhotoBase64 == null)
            {
                ViewBag.GrievanceStatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "InProgress", Text = "In Progress" },
                };
            }
            else if (model.MobilePhotoBase64 != null || model.GrievanceStatus == "Verified" && User.FindFirst("ZonalId")?.Value == "-1")
            {
                ViewBag.GrievanceStatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "InProgress", Text = "In Progress" },
                    new SelectListItem { Value = "Closed", Text = "Closed" }
                };
            }
            else if (model.VerifyDate == null)
            {
                ViewBag.GrievanceStatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "InProgress", Text = "InProgress" }
                };
            }
            else
            {
                ViewBag.GrievanceStatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Closed", Text = "Closed" }
                };
            }
            ViewBag.SeverityOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Major", Text = "Major" },
                new SelectListItem { Value = "Minor", Text = "Minor" }
            };

            var SIList = SIIfacade.ListAllAsync().Result;
            ViewBag.SINameOptions = SIList.Select(si => new SelectListItem
            {
                Value = si.Id.ToString(),  // Assuming each item has an Id property
                Text = si.SIName           // Assuming each item has a Name property
            }).ToList();
            //var UserList = userIFacade.ListAllAsync().Result;
            var UserList = vwUserIFacade.GetUserList("", 0, UserId).Result;
            ViewBag.AssignToOptions = UserList.Select(user => new SelectListItem
            {
                Value = user.Id.ToString(),     // Assuming each item has an Id property
                Text = user.UserName            // Assuming each item has a Name property
            }).ToList();

            ViewBag.StatusOption = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "In Progress" },
                new SelectListItem { Value = "1", Text = "Closed" }
            };

            return PartialView("EditGrievances", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateGrievances(VwGrievanceModel model)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;
            long ZonalId = !string.IsNullOrEmpty(ZonalIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

            var Grievance = grievanceIfacade.GetAsync(model.Id).Result;

            if (Grievance.OpenDate == null)
            {
                long AssignedTo = Convert.ToInt64(model.AssignTo);
                var user = userIFacade.GetAsync(AssignedTo).Result;
                Grievance.GrievanceStatus = model.GrievanceStatus;
                Grievance.SIId = Convert.ToInt64(model.SIName);
                Grievance.AssignedTo = Convert.ToInt64(model.AssignTo);
                Grievance.AssignedToNumber = user.MobileNumber;
                Grievance.AdminComment = model.AdminComment;
                Grievance.OpenDate = DateTime.Now;
                Grievance.IsActive = true;
                Grievance.IsAssign = true;
                Grievance.SiIsAssign = true;
                await grievanceWfacade.UpdateAsync(Grievance.Id, Grievance);
            }
            else if (Grievance.VerifyDate != null )
            {
                Grievance.GrievanceStatus = model.GrievanceStatus;
                Grievance.VerifyComment = model.VerifyComment;
                Grievance.IsActive = false;
                Grievance.CloseDate = DateTime.Now;

                if (model.GrievanceStatus == "Closed" && ZonalId == -1)
                {
                    Grievance.IsClosedByDO = true;
                    Grievance.DIClosingDate = DateTime.Now;
                    Grievance.DORemark = model.DORemark;
                }

                await grievanceWfacade.UpdateAsync(Grievance.Id, Grievance);

            }
            var sms = grievanceWfacade.SendUpdateGrievanceOTP(Grievance.Id);
            return View("Grievances");
        }

        public IActionResult UpdateGrievances1(VwGrievanceModel model)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;
            long ZonalId = !string.IsNullOrEmpty(ZonalIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

            var Grievance = grievanceIfacade.GetAsync(model.Id).Result;

            if (Grievance.OpenDate == null)
            {
                long AssignedTo = Convert.ToInt64(model.AssignTo);
                var user = userIFacade.GetAsync(AssignedTo).Result;
                Grievance.GrievanceStatus = model.GrievanceStatus;
                Grievance.SIId = Convert.ToInt64(model.SIName);
                Grievance.AssignedTo = Convert.ToInt64(model.AssignTo);
                Grievance.AssignedToNumber = user.MobileNumber;
                Grievance.AdminComment = model.AdminComment;
                Grievance.OpenDate = DateTime.Now;
                Grievance.IsActive = true;
                Grievance.IsAssign = true;
                Grievance.SiIsAssign = true;
                grievanceWfacade.UpdateAsync(Grievance.Id, Grievance);
            }
            else if (Grievance.VerifyDate != null && Grievance.IsClosedByDO == false)
            {
                //Grievance.GrievanceStatus = model.GrievanceStatus;
                Grievance.VerifyComment = model.VerifyComment;
                Grievance.IsActive = true;
                if (model.GrievanceStatus == "Closed" && ZonalId == -1)
                {
                    Grievance.IsClosedByDO = true;
                    Grievance.DIClosingDate = DateTime.Now;
                    Grievance.DORemark = model.DORemark;
                }

                grievanceWfacade.UpdateAsync(Grievance.Id, Grievance);

            }
            else if (Grievance.IsClosedByDO == true && Grievance.DIClosingDate != null)
            {
                if (model.GrievanceStatus == "Closed" && ZonalId > 0)
                {
                    Grievance.GrievanceStatus = model.GrievanceStatus;
                    Grievance.CloseDate = DateTime.Now;
                    Grievance.IsActive = false;
                    Grievance.IsClosedByZO = true;
                    Grievance.ZOClosingDate = DateTime.Now;
                    Grievance.ZORemark = model.ZORemark;

                    long GrievanceId = Grievance.Id;
                    Expression<Func<ForwardingGrievanceModel, bool>> filter = a => a.GrievanceId == GrievanceId;
                    var data = grievanceForwardIFacade.ListAllAsync(filter).Result.FirstOrDefault();
                    if (data != null)
                    {
                        if (model.GrievanceStatus == "Closed")
                        {
                            data.ForwardedGrievanceStatus = "5";
                            grievanceForwardWFacade.UpdateAsync(data.Id, data);
                        }
                    }
                }
                else
                {

                }

            }
            var sms = grievanceWfacade.SendUpdateGrievanceOTP(Grievance.Id);
            return View("Grievances");

        }

        public IActionResult GrievanceReAssignment(long GrievanceId, long AssignedToId, long SIId, string AdminComment)
        {
            var Grievance = grievanceIfacade.GetAsync(GrievanceId).Result;

            long AssignedTo = Convert.ToInt64(AssignedToId);
            var user = userIFacade.GetAsync(AssignedTo).Result;
            Grievance.SIId = SIId;
            Grievance.IsAssign = true;
            Grievance.AssignedTo = AssignedTo;
            Grievance.AssignedToNumber = user.MobileNumber;
            Grievance.AdminComment = AdminComment;
            Grievance.OpenDate = DateTime.Now;
            Grievance.IsActive = true;
            Grievance.GrievanceStatus = "InProgress";

            grievanceWfacade.UpdateAsync(Grievance.Id, Grievance);

            return View("Grievances");
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
            return PartialView("GrievancesDetails", data);
        }
        public IActionResult IPInspection()
        {
            return View();
        }
        public async Task<IActionResult> InProgressInspectionList(long DistrictId, long BlockId, long VillageId, long ProjectId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;
            long SIId = ProjectId;   // here SIId will be treated as ProjectId

            var InspectionList = await vwInspectionListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);

            if (InspectionList == null)
            {
                return PartialView(InspectionList);
            }
            else
            {
                return PartialView(new List<VWInspectionInProgressListModel>(InspectionList));
            }
        }
        public IActionResult IPIDetails(long Id)
        {
            var data = vwInspectionIfacade.GetAsync(Id).Result;

            if (data == null || data.Id == 0)
            {
                return new EmptyResult();
            }
            return PartialView("IPIDetails", data);
        }
        public IActionResult SSYInprogress()
        {
            return View();
        }
        public async Task<IActionResult> SSYInProgressInspectionList1(long DistrictId, long BlockId, long VillageId, long SIId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var SSYInspection = SSYIPfacade.ListAllAsync().Result;
            List<VwSSYInspectionInProgress> SSYIPIList = new List<VwSSYInspectionInProgress>();
            if (SSYInspection != null)
            {
                var blockTasks = SSYInspection.Select(v => blockIFacade.GetAsync(v.BlockId)).ToList();
                var blocks = await Task.WhenAll(blockTasks);

                var districtTasks = blocks.Select(b => distIFacade.GetAsync(b.DistrictId)).ToList();
                var districts = await Task.WhenAll(districtTasks);

                var projectTasks = SSYInspection.Select(g => projectIfacade.GetAsync(g.ProjectId)).ToList();
                var projects = await Task.WhenAll(projectTasks);

                var userTasks = SSYInspection.Select(g => userIFacade.GetAsync(g.InspectedBy)).ToList();
                var users = await Task.WhenAll(userTasks);
                for (int i = 0; i < SSYInspection.Count; i++)
                {
                    var item = SSYInspection[i];
                    var district = districts[i];
                    var block = blocks[i];
                    var user = users[i];
                    var project = projects[i];
                    VwSSYInspectionInProgress data = new VwSSYInspectionInProgress();
                    data.Id = item.Id;
                    data.DistrictName = district.DistrictName;
                    data.BlockName = block.BlockName;
                    data.ProjectName = project.ProjectName;
                    data.IsComplete = item.IsComplete;
                    data.IsFaulty = item.IsFaulty;
                    data.Remarks = item.Remarks;
                    data.GeoTag = item.GeoTag;
                    data.GeoTagImage = item.GeoTagImage != null ? Convert.ToBase64String(item.GeoTagImage) : null;
                    data.GeoTagImageType = item.GeoTagImageType;
                    if (user != null)
                    {
                        data.InspectedBy = user.UserName;
                    }
                    data.InspectedOn = item.InspectedOn;
                    data.UpdatedBy = item.UpdatedBy;
                    data.UpdatedOn = item.UpdatedOn;
                    SSYIPIList.Add(data);
                }
            }
            return PartialView(SSYIPIList);
        }

        public async Task<IActionResult> SSYInProgressInspectionList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await SSYIPListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);

            return PartialView("SSYInProgressInspectionList", data);
        }
        public IActionResult SSYIPIDetails(long Id)
        {
            var SSYInspection = SSYIPfacade.GetAsync(Id).Result;
            if (SSYInspection == null)
            {
                return NotFound();
            }
            string StageName = "";
            string userName = "";
            var project = projectIfacade.GetAsync(SSYInspection.ProjectId).Result;
            if (SSYInspection.StageId != 0)
            {
                long projectId = SSYInspection.ProjectId;
                long StageId = SSYInspection.StageId;
                Expression<Func<StageModel, bool>> filter = a => a.ProjectId == projectId && a.StageId == StageId;
                var stage = stagefacade.ListAllAsync(filter).Result;
                StageName = stage[0].StageName;
            }
            var user = userIFacade.GetAsync(SSYInspection.InspectedBy).Result;
            if (user != null) // Corrected null check here
            {
                userName = user.UserName;
            }
            VwSSYInspectionInProgress data = new VwSSYInspectionInProgress();
            data.Id = SSYInspection.Id;
            if (project != null)
            {
                data.ProjectName = project.ProjectName;
            }
            data.InspectedBy = userName;
            data.StageName = StageName;
            data.PlaceorBeneficiaryName = SSYInspection.PlaceorBeneficiaryName;
            data.IsComplete = SSYInspection.IsComplete;
            data.IsFaulty = SSYInspection.IsFaulty;
            data.Remarks = SSYInspection.Remarks;
            data.GeoTag = SSYInspection.GeoTag;
            data.GeoTagImage = SSYInspection.GeoTagImage != null ? Convert.ToBase64String(SSYInspection.GeoTagImage) : null;
            data.GeoTagImageType = SSYInspection.GeoTagImageType;
            if (user != null)
            {
                data.InspectedBy = user.UserName;
            }
            data.InspectedOn = SSYInspection.InspectedOn;
            data.UpdatedBy = SSYInspection.UpdatedBy;
            data.UpdatedOn = SSYInspection.UpdatedOn;



            return PartialView("SSYIPIDetails", data);
        }
        public IActionResult OTRVEDDMReport()
        {
            return View();
        }
        public async Task<IActionResult> OTRVEDDMList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await OTRVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> OTRVEDDGDetails(long Id)
        {
            var data = await OTRVEDDGDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView("OTRVEDDMDetails", data);
        }
        public IActionResult SSYAC()
        {
            return View();
        }
        public async Task<IActionResult> SSYACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await SSYListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> SSYDetails(long Id)
        {
            var data = await SSYDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView("SSYACDetails", data);
        }
        public IActionResult JJMAC()
        {
            return View();
        }
        public async Task<IActionResult> JJMACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await JJMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }


        public async Task<IActionResult> JJMACDetails(long Id)
        {
            var data = await JJMDetailIfacade.GetAsync(Id);

            // Check if the data is null or empty
            if (data.Id == 0)
            {
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }

            return PartialView(data);
        }
        public IActionResult OTJJMAC()
        {
            return View();
        }
        public async Task<IActionResult> OTJJMACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await OTJJMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            if (data is null)
            {
                return PartialView(new List<VwOTJJMAlreadyCompletedListModel>());
            }
            return PartialView(new List<VwOTJJMAlreadyCompletedListModel>(data));
        }
        public async Task<IActionResult> OTJJMACDetails(long Id)
        {
            var data = await OTJJMDetailIfacade.GetAsync(Id);
            if (data.Id == 0)
            {
                return new EmptyResult();
            }
            return PartialView(data);
        }
        public IActionResult RVEDDGAC()
        {
            return View();
        }
        public async Task<IActionResult> RVEDDGACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await RVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> RVEDDGACDetails(long Id)
        {
            var data = await RVEDDGDetailIfacade.GetAsync(Id);
            if (data.Id == 0)
            {
                return new EmptyResult();
            }
            return PartialView(data);
        }
        public IActionResult HMAC()
        {
            return View();
        }
        public async Task<IActionResult> HMACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await HMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> HMACDetails(long Id)
        {
            var data = await HMDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView(data);
        }
        public IActionResult MMAC()
        {
            return View();
        }
        public async Task<IActionResult> MMACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await MMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> MMACDetails(long Id)
        {
            var data = await MMDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView(data);
        }
        public IActionResult BiogasAC()
        {
            return View();
        }
        public async Task<IActionResult> BiogasACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await BiogasListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> BiogasACDetails(long Id)
        {
            var data = await BiogasDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }

            return PartialView("BiogasACDetails", data);
        }
        public IActionResult OGPPAC()
        {
            return View();
        }
        public async Task<IActionResult> OGPPACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await OGPPListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> OGPPACDetails(long Id)
        {
            var data = await OGPPDetailIfacade.GetAsync(Id);

            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }

            return PartialView(data);
        }
        public IActionResult CMGGYAC()
        {
            return View();
        }
        public async Task<IActionResult> CMGGYACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await CMGGYListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> CMGGYACDetails(long Id)
        {
            var data = await CMGGYDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }

            return PartialView(data);
        }
        public IActionResult CIAC()
        {
            return View();
        }
        public async Task<IActionResult> CIACList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await CIListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return PartialView(data);
        }
        public async Task<IActionResult> CIACDetails(long Id)
        {
            var data = await CIDetailIfacade.GetAsync(Id);
            // Check if the data is null or empty
            if (data.Id == 0)
            {
                // Return an empty result or status code 204 (No Content)
                return new EmptyResult(); // Alternatively, you can return a custom message or JSON response
            }
            return PartialView(data);
        }

        //---------------------------------------------------------------------------------------------------

        public async Task<IActionResult> DownloadJJMReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetJJMData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("JJM_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                //worksheet.Column(21).Width = 30;
                //worksheet.Column(22).Width = 30;
                //worksheet.Column(23).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(22).Width = 30;
                //worksheet.Column(23).Width = 20;
                //worksheet.Column(24).Width = 20;
                //worksheet.Column(25).Width = 30;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "SI Name";
                worksheet.Cells[1, 9].Value = "SystemName";
                worksheet.Cells[1, 10].Value = "System Working";
                worksheet.Cells[1, 11].Value = "System Working Remark";
                worksheet.Cells[1, 12].Value = "Pump Working Status";
                worksheet.Cells[1, 13].Value = "Controller Working Status";
                worksheet.Cells[1, 14].Value = "System Layout";
                worksheet.Cells[1, 15].Value = "Panel Make";
                worksheet.Cells[1, 16].Value = "Pipeline Working Status";
                worksheet.Cells[1, 17].Value = "OHT Working Status";
                worksheet.Cells[1, 18].Value = "Total Depth (in meters)";
                worksheet.Cells[1, 19].Value = "System Working Duration (in hours)";
                worksheet.Cells[1, 20].Value = "Technical Fault Remark";
                worksheet.Cells[1, 21].Value = "Any Other Remarks";
                //worksheet.Cells[1, 21].Value = "Image With Functionality";
                //worksheet.Cells[1, 22].Value = "Image Mangpatra";
                //worksheet.Cells[1, 23].Value = "Image With Complete System";
                //worksheet.Cells[1, 22].Value = "Geo Tag";
                //worksheet.Cells[1, 23].Value = "Updated By";
                //worksheet.Cells[1, 24].Value = "Updated On";
                worksheet.Cells[1, 22].Value = "InspectionDate";


                using (var range = worksheet.Cells[1, 1, 1, 22])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].UserName;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].SystemName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].IsSystemWorkingRemark;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].IsPumpWorking;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].IsControllerWorking;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].SystemLayout;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].PanelMake;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].IsPipelineWorking;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].IsOHTWorking;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].TotalDepth;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].SystemWorkingDuration;
                    worksheet.Cells[i + 2, 20].Value = modelData[i].TechnicalFaultRemark;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].AnyOtherRemarks;
                    //worksheet.Cells[i + 2, 22].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 23].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 24].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 22].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy_HH:mm");
                    //worksheet.Cells[i + 2, 21].Value = modelData[i].ImageWithFunctionality;
                    //worksheet.Cells[i + 2, 22].Value = modelData[i].ImageMangpatra;
                    //worksheet.Cells[i + 2, 23].Value = modelData[i].ImageWithCompleteSystem;

                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadJJMACListModel>> GetJJMData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadJJMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }
        //-----------------------OTJJM------------------------------

        public async Task<IActionResult> DownloadOTJJMReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetOTJJMData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("OTJJM_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(23).Width = 30;
                worksheet.Column(24).Width = 30;
                worksheet.Column(25).Width = 30;
                worksheet.Column(26).Width = 30;
                worksheet.Column(27).Width = 30;
                worksheet.Column(28).Width = 30;
                worksheet.Column(29).Width = 30;
                worksheet.Column(30).Width = 30;
                worksheet.Column(31).Width = 30;
                worksheet.Column(32).Width = 30;
                worksheet.Column(33).Width = 30;
                worksheet.Column(34).Width = 40;
                worksheet.Column(35).Width = 40;
                //worksheet.Column(36).Width = 30;
                worksheet.Column(36).Width = 30;
                worksheet.Column(37).Width = 30; // Updated By
                worksheet.Column(38).Width = 20; // Updated On
                worksheet.Column(39).Width = 20;
                worksheet.Column(40).Width = 20;
                //worksheet.Column(41).Width = 30;
                //worksheet.Column(42).Width = 20; // InspectionDate
                //worksheet.Column(43).Width = 15;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "SI Name";
                worksheet.Cells[1, 9].Value = "System Working";
                worksheet.Cells[1, 10].Value = "System Working Remark";
                worksheet.Cells[1, 11].Value = "Pump Make";
                worksheet.Cells[1, 12].Value = "Pump Working Status";
                worksheet.Cells[1, 13].Value = "Controller Make";
                worksheet.Cells[1, 14].Value = "Controller Working Status";
                worksheet.Cells[1, 15].Value = "System Layout";
                worksheet.Cells[1, 16].Value = "Panel Make";
                worksheet.Cells[1, 17].Value = "Panel Volt - Each (in volt)";
                worksheet.Cells[1, 18].Value = "Panel Capacity - Each (in watt)";
                worksheet.Cells[1, 19].Value = "Number Of Panel";
                worksheet.Cells[1, 20].Value = "Handpump Working Status";
                worksheet.Cells[1, 21].Value = "Standpost Condition";
                worksheet.Cells[1, 22].Value = "Number Of Defective Modules";
                worksheet.Cells[1, 23].Value = "System Clean";
                worksheet.Cells[1, 24].Value = "Tap Working";
                worksheet.Cells[1, 25].Value = "Water Tank Leaking";
                worksheet.Cells[1, 26].Value = "Tank Lid Present";
                worksheet.Cells[1, 27].Value = "Sensor Working";
                worksheet.Cells[1, 28].Value = "Union Working";
                worksheet.Cells[1, 29].Value = "Nipple Working";
                worksheet.Cells[1, 30].Value = "Socket Working";
                worksheet.Cells[1, 31].Value = "Gate Valve Working";
                worksheet.Cells[1, 32].Value = "Cable Working";
                worksheet.Cells[1, 33].Value = "RopeWire Working";
                worksheet.Cells[1, 34].Value = "Stand Post Correction Needed";
                worksheet.Cells[1, 35].Value = "Last Water Tank Clean Date";
                //worksheet.Cells[1, 36].Value = "Image With Functionality";
                //worksheet.Cells[1, 36].Value = "Geo Tag";
                //worksheet.Cells[1, 37].Value = "Updated By";
                //worksheet.Cells[1, 38].Value = "Updated On";
                worksheet.Cells[1, 36].Value = "Status";
                worksheet.Cells[1, 37].Value = "Assigned Date";
                worksheet.Cells[1, 38].Value = "AssignedTo";
                worksheet.Cells[1, 39].Value = "InspectionDate";
                worksheet.Cells[1, 40].Value = "SIId";

                using (var range = worksheet.Cells[1, 1, 1, 40])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].User;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorkingRemark;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].PumpMake;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].IsPumpWorking;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].ControllerMake;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].IsControllerWorking;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].SystemLayout;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].PanelMake;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].PanelVolt;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].PanelCapacity;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].NumberOfPanel;
                    worksheet.Cells[i + 2, 20].Value = modelData[i].IsHandpumpWorking;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].StandpostCondition;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].DefectiveNumberOfModules;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].IsSystemClean;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].IsTapWorking;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].IsWaterTankLeaking;
                    worksheet.Cells[i + 2, 26].Value = modelData[i].IsTankLidPresent;
                    worksheet.Cells[i + 2, 27].Value = modelData[i].IsSensorWorking;
                    worksheet.Cells[i + 2, 28].Value = modelData[i].IsUnionWorking;
                    worksheet.Cells[i + 2, 29].Value = modelData[i].IsNippleWorking;
                    worksheet.Cells[i + 2, 30].Value = modelData[i].IsSocketWorking;
                    worksheet.Cells[i + 2, 31].Value = modelData[i].IsGateValveWorking;
                    worksheet.Cells[i + 2, 32].Value = modelData[i].IsCableWorking;
                    worksheet.Cells[i + 2, 33].Value = modelData[i].IsRopeWireWorking;
                    worksheet.Cells[i + 2, 34].Value = modelData[i].IsStandPostCorrectionNeeded;
                    worksheet.Cells[i + 2, 35].Value = modelData[i].LastWaterTankCleanDate;
                    //worksheet.Cells[i + 2, 36].Value = modelData[i].ImageWithFunctionality;
                    //worksheet.Cells[i + 2, 36].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 37].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 38].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 36].Value = modelData[i].Status;
                    worksheet.Cells[i + 2, 37].Value = modelData[i].AssignedDate?.ToString("dd-MM-yyyy") ?? "N/A";
                    worksheet.Cells[i + 2, 38].Value = modelData[i].AssignedTo;
                    worksheet.Cells[i + 2, 39].Value = modelData[i].InspectionDate?.ToString("dd-MM-yyyy_HH:mm");
                    worksheet.Cells[i + 2, 40].Value = modelData[i].SIId;

                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadOTJJMACListModel>> GetOTJJMData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadOTJJMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //-----------------------------SSY------------------------
        public async Task<IActionResult> DownloadSSYReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetSSYData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("SSY_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(23).Width = 30;
                worksheet.Column(24).Width = 30;
                worksheet.Column(25).Width = 30;
                worksheet.Column(26).Width = 30;
                worksheet.Column(27).Width = 30;
                worksheet.Column(28).Width = 30;
                worksheet.Column(29).Width = 30;
                worksheet.Column(30).Width = 30;
                worksheet.Column(31).Width = 30;
                worksheet.Column(32).Width = 30;
                //worksheet.Column(33).Width = 30;
                worksheet.Column(33).Width = 30;
                //worksheet.Column(34).Width = 30; 
                //worksheet.Column(35).Width = 20; 
                //worksheet.Column(36).Width = 20; 
                worksheet.Column(34).Width = 20;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Place/Beneficiary Id";
                worksheet.Cells[1, 7].Value = "Place/Beneficiary Name";
                worksheet.Cells[1, 8].Value = "Project Name";
                worksheet.Cells[1, 9].Value = "SI Name";
                worksheet.Cells[1, 10].Value = "System Working";
                worksheet.Cells[1, 11].Value = "System Working Remarks";
                worksheet.Cells[1, 12].Value = "Pump Status";
                worksheet.Cells[1, 13].Value = "Controller Working";
                worksheet.Cells[1, 14].Value = "System Layout";
                worksheet.Cells[1, 15].Value = "Module Working";
                worksheet.Cells[1, 16].Value = "Number Of Modules";
                worksheet.Cells[1, 17].Value = "Module Capacity";
                worksheet.Cells[1, 18].Value = "Structure Status";
                worksheet.Cells[1, 19].Value = "Controller Make";
                worksheet.Cells[1, 20].Value = "Pipeline Status";
                worksheet.Cells[1, 21].Value = "Lighting Arrester";
                worksheet.Cells[1, 22].Value = "Water Leaking";
                worksheet.Cells[1, 23].Value = "Tank Lid Status";
                worksheet.Cells[1, 24].Value = "Sensor Working";
                worksheet.Cells[1, 25].Value = "Union Working";
                worksheet.Cells[1, 26].Value = "Nipple Working";
                worksheet.Cells[1, 27].Value = "Socket Working";
                worksheet.Cells[1, 28].Value = "Gate Valve Working";
                worksheet.Cells[1, 29].Value = "Cable Working";
                worksheet.Cells[1, 30].Value = "Rope Wire Working";
                worksheet.Cells[1, 31].Value = "Stand Post Correction Needed";
                worksheet.Cells[1, 32].Value = "System Clean";
                worksheet.Cells[1, 33].Value = "Last WaterTank Clean Date";
                //worksheet.Cells[1, 33].Value = "System Working Image";
                //worksheet.Cells[1, 34].Value = "Geo Tag";
                //worksheet.Cells[1, 35].Value = "Updated By";
                //worksheet.Cells[1, 36].Value = "Updated On";
                worksheet.Cells[1, 34].Value = "InspectionDate";

                using (var range = worksheet.Cells[1, 1, 1, 34])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].UserName;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].DistrictName;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].BlockName;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].VillageName;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].PlaceOrBeneficiaryId;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].PlaceOrBeneficiaryName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].ProjectName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].IsSystemWorkingRemarks;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].PumpStatus;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].ControllerStatus;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].SystemLayout;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].IsModuleWorking;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].NumberOfModules;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].ModuleCapacity;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].StructureStatus;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].ControllerMake;
                    worksheet.Cells[i + 2, 20].Value = modelData[i].PipelineStatus;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].LightingArrester;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].IsWaterLeaking;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].TankLidStatus;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].IsSensorWorking;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].IsUnionWorking;
                    worksheet.Cells[i + 2, 26].Value = modelData[i].IsNippleWorking;
                    worksheet.Cells[i + 2, 27].Value = modelData[i].IsSocketWorking;
                    worksheet.Cells[i + 2, 28].Value = modelData[i].IsGateValveWorking;
                    worksheet.Cells[i + 2, 29].Value = modelData[i].IsCableWorking;
                    worksheet.Cells[i + 2, 30].Value = modelData[i].IsRopeWireWorking;
                    worksheet.Cells[i + 2, 31].Value = modelData[i].IsStandPostCorrectionNeeded;
                    worksheet.Cells[i + 2, 32].Value = modelData[i].IsSystemClean;
                    worksheet.Cells[i + 2, 33].Value = modelData[i].LastWaterTankCleanDate.ToString("dd-MM-yyyy");
                    //worksheet.Cells[i + 2, 33].Value = modelData[i].SystemWorkingImage;
                    //worksheet.Cells[i + 2, 34].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 35].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 36].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 34].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy_HH:mm");
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                ? $"SSY_{DateTime.Now:dd-MM-yyyy}.xlsx"
                : $"{DateTime.Now:ddMMyyyy}.xlsx";


                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadSSYACListModel>> GetSSYData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadSSYListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //-------------------------------CMGGY---------------
        public async Task<IActionResult> DownloadCMGGYReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetCMGGYData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("CMGGY_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(23).Width = 30;
                worksheet.Column(24).Width = 30;
                worksheet.Column(25).Width = 30;
                worksheet.Column(26).Width = 30;
                worksheet.Column(27).Width = 30;
                //worksheet.Column(28).Width = 30;
                //worksheet.Column(29).Width = 30;
                //worksheet.Column(30).Width = 30;
                //worksheet.Column(31).Width = 30;
                //worksheet.Column(32).Width = 30;
                worksheet.Column(28).Width = 30;
                worksheet.Column(29).Width = 30;
                worksheet.Column(30).Width = 30;
                //worksheet.Column(31).Width = 20; 
                //worksheet.Column(32).Width = 20;
                //worksheet.Column(33).Width = 30;
                //worksheet.Column(34).Width = 30;
                //worksheet.Column(35).Width = 30;
                //worksheet.Column(36).Width = 30;
                //worksheet.Column(37).Width = 30;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "Gram Panchayat";
                worksheet.Cells[1, 9].Value = "Water Source Name";
                worksheet.Cells[1, 10].Value = "Number of Pond";
                worksheet.Cells[1, 11].Value = "Surface Capacity (in HP)";
                worksheet.Cells[1, 12].Value = "Surface Capacity (in number)";
                worksheet.Cells[1, 13].Value = "Pump Status";
                worksheet.Cells[1, 14].Value = "Number of Working Pump";
                worksheet.Cells[1, 15].Value = "Number of Non Working Pump";
                worksheet.Cells[1, 16].Value = "Controller Status";
                worksheet.Cells[1, 17].Value = "Number of Working Controller";
                worksheet.Cells[1, 18].Value = "Number of Non Working Controller";
                worksheet.Cells[1, 19].Value = "Solar Module";
                worksheet.Cells[1, 20].Value = "Lightning Arrester & Earthing Status";
                worksheet.Cells[1, 21].Value = "Pipe Line Length(in meter)";
                worksheet.Cells[1, 22].Value = "PipeLine Status Remark";
                worksheet.Cells[1, 23].Value = "Safety Fencing Length";
                worksheet.Cells[1, 24].Value = "Fencing & Gate Status Remark";
                worksheet.Cells[1, 25].Value = "Control Room & Pump Status Remark";
                worksheet.Cells[1, 26].Value = "System Working";
                worksheet.Cells[1, 27].Value = "Other Remark";
                //worksheet.Cells[1, 28].Value = "Solar Pump Image";
                //worksheet.Cells[1, 29].Value = "Control Room Image";
                //worksheet.Cells[1, 30].Value = "Solar Panel Image";
                //worksheet.Cells[1, 31].Value = "Fencing Image";
                //worksheet.Cells[1, 32].Value = "Pipe Out let Image";
                //worksheet.Cells[1, 28].Value = "CreatedBy";
                //worksheet.Cells[1, 29].Value = "CreatedOn";
                //worksheet.Cells[1, 30].Value = "Geo Tag";
                //worksheet.Cells[1, 31].Value = "Updated By";
                //worksheet.Cells[1, 32].Value = "Updated On";
                worksheet.Cells[1, 28].Value = "Status";
                //worksheet.Cells[1, 34].Value = "Assigned Date";
                worksheet.Cells[1, 29].Value = "AssignedTo";
                worksheet.Cells[1, 30].Value = "InspectionDate";
                //worksheet.Cells[1, 37].Value = "SIId";

                using (var range = worksheet.Cells[1, 1, 1, 30])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].User;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].GramPanchayatName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].WaterSourceName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].PondCount;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].SurfaceCapacityinHP;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].SurfaceCapacityCount;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].PumpStatus;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].WorkingPumpCount;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].NonWorkingPumpCount;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].ControllerStatus;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].WorkingControllerCount;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].NonWorkingControllerCount;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].SolarModule;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].LightningArresterStatus;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].PipelineLength;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].PipeLineStatusRemark;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].SafetyFencingLength;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].FencingAndGateStatusRemark;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].ControlRoomandPumpStatusComment;
                    worksheet.Cells[i + 2, 26].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 27].Value = modelData[i].OtherRemark;
                    //worksheet.Cells[i + 2, 28].Value = modelData[i].SolarPumpImage;
                    //worksheet.Cells[i + 2, 29].Value = modelData[i].ControlRoomImage;
                    //worksheet.Cells[i + 2, 30].Value = modelData[i].SolarPanelImage;
                    //worksheet.Cells[i + 2, 31].Value = modelData[i].FencingImage;
                    //worksheet.Cells[i + 2, 32].Value = modelData[i].PipeOutletImage;
                    //worksheet.Cells[i + 2, 28].Value = modelData[i].CreatedBy;
                    //worksheet.Cells[i + 2, 29].Value = modelData[i].CreatedOn.ToString("dd-MM-yyyy");
                    //worksheet.Cells[i + 2, 30].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 31].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 32].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 28].Value = modelData[i].Status;
                    //worksheet.Cells[i + 2, 34].Value = modelData[i].AssignedDate.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 29].Value = modelData[i].AssignedTo;
                    worksheet.Cells[i + 2, 30].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy_HH:mm");
                    //worksheet.Cells[i + 2, 31].Value = modelData[i].SIId;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadCMGGYACListModel>> GetCMGGYData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadCMGGYListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //--------------------------CIAC------------------

        public async Task<IActionResult> DownloadCIReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetCIData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("CI_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(23).Width = 30;
                worksheet.Column(24).Width = 30;
                worksheet.Column(25).Width = 30;
                worksheet.Column(26).Width = 30;
                worksheet.Column(27).Width = 30;
                //worksheet.Column(28).Width = 30;
                //worksheet.Column(29).Width = 30;
                //worksheet.Column(30).Width = 30;
                //worksheet.Column(31).Width = 30;
                //worksheet.Column(32).Width = 30;
                worksheet.Column(28).Width = 30;
                worksheet.Column(29).Width = 30;
                worksheet.Column(30).Width = 30;
                //worksheet.Column(31).Width = 20; 
                //worksheet.Column(32).Width = 20;
                //worksheet.Column(33).Width = 30;
                //worksheet.Column(34).Width = 30;
                //worksheet.Column(35).Width = 30;
                //worksheet.Column(36).Width = 30;
                //worksheet.Column(37).Width = 30;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "Gram Panchayat";
                worksheet.Cells[1, 9].Value = "Water Source Name";
                worksheet.Cells[1, 10].Value = "Project Area";
                worksheet.Cells[1, 11].Value = "Solar Pump Capacity (in HP)";
                worksheet.Cells[1, 12].Value = "Solar Pump Count";
                worksheet.Cells[1, 13].Value = "Pump Status";
                worksheet.Cells[1, 14].Value = "Number of Working Pump";
                worksheet.Cells[1, 15].Value = "Number of Non Working Pump";
                worksheet.Cells[1, 16].Value = "Controller Status";
                worksheet.Cells[1, 17].Value = "Number of Working Controller";
                worksheet.Cells[1, 18].Value = "Number of Non Working Controller";
                worksheet.Cells[1, 19].Value = "Solar Module";
                worksheet.Cells[1, 20].Value = "Lighting Arrester & Earthing";
                worksheet.Cells[1, 21].Value = "Pipeline Length";
                worksheet.Cells[1, 22].Value = "PipeLine Status Remark";
                worksheet.Cells[1, 23].Value = "Safety Fencing Length";
                worksheet.Cells[1, 24].Value = "Fencing & Gate Status Remark";
                worksheet.Cells[1, 25].Value = "Number of Farmer ";
                worksheet.Cells[1, 26].Value = "System Working";
                worksheet.Cells[1, 27].Value = "Other Remark";
                //worksheet.Cells[1, 28].Value = "Solar Pump Image";
                //worksheet.Cells[1, 29].Value = "Control Room Image";
                //worksheet.Cells[1, 30].Value = "Solar Panel Image";
                //worksheet.Cells[1, 31].Value = "Fencing Image";
                //worksheet.Cells[1, 32].Value = "Pipe Out let Image";
                //worksheet.Cells[1, 28].Value = "CreatedBy";
                //worksheet.Cells[1, 29].Value = "CreatedOn";
                //worksheet.Cells[1, 30].Value = "Geo Tag";
                //worksheet.Cells[1, 31].Value = "Updated By";
                //worksheet.Cells[1, 32].Value = "Updated On";
                worksheet.Cells[1, 28].Value = "Status";
                //worksheet.Cells[1, 34].Value = "Assigned Date";
                worksheet.Cells[1, 29].Value = "AssignedTo";
                worksheet.Cells[1, 30].Value = "InspectionDate";
                //worksheet.Cells[1, 37].Value = "SIId";

                using (var range = worksheet.Cells[1, 1, 1, 30])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].User;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].GramPanchayat;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].WaterSourceName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].ProjectArea;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].SolarPumpCapacityinHP;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].SolarPumpCount;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].PumpStatus;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].WorkingPumpCount;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].NonWorkingPumpCount;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].ControllerStatus;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].WorkingControllerCount;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].NonWorkingControllerCount;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].SolarModule;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].LightningArresterStatus;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].PipelineLength;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].PipeLineStatusRemark;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].SafetyFencingLength;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].FencingAndGateStatusRemark;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].FarmerCount;
                    worksheet.Cells[i + 2, 26].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 27].Value = modelData[i].OtherRemark;
                    //worksheet.Cells[i + 2, 28].Value = modelData[i].SolarPumpImage;
                    //worksheet.Cells[i + 2, 29].Value = modelData[i].ControlRoomImage;
                    //worksheet.Cells[i + 2, 30].Value = modelData[i].SolarPanelImage;
                    //worksheet.Cells[i + 2, 31].Value = modelData[i].FencingImage;
                    //worksheet.Cells[i + 2, 32].Value = modelData[i].PipeOutletImage;
                    //worksheet.Cells[i + 2, 28].Value = modelData[i].CreatedBy;
                    //worksheet.Cells[i + 2, 29].Value = modelData[i].CreatedOn.ToString("dd-MM-yyyy");
                    //worksheet.Cells[i + 2, 30].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 31].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 32].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 28].Value = modelData[i].Status;
                    //worksheet.Cells[i + 2, 34].Value = modelData[i].AssignedDate.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 29].Value = modelData[i].AssignedTo;
                    worksheet.Cells[i + 2, 30].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy_HH:mm");
                    //worksheet.Cells[i + 2, 37].Value = modelData[i].SIId;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadCIACListModel>> GetCIData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadCIListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //-----------------------RVEDDG--------------------
        public async Task<IActionResult> DownloadRVEDDGReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetRVEDDGData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("RVEDDG_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(23).Width = 30;
                worksheet.Column(24).Width = 30;
                worksheet.Column(25).Width = 30;
                worksheet.Column(26).Width = 30;
                worksheet.Column(27).Width = 30;
                worksheet.Column(28).Width = 30;
                worksheet.Column(29).Width = 30;
                worksheet.Column(30).Width = 30;
                worksheet.Column(31).Width = 30;
                worksheet.Column(32).Width = 30;
                worksheet.Column(33).Width = 30;
                worksheet.Column(34).Width = 30; // GeoTag
                worksheet.Column(35).Width = 30; // Updated By
                worksheet.Column(36).Width = 20; // Updated On
                worksheet.Column(37).Width = 20;
                worksheet.Column(38).Width = 30;
                worksheet.Column(39).Width = 30;
                worksheet.Column(40).Width = 30;
                worksheet.Column(41).Width = 30;
                worksheet.Column(42).Width = 30;
                worksheet.Column(43).Width = 30;
                worksheet.Column(44).Width = 30;
                worksheet.Column(45).Width = 30;
                worksheet.Column(46).Width = 30;
                worksheet.Column(47).Width = 30;
                worksheet.Column(48).Width = 30;
                worksheet.Column(49).Width = 30;
                worksheet.Column(50).Width = 30;
                worksheet.Column(51).Width = 30;
                worksheet.Column(52).Width = 30;
                worksheet.Column(53).Width = 30;
                worksheet.Column(54).Width = 30;
                worksheet.Column(55).Width = 30;
                worksheet.Column(56).Width = 30;
                worksheet.Column(57).Width = 30;
                //worksheet.Column(58).Width = 30;
                //worksheet.Column(59).Width = 30;
                //worksheet.Column(60).Width = 30;
                //worksheet.Column(61).Width = 30;
                //worksheet.Column(62).Width = 30;
                //worksheet.Column(63).Width = 30;
                //worksheet.Column(64).Width = 30;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspected By";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "SI Name";
                worksheet.Cells[1, 9].Value = "System Name";
                worksheet.Cells[1, 10].Value = "System Working";
                worksheet.Cells[1, 11].Value = "Monthly Working Days";
                worksheet.Cells[1, 12].Value = "Number Of Batteries";
                worksheet.Cells[1, 13].Value = "BatteryAH";
                worksheet.Cells[1, 14].Value = "Battery Rated Voltage";
                worksheet.Cells[1, 15].Value = "Measured Battery Bank Voltage";
                worksheet.Cells[1, 16].Value = "Last Date of Distilled Water in System";
                worksheet.Cells[1, 17].Value = "Number Of Established Solar Panel";
                worksheet.Cells[1, 18].Value = "Solar Panel Capacity";
                worksheet.Cells[1, 19].Value = "Total Array";
                worksheet.Cells[1, 20].Value = "Voltage Array-1";
                worksheet.Cells[1, 21].Value = "Voltage Array-2";
                worksheet.Cells[1, 22].Value = "Voltage Array-3";
                worksheet.Cells[1, 23].Value = "Voltage Array-4";
                worksheet.Cells[1, 24].Value = "Voltage Array-5";
                worksheet.Cells[1, 25].Value = "Voltage Array-6";
                worksheet.Cells[1, 26].Value = "Voltage Array-7";
                worksheet.Cells[1, 27].Value = "Voltage Array-8";
                worksheet.Cells[1, 28].Value = "Voltage Array-9";
                worksheet.Cells[1, 29].Value = "Voltage Array-10";
                worksheet.Cells[1, 30].Value = "Current Array-1";
                worksheet.Cells[1, 31].Value = "Current Array-2";
                worksheet.Cells[1, 32].Value = "Current Array-3";
                worksheet.Cells[1, 33].Value = "Current Array-4";
                worksheet.Cells[1, 34].Value = "Current Array-5";
                worksheet.Cells[1, 35].Value = "Current Array-6";
                worksheet.Cells[1, 36].Value = "Current Array-7";
                worksheet.Cells[1, 37].Value = "Current Array-8";
                worksheet.Cells[1, 38].Value = "Current Array-9";
                worksheet.Cells[1, 39].Value = "Current Array-10";
                worksheet.Cells[1, 40].Value = "Total Voltage";
                worksheet.Cells[1, 41].Value = "Total Current";
                worksheet.Cells[1, 42].Value = "Energy Meter Reading";
                worksheet.Cells[1, 43].Value = "AH Charging Meter Reading";
                worksheet.Cells[1, 44].Value = "Ah Discharging Meter Reading";
                worksheet.Cells[1, 45].Value = "Number Of Poles";
                worksheet.Cells[1, 46].Value = "Number Of Family Members With System";
                worksheet.Cells[1, 47].Value = "Number Of System Working Connection";
                worksheet.Cells[1, 48].Value = "Number Of Established Street Light";
                worksheet.Cells[1, 49].Value = "System Working Hours";
                worksheet.Cells[1, 50].Value = "Number Of Working Street Lights";
                worksheet.Cells[1, 51].Value = "System Working Remarks";
                worksheet.Cells[1, 52].Value = "Number Of Defective Batteries";
                worksheet.Cells[1, 53].Value = "Number Of Defective Module";
                worksheet.Cells[1, 54].Value = "Invertor Working";
                worksheet.Cells[1, 55].Value = "PDN Status Remark";
                worksheet.Cells[1, 56].Value = "Any Other Remark";
                //worksheet.Cells[1, 57].Value = "GeoTag";
                //worksheet.Cells[1, 58].Value = "Update By";
                //worksheet.Cells[1, 59].Value = "Update On";
                //worksheet.Cells[1, 60].Value = "Status";
                //worksheet.Cells[1, 61].Value = "Assigned Date";
                //worksheet.Cells[1, 62].Value = "Assigned To";
                worksheet.Cells[1, 57].Value = "InspectionDate";
                //worksheet.Cells[1, 64].Value = "SI ID";


                using (var range = worksheet.Cells[1, 1, 1, 57])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].User;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].SystemName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].MonthlyWorkingDays;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].NumberOfBattery;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].BatteryAH;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].BatteryRatedVoltage;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].MeasuredBatteryBankVoltage;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].LastDateSystemDistilledWater?.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 17].Value = modelData[i].NumberOfEstablishedSolarPanel;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].SolarPanelCapacity;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].TotalArray;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].VoltageArray1;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].VoltageArray2;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].VoltageArray3;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].VoltageArray4;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].VoltageArray5;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].VoltageArray6;
                    worksheet.Cells[i + 2, 26].Value = modelData[i].VoltageArray7;
                    worksheet.Cells[i + 2, 27].Value = modelData[i].VoltageArray8;
                    worksheet.Cells[i + 2, 28].Value = modelData[i].VoltageArray9;
                    worksheet.Cells[i + 2, 29].Value = modelData[i].VoltageArray10;
                    worksheet.Cells[i + 2, 30].Value = modelData[i].CurrentArray1;
                    worksheet.Cells[i + 2, 31].Value = modelData[i].CurrentArray2;
                    worksheet.Cells[i + 2, 32].Value = modelData[i].CurrentArray3;
                    worksheet.Cells[i + 2, 33].Value = modelData[i].CurrentArray4;
                    worksheet.Cells[i + 2, 34].Value = modelData[i].CurrentArray5;
                    worksheet.Cells[i + 2, 35].Value = modelData[i].CurrentArray6;
                    worksheet.Cells[i + 2, 36].Value = modelData[i].CurrentArray7;
                    worksheet.Cells[i + 2, 37].Value = modelData[i].CurrentArray8;
                    worksheet.Cells[i + 2, 38].Value = modelData[i].CurrentArray9;
                    worksheet.Cells[i + 2, 39].Value = modelData[i].CurrentArray10;
                    worksheet.Cells[i + 2, 40].Value = modelData[i].TotalVoltage;
                    worksheet.Cells[i + 2, 41].Value = modelData[i].TotalCurrent;
                    worksheet.Cells[i + 2, 42].Value = modelData[i].EnergyMeterReading;
                    worksheet.Cells[i + 2, 43].Value = modelData[i].AHChargingMeterReading;
                    worksheet.Cells[i + 2, 44].Value = modelData[i].AhDischargingMeterReading;
                    worksheet.Cells[i + 2, 45].Value = modelData[i].NumberOfPoles;
                    worksheet.Cells[i + 2, 46].Value = modelData[i].NumberOfFamilyMembersWithSystem;
                    worksheet.Cells[i + 2, 47].Value = modelData[i].NumberOfSystemWorkingConnection;
                    worksheet.Cells[i + 2, 48].Value = modelData[i].NumberOfEstablishedStreetLight;
                    worksheet.Cells[i + 2, 49].Value = modelData[i].SystemWorkingHours;
                    worksheet.Cells[i + 2, 50].Value = modelData[i].NumberOfWorkingStreetLights;
                    worksheet.Cells[i + 2, 51].Value = modelData[i].IsSystemWorkingRemarks;
                    worksheet.Cells[i + 2, 52].Value = modelData[i].NumberOfDefectiveBattery;
                    worksheet.Cells[i + 2, 53].Value = modelData[i].NumberOfDefectiveModule;
                    worksheet.Cells[i + 2, 54].Value = modelData[i].IsInvertorWorking;
                    worksheet.Cells[i + 2, 55].Value = modelData[i].PDNStatusRemark;
                    worksheet.Cells[i + 2, 56].Value = modelData[i].AnyOtherRemark;
                    //worksheet.Cells[i + 2, 57].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 58].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 59].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    //worksheet.Cells[i + 2, 60].Value = modelData[i].Status;
                    //worksheet.Cells[i + 2, 61].Value = modelData[i].AssignedDate?.ToString("dd-MM-yyyy");
                    //worksheet.Cells[i + 2, 62].Value = modelData[i].AssignedTo;
                    worksheet.Cells[i + 2, 57].Value = modelData[i].InspectionDate?.ToString("dd-MM-yyyy_HH:mm");
                    //worksheet.Cells[i + 2, 64].Value = modelData[i].SIId;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadRVEDDGACListModel>> GetRVEDDGData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            //var data = await RVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            var data = await DownloadRVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }
        //--------------------------OTRVEDDG------------------------
        public async Task<IActionResult> DownloadOTRVEDDGReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetOTRVEDDGData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("OTRVEDDG_Report");

                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 30;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 30;
                worksheet.Column(11).Width = 30;
                worksheet.Column(12).Width = 30;
                worksheet.Column(13).Width = 30;
                worksheet.Column(14).Width = 30;
                worksheet.Column(15).Width = 30;
                worksheet.Column(16).Width = 30;
                worksheet.Column(17).Width = 30;
                worksheet.Column(18).Width = 30;
                worksheet.Column(19).Width = 30;
                worksheet.Column(20).Width = 30;
                worksheet.Column(21).Width = 30;
                worksheet.Column(21).Width = 30;
                //worksheet.Column(22).Width = 30;
                //worksheet.Column(23).Width = 30;
                //worksheet.Column(24).Width = 30;
                //worksheet.Column(25).Width = 30;
                //worksheet.Column(22).Width = 20;
                //worksheet.Column(23).Width = 20;
                worksheet.Column(22).Width = 30;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "User Name";
                worksheet.Cells[1, 3].Value = "District";
                worksheet.Cells[1, 4].Value = "Block";
                worksheet.Cells[1, 5].Value = "Village";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Project Name";
                worksheet.Cells[1, 8].Value = "SI Name";
                worksheet.Cells[1, 9].Value = "System Working";
                worksheet.Cells[1, 10].Value = "System Working Remark";
                worksheet.Cells[1, 11].Value = "Meter Reading";
                worksheet.Cells[1, 12].Value = "Invertor Working";
                worksheet.Cells[1, 13].Value = "AH Charging Meter Reading";
                worksheet.Cells[1, 14].Value = "AH  DisChargingMeter Reading";
                worksheet.Cells[1, 15].Value = "Number Of Batteries";
                worksheet.Cells[1, 16].Value = "Battery AH";
                worksheet.Cells[1, 17].Value = "Battery Rated Voltage";
                worksheet.Cells[1, 18].Value = "Total Voltage";
                worksheet.Cells[1, 19].Value = "Total Current";
                worksheet.Cells[1, 20].Value = "Number Of Defective Battery";
                worksheet.Cells[1, 21].Value = "Number Of Defective Module";
                //worksheet.Cells[1, 22].Value = "System Working Image Base64";
                //worksheet.Cells[1, 23].Value = "System Working Image GeoTag";
                //worksheet.Cells[1, 24].Value = "System Maintanence Image Base64";
                //worksheet.Cells[1, 25].Value = "System Maintanence Image GeoTag";
                //worksheet.Cells[1, 22].Value = "Updated By";
                //worksheet.Cells[1, 23].Value = "Updated On";
                worksheet.Cells[1, 22].Value = "InspectionDate";

                using (var range = worksheet.Cells[1, 1, 1, 22])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].UserName;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].DistrictName;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].BlockName;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].VillageName;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].SiteName;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].ProjectName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].IsSystemWorking;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorkingRemarks;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].MeterReading;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].IsInvertorWorking;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].AHChargingMeterReading;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].AHDisChargingMeterReading;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].NumberOfBatteries;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].BatteryAH;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].BatteryRatedVoltage;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].TotalVoltage;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].TotalCurrent;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].NumberOfDefectiveBattery;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].NumberOfDefectiveModule;
                    //worksheet.Cells[i + 2, 22].Value = modelData[i].SystemWorkingImageBase64;
                    //worksheet.Cells[i + 2, 23].Value = modelData[i].SystemWorkingImageGeoTag;
                    //worksheet.Cells[i + 2, 24].Value = modelData[i].SystemMaintanenceImageBase64;
                    //worksheet.Cells[i + 2, 25].Value = modelData[i].SystemMaintanenceImageGeoTag;
                    //worksheet.Cells[i + 2, 22].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 23].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 22].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy_HH:mm");
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.ProjectName}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadOTRVEDDGACListModel>> GetOTRVEDDGData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            //var data = await OTRVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            var data = await DownloadOTRVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //--------------------------On Grid Power Plant OGPP------------------------
        public async Task<IActionResult> DownloadOGPPReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetOGPPData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("OGPP_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 30;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                worksheet.Column(12).Width = 20;
                worksheet.Column(13).Width = 20;
                worksheet.Column(14).Width = 20;
                worksheet.Column(15).Width = 20;
                worksheet.Column(16).Width = 20;
                worksheet.Column(17).Width = 20;
                worksheet.Column(18).Width = 20;
                worksheet.Column(19).Width = 20;
                worksheet.Column(20).Width = 20;
                worksheet.Column(21).Width = 20;
                worksheet.Column(22).Width = 20;
                worksheet.Column(23).Width = 20;
                worksheet.Column(24).Width = 20;
                worksheet.Column(25).Width = 20;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "Inspection By";
                worksheet.Cells[1, 3].Value = "Inspection Date";
                worksheet.Cells[1, 4].Value = "District";
                worksheet.Cells[1, 5].Value = "Block";
                worksheet.Cells[1, 6].Value = "Village";
                worksheet.Cells[1, 7].Value = "Site Name";
                worksheet.Cells[1, 8].Value = "Project Name";
                worksheet.Cells[1, 9].Value = "SI Name";

                worksheet.Cells[1, 10].Value = "System Working Status";
                worksheet.Cells[1, 11].Value = "System Working Remark";
                worksheet.Cells[1, 12].Value = "Meter Reading";
                worksheet.Cells[1, 13].Value = "Invertor Count";
                worksheet.Cells[1, 14].Value = "Fault Invertor Count";
                worksheet.Cells[1, 15].Value = "Solar Module Count";
                worksheet.Cells[1, 16].Value = "Solar Module Capacity";
                worksheet.Cells[1, 17].Value = "Fault Solar Module Count";
                worksheet.Cells[1, 18].Value = "DC Combiner Box Status";
                worksheet.Cells[1, 19].Value = "AC Combiner Box Status";
                worksheet.Cells[1, 20].Value = "Earthing Status";
                worksheet.Cells[1, 21].Value = "LA Status";
                worksheet.Cells[1, 22].Value = "RMS Installation Status";
                worksheet.Cells[1, 23].Value = "RMS Working Status";
                worksheet.Cells[1, 24].Value = "RMS Fault Remark";
                worksheet.Cells[1, 25].Value = "Geo Tag";



                using (var range = worksheet.Cells[1, 1, 1, 25])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].UpdatedBy;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].InspectionDate.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 4].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsSystemWorking;

                    worksheet.Cells[i + 2, 11].Value = modelData[i].IsSystemWorkingRemarks;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].MeterReading;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].InvertorCount;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].FaultInvertorCount;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].SolarModuleCount;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].SolarmoduleCapacity;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].FaultSolarModuleCount;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].DCCombinerBoxStatus;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].ACCombinerBoxStatus;
                    worksheet.Cells[i + 2, 20].Value = modelData[i].EarthingStatus;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].LAStatus;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].RMSInstallationStatus;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].RMSWorkingStatus;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].RMSFaultRemark;
                    worksheet.Cells[i + 2, 25].Value = modelData[i].SystemWorkingImageGeoTag;


                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadOGPPACListModel>> GetOGPPData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            //var data = await OTRVEDDGListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            var data = await DownloadOGPPListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //------------------------HM--------------------

        public async Task<IActionResult> DownloadHMReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetHMData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("HM_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 30;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                worksheet.Column(12).Width = 20;
                worksheet.Column(13).Width = 20;
                //worksheet.Column(14).Width = 20;
                worksheet.Column(15).Width = 20;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "District";
                worksheet.Cells[1, 3].Value = "Block";
                worksheet.Cells[1, 4].Value = "Village";
                worksheet.Cells[1, 5].Value = "Site Name";
                worksheet.Cells[1, 6].Value = "Project Name";
                worksheet.Cells[1, 7].Value = "SI Name";

                worksheet.Cells[1, 8].Value = "Number of Working Lights";
                worksheet.Cells[1, 9].Value = "Number 0f Not Working Lights";
                worksheet.Cells[1, 10].Value = "Rope Wire Status";
                worksheet.Cells[1, 11].Value = "Working Hour";
                worksheet.Cells[1, 12].Value = "Geo Tag";
                worksheet.Cells[1, 13].Value = "System Working";
                //worksheet.Cells[1, 14].Value = "Updated By";
                worksheet.Cells[1, 15].Value = "Inspection Date";

                using (var range = worksheet.Cells[1, 1, 1, 15])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].NumberOfWorkingLights;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].NumberOfNotWorkingLights;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].RopeWireStatus;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].SystemWorkingHours;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].ImageGeoTag;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].IsSystemWorking;
                    //worksheet.Cells[i + 2, 14].Value = modelData[i].UpdatedBy;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy");

                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadHMACListModel>> GetHMData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadHMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //----------------------MM--------------------
        public async Task<IActionResult> DownloadMMReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetMMData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("MM_Report");

                // Set column widths for better visibility
                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                //worksheet.Column(12).Width = 20;
                //worksheet.Column(13).Width = 20;
                //worksheet.Column(14).Width = 20;

                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "District";
                worksheet.Cells[1, 3].Value = "Block";
                worksheet.Cells[1, 4].Value = "Village";
                worksheet.Cells[1, 5].Value = "Site";
                worksheet.Cells[1, 6].Value = "Project ";
                worksheet.Cells[1, 7].Value = "SI Name";
                worksheet.Cells[1, 8].Value = "Number of Working Lights";
                worksheet.Cells[1, 9].Value = "Number of Non Working Lights";
                worksheet.Cells[1, 10].Value = "Working Hour";
                //worksheet.Cells[1, 11].Value = "Geo Tag";
                //worksheet.Cells[1, 12].Value = "System Working";
                //worksheet.Cells[1, 13].Value = "Updated By";
                worksheet.Cells[1, 11].Value = "Inspection Date";

                using (var range = worksheet.Cells[1, 1, 1, 11])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].NumberOfWorkingLights;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].NumberOfNotWorkingLights;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].SystemWorkingHours;
                    //worksheet.Cells[i + 2, 11].Value = modelData[i].ImageGeoTag;
                    //worksheet.Cells[i + 2, 12].Value = modelData[i].IsSystemWorking;
                    //worksheet.Cells[i + 2, 13].Value = modelData[i].UpdatedBy;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy");
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:ddMMyyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadMMACListModel>> GetMMData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadMMListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //------------------------Biogas---------------------------------
        public async Task<IActionResult> DownloadBiogasReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetBIOGASData(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Biogas_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                worksheet.Column(12).Width = 20;
                worksheet.Column(13).Width = 20;
                worksheet.Column(14).Width = 20;
                worksheet.Column(15).Width = 20;
                worksheet.Column(16).Width = 20;
                worksheet.Column(17).Width = 20;
                worksheet.Column(18).Width = 20;
                worksheet.Column(19).Width = 20;
                //worksheet.Column(20).Width = 20;
                //worksheet.Column(21).Width = 20;
                //worksheet.Column(22).Width = 20;



                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "District";
                worksheet.Cells[1, 3].Value = "Block";
                worksheet.Cells[1, 4].Value = "Village";
                worksheet.Cells[1, 5].Value = "Site";
                worksheet.Cells[1, 6].Value = "Project";

                worksheet.Cells[1, 7].Value = "Gram Name";
                worksheet.Cells[1, 8].Value = "Gram Panchayat";
                worksheet.Cells[1, 9].Value = "Beneficiary Name";
                worksheet.Cells[1, 10].Value = "Installation Year";
                worksheet.Cells[1, 11].Value = "Meshan Name";
                worksheet.Cells[1, 12].Value = "SEW Name";
                worksheet.Cells[1, 13].Value = "Beneficiary Class";
                worksheet.Cells[1, 14].Value = "Biogas Capacity";
                worksheet.Cells[1, 15].Value = "Construction Material";
                worksheet.Cells[1, 16].Value = "Construction Status";
                worksheet.Cells[1, 17].Value = "Extra Construction Material";


                worksheet.Cells[1, 18].Value = "Is System Working";
                //worksheet.Cells[1, 19].Value = "Geo Tag";
                //worksheet.Cells[1, 20].Value = "Remark";
                //worksheet.Cells[1, 21].Value = "Updated By";
                worksheet.Cells[1, 19].Value = "Updated On";

                using (var range = worksheet.Cells[1, 1, 1, 19])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].District;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].Block;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].Village;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].Site;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].Project;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].GramName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].GramPanchayatName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].BeneficiaryName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].BiogasInstallationYear;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].BiogasMeshanName;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].BiogasSEWName;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].BeneficiaryClass;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].DinbandhuBiogasCapacity;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].ConstructionMaterial;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].SystemConstructionStatus;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].ExtraConstructionMaterial;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].IsSystemWorking;
                    //worksheet.Cells[i + 2, 19].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 20].Value = modelData[i].Remarks;
                    //worksheet.Cells[i + 2, 21].Value = modelData[i].UpdatedBy;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].InspectionDate.ToString("dd-MM-yyyy");
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{firstItem.Project}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:dd/MM/yyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadBioGasListModel>> GetBIOGASData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadBioGasListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        //------------------Inspection In Progress --------------------------
        public async Task<IActionResult> DownloadInspectionIPReport(long DistrictId, long BlockId, long VillageId, long ProjectId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var modelData = await GetInspectionIPDataDownload(DistrictId, BlockId, VillageId, ProjectId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 20;
                //worksheet.Column(11).Width = 20;
                //worksheet.Column(12).Width = 20;
                //worksheet.Column(13).Width = 20;




                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "District";
                worksheet.Cells[1, 3].Value = "Block";
                worksheet.Cells[1, 4].Value = "Village";
                worksheet.Cells[1, 5].Value = "Site";
                worksheet.Cells[1, 6].Value = "Project";

                worksheet.Cells[1, 7].Value = "Stage";
                worksheet.Cells[1, 8].Value = "Completed";
                worksheet.Cells[1, 9].Value = "Faulty";
                worksheet.Cells[1, 10].Value = "Remarks";
                //worksheet.Cells[1, 11].Value = "Geo Tag";
                //worksheet.Cells[1, 12].Value = "Updated By";
                //worksheet.Cells[1, 13].Value = "Updated On";


                using (var range = worksheet.Cells[1, 1, 1, 10])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].DistrictName;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].BlockName;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].VillageName;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].SiteName;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].ProjectName;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].StageName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].IsComplete;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].IsFaulty;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].Remarks;
                    //worksheet.Cells[i + 2, 11].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 12].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 13].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy"); 

                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{"Inspection_In_Progress"}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:dd/MM/yyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
        private async Task<List<DownloadInspectionIPListModel>> GetInspectionIPDataDownload(long DistrictId, long BlockId, long VillageId, long ProjectId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            long SIId = ProjectId;

            var data = await DownloadIPListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }


        //------------------Inspection SSY In Progress --------------------------
        public async Task<IActionResult> DownloadSSYInspectionIPReport(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetSSYInspectionIPDataDownload(DistrictId, BlockId, VillageId, SIId, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("SSYIP_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                worksheet.Column(12).Width = 20;
                //worksheet.Column(13).Width = 20;
                //worksheet.Column(14).Width = 20;
                //worksheet.Column(15).Width = 20;

                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Inspection Id";
                worksheet.Cells[1, 2].Value = "District";
                worksheet.Cells[1, 3].Value = "Block";
                worksheet.Cells[1, 4].Value = "Village";
                worksheet.Cells[1, 5].Value = "Project";

                worksheet.Cells[1, 6].Value = "Phase";
                worksheet.Cells[1, 7].Value = "Place or Beneficiary Name";
                worksheet.Cells[1, 8].Value = "Place or Beneficiary Id";
                worksheet.Cells[1, 9].Value = "Stage";
                worksheet.Cells[1, 10].Value = "Completed";
                worksheet.Cells[1, 11].Value = "Faulty";
                worksheet.Cells[1, 12].Value = "Remarks";
                //worksheet.Cells[1, 13].Value = "Geo Tag";
                //worksheet.Cells[1, 14].Value = "Updated By";
                //worksheet.Cells[1, 15].Value = "Updated On";


                using (var range = worksheet.Cells[1, 1, 1, 12])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].DistrictName;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].BlockName;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].VillageName;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].ProjectName;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].PhaseName;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].PlaceorBeneficiaryName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].PlaceorBeneficiaryId;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].StageName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].IsComplete;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].IsFaulty;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].Remarks;
                    //worksheet.Cells[i + 2, 13].Value = modelData[i].GeoTag;
                    //worksheet.Cells[i + 2, 14].Value = modelData[i].UpdatedBy;
                    //worksheet.Cells[i + 2, 15].Value = modelData[i].UpdatedOn.ToString("dd-MM-yyyy"); ;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"{"SSY_Inspection_In_Progress"}_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:dd/MM/yyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
        private async Task<List<DownloadSSYInspectionIPListModel>> GetSSYInspectionIPDataDownload(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadSSYIPListIfacade.GetList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus);
            return data;
        }

        public async Task<IActionResult> DownloadJJMPdf(long id)
        {
            var model = await JJMDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"JJM_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("JJMReportPdf", model)
            {
                FileName = fileName
            };
        }


        public async Task<IActionResult> DownloadOTJJMPdf(long id)
        {
            var model = await OTJJMDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Other_than_JJM_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("OTJJMReportPdf", model)
            {
                FileName = fileName
            };
        }


        public async Task<IActionResult> DownloadHMPdf(long id)
        {
            var model = await HMDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"High_Mast_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("HMACReportPdf", model)
            {
                FileName = fileName
            };
        }


        public async Task<IActionResult> DownloadMMPdf(long id)
        {
            var model = await MMDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Mini_Mast_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("MMACReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadIPPdf(long id)
        {
            var model = await vwInspectionIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Inspection_Inprogress_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("IPReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadCIPdf(long id)
        {
            var model = await CIDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Community_Irrigation_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("CIACReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadCMGGYPdf(long id)
        {
            var model = await CMGGYDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"CM_Gaon_Ganga_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("CMGGYReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadRVEDDGPdf(long id)
        {
            var model = await RVEDDGDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"RVEDDG_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("RVEDDGReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadOTRVEDDGPdf(long id)
        {
            var model = await OTRVEDDGDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Off_Grid_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("OTRVDDMReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadOGPPPdf(long id)
        {
            var model = await OGPPDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"On_Grid_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("OGPPReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadBGPdf(long id)
        {
            var model = await BiogasDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Biogas_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("BioGasReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadSSYPdf(long id)
        {
            var model = await SSYDetailIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"SSY_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("SSYReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadSSYIPPdf(long id)
        {
            var model = await vwInspectionIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"SSY_InProgress_SiteReport_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("SSYIPReportPdf", model)
            {
                FileName = fileName
            };
        }

        public async Task<IActionResult> DownloadGrievancesPdf(long id)
        {
            var model = await vwGrievanceIfacade.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"Grievances_Report_{model.Id}_{currentDate}.pdf";

            Response.Headers.Add("File-Name", fileName);
            return new ViewAsPdf("GrievancesReportPdf", model)
            {
                FileName = fileName
            };
        }

        public IActionResult GrievancesReportAnalytics()
        {
            return View();
        }

        public IActionResult _GrievancesAnalyticsList()
        {
            return PartialView("_GrievancesAnalyticsList");
        }

        [HttpGet]
        public async Task<IActionResult> GetGrievanceAnalyticsCountData()
        {
            var data = await GrievanceAnalyticsDataIfacade.GetGrievanceAnalyticsGraphData();
            return Json(data);
        }




        //------------------------GrievanceList Download---------------------------------
        public async Task<IActionResult> DownloadGrievanceReportList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus, DateTime StartDate, DateTime EndDate, int FilterStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetGrievanceData(DistrictId, BlockId, VillageId, SIId, WorkingStatus, StartDate, EndDate, FilterStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Grievance_Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 20;
                worksheet.Column(10).Width = 20;
                worksheet.Column(11).Width = 20;
                worksheet.Column(12).Width = 20;
                worksheet.Column(13).Width = 20;
                worksheet.Column(14).Width = 20;
                worksheet.Column(15).Width = 20;
                worksheet.Column(16).Width = 20;
                worksheet.Column(17).Width = 20;
                worksheet.Column(18).Width = 20;
                worksheet.Column(19).Width = 20;
                worksheet.Column(20).Width = 20;
                worksheet.Column(21).Width = 20;
                worksheet.Column(22).Width = 20;
                worksheet.Column(23).Width = 20;
                worksheet.Column(24).Width = 20;


                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }

                worksheet.Cells[1, 1].Value = "Grievance Id";
                worksheet.Cells[1, 2].Value = "Grievance Status";
                worksheet.Cells[1, 3].Value = "Beneficiary Name";
                worksheet.Cells[1, 4].Value = "Beneficiary Mobile Number";
                worksheet.Cells[1, 5].Value = "District Name";
                worksheet.Cells[1, 6].Value = "Block Name";
                worksheet.Cells[1, 7].Value = "Village Name";
                worksheet.Cells[1, 8].Value = "Site Name";
                worksheet.Cells[1, 9].Value = "Project Name";
                worksheet.Cells[1, 10].Value = "Region";
                worksheet.Cells[1, 11].Value = "Area";
                worksheet.Cells[1, 12].Value = "Fault Remark";
                worksheet.Cells[1, 13].Value = "Complaint Date";
                worksheet.Cells[1, 14].Value = "Severity";
                worksheet.Cells[1, 15].Value = "SI Name";
                worksheet.Cells[1, 16].Value = "Assigned To";
                worksheet.Cells[1, 17].Value = "Admin Comment";
                worksheet.Cells[1, 18].Value = "Remark During Inspection";
                worksheet.Cells[1, 19].Value = "Verify Date";
                worksheet.Cells[1, 20].Value = "Verify Comment";
                worksheet.Cells[1, 21].Value = "Close Date";
                worksheet.Cells[1, 22].Value = "Geo Tag";
                worksheet.Cells[1, 23].Value = "Complaint Medium";
                worksheet.Cells[1, 24].Value = "Forwarding Status";

                using (var range = worksheet.Cells[1, 1, 1, 24])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Adding data to the worksheet
                for (int i = 0; i < modelData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = modelData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = modelData[i].GrievanceStatus;
                    worksheet.Cells[i + 2, 3].Value = modelData[i].BeneficiaryName;
                    worksheet.Cells[i + 2, 4].Value = modelData[i].ApplicantMobNo;
                    worksheet.Cells[i + 2, 5].Value = modelData[i].DistrictName;
                    worksheet.Cells[i + 2, 6].Value = modelData[i].BlockName;
                    worksheet.Cells[i + 2, 7].Value = modelData[i].VillageName;
                    worksheet.Cells[i + 2, 8].Value = modelData[i].SiteName;
                    worksheet.Cells[i + 2, 9].Value = modelData[i].ProjectName;
                    worksheet.Cells[i + 2, 10].Value = modelData[i].Region;
                    worksheet.Cells[i + 2, 11].Value = modelData[i].ComplaintPlace;
                    worksheet.Cells[i + 2, 12].Value = modelData[i].ComplaintDescription;
                    worksheet.Cells[i + 2, 13].Value = modelData[i].ComplaintDate;
                    worksheet.Cells[i + 2, 14].Value = modelData[i].Severity;
                    worksheet.Cells[i + 2, 15].Value = modelData[i].SIName;
                    worksheet.Cells[i + 2, 16].Value = modelData[i].AssignTo;
                    worksheet.Cells[i + 2, 17].Value = modelData[i].AdminComment;
                    worksheet.Cells[i + 2, 18].Value = modelData[i].RemarkDuringInspection;
                    worksheet.Cells[i + 2, 19].Value = modelData[i].VerifyDate;
                    worksheet.Cells[i + 2, 20].Value = modelData[i].VerifyComment;
                    worksheet.Cells[i + 2, 21].Value = modelData[i].CloseDate;
                    worksheet.Cells[i + 2, 22].Value = modelData[i].FaultImageGeoTag;
                    worksheet.Cells[i + 2, 23].Value = modelData[i].ComplaintMedium;
                    worksheet.Cells[i + 2, 24].Value = modelData[i].GrievanceForwardStatus;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"Grievance_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:dd/MM/yyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<DownloadGrievanceListModel>> GetGrievanceData(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus, DateTime StartDate, DateTime EndDate, long FilterStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await DownloadGrievanceListIfacade.GetGrievanceList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus, FilterStatus, StartDate, EndDate);
            if (data == null || data.Count == 0)
            {
                return new List<DownloadGrievanceListModel>(); // Return an empty list
            }
            return data;
        }

        [HttpPost]
        public IActionResult ForwardGrievance([FromForm] ForwardingGrievanceModel model, IFormFile DIForwardingDocument)
        {
            try
            {
                if (DIForwardingDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        DIForwardingDocument.CopyTo(memoryStream);
                        model.DIForwardingDocument = memoryStream.ToArray();
                    }
                }

                model.DIForwardingDate = DateTime.Now;
                model.ForwardedGrievanceStatus = "5"; // Forwarded to Head Office

                var result = grievanceForwardWFacade.InsertAsync(model);

                var grievance = grievanceIfacade.GetAsync(model.GrievanceId).Result;
                if (grievance != null)
                {
                    grievance.IsForwardedToZO = true;
                    var updateGrievance = grievanceWfacade.UpdateAsync(grievance.Id, grievance);
                }

                // Return JSON response indicating success
                return Json(new { success = true, message = "Grievance forwarded successfully." });
            }
            catch (Exception ex)
            {
                // Return JSON response indicating failure
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }


    }
}