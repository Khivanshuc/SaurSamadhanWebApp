using CredaData.Client;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Linq.Expressions;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ComplaintManagementController : Controller
    {

        private readonly IFacade<DistrictModel> distIFacade;
        private readonly IFacade<BlockModel> blockIFacade;
        private readonly IFacade<RoleModel> roleIFacade;
        private readonly IWritableFacade<UserModel> userWFacade;
        private readonly IFacade<UserModel> userIFacade;
        private readonly IFacade<VillageModel> villageIFacade;
        private readonly IFacade<SiteModel> siteIFacade;
        private readonly IWritableFacade<ComplaintRegisterModel> rgstrComplaintWFacade;
        private readonly IWritableFacade<ComplaintAuditModel> complntAuditWFacade;
        private readonly IWritableFacade<ComplaintStatusHistoryModel> complntStatusWFacade;
        private readonly IFacade<VwComplaintListModel> compListIfacade;
        private readonly IFacade<VwRegisteredComplaintModel> compDetailIfacade;
        private readonly IWritableFacade<ComplaintActionModel> compActionWFacade;
        private readonly IFacade<DistrictandZonalModel> distZonalIfacade;
        private readonly IFacade<AdminPanelUserModel> adminPanelUserFacade;
        private readonly IWritableFacade<ComplaintEscalationModel> complntEscalateWFacade;
        private readonly IFacade<ComplaintListNotificationModel> compNotificationLstIFacade;
        private readonly IFacade<GrievanceListNotificationModel> grievanceNotificationLstIFacade;
        private readonly IFacade<VwGrievanceModel> grievanceIFacade;
        private readonly IFacade<ForwardedGrievanceListModel> forwardedGrievanceListIFacade;
        private readonly IFacade<ForwardedGrievanceDetailModel> forwardedGrievanceDetailIFacade;
        private readonly IWritableFacade<ForwardingGrievanceModel> grievanceForwardWFacade;
        private readonly IFacade<ForwardingGrievanceModel> grievanceForwardIFacade;
        private readonly IWritableFacade<GrievanceModel> grievanceWFacade;

        public ComplaintManagementController(
            IFacade<DistrictModel> distIFacade,
            IFacade<BlockModel> blockIFacade,
            IFacade<RoleModel> roleIFacade,
            IWritableFacade<UserModel> userWFacade,
            IFacade<UserModel> userIFacade,
            IFacade<VillageModel> villageIFacade,
            IFacade<SiteModel> siteIFacade,
            IWritableFacade<ComplaintRegisterModel> rgstrComplaintWFacade,
            IWritableFacade<ComplaintAuditModel> complntAuditWFacade,
            IWritableFacade<ComplaintStatusHistoryModel> complntStatusWFacade,
            IFacade<VwComplaintListModel> compListIfacade,
            IFacade<VwRegisteredComplaintModel> compDetailIfacade,
            IWritableFacade<ComplaintActionModel> compActionWFacade,
            IFacade<DistrictandZonalModel> distZonalIfacade,
            IFacade<AdminPanelUserModel> adminPanelUserFacade,
            IWritableFacade<ComplaintEscalationModel> complntEscalateWFacade,
            IFacade<ComplaintListNotificationModel> compNotificationLstIFacade,
            IFacade<GrievanceListNotificationModel> grievanceNotificationLstIFacade,
            IFacade<VwGrievanceModel> grievanceIFacade,
            IFacade<ForwardedGrievanceListModel> forwardedGrievanceListIFacade,
            IFacade<ForwardedGrievanceDetailModel> forwardedGrievanceDetailIFacade,
            IWritableFacade<ForwardingGrievanceModel> grievanceForwardWFacade,
            IFacade<ForwardingGrievanceModel> grievanceForwardIFacade,
            IWritableFacade<GrievanceModel> grievanceWFacade
            )
        {
            this.distIFacade = distIFacade;
            this.blockIFacade = blockIFacade;
            this.roleIFacade = roleIFacade;
            this.userWFacade = userWFacade;
            this.userIFacade = userIFacade;
            this.villageIFacade = villageIFacade;
            this.siteIFacade = siteIFacade;
            this.rgstrComplaintWFacade = rgstrComplaintWFacade;
            this.complntAuditWFacade = complntAuditWFacade;
            this.complntStatusWFacade = complntStatusWFacade;
            this.compListIfacade = compListIfacade;
            this.compDetailIfacade = compDetailIfacade;
            this.compActionWFacade = compActionWFacade;
            this.distZonalIfacade = distZonalIfacade;
            this.adminPanelUserFacade = adminPanelUserFacade;
            this.complntEscalateWFacade = complntEscalateWFacade;
            this.compNotificationLstIFacade = compNotificationLstIFacade;
            this.grievanceNotificationLstIFacade = grievanceNotificationLstIFacade;
            this.grievanceIFacade = grievanceIFacade;
            this.forwardedGrievanceListIFacade = forwardedGrievanceListIFacade;
            this.forwardedGrievanceDetailIFacade = forwardedGrievanceDetailIFacade;
            this.grievanceForwardWFacade = grievanceForwardWFacade;
            this.grievanceForwardIFacade = grievanceForwardIFacade;
            this.grievanceWFacade = grievanceWFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterComplaint()
        {
            return View();
        }

        public IActionResult ComplaintList()
        {
            return View();
        }

        public IActionResult ForwardHOLandingPage()
        {
            return View();
        }
        public IActionResult GenerateNotice()
        {
            return View();
        }

        public IActionResult DeductionOfFunds()
        {
            return View();
        }
        public IActionResult CaseClosing()
        {
            return View();
        }
        public IActionResult Others()
        {
            return View();
        }

        public IActionResult Notice()
        {
            return View();
        }

        public async Task<IActionResult> _ComplaintList(long DistrictId, long BlockId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long loggedInUser = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await compListIfacade.GetComplaintList(DistrictId, BlockId, SIId, loggedInUser, WorkingStatus);
            return PartialView("_ComplaintList", data);
        }

        public async Task<IActionResult> _ViewComplaintDetail(long ComplaintId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            // Await the result from GetAsync
            var data = await compDetailIfacade.GetAsync(ComplaintId);

            if (data != null)
            {
                return PartialView("_ViewComplaintDetail", data);
            }
            else
            {
                // Handle case when no data is found
                return PartialView("_ErrorPartial", new { message = "Complaint details not found" });
            }
        }

        public IActionResult _EditComplaintDetail()
        {

            return PartialView("_EditComplaintDetail");
        }

        public async Task<IActionResult> _ActionComplaintDetail(long ComplaintId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            // Await the result from GetAsync
            var data = await compDetailIfacade.GetAsync(ComplaintId);

            if (data != null)
            {
                return PartialView("_ActionComplaintDetail", data);
            }
            else
            {
                // Handle case when no data is found
                return PartialView("_ErrorPartial", new { message = "Complaint details not found" });
            }

            //return PartialView("_ActionComplaintDetail");
        }
        public async Task<IActionResult> SaveComplaint(ComplaintRegisterModel data)
        {
            if (data != null)
            {
                var UserIdClaim = User.FindFirst("UserId")?.Value;
                long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;
                data.UserId = UserId;

                long insertResult = await rgstrComplaintWFacade.InsertAsync(data);
                if (insertResult != 0)
                {
                    return Ok(new { success = true, message = "Data Save Successfully", insertedId = insertResult });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        public async Task<IActionResult> SaveComplaintAudit(ComplaintAuditModel data)
        {
            if (data != null)
            {
                var UserIdClaim = User.FindFirst("UserId")?.Value;
                long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

                data.OfficeLevel = UserId;

                long insertResult = await complntAuditWFacade.InsertAsync(data);
                if (insertResult != 0)
                {
                    return Ok(new { success = true, message = "Data Save Successfully", insertedId = insertResult });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        public async Task<IActionResult> SaveComplaintAction(ComplaintActionModel data)
        {
            if (data != null)
            {
                var UserIdClaim = User.FindFirst("UserId")?.Value;
                long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

                data.UserId = UserId;

                long insertResult = await compActionWFacade.InsertAsync(data);
                if (insertResult != 0)
                {
                    return Ok(new { success = true, message = "Data Save Successfully", insertedId = insertResult });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        public async Task<IActionResult> SaveComplaintStatus(ComplaintStatusHistoryModel data)
        {
            if (data != null)
            {
                long insertResult = await complntStatusWFacade.InsertAsync(data);
                if (insertResult != 0)
                {
                    return Ok(new { success = true, message = "Data Save Successfully", insertedId = insertResult });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }

        public async Task<IActionResult> SaveEscalationComplaint(ComplaintEscalationModel data)
        {
            if (data != null)
            {
                var UserIdClaim = User.FindFirst("UserId")?.Value;
                long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

                data.EscalatedBy = UserId;

                var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
                long ZonalId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

                var DistrictIdClaim = User.FindFirst("DistrictId")?.Value;
                long DistrictId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(DistrictIdClaim) : 0;

                if (ZonalId == -1)
                {
                    //get the zone Id with the help of District Id
                    Expression<Func<DistrictandZonalModel, bool>> filter = a => a.DistrictId == DistrictId;
                    var ZonalList = await distZonalIfacade.ListAllAsync();
                    var filteredZonalList = ZonalList.Where(z => z.DistrictId == DistrictId).FirstOrDefault();

                    //get the UserId of the Zonal Officer with the help of Zonal Id  from tblAdminPanelUser
                    var adminUserList = await adminPanelUserFacade.ListAllAsync();
                    var zoneUserData = adminUserList.Where(a => a.ZonalId == filteredZonalList.ZonalId).FirstOrDefault();
                    data.EscalatedTo = zoneUserData.Id;

                }
                else
                {

                }

                long insertResult = await complntEscalateWFacade.InsertAsync(data);
                if (insertResult != 0)
                {
                    return Ok(new { success = true, message = "Data Save Successfully", insertedId = insertResult });
                }

            }
            return BadRequest(new { success = false, message = "Invalid data received" });
        }
        public async Task<IActionResult> _GetEscalatedComplaint(long DistrictId, long BlockId, long SIId, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
            long ZonalId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

            //Get Escalated Complaint on the base of UserId 


            var data = await compListIfacade.GetComplaintList(DistrictId, BlockId, SIId, UserId, WorkingStatus);
            return PartialView("_ComplaintList", data);
        }

        public async Task<JsonResult> GetTodayRegisterdComplntNotification()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await compNotificationLstIFacade.GetList(UserId);

            return Json(data);
        }

        public async Task<JsonResult> GetTodayRegisterdGrievanceNotification()
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await grievanceNotificationLstIFacade.GetList(UserId);

            return Json(data);
        }

        public async Task<IActionResult> GetPublicGrievanceDataById(long GrievanceId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;


            var data = await grievanceIFacade.GetAsync(GrievanceId);

            //return that Partial View 
            return PartialView("_PGrievanceRgstrCmplnt", data);
        }

        public IActionResult ForwardedComplaint()
        {
            return View();
        }

        public async Task<IActionResult> ForwardedComplaintList(long siId, long distId, long forwardStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
            long ZonalId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

            var data = await forwardedGrievanceListIFacade.GetForwardedGrievanceList(UserId, siId, distId, forwardStatus);

            if (data == null)
            {
                return PartialView("ForwardedComplaintListPartialView", new List<ForwardedGrievanceListModel>());
            }

            return PartialView("ForwardedComplaintListPartialView", data);
        }

        public async Task<IActionResult> ForwardedComplaintDetail(long GrievanceId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var ZonalIdClaim = User.FindFirst("ZonalId")?.Value;
            long ZonalId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(ZonalIdClaim) : 0;

            var data = await forwardedGrievanceDetailIFacade.GetForwardedGrievanceDetail(GrievanceId);

            ViewData["ZonalId"] = ZonalId;

            return PartialView("ForwardedGrievanceDetailPartialView", data);
        }
        [HttpPost]
        public IActionResult ForwardedGrievanceAccept(ForwardingGrievanceModel model)
        {
            try
            {
                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.IsAcceptedByHO = true;
                    forwardedGrievance.HOAcceptanceComment = model.HOAcceptanceComment;
                    forwardedGrievance.HOAcceptanceDate = DateTime.Now;
                    forwardedGrievance.ForwardedGrievanceStatus = "2"; // Pending at Head Office
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsAcceptedByHO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return success response
                return Json(new { success = true, message = "Grievance accepted successfully." });
            }
            catch (Exception ex)
            {
                // Handle and return error response
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult ForwardedGrievanceRevert([FromForm] ForwardingGrievanceModel model, IFormFile HOReversionDocument)
        {
            try
            {
                if (HOReversionDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        HOReversionDocument.CopyTo(memoryStream);
                        model.HOReversionDocument = memoryStream.ToArray();
                    }
                }

                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.HOReversionComment = model.HOReversionComment;
                    forwardedGrievance.HOReversionDate = DateTime.Now;
                    forwardedGrievance.HOReversionDocument = model.HOReversionDocument;
                    forwardedGrievance.IsRevertedByHO = true;
                    forwardedGrievance.ForwardedGrievanceStatus = "4"; // Reopen at District Office after Reversion
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsRevertedByHO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return success response
                return Json(new { success = true, message = "Grievance reverted successfully." });
            }
            catch (Exception ex)
            {
                // Handle and return error response
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }


        [HttpPost]
        public IActionResult ForwardedGrievanceReject([FromForm] ForwardingGrievanceModel model, IFormFile HORejectedDocument)
        {
            try
            {
                if (HORejectedDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        HORejectedDocument.CopyTo(memoryStream);
                        model.HORejectedDocument = memoryStream.ToArray();
                    }
                }

                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.IsAcceptedByHO = false; // Setting to false for rejection
                    forwardedGrievance.HORejectionComment = model.HORejectionComment;
                    forwardedGrievance.HORejectedDocument = model.HORejectedDocument;
                    forwardedGrievance.HORejectionDate = DateTime.Now;
                    forwardedGrievance.IsRejectedByHO = true;
                    forwardedGrievance.ForwardedGrievanceStatus = "3"; // Reopen at District Office after Rejection
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsRejectedByHO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return JSON response indicating success
                return Json(new { success = true, message = "Grievance rejected successfully." });
            }
            catch (Exception ex)
            {
                // Return JSON response indicating failure
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult ForwardedGrievanceAcceptByZO(ForwardingGrievanceModel model)
        {
            try
            {
                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.IsAcceptedByZO = true;
                    forwardedGrievance.ZOAcceptanceComment = model.ZOAcceptanceComment;
                    forwardedGrievance.ZOAcceptanceDate = DateTime.Now;
                    forwardedGrievance.ForwardedGrievanceStatus = "6"; // Pending at Head Office
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsAcceptedByZO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return success response
                return Json(new { success = true, message = "Grievance accepted successfully." });
            }
            catch (Exception ex)
            {
                // Handle and return error response
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult ForwardedGrievanceRevertedByZO([FromForm] ForwardingGrievanceModel model, IFormFile ZOReversionDocument)
        {
            try
            {
                if (ZOReversionDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        ZOReversionDocument.CopyTo(memoryStream);
                        model.ZOReversionDocument = memoryStream.ToArray();
                    }
                }

                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.ZOReversionComment = model.ZOReversionComment;
                    forwardedGrievance.ZOReversionDate = DateTime.Now;
                    forwardedGrievance.ZOReversionDocument = model.ZOReversionDocument;
                    forwardedGrievance.IsRevertedByZO = true;
                    forwardedGrievance.ForwardedGrievanceStatus = "7"; // Reopen at District Office after Reversion
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsRevertedByZO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return success response
                return Json(new { success = true, message = "Grievance reverted successfully." });
            }
            catch (Exception ex)
            {
                // Handle and return error response
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult ForwardedGrievanceRejectedByZO([FromForm] ForwardingGrievanceModel model, IFormFile ZORejectionDocument)
        {
            try
            {
                if (ZORejectionDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        ZORejectionDocument.CopyTo(memoryStream);
                        model.ZORejectionDocument = memoryStream.ToArray();
                    }
                }

                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.IsAcceptedByZO = false; // Setting to false for rejection
                    forwardedGrievance.ZORejectionComment = model.ZORejectionComment;
                    forwardedGrievance.ZORejectionDocument = model.ZORejectionDocument;
                    forwardedGrievance.ZORejectionDate = DateTime.Now;
                    forwardedGrievance.IsRejectedByZO = true;
                    forwardedGrievance.ForwardedGrievanceStatus = "8"; // Reopen at District Office after Rejection
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsRejectedByZO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
                }

                // Return JSON response indicating success
                return Json(new { success = true, message = "Grievance rejected successfully." });
            }
            catch (Exception ex)
            {
                // Return JSON response indicating failure
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GrievanceForwardedByZO([FromForm] ForwardingGrievanceModel model, IFormFile ZOForwardingDocument)
        {
            try
            {
                if (ZOForwardingDocument != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        ZOForwardingDocument.CopyTo(memoryStream);
                        model.ZOForwardingDocument = memoryStream.ToArray();
                    }
                }

                var forwardedGrievance = grievanceForwardIFacade.GetAsync(model.Id).Result;

                if (forwardedGrievance != null)
                {
                    forwardedGrievance.IsForwardedByZO = true; // Setting to false for rejection
                    forwardedGrievance.ZOForwardingComment = model.ZOForwardingComment;
                    forwardedGrievance.ZOForwardingDocument = model.ZOForwardingDocument;
                    forwardedGrievance.ZOForwardingDate = DateTime.Now;
                    forwardedGrievance.ForwardedGrievanceStatus = "9"; // Reopen at District Office after Rejection
                    forwardedGrievance.UpdatedOn = DateTime.Now;

                    grievanceForwardWFacade.UpdateAsync(model.Id, forwardedGrievance);

                    var grievanceData = grievanceWFacade.GetAsync(model.GrievanceId).Result;
                    if (grievanceData != null)
                    {
                        grievanceData.IsForwardedToHO = true;
                        grievanceWFacade.UpdateAsync(model.GrievanceId, grievanceData);
                    }
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

        //------------------------GrievanceForwardList Download---------------------------------
        public async Task<IActionResult> DownloadForwardGrievanceList(long DistrictId, long SIId, long GrievanceStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var modelData = await forwardedGrievanceListIFacade.GetForwardedGrievanceList(UserId, SIId, DistrictId, GrievanceStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("GrievanceForwarding_Report");

                //    // Set column widths for better visibility
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 30;
                worksheet.Column(7).Width = 30;
                worksheet.Column(8).Width = 20;

                worksheet.Row(1).Height = 25;
                for (int i = 2; i <= modelData.Count + 1; i++)
                {
                    worksheet.Row(i).Height = 20;
                }
                worksheet.Cells[1, 1].Value = "S.No";
                worksheet.Cells[1, 2].Value = "Grievance Id";
                worksheet.Cells[1, 3].Value = "District Name";
                worksheet.Cells[1, 4].Value = "Block Name";
                worksheet.Cells[1, 5].Value = "Village Name";
                worksheet.Cells[1, 6].Value = "Site Name";
                worksheet.Cells[1, 7].Value = "Forwarding Remark";
                worksheet.Cells[1, 8].Value = "Forwarding Date";
                worksheet.Cells[1, 9].Value = "Forwarding Status";

                using (var range = worksheet.Cells[1, 1, 1, 9])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                for (int i = 0; i < modelData.Count; i++)
                {
                    int row = i + 2;

                    worksheet.Cells[row, 1].Value = i + 1;  // ✅ Serial Number
                    worksheet.Cells[row, 2].Value = modelData[i].GrievanceId;
                    worksheet.Cells[row, 3].Value = modelData[i].DistrictName;
                    worksheet.Cells[row, 4].Value = modelData[i].BlockName;
                    worksheet.Cells[row, 5].Value = modelData[i].VillageName;
                    worksheet.Cells[row, 6].Value = modelData[i].SiteName;
                    worksheet.Cells[row, 7].Value = modelData[i].DIForwardingRemark;

                    if (modelData[i].DIForwardingDate != null)
                    {
                        worksheet.Cells[i + 2, 8].Value = modelData[i].DIForwardingDate; // assign DateTime
                        worksheet.Cells[i + 2, 8].Style.Numberformat.Format = "dd-MMM-yyyy";
                    }
                    worksheet.Cells[row, 9].Value = modelData[i].ForwardedGrievanceStatus;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var firstItem = modelData.FirstOrDefault();
                string fileName = firstItem != null
                    ? $"Forwarded_Grievance_{DateTime.Now:dd-MM-yyyy}.xlsx"
                    : $"{DateTime.Now:dd/MM/yyyy}.xlsx";

                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }


    }
}
