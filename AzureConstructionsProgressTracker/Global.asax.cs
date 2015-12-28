using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AzureConstructionsProgressTracker.Common;
using AzureConstructionsProgressTracker.Features.ProgressTracking;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureConstructionsProgressTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var instrumentationKey = ConfigurationManager.AppSettings["AppInsightsInstrumentationKey"];
            if (!string.IsNullOrWhiteSpace(instrumentationKey))
                TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            
            var serviceBusManager = new ServiceBusManager(ConfigurationManager.ConnectionStrings["AzureWebJobsServiceBus"].ConnectionString);
            serviceBusManager.CreateQueue();
        }
    }
}
