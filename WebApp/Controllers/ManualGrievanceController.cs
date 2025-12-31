
using CredaData.Client;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ManualGrievanceController : Controller
    {
        private IWritableFacade<GrievanceModel> grievanceWFacade;
        private IFacade<UserModel> userFacade;
        private IFacade<SIUserModel> siUserFacade;

        public ManualGrievanceController(IWritableFacade<GrievanceModel> grievanceWFacade, IFacade<UserModel> userFacade, IFacade<SIUserModel> siUserFacade)
        {
            this.grievanceWFacade = grievanceWFacade;
            this.userFacade = userFacade;
            this.siUserFacade = siUserFacade;
        }

        [HttpPost]
        public async Task<IActionResult> InsertManualGrievance([FromForm] GrievanceModel model, IFormFile FaultImage)
        {
            try
            {
                if (FaultImage != null && FaultImage.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await FaultImage.CopyToAsync(ms);
                    model.FaultImage = ms.ToArray();
                }

                if (model.IsSystemWorking)
                {
                    model.Severity = "Minor";
                    model.DaysForResolve = 7;
                }
                else
                {
                    model.Severity = "Major";
                    model.DaysForResolve = 15;
                }

                model.CreatedOn = DateTime.Now;
                model.GrievanceStatus = "Open";
                model.IsActive = true;
                model.SiWorkingStatus = true;
                model.IsManualGrievance = true;
                model.IsDeleted = false;
                model.AssignedToNumber = "";
                model.AdminComment = "";
                model.VerifyComment = "";
                model.SiIsAssign = false;
                model.SITimeWorkingStatus = false;
                model.FaultImageGeoTag = "";
                model.FaultImageType = "";
                model.MobilePhotoGeoTag = "";
                model.MobilePhotoType = "";

                var result = await grievanceWFacade.InsertAsync(model);
                return Json(new { success = true, message = "Grievance Added Successfully." });
            }
            catch (Exception ex)
            {
                // Return JSON response indicating failure
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> GetOTP(string mobileNumber)
        {
            Expression<Func<UserModel, bool>> filter = a => a.MobileNumber == mobileNumber;
            var users = await userFacade.ListAllAsync(filter);

            if (users == null || !users.Any())
            {
                Expression<Func<SIUserModel, bool>> filterdata = a => a.MobileNumber == mobileNumber;
                var siusers = await siUserFacade.ListAllAsync(filterdata);

                if(siusers == null || !siusers.Any())
                {
                    return NotFound(new
                    {
                        error = "UserNotFound",
                        message = $"Invalid. Please Check Entered Mobile Number {mobileNumber}."
                    });
                }

                var siuser = siusers.First();
                return Ok(new
                {
                    mobile = siuser.MobileNumber,
                    otp = siuser.OTP
                });
            }

            var user = users.First();
            return Ok(new
            {
                mobile = user.MobileNumber,
                otp = user.Password 
            });
        }
    }
}
