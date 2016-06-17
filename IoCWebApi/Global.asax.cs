using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Serilog;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Sinks.RollingFileAlternate;
using SerilogWeb.Classic;
using SerilogWeb.Classic.Enrichers;

namespace IoCWebApi
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();

            new RequestStartLogger().Init(this);
        }

        protected void Application_Start()
        {
            var seqUrl = ConfigurationManager.AppSettings["SeqUrl"] ?? "http://localhost:5341";
            var logDirectory = ConfigurationManager.AppSettings["LogDirectory"] ?? @"C:\Logs\IoCWebApi.txt";

            // Log all finished requests with their return code and execution time (logs also unhandled exceptions)
            ApplicationLifecycleModule.IsEnabled = true;
            ApplicationLifecycleModule.RequestLoggingLevel = LogEventLevel.Debug;

            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Debug()
                .ReadFrom.AppSettings()
                .WriteTo.Seq(seqUrl)
                .WriteTo.RollingFileAlternate(logDirectory, fileSizeLimitBytes: 5000000)
                .Enrich.WithProperty("Environment", "Development")
                .Enrich.With(new HttpRequestIdEnricher())
                .Enrich.With(new HttpRequestRawUrlEnricher())
                .Enrich.With(new HttpRequestUserAgentEnricher())
                .Enrich.With(new EnvironmentUserNameEnricher())
                .Enrich.With(new HttpRequestClientHostIPEnricher())
                .CreateLogger();
        }
    }

    /// <summary>
    /// Custom IHttpModule to log requests when they start.
    /// </summary>
    public class RequestStartLogger : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                Log.Debug("HTTP {Method} {RawUrl}", context.Request.HttpMethod, context.Request.RawUrl);
            };
        }

        public void Dispose()
        {
        }
    }
}
