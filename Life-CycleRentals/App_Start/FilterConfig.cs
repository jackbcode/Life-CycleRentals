using System.Web;
using System.Web.Mvc;

namespace Life_CycleRentals
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());
            //may have to change above
        }
    }
}
