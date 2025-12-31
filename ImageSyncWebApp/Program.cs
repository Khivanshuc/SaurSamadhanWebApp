using CredaData.Client;
using ImageSyncWebApp.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(a => (IWebContextModel)ActivatorUtilities.CreateInstance<WebContextModel>
                (a, "https://creda.binomial.in/api", "deviceUniqueId", "authApiKey", new CookieContainer()));

builder.Services.AddSingleton<IFacade<GrievanceModel>, Facade<GrievanceModel>>();
builder.Services.AddSingleton<IWritableFacade<GrievanceModel>, WritableFacade<GrievanceModel>>();

builder.Services.AddSingleton<IFacade<JJMAlreadyCompletedModel>, Facade<JJMAlreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<JJMAlreadyCompletedModel>, WritableFacade<JJMAlreadyCompletedModel>>();

builder.Services.AddSingleton<IFacade<otherthanjjmalreadycompleted>, Facade<otherthanjjmalreadycompleted>>();
builder.Services.AddSingleton<IWritableFacade<otherthanjjmalreadycompleted>, WritableFacade<otherthanjjmalreadycompleted>>();

builder.Services.AddSingleton<IFacade<biogasalreadycompleted>, Facade<biogasalreadycompleted>>();
builder.Services.AddSingleton<IWritableFacade<biogasalreadycompleted>, WritableFacade<biogasalreadycompleted>>();

builder.Services.AddSingleton<IFacade<RVEDDGalreadycompleted>, Facade<RVEDDGalreadycompleted>>();
builder.Services.AddSingleton<IWritableFacade<RVEDDGalreadycompleted>, WritableFacade<RVEDDGalreadycompleted>>();

builder.Services.AddSingleton<IFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>, Facade<OtherThanRVEDDGMonitoringAlreadyCompleted>>();
builder.Services.AddSingleton<IWritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>, WritableFacade<OtherThanRVEDDGMonitoringAlreadyCompleted>>();

builder.Services.AddSingleton<IFacade<SSYalreadyCompletedModel>, Facade<SSYalreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<SSYalreadyCompletedModel>, WritableFacade<SSYalreadyCompletedModel>>();

builder.Services.AddSingleton<IFacade<HighMastAlreadyCompletedmodel>, Facade<HighMastAlreadyCompletedmodel>>();
builder.Services.AddSingleton<IWritableFacade<HighMastAlreadyCompletedmodel>, WritableFacade<HighMastAlreadyCompletedmodel>>();

builder.Services.AddSingleton<IFacade<InspectionInProgressModel>, Facade<InspectionInProgressModel>>();
builder.Services.AddSingleton<IWritableFacade<InspectionInProgressModel>, WritableFacade<InspectionInProgressModel>>();

builder.Services.AddSingleton<IFacade<OnGridPowerPlantAlreadyCompletedModel>, Facade<OnGridPowerPlantAlreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<OnGridPowerPlantAlreadyCompletedModel>, WritableFacade<OnGridPowerPlantAlreadyCompletedModel>>();

builder.Services.AddSingleton<IFacade<MiniMastAlreadyCompletedModel>, Facade<MiniMastAlreadyCompletedModel>>();
builder.Services.AddSingleton<IWritableFacade<MiniMastAlreadyCompletedModel>, WritableFacade<MiniMastAlreadyCompletedModel>>();

builder.Services.AddSingleton<IFacade<SSYInProgressModel>, Facade<SSYInProgressModel>>();
builder.Services.AddSingleton<IWritableFacade<SSYInProgressModel>, WritableFacade<SSYInProgressModel>>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
