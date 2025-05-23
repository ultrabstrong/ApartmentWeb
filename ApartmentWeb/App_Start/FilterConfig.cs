﻿using ApartmentWeb.Filters;
using System.Web.Mvc;

namespace ApartmentWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SecurityHeadersAttribute());
        }
    }
}
