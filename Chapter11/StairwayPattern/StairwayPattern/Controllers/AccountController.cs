using Services;
using System;
using System.Web.Mvc;

namespace StairwayPattern.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISecurityService securityService;

        public AccountController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        public void ChangePassword(Guid userID, string password)
        {
            this.securityService.ChangeUsersPassword(userID, password);
        }
    }
}