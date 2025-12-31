
using CredaData.Client;
using CredaData.Client.Models;
using CredaData.Common.Model;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System.Net;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(a => (IWebContextModel)ActivatorUtilities.CreateInstance<WebContextModel>
                (a, "https://creda.binomial.in/api", "deviceUniqueId", "authApiKey", new CookieContainer()));
builder.Services.AddSingleton<IFacade<UserModel>, Facade<UserModel>>();
builder.Services.AddSingleton<IFacade<RoleModel>, Facade<RoleModel>>();

builder.Services.AddSingleton<IFacade<DistrictModel>, Facade<DistrictModel>>();
builder.Services.AddSingleton<IWritableFacade<DistrictModel>, WritableFacade<DistrictModel>>();

builder.Services.AddSingleton<IFacade<BlockModel>, Facade<BlockModel>>();
builder.Services.AddSingleton<IWritableFacade<BlockModel>, WritableFacade<BlockModel>>();

builder.Services.AddSingleton<IFacade<ProjectModel>, Facade<ProjectModel>>();
builder.Services.AddSingleton<IWritableFacade<ProjectModel>, WritableFacade<ProjectModel>>();

builder.Services.AddSingleton<IFacade<VillageModel>, Facade<VillageModel>>();
builder.Services.AddSingleton<IWritableFacade<VillageModel>, WritableFacade<VillageModel>>();

builder.Services.AddSingleton<IFacade<SiteModel>, Facade<SiteModel>>();
builder.Services.AddSingleton<IWritableFacade<SiteModel>, WritableFacade<SiteModel>>();

builder.Services.AddSingleton<IFacade<SiteProjectModel>, Facade<SiteProjectModel>>();
builder.Services.AddSingleton<IWritableFacade<SiteProjectModel>, WritableFacade<SiteProjectModel>>();

builder.Services.AddSingleton<IFacade<StageModel>, Facade<StageModel>>();
builder.Services.AddSingleton<IWritableFacade<StageModel>, WritableFacade<StageModel>>();

builder.Services.AddSingleton<IFacade<UserModel>, Facade<UserModel>>();
builder.Services.AddSingleton<IWritableFacade<UserModel>, WritableFacade<UserModel>>();

builder.Services.AddSingleton<IFacade<GrievanceModel>, Facade<GrievanceModel>>();
builder.Services.AddSingleton<IWritableFacade<GrievanceModel>, WritableFacade<GrievanceModel>>();

builder.Services.AddSingleton<IFacade<InspectionInProgressModel>, Facade<InspectionInProgressModel>>();
builder.Services.AddSingleton<IWritableFacade<InspectionInProgressModel>, WritableFacade<InspectionInProgressModel>>();

builder.Services.AddSingleton<IFacade<SystemIntegratorModel>, Facade<SystemIntegratorModel>>();
builder.Services.AddSingleton<IWritableFacade<SystemIntegratorModel>, WritableFacade<SystemIntegratorModel>>();
//Testing
builder.Services.AddSingleton<IFacade<otherthanjjmalreadycompleted>, Facade<otherthanjjmalreadycompleted>>();
builder.Services.AddSingleton<IWritableFacade<otherthanjjmalreadycompleted>, WritableFacade<otherthanjjmalreadycompleted>>();

builder.Services.AddSingleton<IFacade<StageModel>, Facade<StageModel>>();

builder.Services.AddSingleton<IFacade<biogasalreadycompleted>, Facade<biogasalreadycompleted>>();
builder.Services.AddSingleton<IWritableFacade<biogasalreadycompleted>, WritableFacade<biogasalreadycompleted>>();

builder.Services.AddSingleton<IFacade<SSYInspectionInProgress>, Facade<SSYInspectionInProgress>>();
builder.Services.AddSingleton<IWritableFacade<SSYInspectionInProgress>, WritableFacade<SSYInspectionInProgress>>();

builder.Services.AddSingleton<IFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>, Facade<OtherThanRVEDDGMonitoringAlreadyCompleted>>();
builder.Services.AddSingleton<IWritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>, WritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>>();

builder.Services.AddSingleton<IFacade<SSYalreadyCompletedModel>, Facade<SSYalreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<SSYalreadyCompletedModel>, WritableFacade<SSYalreadyCompletedModel>>();

builder.Services.AddSingleton<IFacade<JJMAlreadyCompletedModel>, Facade<JJMAlreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<JJMAlreadyCompletedModel>, WritableFacade<JJMAlreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<OfflinePassModel>, WritableFacade<OfflinePassModel>>();

builder.Services.AddSingleton<IFacade<ZonalModel>, Facade<ZonalModel>>();
builder.Services.AddSingleton<IWritableFacade<ZonalModel>, WritableFacade<ZonalModel>>();

builder.Services.AddSingleton<IFacade<DistrictandZonalModel>, Facade<DistrictandZonalModel>>();
builder.Services.AddSingleton<IWritableFacade<DistrictandZonalModel>, WritableFacade<DistrictandZonalModel>>();

builder.Services.AddSingleton<IFacade<OfficeLevelModel>, Facade<OfficeLevelModel>>();
builder.Services.AddSingleton<IWritableFacade<OfficeLevelModel>, WritableFacade<OfficeLevelModel>>();

builder.Services.AddSingleton<IFacade<ForwardingGrievanceModel>, Facade<ForwardingGrievanceModel>>();
builder.Services.AddSingleton<IWritableFacade<ForwardingGrievanceModel>, WritableFacade<ForwardingGrievanceModel>>();

builder.Services.AddSingleton<IFacade<VwJJMAlreadyCompletedListModel>, Facade<VwJJMAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwJJMAlreadyCompletedModel>, Facade<VwJJMAlreadyCompletedModel>>();
builder.Services.AddSingleton<IFacade<VwOTJJMAlreadyCompletedListModel>, Facade<VwOTJJMAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwOTJJMAlreadyCompletedModel>, Facade<VwOTJJMAlreadyCompletedModel>>();
builder.Services.AddSingleton<IFacade<VwSSYAlreadyCompletedListModel>, Facade<VwSSYAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwSSYalreadyCompletedDetailModel>, Facade<VwSSYalreadyCompletedDetailModel>>();
builder.Services.AddSingleton<IFacade<UserProfileModel>, Facade<UserProfileModel>>();
builder.Services.AddSingleton<IFacade<VwOTRVEDDGAlreadyCompletedListModel>, Facade<VwOTRVEDDGAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwOtherThanRVEDDGMonitoringAlreadyCompleted>, Facade<VwOtherThanRVEDDGMonitoringAlreadyCompleted>>();
builder.Services.AddSingleton<IFacade<VwRVEDDGAlreadyCompletedListModel>, Facade<VwRVEDDGAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwRVEDDGalreadycompletedModel>, Facade<VwRVEDDGalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwHMAlreadyCompletedListModel>, Facade<VwHMAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwHMalreadycompletedModel>, Facade<VwHMalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwMMAlreadyCompletedListModel>, Facade<VwMMAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwMMalreadycompletedModel>, Facade<VwMMalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwBiogasAlreadyCompletedListModel>, Facade<VwBiogasAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwBiogasalreadycompletedModel>, Facade<VwBiogasalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwOGPPAlreadyCompletedListModel>, Facade<VwOGPPAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwOGPPalreadycompletedModel>, Facade<VwOGPPalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwCMGGYAlreadyCompletedListModel>, Facade<VwCMGGYAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwCMGGYalreadycompletedModel>, Facade<VwCMGGYalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwCIAlreadyCompletedListModel>, Facade<VwCIAlreadyCompletedListModel>>();
builder.Services.AddSingleton<IFacade<VwCIalreadycompletedModel>, Facade<VwCIalreadycompletedModel>>();
builder.Services.AddSingleton<IFacade<VwProjectWorkingCountModel>, Facade<VwProjectWorkingCountModel>>();

builder.Services.AddSingleton<IFacade<VwGrievanceListModel>, Facade<VwGrievanceListModel>>();
builder.Services.AddSingleton<IFacade<VwGrievanceModel>, Facade<VwGrievanceModel>>();
builder.Services.AddSingleton<IFacade<AreaBasedGrievanceCountModel>, Facade<AreaBasedGrievanceCountModel>>();
builder.Services.AddSingleton<IWritableFacade<AreaBasedGrievanceCountModel>, WritableFacade<AreaBasedGrievanceCountModel>>();
builder.Services.AddSingleton<IFacade<VwVillageWiseGrievanceModel>, Facade<VwVillageWiseGrievanceModel>>();
builder.Services.AddSingleton<IFacade<VWInspectionInProgressListModel>, Facade<VWInspectionInProgressListModel>>();
builder.Services.AddSingleton<IFacade<VWInspectionInProgressModel>, Facade<VWInspectionInProgressModel>>();
builder.Services.AddSingleton<IFacade<TrackGrievanceModel>, Facade<TrackGrievanceModel>>();
builder.Services.AddSingleton<IFacade<VwUserModel>, Facade<VwUserModel>>();
builder.Services.AddSingleton<IFacade<VwSiteModel>, Facade<VwSiteModel>>();
builder.Services.AddSingleton<IFacade<GrievanceCountModel>, Facade<GrievanceCountModel>>();

builder.Services.AddSingleton<IFacade<ShowProjectReportModel>, Facade<ShowProjectReportModel>>();
builder.Services.AddSingleton<IFacade<DownloadProjectReportModel>, Facade<DownloadProjectReportModel>>();

builder.Services.AddSingleton<IFacade<AdminPanelUserModel>, Facade<AdminPanelUserModel>>();
builder.Services.AddSingleton<IWritableFacade<AdminPanelUserModel>, WritableFacade<AdminPanelUserModel>>();

builder.Services.AddSingleton<IFacade<VwSSYInspectionInProgressListModel>, Facade<VwSSYInspectionInProgressListModel>>();
builder.Services.AddSingleton<IFacade<VwProjectReportListWithCount>, Facade<VwProjectReportListWithCount>>();

builder.Services.AddSingleton<IFacade<DownloadJJMACListModel>, Facade<DownloadJJMACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadOTJJMACListModel>, Facade<DownloadOTJJMACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadSSYACListModel>, Facade<DownloadSSYACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadCMGGYACListModel>, Facade<DownloadCMGGYACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadCIACListModel>, Facade<DownloadCIACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadRVEDDGACListModel>, Facade<DownloadRVEDDGACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadOTRVEDDGACListModel>, Facade<DownloadOTRVEDDGACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadOGPPACListModel>, Facade<DownloadOGPPACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadHMACListModel>, Facade<DownloadHMACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadMMACListModel>, Facade<DownloadMMACListModel>>();
builder.Services.AddSingleton<IFacade<DownloadBioGasListModel>, Facade<DownloadBioGasListModel>>();
builder.Services.AddSingleton<IFacade<DownloadSSYInspectionIPListModel>, Facade<DownloadSSYInspectionIPListModel>>();
builder.Services.AddSingleton<IFacade<DownloadInspectionIPListModel>, Facade<DownloadInspectionIPListModel>>();
builder.Services.AddSingleton<IFacade<DownloadGrievanceListModel>, Facade<DownloadGrievanceListModel>>();
builder.Services.AddSingleton<IFacade<GrievanceGlanceCountModel>, Facade<GrievanceGlanceCountModel>>();
builder.Services.AddSingleton<IFacade<VwSSYRegistrationFormModel>, Facade<VwSSYRegistrationFormModel>>();
builder.Services.AddSingleton<IFacade<VwComplaintListModel>, Facade<VwComplaintListModel>>();
builder.Services.AddSingleton<IFacade<VwRegisteredComplaintModel>, Facade<VwRegisteredComplaintModel>>();
builder.Services.AddSingleton<IFacade<ForwardedGrievanceListModel>, Facade<ForwardedGrievanceListModel>>();
builder.Services.AddSingleton<IFacade<ForwardedGrievanceDetailModel>, Facade<ForwardedGrievanceDetailModel>>();

builder.Services.AddSingleton<IFacade<VwAdminPanelUserModel>, Facade<VwAdminPanelUserModel>>();
builder.Services.AddSingleton<IFacade<UserWiseAllProjectCountsAdminModel>, Facade<UserWiseAllProjectCountsAdminModel>>();
builder.Services.AddSingleton<IFacade<UserWiseProjectWiseListModel>, Facade<UserWiseProjectWiseListModel>>();
builder.Services.AddSingleton<IFacade<UserListByZonalModel>, Facade<UserListByZonalModel>>();
builder.Services.AddSingleton<IFacade<GrievanceGlanceListModel>, Facade<GrievanceGlanceListModel>>();
builder.Services.AddSingleton<IFacade<ComplaintListNotificationModel>, Facade<ComplaintListNotificationModel>>();
builder.Services.AddSingleton<IFacade<GrievanceListNotificationModel>, Facade<GrievanceListNotificationModel>>();

builder.Services.AddSingleton<IFacade<SSYRegistrationModel>, Facade<SSYRegistrationModel>>();
builder.Services.AddSingleton<IWritableFacade<SSYRegistrationModel>, WritableFacade<SSYRegistrationModel>>();

builder.Services.AddSingleton<IFacade<SSYPaymentMasterModel>, Facade<SSYPaymentMasterModel>>();
builder.Services.AddSingleton<IWritableFacade<SSYPaymentMasterModel>, WritableFacade<SSYPaymentMasterModel>>();

builder.Services.AddSingleton<IFacade<BankDetailModel>, Facade<BankDetailModel>>();
builder.Services.AddSingleton<IWritableFacade<BankDetailModel>, WritableFacade<BankDetailModel>>();

builder.Services.AddSingleton<IFacade<ComplaintRegisterModel>, Facade<ComplaintRegisterModel>>();
builder.Services.AddSingleton<IWritableFacade<ComplaintRegisterModel>, WritableFacade<ComplaintRegisterModel>>();

builder.Services.AddSingleton<IFacade<ComplaintAuditModel>, Facade<ComplaintAuditModel>>();
builder.Services.AddSingleton<IWritableFacade<ComplaintAuditModel>, WritableFacade<ComplaintAuditModel>>();

builder.Services.AddSingleton<IFacade<ComplaintStatusHistoryModel>, Facade<ComplaintStatusHistoryModel>>();
builder.Services.AddSingleton<IWritableFacade<ComplaintStatusHistoryModel>, WritableFacade<ComplaintStatusHistoryModel>>();

builder.Services.AddSingleton<IFacade<ComplaintActionModel>, Facade<ComplaintActionModel>>();
builder.Services.AddSingleton<IWritableFacade<ComplaintActionModel>, WritableFacade<ComplaintActionModel>>();

builder.Services.AddSingleton<IFacade<ComplaintEscalationModel>, Facade<ComplaintEscalationModel>>();
builder.Services.AddSingleton<IWritableFacade<ComplaintEscalationModel>, WritableFacade<ComplaintEscalationModel>>();

builder.Services.AddSingleton<IFacade<SIUserModel>, Facade<SIUserModel>>();
builder.Services.AddSingleton<IWritableFacade<SIUserModel>, WritableFacade<SIUserModel>>();

builder.Services.AddSingleton<IFacade<GrievanceAnalyticsDataModel>, Facade<GrievanceAnalyticsDataModel>>();

builder.Services.AddSingleton<IFacade<GrievanceRevertionModel>, Facade<GrievanceRevertionModel>>();
builder.Services.AddSingleton<IWritableFacade<GrievanceRevertionModel>, WritableFacade<GrievanceRevertionModel>>();

builder.Services.AddSingleton<IFacade<GrievanceDeleteLogModel>, Facade<GrievanceDeleteLogModel>>();
builder.Services.AddSingleton<IWritableFacade<GrievanceDeleteLogModel>, WritableFacade<GrievanceDeleteLogModel>>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/LoginBasic";
        options.LogoutPath = "/Auth/Logout";
    });

builder.Services.AddAuthorization(options =>
{
    // Require authentication globally
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
var app = builder.Build();

var rotativaPath = Path.Combine(app.Environment.WebRootPath, "");
RotativaConfiguration.Setup(rotativaPath);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

