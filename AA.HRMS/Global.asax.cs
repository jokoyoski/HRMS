using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Loader;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Xml;
using AA.HRMS.DI.Windsor.Installers;
using AA.HRMS.DI.Windsor.Plumbing;
using FluentScheduler;
using AA.HRMS.Domain.Services;
using Scheduler;

namespace AA.HRMS
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //JobManager.Initialize(new JobRegistry());
            //JobManager.StopAndBlock();
            //JobManager.UseUtcTime();


            // Implement Windsor Castle for DI/Ioc introduced
            BootstrapContainer();
            MvcSiteMapProviderDiConfiguration();
        }

        protected void Session_OnStart()
        {
            HttpContext.Current.Session.RemoveAll();
            FormsAuthentication.SignOut();
        }

        protected void Session_OnEnd()
        {

            HttpContext.Current.Session.RemoveAll();
            FormsAuthentication.SignOut();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private static void MvcSiteMapProviderDiConfiguration()
        {
            // Create the DI container (typically part of your DI setup already)
            var container = new WindsorContainer();

            // Setup configuration of DI
            container.Install(new MvcSiteMapProviderInstaller()); // Required

            container.Install(new MvcInstaller()); // Required by MVC. Typically already part of your setup (double check the contents of the module).

            // setup global sitemap loader (required)
            SiteMaps.Loader = container.Resolve<ISiteMapLoader>();

            //check all configured .sitemap files to ensure they follow the XSD for MvcSiteMapProvider(optional)
            var validator = container.Resolve<ISiteMapXmlValidator>();
            validator.ValidateXml(HostingEnvironment.MapPath("~/Mvc.sitemap"));

            //Register the Sitemaps routes for search engines (optional)
            XmlSiteMapController.RegisterRoutes(RouteTable.Routes);
        }
      
    }
}
