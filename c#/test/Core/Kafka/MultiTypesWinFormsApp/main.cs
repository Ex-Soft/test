using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MultiTypesWinFormsApp.Consumer;

namespace MultiTypesWinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<MainForm>();
            services.AddTransient<IKafkaConsumer, KafkaConsumer>();
            services.AddTransient<IKafkaConsumerBuilder, KafkaConsumerBuilder>();
            services.AddTransient<IConsumer, Consumer.Consumer>();
            services.AddTransient<IConsumerBuilder, ConsumerBuilder>();
        }
    }
}
