﻿using System.Web;
using System.Web.Mvc;

namespace HW3_U21470121
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
