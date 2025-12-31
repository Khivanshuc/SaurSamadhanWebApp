using CredaData.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly IFacade<VwGrievanceListModel> vwGrievanceListIfacade;
        private readonly IFacade<GrievanceModel> grievanceIfacade;
        private readonly IWritableFacade<GrievanceModel> grievanceWfacade;
        private readonly IWritableFacade<GrievanceDeleteLogModel> gDelLogWfacade;
        private readonly IFacade<GrievanceDeleteLogModel> grievanceDelIfacade;
        private readonly IWritableFacade<GrievanceRevertionModel> grievanceRevertionWFacade;
        public AdministratorController(
            IFacade<VwGrievanceListModel> vwGrievanceListIfacade,
            IFacade<GrievanceModel> grievanceIfacade,
            IWritableFacade<GrievanceRevertionModel> grievanceRevertionWFacade,
            IWritableFacade<GrievanceModel> grievanceWfacade,
            IWritableFacade<GrievanceDeleteLogModel> gDelLogWfacade,
            IFacade<GrievanceDeleteLogModel> grievanceDelIfacade
            )
        {
            this.vwGrievanceListIfacade = vwGrievanceListIfacade;
            this.grievanceIfacade = grievanceIfacade;
            this.grievanceRevertionWFacade = grievanceRevertionWFacade;
            this.grievanceWfacade = grievanceWfacade;
            this.gDelLogWfacade = gDelLogWfacade;
            this.grievanceDelIfacade = grievanceDelIfacade;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Grievances()
        {
            return View();
        }

        public IActionResult ManualGrievanceEntry()
        {
            return View();
        }

        public IActionResult LoginAccess()
        {
            return View();
        }

        public IActionResult DeletedGrievances()
        {
            return View();
        }

        public async Task<IActionResult> GrievancesList(long DistrictId, long BlockId, long VillageId, long SIId, long WorkingStatus, DateTime StartDate, DateTime EndDate, long FilterStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            //var GrievanceList = vwGrievanceListIfacade.GetList(District, Block).Result;
            var GrievanceList = vwGrievanceListIfacade.GetGrievanceList(DistrictId, BlockId, VillageId, SIId, UserId, WorkingStatus, FilterStatus, StartDate, EndDate).Result;

            return PartialView("GrievanceList", GrievanceList);
        }
        public async Task<IActionResult> StepBackComplaint(long GrievanceId, string GrievanceStatus, string RevertionComment)
        {
            GrievanceRevertionModel grievanceRevertion = new();
            if (GrievanceId > 0)
            {
                var data = grievanceIfacade.StepBackGrievance(GrievanceId, GrievanceStatus);
                if (data != null)
                {
                    grievanceRevertion.GrievanceId = GrievanceId;
                    grievanceRevertion.GrievanceRevertionComment = RevertionComment;
                    grievanceRevertion.GrievanceRevertionType = GrievanceStatus;
                    grievanceRevertion.CreatedOn = DateTime.Now;
                    grievanceRevertion.CreatedBy = "Administrator";
                    grievanceRevertion.UpdatedOn = DateTime.Now;
                    grievanceRevertion.UpdatedBy = "Administrator";

                    var RevertedData = grievanceRevertionWFacade.InsertAsync(grievanceRevertion);

                    return Json(new { success = true, message = "Grievance reverted successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Something went wrong!" });
                }
            }
            return Json(new { success = false, message = "Something went wrong!" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImageDocument([FromBody] GrievanceUploadDocumentModel data)
        {
            var grievanceExistingData = await grievanceIfacade.GetAsync(data.Id);

            if (!string.IsNullOrEmpty(data.ImageBase64))
            {
                data.Image = Convert.FromBase64String(data.ImageBase64);
            }

            if (!string.IsNullOrEmpty(data.DocumentBase64))
            {
                data.Document = Convert.FromBase64String(data.DocumentBase64);
            }

            if (data.GrievanceStatus == "InProgress")
            {
                grievanceExistingData.ComplaintVerificationDate = data.DateTime;
                grievanceExistingData.SIAssignedDate = data.DateTime;
                grievanceExistingData.SiIsAssign = true;
                grievanceExistingData.GrievanceStatus = data.GrievanceStatus;
                grievanceExistingData.ImageBeforeRectification = data.Image;
                var updatedData = await grievanceWfacade.UpdateAsync(grievanceExistingData.Id, grievanceExistingData);
            }
            else
            {
                grievanceExistingData.MobilePhoto = data.Image;
                grievanceExistingData.CertificatePhoto = data.Document;
                grievanceExistingData.VerifyDate = data.DateTime;
                grievanceExistingData.RemarkDuringInspection = data.VerificationComment;
                grievanceExistingData.IsAssign = false;
                grievanceExistingData.SiIsAssign = false;
                grievanceExistingData.MobilePhotoGeoTag = data.GeoTag;
                grievanceExistingData.GrievanceStatus = data.GrievanceStatus;

                var updatedData = await grievanceWfacade.UpdateAsync(grievanceExistingData.Id,grievanceExistingData);
            }

            return Json(new { success = true, message = "Grievance reverted successfully!" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGrievance(long grievanceId, string remark)
        {
            var deletedId = await grievanceIfacade.DeleteGrievance(grievanceId);

            if (deletedId == null || deletedId == 0)
            {
                return Json(new { success = false, message = "Delete failed or record not found." });
            }

            DeletedGrievanceLog(grievanceId, remark);

            return Json(new { success = true, Id = deletedId, message = "Data Deleted Successfully" });
        }

        public void DeletedGrievanceLog(long GrievanceId ,String Remark)
        {
            var DeleteGrievancelogDetails = new GrievanceDeleteLogModel
            {
                GrievanceId = GrievanceId,
                Remark = Remark,
                CreatedOn = DateTime.Now,
                CreatedBy = "Administrator",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "Administrator"
            };

            var DeletedId = gDelLogWfacade.InsertAsync(DeleteGrievancelogDetails);
        }

        public async Task<IActionResult> DeletedGrievanceList()
        {
            var deletedList = grievanceDelIfacade.ListAllAsync().Result.ToList();
            return PartialView("DeletedGrievanceList", deletedList);
        }

    }
}
