﻿using System.Web;
using System.Web.Mvc;

namespace SEIP_Class_28
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
