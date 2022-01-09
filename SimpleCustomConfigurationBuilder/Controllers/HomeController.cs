using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCustomConfigurationBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string someAppSetting = ConfigurationManager.AppSettings["MyCustomSetting"] ?? "Not found";
            string someOtherAppSetting = ConfigurationManager.AppSettings["SomeOtherSettingThatDoesntExist"] ?? "Not found";

            return Json(new { someAppSetting, someOtherAppSetting }, JsonRequestBehavior.AllowGet);
        }
    }
}