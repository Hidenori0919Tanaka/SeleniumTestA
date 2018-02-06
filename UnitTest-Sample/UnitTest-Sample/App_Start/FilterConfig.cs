using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnitTest_Sample.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}