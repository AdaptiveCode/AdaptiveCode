using NHibernate;
using NHibernate.Cfg;
using StairwayPattern.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Domain.NHibernate;
using Services.Implementations;

namespace StairwayPattern
{
    public class ManualConstructionControllerFactory : IControllerFactory
    {
        private readonly ISession session;

        public ManualConstructionControllerFactory()
        {
            var config = new Configuration();
            var sessionFactory = config.BuildSessionFactory();
            this.session = sessionFactory.OpenSession();
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "AccountController":
                    return new AccountController(new SecurityService(new UserRepository(this.session)));
                default:
                    throw new NotSupportedException($"The controller `{controllerName}` has not been configured");
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            (controller as IDisposable)?.Dispose();
        }
    }
}