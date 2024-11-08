using System.Web.Mvc;

namespace Project_63132041.Areas.Admin_63132041
{
    public class Admin_63132041AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin_63132041";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_63132041_default",
                "Admin_63132041/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}