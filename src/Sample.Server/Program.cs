using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.IO;

namespace Sample.Server
{
    public class Program
    {
        private const string _appsettingsFilename = "appsettings.json";
        private const string _nlogConfigFilename = "NLog.config";

        public static void Main(string[] args)
        {
            var logger = LogManager
                .Setup()
                .GetCurrentClassLogger();

            try
            {
                logger.Debug("Creating host and run");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped application because of an exception.");
                throw;
            }
            finally
            {
                logger.Info("Application is shutting down...");
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath: Directory.GetCurrentDirectory())
                .AddJsonFile(path: _appsettingsFilename, optional: true, reloadOnChange: true)
                .Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    // webBuilder.UseUrls(urls: "http://0.0.0.0:5000");
                    // Configure it in appsettings.json instead.
                    // Don't forget to add ["externalUrlConfiguration": true] to Properties/launchSettings.json to explicitly override from appsettings.json and avoid warning.
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddNLog(configFileName: _nlogConfigFilename);
                })
                .UseNLog();
        }
    }
}
