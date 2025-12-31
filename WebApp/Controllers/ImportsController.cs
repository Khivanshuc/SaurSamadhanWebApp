using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.Models;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Threading.Tasks;
using CredaData.Client;
using System.Linq;

namespace WebApp.Controllers
{
    public class ImportsController : Controller
    {
        private IWritableFacade<DistrictModel> distWFacade;
        private IFacade<DistrictModel> distIFacade;
        private IWritableFacade<BlockModel> blockWFacade;
        private IFacade<BlockModel> blockIFacade;
        private IWritableFacade<ProjectModel> projectWFacade;
        private IFacade<ProjectModel> projectIFacade;
        private IWritableFacade<VillageModel> villlageWFacade;
        private IFacade<VillageModel> villageIFacade;
        private IWritableFacade<SiteModel> siteWFacade;
        private IFacade<SiteModel> siteIFacade;
        private IWritableFacade<SiteProjectModel> siteProjectWFacade;
        private IFacade<SiteProjectModel> siteProjectIFacade;
        private IWritableFacade<StageModel> stageWFacade;
        private IFacade<StageModel> stageIFacade;
        public ImportsController(IWritableFacade<DistrictModel> distWFacade, IFacade<DistrictModel> distIFacade, IWritableFacade<BlockModel> blockWFacade, IFacade<BlockModel> blockIFacade, IWritableFacade<ProjectModel> projectWFacade, IFacade<ProjectModel> projectIFacade, IWritableFacade<VillageModel> villlageWFacade, IFacade<VillageModel> villageIFacade, IWritableFacade<SiteModel> siteWFacade, IFacade<SiteModel> siteIFacade, IWritableFacade<SiteProjectModel> siteProjectWFacade, IFacade<SiteProjectModel> siteProjectIFacade, IWritableFacade<StageModel> stageWFacade, IFacade<StageModel> stageIFacade)
        {
            this.distWFacade = distWFacade;
            this.distIFacade = distIFacade;
            this.blockWFacade = blockWFacade;
            this.blockIFacade = blockIFacade;
            this.projectWFacade = projectWFacade;
            this.projectIFacade = projectIFacade;
            this.villageIFacade = villageIFacade;
            this.villlageWFacade = villlageWFacade;
            this.siteWFacade = siteWFacade;
            this.siteIFacade = siteIFacade;
            this.siteProjectIFacade = siteProjectIFacade;
            this.siteProjectWFacade = siteProjectWFacade;
            this.stageIFacade = stageIFacade;
            this.stageWFacade = stageWFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Block()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImportProject(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<ProjectModel> projects = MapDataTableToProjects(dataset.Tables[0]);
                        var projectResult = InsertProjects(projects);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportSite(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<VwSiteModel> sites = MapDataTableToSites(dataset.Tables[0]);
                        var sitResult = InsertSite(sites);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportSiteAndProject(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<VwSiteProjectModel> siteProjects = MapDataTableToSiteProjects(dataset.Tables[0]);
                        var siteProjectResult = InsertSiteProject(siteProjects);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportDistrict(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<DistrictModel> district = MapDataTableToDistricts(dataset.Tables[0]);
                        var distResult = InsertDistrict(district);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportBlock(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<VwBlockModel> blocks = MapDataTableToBlocks(dataset.Tables[0]);
                        var blockResult = InsertBlock(blocks);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportVillage(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<VwVillageModel> villages = MapDataTableToVillages(dataset.Tables[0]);
                        var villageResult = InsertVillage(villages);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ImportAll(ImportFiles model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var dataset = await ReadExcelFile(model.File);

                    if (dataset != null && dataset.Tables.Count > 0)
                    {
                        List<DistrictModel> district = MapDataTableToDistricts(dataset.Tables[0]);
                        var distResult = InsertDistrict(district);

                        List<VwBlockModel> blocks = MapDataTableToBlocks(dataset.Tables[0]);
                        var blockResult = InsertBlock(blocks);

                        List<ProjectModel> projects = MapDataTableToProjects(dataset.Tables[0]);
                        var projectResult = InsertProjects(projects);

                        for (int i = 0; i < dataset.Tables.Count; i++)
                        {
                            List<VwVillageModel> villages = MapDataTableToVillages(dataset.Tables[0]);
                            var villageResult = InsertVillage(villages);
                        }


                        List<VwSiteModel> sites = MapDataTableToSites(dataset.Tables[0]);
                        var sitResult = InsertSite(sites);

                        List<VwSiteProjectModel> siteProjects = MapDataTableToSiteProjects(dataset.Tables[0]);
                        var siteProjectResult = InsertSiteProject(siteProjects);

                        List<VwStageModel> stages = MapDataTableTostage(dataset.Tables[0]);
                        var stagesResult = InsertStage(stages);
                        return Ok("Data Inserted");
                    }
                    else
                    {
                        return BadRequest("No data found in the Excel file.");
                    }
                }
                else
                {
                    return BadRequest("No file selected or file is empty.");
                }
            }
            else
            {
                return BadRequest("Model validation failed.");
            }
        }
        private async Task<DataSet> ReadExcelFile(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var dataset = new DataSet();

                using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileStream, false))
                {
                    WorkbookPart workbookPart = document.WorkbookPart;
                    foreach (Sheet sheet in workbookPart.Workbook.Descendants<Sheet>())
                    {

                        try
                        {


                            DataTable table = new DataTable(sheet.Name.ToString());
                            WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                            int rowIndex = 0;
                            foreach (Row row in sheetData.Elements<Row>())
                            {


                                // Assuming the first row contains column headers
                                if (rowIndex == 0)
                                {
                                    foreach (Cell cell in row.Elements<Cell>())
                                    {
                                        table.Columns.Add(GetCellValue(workbookPart, cell));
                                    }
                                }
                                else
                                {

                                    DataRow newRow = table.NewRow();
                                    int columnIndex = 0;
                                    foreach (Cell cell in row.Elements<Cell>())
                                    {
                                        newRow[columnIndex] = GetCellValue(workbookPart, cell);
                                        columnIndex++;
                                    }
                                    table.Rows.Add(newRow);
                                }

                                rowIndex++;
                            }

                            dataset.Tables.Add(table);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }

                return dataset;
            }
        }
        private string GetCellValue(WorkbookPart workbookPart, Cell cell)
        {
            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                SharedStringTablePart stringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                if (stringTablePart != null)
                {
                    SharedStringItem sharedStringItem = (SharedStringItem)stringTablePart.SharedStringTable.ElementAt(int.Parse(cell.InnerText));
                    return sharedStringItem.Text.Text;
                }
            }
            else if (cell.CellValue != null)
            {
                return cell.CellValue.InnerText;
            }

            return null;
        }
        private List<DistrictModel> MapDataTableToDistricts(DataTable dataTable)
        {
            var districts = new List<DistrictModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var district = new DistrictModel
                {
                    Id = 0,
                    DistrictName = row[0].ToString(),
                    DistrictId = 0,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "System",
                    UpdatedOn = DateTime.Now
                };

                districts.Add(district);
            }

            return districts;
        }

        private bool InsertDistrict(List<DistrictModel> district)
        {
            foreach (var item in district)
            {
                var districtList = distIFacade.ListAllAsync().Result;
                var districtIdNameList = districtList.Select(s => new { s.Id, s.DistrictName });
                var DistId = districtIdNameList
                   .Where(d => d.DistrictName == item.DistrictName)
                   .Select(s => s.Id).FirstOrDefault();
                if (DistId == 0)
                {
                    var result = distWFacade.InsertAsync(item, "System").Result;
                }
            }
            return true;
        }
        private List<VwBlockModel> MapDataTableToBlocks(DataTable dataTable)
        {
            var districts = new List<VwBlockModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var district = new VwBlockModel
                {
                    BlockName = row[1].ToString(),
                    DistrictName = row[0].ToString()
                };

                districts.Add(district);
            }

            return districts;
        }

        private bool InsertBlock(List<VwBlockModel> blocks)
        {
            var districtListforBlock = distIFacade.ListAllAsync().Result;
            List<BlockModel> blockList = new List<BlockModel>();
            foreach (var item in blocks)
            {
                BlockModel block = new BlockModel();
                var DistId = districtListforBlock
                  .Where(d => d.DistrictName.ToLower() == item.DistrictName.ToLower())
                  .Select(s => s.Id).FirstOrDefault();
                if (DistId != 0)
                {
                    block.UpdatedBy = "System";
                    block.UpdatedOn = DateTime.Now;
                    block.CreatedBy = "System";
                    block.CreatedOn = DateTime.Now;
                    block.DistrictId = DistId;
                    block.BlockName = item.BlockName;
                    block.BlockId = 0;
                    blockList.Add(block);
                }
            }
            foreach (var item in blockList)
            {
                var result = blockWFacade.InsertAsync(item, "System").Result;
            }
            return true;
        }

        private List<ProjectModel> MapDataTableToProjects(DataTable dataTable)
        {
            var projects = new List<ProjectModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var project = new ProjectModel
                {
                    Id = 0,
                    ProjectName = row[5].ToString(),
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "System",
                    UpdatedOn = DateTime.Now
                };

                projects.Add(project);
            }

            return projects;
        }
        private bool InsertProjects(List<ProjectModel> district)
        {
            foreach (var item in district)
            {
                var ProjectsList = projectIFacade.ListAllAsync().Result;
                var districtIdNameList = ProjectsList.Select(s => new { s.Id, s.ProjectName });
                var DistId = districtIdNameList
                   .Where(d => d.ProjectName == item.ProjectName)
                   .Select(s => s.Id).FirstOrDefault();
                if (DistId == 0)
                {
                    var result = projectWFacade.InsertAsync(item, "System").Result;
                }
            }
            return true;
        }

        private List<VwVillageModel> MapDataTableToVillages(DataTable dataTable)
        {
            var villages = new List<VwVillageModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var village = new VwVillageModel
                {
                    BlockName = row[0].ToString(),
                    VillageName = row[1].ToString(),
                    VillageHindiName = row[2].ToString()
                };

                villages.Add(village);
            }

            return villages;
        }
        private bool InsertVillage(List<VwVillageModel> villages)
        {
            var districtListforBlock = distIFacade.ListAllAsync().Result;
            var blockListforVillage = blockIFacade.ListAllAsync().Result;
            List<VillageModel> villageList = new List<VillageModel>();
            foreach (var item in villages)
            {
                VillageModel block = new VillageModel();
                var blockId = blockListforVillage
                  .Where(d => d.BlockName.ToLower() == item.BlockName.ToLower())
                  .Select(s => new { s.Id, s.DistrictId }).FirstOrDefault();

                if (blockId != null)
                {
                    block.UpdatedBy = "System";
                    block.UpdatedOn = DateTime.Now;
                    block.CreatedBy = "System";
                    block.CreatedOn = DateTime.Now;
                    block.BlockId = blockId.Id;
                    block.DistrictId = blockId.DistrictId;
                    block.VillageId = 0;
                    block.VillageName = item.VillageName;
                    block.VillageHindiName = item.VillageHindiName;
                    villageList.Add(block);
                }
                else
                {

                }
            }
            foreach (var item in villageList)
            {
                var ExistvilllageList = villageIFacade.ListAllAsync().Result;
                var isExist = ExistvilllageList.Where(s => s.VillageName == item.VillageName && s.BlockId == item.BlockId && s.DistrictId == item.DistrictId).FirstOrDefault();
                if (isExist == null)
                {
                    var result = villlageWFacade.InsertAsync(item, "System").Result;
                }
            }
            return true;
        }

        private List<VwSiteModel> MapDataTableToSites(DataTable dataTable)
        {
            var sites = new List<VwSiteModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    string value = row[1].ToString().Trim();
                    long SiteId = Convert.ToInt64(value);
                    var site = new VwSiteModel
                    {
                        SiteId = SiteId,
                        SiteName = row[2].ToString(),
                        DistrictName = row[4].ToString(),
                        BlockName = row[4].ToString(),
                        VillageName = row[4].ToString(),
                    };
                    sites.Add(site);
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }


            }

            return sites;
        }
        private bool InsertSite(List<VwSiteModel> sites)
        {
            var districtListforBlock = distIFacade.ListAllAsync().Result;
            var blockListforVillage = blockIFacade.ListAllAsync().Result;
            List<SiteModel> siteList = new List<SiteModel>();
            foreach (var item in sites)
            {
                SiteModel site = new SiteModel();
                var DistId = districtListforBlock
                  .Where(d => d.DistrictName.ToLower() == item.DistrictName.ToLower())
                  .Select(s => s.Id).FirstOrDefault();

                if (DistId != 0)
                {
                    site.UpdatedBy = "System";
                    site.UpdatedOn = DateTime.Now;
                    site.CreatedBy = "System";
                    site.CreatedOn = DateTime.Now;
                    site.BlockId = DistId;
                    site.DistrictId = DistId;
                    site.VillageId = DistId;
                    site.SiteId = item.SiteId;
                    site.SiteName = item.SiteName;
                    siteList.Add(site);
                }
            }
            foreach (var item in siteList)
            {
                var sitelist = siteIFacade.ListAllAsync().Result;
                var IsExist = sitelist.Where(d => d.SiteName.ToLower() == item.SiteName.ToLower()).ToList();
                if (IsExist.Count == 0)
                {
                    var result = siteWFacade.InsertAsync(item, "System").Result;
                }
                else
                {

                }
            }
            return true;
        }

        private List<VwSiteProjectModel> MapDataTableToSiteProjects(DataTable dataTable)
        {
            var siteProjects = new List<VwSiteProjectModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    var CSiteId = (row[1].ToString());
                    var SiteName = row[2].ToString();
                    var ProjectName = row[5].ToString();
                    var Capacity = (row[7].ToString());
                    var SystemIntegrator = row[6].ToString();
                    var InstallationYear = (row[3].ToString());
                    var UpdationDate = (row[8].ToString());
                    var IsWorking = row[9].ToString();
                    var Remark = row[10].ToString();
                    var siteProject = new VwSiteProjectModel
                    {
                        CSiteId = CSiteId.ToString(),
                        SiteName = SiteName,
                        ProjectName = ProjectName,
                        Capacity = Capacity,
                        SystemIntegrator = SystemIntegrator,
                        InstallationYear = InstallationYear,
                        UpdationDate = UpdationDate,
                        IsWorking = IsWorking,
                        Remark = Remark
                    };

                    siteProjects.Add(siteProject);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return siteProjects;
        }
        private bool InsertSiteProject(List<VwSiteProjectModel> siteProjects)
        {
            var sitelist = siteIFacade.ListAllAsync().Result;
            var projectlist = projectIFacade.ListAllAsync().Result;
            List<SiteProjectModel> siteProjectList = new List<SiteProjectModel>();
            foreach (var item in siteProjects)
            {
                var siteDetail = sitelist.Where(s => s.SiteName == item.SiteName).Select(s => new { s.Id }).FirstOrDefault();
                var projectDetail = projectlist.Where(s => s.ProjectName == item.ProjectName).Select(s => new { s.Id }).FirstOrDefault();
                SiteProjectModel siteProject = new SiteProjectModel();
                if (siteDetail != null && projectDetail != null)
                {
                    siteProject.UpdatedBy = "System";
                    siteProject.UpdatedOn = DateTime.Now;
                    siteProject.CreatedBy = "System";
                    siteProject.CreatedOn = DateTime.Now;
                    siteProject.CSiteId = item.CSiteId;
                    siteProject.SiteId = siteDetail.Id;
                    siteProject.ProjectId = projectDetail.Id;
                    siteProject.Capacity = item.Capacity;
                    siteProject.SystemIntegrator = item.SystemIntegrator;
                    siteProject.InstallationYear = item.InstallationYear;
                    siteProject.UpdationDate = item.UpdationDate;
                    siteProject.IsWorking = item.IsWorking;
                    siteProject.Remark = item.Remark;
                    siteProjectList.Add(siteProject);
                }
            }
            foreach (var item in siteProjectList)
            {
                var result = siteProjectWFacade.InsertAsync(item, "System").Result;
            }
            return true;
        }


        private List<VwStageModel> MapDataTableTostage(DataTable dataTable)
        {
            var siteProjects = new List<VwStageModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    var stageId = row[1].ToString();
                    var StageName = row[2].ToString();
                    var ProjectName = row[3].ToString();
                    var stageProject = new VwStageModel
                    {
                        StageId = Convert.ToInt64(stageId),
                        StageName = StageName,
                        ProjectName = ProjectName,
                    };

                    siteProjects.Add(stageProject);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return siteProjects;
        }
        private bool InsertStage(List<VwStageModel> stages)
        {
            var projectlist = projectIFacade.ListAllAsync().Result;
            List<StageModel> stageList = new List<StageModel>();
            foreach (var item in stages)
            {
                var projectDetail = projectlist.Where(s => s.ProjectName == item.ProjectName).Select(s => new { s.Id }).FirstOrDefault();
                StageModel stage = new StageModel();
                if (projectDetail != null)
                {
                    stage.UpdatedBy = "System";
                    stage.UpdatedOn = DateTime.Now;
                    stage.CreatedBy = "System";
                    stage.CreatedOn = DateTime.Now;
                    stage.StageId = stage.Id;
                    stage.ProjectId = projectDetail.Id;
                    stage.StageName = item.StageName;
                    stageList.Add(stage);
                }
            }
            foreach (var item in stageList)
            {
                var result = stageWFacade.InsertAsync(item, "System").Result;
            }
            return true;
        }

    }
}
