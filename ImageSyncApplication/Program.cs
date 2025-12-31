using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace ImageSyncApplication
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Configure HttpClient
            services.AddHttpClient("CredaApiClient", client =>
            {
                client.BaseAddress = new Uri("https://creda.binomial.in/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                // Add any additional headers or configurations
            });

            // Register your forms and other services
            services.AddTransient<Form1>();  // Register your main form
        }
    }
}
