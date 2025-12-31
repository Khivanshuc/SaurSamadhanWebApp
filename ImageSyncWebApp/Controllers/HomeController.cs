using CredaData.Client;
using ImageSyncWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ImageSyncWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IWritableFacade<GrievanceModel> grievanceWfacade;
        private IWritableFacade<JJMAlreadyCompletedModel> jjmWfacade;
        private IWritableFacade<otherthanjjmalreadycompleted> OTjjmWfacade;
        private IWritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted> OTRVEDDGWfacade;
        private IWritableFacade<HighMastAlreadyCompletedmodel> HighMastWfacade;
        //private IWritableFacade<MiniMastAlreadyCompletedModel> MiniMastWfacade;
        private IWritableFacade<biogasalreadycompleted> biogasWfacade;
        private IWritableFacade<RVEDDGalreadycompleted> RVEDDGWfacade;
        private IWritableFacade<SSYalreadyCompletedModel> SSYWfacade;
        private IWritableFacade<InspectionInProgressModel> IPWfacade;
        private IWritableFacade<OnGridPowerPlantAlreadyCompletedModel> OnGridPPWfacade;
        private IWritableFacade<MiniMastAlreadyCompletedModel> MiniMastWfacade;
        private IWritableFacade<SSYInProgressModel>SSYInProgressWfacade;

        public HomeController(IWritableFacade<GrievanceModel> grievanceWfacade,
            IWritableFacade<JJMAlreadyCompletedModel> jjmWfacade,
            IWritableFacade<otherthanjjmalreadycompleted> OTjjmWfacade,
            IWritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted> OTRVEDDGWfacade,
            IWritableFacade<HighMastAlreadyCompletedmodel> HighMastWfacade,
            IWritableFacade<biogasalreadycompleted> biogasWfacade,
            IWritableFacade<RVEDDGalreadycompleted> RVEDDGWfacade,
            IWritableFacade<SSYalreadyCompletedModel> SSYWfacade,
            IWritableFacade<InspectionInProgressModel> IPWfacade,
            IWritableFacade<OnGridPowerPlantAlreadyCompletedModel> OnGridPPWfacade,
            IWritableFacade<MiniMastAlreadyCompletedModel> MiniMastWfacade,
            IWritableFacade<SSYInProgressModel> SSYInProgressWfacade

            )
        {
            this.grievanceWfacade = grievanceWfacade;
            this.jjmWfacade = jjmWfacade;
            this.OTjjmWfacade = OTjjmWfacade;
            this.biogasWfacade = biogasWfacade;
            this.RVEDDGWfacade = RVEDDGWfacade;
            this.OTRVEDDGWfacade = OTRVEDDGWfacade;
            this.HighMastWfacade = HighMastWfacade;
            this.SSYWfacade = SSYWfacade;
            this.IPWfacade = IPWfacade;
            this.OnGridPPWfacade = OnGridPPWfacade;
            this.MiniMastWfacade = MiniMastWfacade;
            this.SSYInProgressWfacade = SSYInProgressWfacade;



        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetBioGasListRishant()
        {
            var BioGasList = biogasWfacade.ListAllAsync().Result.ToList();

            if (BioGasList == null || !BioGasList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Bio Gas";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var BioGas in BioGasList)
            {
                // Use reflection to get the property names and their data types
                var attributes = BioGas.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(BioGas),
                                              Id = BioGas.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetGrievanceListRishant()
        {
            var grievanceList = grievanceWfacade.ListAllAsync().Result.ToList();

            if (grievanceList == null || !grievanceList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Grievance";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var grievance in grievanceList)
            {
                // Use reflection to get the property names and their data types
                var attributes = grievance.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(grievance),
                                              Id = grievance.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }
            
            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public async Task<JsonResult> GetJJMListRishant()
        {
            var JJMList = new List<JJMAlreadyCompletedModel>();
            long number = 1;

            for (int i = 0; i <= 1000; i++)
            {
                var JJMData = await jjmWfacade.GetAsync(number);
                if (JJMData != null)
                {
                    JJMList.Add(JJMData);
                }

                number++; // Increment the number for the next iteration
            }

            if (!JJMList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            string baseFolder = "JJM";

            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            foreach (var JJM in JJMList)
            {
                var attributes = JJM.GetType().GetProperties()
                                      .Where(prop => prop.PropertyType == typeof(byte[]))
                                      .Select(prop => new
                                      {
                                          Name = prop.Name,
                                          Value = (byte[])prop.GetValue(JJM),
                                          Id = JJM.Id
                                      })
                                      .ToList();

                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }



        [HttpGet]
        public JsonResult GetOTJJMListRishant()
        {
            var OTJJMList = OTjjmWfacade.ListAllAsync().Result.ToList();

            if (OTJJMList == null || !OTJJMList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Other Than JJM";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var OTJJM in OTJJMList)
            {
                // Use reflection to get the property names and their data types
                var attributes = OTJJM.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(OTJJM),
                                              Id = OTJJM.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetRVEDDGListRishant()
        {
            var RVEDDGList = RVEDDGWfacade.ListAllAsync().Result.ToList();

            if (RVEDDGList == null || !RVEDDGList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "RVE DDG";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var RVEDDG in RVEDDGList)
            {
                // Use reflection to get the property names and their data types
                var attributes = RVEDDG.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(RVEDDG),
                                              Id = RVEDDG.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetOTRVEDDGListRishant()
        {
            var OTRVEDDGList = OTRVEDDGWfacade.ListAllAsync().Result.ToList();

            if (OTRVEDDGList == null || !OTRVEDDGList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Other Than RVE DDG";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var OTRVEDDG in OTRVEDDGList)
            {
                // Use reflection to get the property names and their data types
                var attributes = OTRVEDDG.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(OTRVEDDG),
                                              Id = OTRVEDDG.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }


        [HttpGet]
        public JsonResult GetHghMastListRishant()
        {
            var HighMastList = HighMastWfacade.ListAllAsync().Result.ToList();

            if (HighMastList == null || !HighMastList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "High Mast";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var HighMast in HighMastList)
            {
                // Use reflection to get the property names and their data types
                var attributes = HighMast.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(HighMast),
                                              Id = HighMast.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetSSYListRishant()
        {
            var SSYList = SSYWfacade.ListAllAsync().Result.ToList();

            if (SSYList == null || !SSYList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "SSY";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var SSY in SSYList)
            {
                // Use reflection to get the property names and their data types
                var attributes = SSY.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(SSY),
                                              Id = SSY.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetInspectionInProgressListRishant()
        {
            var IPList = IPWfacade.ListAllAsync().Result.ToList();

            if (IPList == null || !IPList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Inspection In Progress";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var item in IPList)
            {
                // Use reflection to get the property names and their data types
                var attributes = item.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(item),
                                              Id = item.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetOnGridPowerPlantListRishant()
        {
            var IPList = OnGridPPWfacade.ListAllAsync().Result.ToList();

            if (IPList == null || !IPList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "OnGrid Power Plant";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var item in IPList)
            {
                // Use reflection to get the property names and their data types
                var attributes = item.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(item),
                                              Id = item.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetMiniMastListRishant()
        {
            var IPList = MiniMastWfacade.ListAllAsync().Result.ToList();

            if (IPList == null || !IPList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "Mini Mast";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var item in IPList)
            {
                // Use reflection to get the property names and their data types
                var attributes = item.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(item),
                                              Id = item.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }


        [HttpGet]
        public JsonResult GetSSYIPListRishant()
        {
            var IPList = SSYInProgressWfacade.ListAllAsync().Result.ToList();

            if (IPList == null || !IPList.Any())
            {
                return Json(new { Success = false, Message = "No grievance data found." });
            }

            // Get the table name to use as the base folder name (assuming it's "Grievance")
            string baseFolder = "SSY InProgress";

            // Ensure the base folder exists
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Iterate over the list of grievances
            foreach (var item in IPList)
            {
                // Use reflection to get the property names and their data types
                var attributes = item.GetType().GetProperties()
                                          .Where(prop => prop.PropertyType == typeof(byte[]))
                                          .Select(prop => new
                                          {
                                              Name = prop.Name,
                                              Value = (byte[])prop.GetValue(item),
                                              Id = item.Id
                                          })
                                          .ToList();

                // Iterate over the byte[] properties and save them as images
                foreach (var attr in attributes)
                {
                    if (attr.Value != null && attr.Value.Length > 0)
                    {
                        // Create a subfolder for the byte[] property
                        string subFolder = Path.Combine(baseFolder, attr.Name);
                        if (!Directory.Exists(subFolder))
                        {
                            Directory.CreateDirectory(subFolder);
                        }

                        // Define the file path for the image (e.g., "Grievance/FaultImage/123.jpg")
                        string imagePath = Path.Combine(subFolder, $"{attr.Id}.jpg");

                        // Save the byte[] as an image file
                        System.IO.File.WriteAllBytes(imagePath, attr.Value);
                    }
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        [HttpGet]
        public JsonResult GetGrievanceList()
        {
            var GrievanceList = grievanceWfacade.ListAllAsync().Result.ToList();
            //var JJMList = jjmWfacade.ListAllAsync().Result.ToList();
            //var OTJJMList = OTjjmWfacade.ListAllAsync().Result.ToList();



            // Base folder named after the table
            string baseFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grievance");
            Directory.CreateDirectory(baseFolderPath);

            foreach (var grievance in GrievanceList)
            {
                // Check for each byte[] property and create subfolder if necessary
                if (grievance.FaultImage != null && grievance.FaultImage.Length > 0)
                {
                    string faultImagePath = Path.Combine(baseFolderPath, "FaultImage");
                    Directory.CreateDirectory(faultImagePath);
                    System.IO.File.WriteAllBytes(Path.Combine(faultImagePath, $"{grievance.Id}.jpg"), grievance.FaultImage);
                }

                if (grievance.MobilePhoto != null && grievance.MobilePhoto.Length > 0)
                {
                    string mobilePhotoPath = Path.Combine(baseFolderPath, "MobilePhoto");
                    Directory.CreateDirectory(mobilePhotoPath);
                    System.IO.File.WriteAllBytes(Path.Combine(mobilePhotoPath, $"{grievance.Id}.jpg"), grievance.MobilePhoto);
                }

                if (grievance.CertificatePhoto != null && grievance.CertificatePhoto.Length > 0)
                {
                    string certificatePhotoPath = Path.Combine(baseFolderPath, "CertificatePhoto");
                    Directory.CreateDirectory(certificatePhotoPath);
                    System.IO.File.WriteAllBytes(Path.Combine(certificatePhotoPath, $"{grievance.Id}.jpg"), grievance.CertificatePhoto);
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }

        public JsonResult GetGrievanceListRavi()
        {
            var GrievanceList = grievanceWfacade.ListAllAsync().Result.ToList();
            //var JJMList = jjmWfacade.ListAllAsync().Result.ToList();
            //var OTJJMList = OTjjmWfacade.ListAllAsync().Result.ToList();





            // Base folder named after the table
            string baseFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grievance");
            Directory.CreateDirectory(baseFolderPath);

            foreach (var grievance in GrievanceList)
            {
                // Check for each byte[] property and create subfolder if necessary
                if (grievance.FaultImage != null && grievance.FaultImage.Length > 0)
                {
                    string faultImagePath = Path.Combine(baseFolderPath, "FaultImage");
                    Directory.CreateDirectory(faultImagePath);
                    System.IO.File.WriteAllBytes(Path.Combine(faultImagePath, $"{grievance.Id}.jpg"), grievance.FaultImage);
                }

                if (grievance.MobilePhoto != null && grievance.MobilePhoto.Length > 0)
                {
                    string mobilePhotoPath = Path.Combine(baseFolderPath, "MobilePhoto");
                    Directory.CreateDirectory(mobilePhotoPath);
                    System.IO.File.WriteAllBytes(Path.Combine(mobilePhotoPath, $"{grievance.Id}.jpg"), grievance.MobilePhoto);
                }

                if (grievance.CertificatePhoto != null && grievance.CertificatePhoto.Length > 0)
                {
                    string certificatePhotoPath = Path.Combine(baseFolderPath, "CertificatePhoto");
                    Directory.CreateDirectory(certificatePhotoPath);
                    System.IO.File.WriteAllBytes(Path.Combine(certificatePhotoPath, $"{grievance.Id}.jpg"), grievance.CertificatePhoto);
                }
            }

            return Json(new { Success = true, Message = "Images saved successfully" });
        }
    }
}
