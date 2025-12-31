using System.Diagnostics;
using System.Linq.Expressions;
using CredaData.Client;
using CredaData.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;
[Authorize]
public class DashboardsController : Controller
{

    private IFacade<SiteProjectModel> siteProjectIFacade;
    private IFacade<GrievanceCountModel> gIFacade;
    private IFacade<InspectionInProgressModel> IIFacade;
    private IFacade<AreaBasedGrievanceCountModel> abgIFacade;
    private IFacade<VwVillageWiseGrievanceModel> vsgIFacade;
    private IFacade<TrackGrievanceModel> tgIFacade;
    private IWritableFacade<OfflinePassModel> offlinePassIFacade;
    public DashboardsController(IFacade<SiteProjectModel> siteProjectIFacade,
        IFacade<GrievanceCountModel> gIFacade, 
        IFacade<InspectionInProgressModel> iIFacade, 
        IFacade<AreaBasedGrievanceCountModel> abgIFacade,
        IFacade<VwVillageWiseGrievanceModel> vsgIFacade,
        IFacade<TrackGrievanceModel> tgIFacade,
        IWritableFacade<OfflinePassModel> offlinePassIFacade)
    {
        this.siteProjectIFacade = siteProjectIFacade;
        this.gIFacade = gIFacade;
        IIFacade = iIFacade;
        this.abgIFacade = abgIFacade;
        this.vsgIFacade= vsgIFacade;
        this.tgIFacade = tgIFacade;
        this.offlinePassIFacade = offlinePassIFacade;
    }
    public async Task<IActionResult> Index() {
        AnalyticsModel analytics = new AnalyticsModel();

       //OfflinePassModel pass=new OfflinePassModel();
       // pass.MobileNumber = "8871162225"; ;
       // pass.Password = "admin test";
       // await offlinePassIFacade.InsertAsync(pass);


        Expression<Func<SiteProjectModel, bool>> workingfilter = a => a.IsWorking == "Working";
        analytics.TotalMonitoredSystem = await siteProjectIFacade.Count();
        analytics.TotalWorkingSystems = await siteProjectIFacade.Count(workingfilter);
        analytics.FaultySystems = analytics.TotalMonitoredSystem - analytics.TotalWorkingSystems;
        var gdata = await gIFacade.GetCountAsync();
        analytics.TotalReportSubmission = await IIFacade.Count();


        //ParamModel paramModel = new ParamModel();
        //paramModel.DistrictId = 7;
        //paramModel.StatusName = "Verified";
        //var resg = await abgIFacade.GetList(paramModel);
        //var res = await vsgIFacade.GetList(0, 33, "Closed");
        //var res1 = await vsgIFacade.GetList(0, 33, "Open");
        //var res2 = await vsgIFacade.GetList(0, 33, "InProgress");
        //var res3 = await vsgIFacade.GetList(0, 33, "Verified");
        //var tgres =await tgIFacade.GetList(50);


        ////Testing
        //analytics.TotalMonitoredSystem = 0;
        //analytics.TotalWorkingSystems = 0;
        //analytics.FaultySystems = 0;
        analytics.TotalGrievances = gdata.TotalGrievanceCount;
        //analytics.TotalReportSubmission = 0;
        return View(analytics);
    }

    public async Task<IActionResult> LandingPage()
    {
        return View();
    }

    public async Task<IActionResult> MonitoringHome()
    {
        return View();
    }

    public async Task<IActionResult> GrievanceReporting()
    {
        return View();
    }

}