using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EntourageAntiPattern
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(typeof(ManualConstructionControllerFactory));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
