using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAL;
using Model;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private UserDal userDal = new UserDal();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                if (userDal.IsUser(user))
                {
                    FormsAuthentication.RedirectFromLoginPage(user.UserName, false);
                    
                }
                return View("Error");
            }catch(Exception e)
            {
                return View("Error");
            }
        }
    }
}