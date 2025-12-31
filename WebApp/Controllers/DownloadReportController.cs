using CredaData.Client;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Drawing;
using System.Web.WebPages;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DownloadReportController : Controller
    {
        private IFacade<ShowProjectReportModel> showProjectReportIFacade;
        private IFacade<DownloadProjectReportModel> downloadProjectReportIFacade;
        private IFacade<VwProjectReportListWithCount> ShowProjectReportCountIFacade;
        private IFacade<UserWiseAllProjectCountsAdminModel> UserProjectReportCountIFacade;
        private IFacade<UserWiseProjectWiseListModel> UserWiseProjectWiseListIFacade;


        public DownloadReportController(IFacade<ShowProjectReportModel> showProjectReportIFacade,
            IFacade<DownloadProjectReportModel> downloadProjectReportIFacade,
            IFacade<VwProjectReportListWithCount> ShowProjectReportCountIFacade,
            IFacade<UserWiseAllProjectCountsAdminModel> UserProjectReportCountIFacade,
            IFacade<UserWiseProjectWiseListModel> UserWiseProjectWiseListIFacade
            )
        {
            this.showProjectReportIFacade = showProjectReportIFacade;
            this.downloadProjectReportIFacade = downloadProjectReportIFacade;
            this.ShowProjectReportCountIFacade = ShowProjectReportCountIFacade;
            this.UserProjectReportCountIFacade = UserProjectReportCountIFacade;
            this.UserWiseProjectWiseListIFacade = UserWiseProjectWiseListIFacade;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjectWiseReport()
        {
            return View();
        }
        public async Task<IActionResult> ProjectReportList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await showProjectReportIFacade.ShowProjectReportList(ProjectId, DistrictId, StartDate, EndDate, UserId);
            return PartialView(data);
        }

        public IActionResult ProjectReportCount()
        {
            return View();
        }

        public IActionResult UserReportCount()
        {
            return View();
        }

        public async Task<IActionResult> UserReportCountList(long DistrictId, long BlockId, long UserId, DateTime StartDate, DateTime EndDate, int FilterStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long loggedInUser = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await UserProjectReportCountIFacade.GetList(loggedInUser, DistrictId, BlockId, UserId, StartDate, EndDate, FilterStatus);
            return PartialView("UserReportCountList", data);
        }

        public async Task<IActionResult> DownloadUserReportCountList(long DistrictId, long BlockId, long UserId, DateTime StartDate, DateTime EndDate, int FilterStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long loggedInUser = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await UserProjectReportCountIFacade.GetList(loggedInUser, DistrictId, BlockId, UserId, StartDate, EndDate, FilterStatus);


            if (data == null || !data.Any())
            {
                return NotFound("No data found for the given criteria.");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Ensure license context is set

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Project Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 10; // Serial No
                worksheet.Column(2).Width = 30; // User Name
                worksheet.Column(3).Width = 20; // Name of District
                worksheet.Column(4).Width = 10; // Biogas
                worksheet.Column(5).Width = 20; // Jal Jivan Mission
                worksheet.Column(6).Width = 20; // Other Than JJM
                worksheet.Column(7).Width = 20; // Saur Sujla Yojna
                worksheet.Column(8).Width = 20; // CM Gaon Ganga Yojana
                worksheet.Column(9).Width = 20; // Community Irrigation
                worksheet.Column(10).Width = 20; // RVE DDG Monitoring
                worksheet.Column(11).Width = 20; // RVE DDG - Off Grid
                worksheet.Column(12).Width = 20; // On Grid Power Plant
                worksheet.Column(13).Width = 20; // High Mast
                worksheet.Column(14).Width = 20; // Mini Mast
                worksheet.Column(15).Width = 20; // Total

                // Add headers
                worksheet.Cells[1, 1].Value = "SNo";
                worksheet.Cells[1, 2].Value = "User Name";
                worksheet.Cells[1, 3].Value = "District Name";
                worksheet.Cells[1, 4].Value = "Biogas";
                worksheet.Cells[1, 5].Value = "Jal Jivan Mission";
                worksheet.Cells[1, 6].Value = "Other than JJM";
                worksheet.Cells[1, 7].Value = "SSY";
                worksheet.Cells[1, 8].Value = "CM Gaon Ganga Yojna";
                worksheet.Cells[1, 9].Value = "Community Irrigation";
                worksheet.Cells[1, 10].Value = "RVE-DDG";
                worksheet.Cells[1, 11].Value = "Other than RVE-DDG";
                worksheet.Cells[1, 12].Value = "On Grid Power Plant";
                worksheet.Cells[1, 13].Value = "High Mast";
                worksheet.Cells[1, 14].Value = "Mini Mast";
                worksheet.Cells[1, 15].Value = "Total";

                // Apply styles to the header row
                using (var range = worksheet.Cells[1, 1, 1, 15])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                long serialNo = 1;
                // Add data rows
                for (int i = 0; i < data.Count; i++)
                {
                    var row = i + 2; // Row index starting from 2 for data
                    worksheet.Cells[row, 1].Value = serialNo++;
                    worksheet.Cells[row, 2].Value = data[i].UserName;
                    worksheet.Cells[row, 3].Value = data[i].DistrictName;
                    worksheet.Cells[row, 4].Value = data[i].BioGasProjectCount;
                    worksheet.Cells[row, 5].Value = data[i].JJMProjectCount;
                    worksheet.Cells[row, 6].Value = data[i].OtherThanJJMProjectCount;
                    worksheet.Cells[row, 7].Value = data[i].SSYProjectCount;
                    worksheet.Cells[row, 8].Value = data[i].CMYojnaProjectCount;
                    worksheet.Cells[row, 9].Value = data[i].CommunityIrrigationProjectCount;
                    worksheet.Cells[row, 10].Value = data[i].RVEDDProjectCount;
                    worksheet.Cells[row, 11].Value = data[i].OtherRVEDDProjectCount;
                    worksheet.Cells[row, 12].Value = data[i].OnGridProjectCount;
                    worksheet.Cells[row, 13].Value = data[i].HighMastProjectCount;
                    worksheet.Cells[row, 14].Value = data[i].MiniMastProjectCount;
                    worksheet.Cells[row, 15].Value = data[i].TotalProjectCount;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "UserList.xlsx";

                return File(stream, contentType, fileName);
            }
        }

        public async Task<IActionResult> UserReportCountListDetail(long UserId, long ProjectId, int FilterStatus, DateTime StartDate, DateTime EndDate)
        {

            var data = await UserWiseProjectWiseListIFacade.GetUserWiseProjectWiseList(UserId, ProjectId, FilterStatus, StartDate, EndDate);

            return PartialView("UserReportCountListDetail", data);
        }

        public async Task<IActionResult> ProjectReportCountList(DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await ShowProjectReportCountIFacade.ShowProjectCountReport(UserId, StartDate, EndDate, filterStatus, WorkingStatus);
            return PartialView(data);
        }

        public async Task<IActionResult> ProjectReportCountListDetail(DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus, long DistrictId, long ProjectId)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await showProjectReportIFacade.ShowProjectCountListReport(ProjectId, DistrictId, UserId, StartDate, EndDate, filterStatus, WorkingStatus);
            return PartialView(data);
        }

        public async Task<IActionResult> DownloadProjectList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                var UserIdClaim = User.FindFirst("UserId")?.Value;
                long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

                var data = await downloadProjectReportIFacade.DownloadProjectReportList(ProjectId, DistrictId, StartDate, EndDate, UserId);

                if (data == null || !data.Any())
                {
                    return NotFound("No data found for the given criteria.");
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Ensure license context is set

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Project Report");

                    // Set column widths for better visibility
                    worksheet.Column(1).Width = 10;
                    worksheet.Column(2).Width = 30;
                    worksheet.Column(3).Width = 20;
                    worksheet.Column(4).Width = 20;
                    worksheet.Column(5).Width = 20;
                    worksheet.Column(6).Width = 20;
                    worksheet.Column(7).Width = 30;
                    worksheet.Column(8).Width = 20;
                    worksheet.Column(9).Width = 20;
                    worksheet.Column(10).Width = 30;


                    // Add headers
                    worksheet.Cells[1, 1].Value = "SNo";
                    worksheet.Cells[1, 2].Value = "District Name";
                    worksheet.Cells[1, 3].Value = "Block Name";
                    worksheet.Cells[1, 4].Value = "Village Name";
                    worksheet.Cells[1, 5].Value = "Site Name";
                    worksheet.Cells[1, 6].Value = "SI Name";
                    worksheet.Cells[1, 7].Value = "Inspection Done By";
                    worksheet.Cells[1, 8].Value = "Inspection Date";
                    worksheet.Cells[1, 9].Value = "Working Status";
                    worksheet.Cells[1, 10].Value = "Faulty Remark";
                    //worksheet.Cells[1, 11].Value = "Image1";
                    //worksheet.Cells[1, 12].Value = "Image2";
                    //worksheet.Cells[1, 13].Value = "Image3";
                    //worksheet.Cells[1, 14].Value = "Image4";
                    //worksheet.Cells[1, 15].Value = "Image5";


                    // Apply styles to the header row
                    using (var range = worksheet.Cells[1, 1, 1, 10])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                    }
                    // Add data rows
                    for (int i = 0; i < data.Count; i++)
                    {
                        var row = i + 2; // Row index starting from 2 for data
                        worksheet.Cells[row, 1].Value = data[i].SNo;
                        worksheet.Cells[row, 2].Value = data[i].DistrictName;
                        worksheet.Cells[row, 3].Value = data[i].BlockName;
                        worksheet.Cells[row, 4].Value = data[i].VillageName;
                        worksheet.Cells[row, 5].Value = data[i].SiteName;
                        worksheet.Cells[row, 6].Value = data[i].SIName;
                        worksheet.Cells[row, 7].Value = data[i].InspectionDoneBy;
                        worksheet.Cells[row, 8].Value = data[i].InspectionDate?.ToString("yyyy-MM-dd");
                        worksheet.Cells[row, 9].Value = data[i].WorkingStatus;
                        worksheet.Cells[row, 10].Value = data[i].FaultyRemark;

                        // Insert images
                        //InsertImageToWorksheet(worksheet, data[i].Image1, row, 11);
                        //InsertImageToWorksheet(worksheet, data[i].Image2, row, 12);
                        //InsertImageToWorksheet(worksheet, data[i].Image3, row, 13);
                        //InsertImageToWorksheet(worksheet, data[i].Image4, row, 14);
                        //InsertImageToWorksheet(worksheet, data[i].Image5, row, 15);
                    }

                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    stream.Position = 0;

                    var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    var fileName = "ProjectReport.xlsx";

                    return File(stream, contentType, fileName);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (or handle it as needed)
                Console.WriteLine($"Error generating Excel file: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private void InsertImageToWorksheet(ExcelWorksheet worksheet, byte[] imageData, int rowIndex, int columnIndex)
        {
            if (imageData != null && imageData.Length > 0)
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");

                try
                {
                    using (var stream = new MemoryStream(imageData))
                    {
                        using (var image = Image.FromStream(stream))
                        {
                            image.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        var fileInfo = new FileInfo(tempFilePath);
                        var picture = worksheet.Drawings.AddPicture($"Image_{rowIndex}_{columnIndex}", fileInfo);
                        picture.SetPosition(rowIndex - 1, 0, columnIndex - 1, 0);
                        picture.SetSize(100, 100); // Adjust size as needed
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Failed to insert image at row {rowIndex}, column {columnIndex}: {ex.Message}");
                }
                finally
                {
                    // Ensure the file is deleted after usage
                    if (System.IO.File.Exists(tempFilePath))
                    {
                        try
                        {
                            System.IO.File.Delete(tempFilePath);
                        }
                        catch (Exception ex)
                        {
                            // Handle the error here
                            Console.WriteLine($"Failed to delete temporary file: {ex.Message}");
                        }
                    }
                }
            }
        }

        //------------------Download Project Report Count List in Excel --------------------------
        public async Task<IActionResult> DownloadProjectReportCountList(DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var modelData = await GetSSYInspectionIPDataDownload(StartDate, EndDate, filterStatus, WorkingStatus);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Project Report");

                // Set column widths for better visibility
                worksheet.Column(1).Width = 30; // Name of District
                worksheet.Column(2).Width = 10; // Biogas
                worksheet.Column(3).Width = 20; // Jal Jivan Mission
                worksheet.Column(4).Width = 20; // Other Than JJM
                worksheet.Column(5).Width = 20; // Saur Sujla Yojna
                worksheet.Column(6).Width = 20; // CM Gaon Ganga Yojana
                worksheet.Column(7).Width = 20; // Community Irrigation
                worksheet.Column(8).Width = 20; // RVE DDG Monitoring
                worksheet.Column(9).Width = 20; // RVE DDG - Off Grid
                worksheet.Column(10).Width = 20; // On Grid Power Plant
                worksheet.Column(11).Width = 20; // High Mast
                worksheet.Column(12).Width = 20; // Mini Mast
                worksheet.Column(13).Width = 20; // Total

                // Define the headers (matching HTML structure)
                worksheet.Cells[1, 1].Value = "Name of District";
                worksheet.Cells[1, 2].Value = "Biogas";
                worksheet.Cells[1, 3].Value = "Jal Jivan Mission";
                worksheet.Cells[1, 4].Value = "Other Than JJM";
                worksheet.Cells[1, 5].Value = "Saur Sujla Yojna";
                worksheet.Cells[1, 6].Value = "CM Gaon Ganga Yojana";
                worksheet.Cells[1, 7].Value = "Community Irrigation";
                worksheet.Cells[1, 8].Value = "RVE DDG Monitoring";
                worksheet.Cells[1, 9].Value = "RVE DDG - Off Grid";
                worksheet.Cells[1, 10].Value = "On Grid Power Plant";
                worksheet.Cells[1, 11].Value = "High Mast";
                worksheet.Cells[1, 12].Value = "Mini Mast";
                worksheet.Cells[1, 13].Value = "Total";

                // Apply styles to the header row
                using (var range = worksheet.Cells[1, 1, 1, 13])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#00CCDD"));
                }

                // Calculate total counts for each project type
                int totalBiogas = modelData.Sum(x => x.BioGasProjectCount);
                int totalJJM = modelData.Sum(x => x.JJMProjectCount);
                int totalOtherThanJJM = modelData.Sum(x => x.OtherThanJJMProjectCount);
                int totalSSY = modelData.Sum(x => x.SSYProjectCount);
                int totalCMYojna = modelData.Sum(x => x.CMYojnaProjectCount);
                int totalCommunityIrrigation = modelData.Sum(x => x.CommunityIrrigationProjectCount);
                int totalRVEDD = modelData.Sum(x => x.RVEDDProjectCount);
                int totalOtherRVEDD = modelData.Sum(x => x.OtherRVEDDProjectCount);
                int totalOnGrid = modelData.Sum(x => x.OnGridProjectCount);
                int totalHighMast = modelData.Sum(x => x.HighMastProjectCount);
                int totalMiniMast = modelData.Sum(x => x.MiniMastProjectCount);
                int grandTotal = modelData.Sum(x => x.TotalProjectCount);

                // Insert the totals row after the header
                worksheet.Cells[2, 1].Value = "Total";
                worksheet.Cells[2, 2].Value = totalBiogas;
                worksheet.Cells[2, 3].Value = totalJJM;
                worksheet.Cells[2, 4].Value = totalOtherThanJJM;
                worksheet.Cells[2, 5].Value = totalSSY;
                worksheet.Cells[2, 6].Value = totalCMYojna;
                worksheet.Cells[2, 7].Value = totalCommunityIrrigation;
                worksheet.Cells[2, 8].Value = totalRVEDD;
                worksheet.Cells[2, 9].Value = totalOtherRVEDD;
                worksheet.Cells[2, 10].Value = totalOnGrid;
                worksheet.Cells[2, 11].Value = totalHighMast;
                worksheet.Cells[2, 12].Value = totalMiniMast;
                worksheet.Cells[2, 13].Value = grandTotal;

                // Add styling to the totals row
                using (var range = worksheet.Cells[2, 1, 2, 13])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFF99"));
                }

                // Add the data to the worksheet (starting from row 3, since row 2 is now for totals)
                for (int i = 0; i < modelData.Count; i++)
                {
                    var row = i + 3; // Data starts from the third row

                    worksheet.Cells[row, 1].Value = modelData[i].AreaName;
                    worksheet.Cells[row, 2].Value = modelData[i].BioGasProjectCount;
                    worksheet.Cells[row, 3].Value = modelData[i].JJMProjectCount;
                    worksheet.Cells[row, 4].Value = modelData[i].OtherThanJJMProjectCount;
                    worksheet.Cells[row, 5].Value = modelData[i].SSYProjectCount;
                    worksheet.Cells[row, 6].Value = modelData[i].CMYojnaProjectCount;
                    worksheet.Cells[row, 7].Value = modelData[i].CommunityIrrigationProjectCount;
                    worksheet.Cells[row, 8].Value = modelData[i].RVEDDProjectCount;
                    worksheet.Cells[row, 9].Value = modelData[i].OtherRVEDDProjectCount;
                    worksheet.Cells[row, 10].Value = modelData[i].OnGridProjectCount;
                    worksheet.Cells[row, 11].Value = modelData[i].HighMastProjectCount;
                    worksheet.Cells[row, 12].Value = modelData[i].MiniMastProjectCount;
                    worksheet.Cells[row, 13].Value = modelData[i].TotalProjectCount;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string fileName = $"Project_Wise_Summary_{DateTime.Now:dd-MM-yyyy}.xlsx";
                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private async Task<List<VwProjectReportListWithCount>> GetSSYInspectionIPDataDownload(DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus)
        {
            var UserIdClaim = User.FindFirst("UserId")?.Value;
            long UserId = !string.IsNullOrEmpty(UserIdClaim) ? Convert.ToInt64(UserIdClaim) : 0;

            var data = await ShowProjectReportCountIFacade.ShowProjectCountReport(UserId, StartDate, EndDate, filterStatus, WorkingStatus);
            return data;
        }
    }
}
