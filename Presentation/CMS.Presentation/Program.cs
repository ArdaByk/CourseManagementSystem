using CMS.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddPersistenceServices();

            services.AddTransient<LoginForm>();

            var serviceProvider = services.BuildServiceProvider();

            System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<LoginForm>());
        }
    }
}