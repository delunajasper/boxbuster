using System.Web;
using System.Web.Mvc;

namespace BoxBuster
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //redirects user to error page when theres exception
            filters.Add(new HandleErrorAttribute());

            //authorize attribute
            filters.Add(new AuthorizeAttribute());

            //old port is no longer accessible on http channel
            filters.Add(new RequireHttpsAttribute());


        }
    }
}
