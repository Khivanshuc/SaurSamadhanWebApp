using ElectionApp.Models;
using ElectionApp.Services;
using ElectionApp.ViewModels;
using ElectionApp.Views;
using ElectionData.Client;
using ElectionData.Models;
using System.Net;


namespace ElectionApp
{
    public static class MauiProgram
    {
        public const string API_BASE_URL ="https://localhost/api";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var deviceUniqueId = string.Empty;
            var authApiKey = string.Empty;

            if (Preferences.ContainsKey("DeviceUniqueId"))
            {
                deviceUniqueId = Preferences.Get("DeviceUniqueId", "");
            }
            if (Preferences.ContainsKey("AuthApiKey"))
            {
                authApiKey = Preferences.Get("AuthApiKey", "");
            }


            builder
                .UseMauiApp<App>()
                     .RegisterAppServices(API_BASE_URL, deviceUniqueId, authApiKey)
                     .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            return builder.Build();
        }
    }
    public static class MauiInitExt
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder, string apiBaseUrl, string deviceUniqueId, string authApiKey)
        {
            mauiAppBuilder.Services.AddSingleton(a => (IWebContextModel)ActivatorUtilities.CreateInstance<WebContextModel>
                (a, apiBaseUrl, deviceUniqueId, authApiKey, new CookieContainer()));

            mauiAppBuilder.Services.AddSingleton<IFacade<UserProfileModel>, Facade<UserProfileModel>>();
            return mauiAppBuilder;
        }
        
    }
}
        
