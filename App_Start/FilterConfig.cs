using System.Web;
using System.Web.Mvc;

namespace ArmyTech_Task_SaeedAbdalWahab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
