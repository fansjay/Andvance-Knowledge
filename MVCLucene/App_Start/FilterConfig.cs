﻿using MVCLucene.Models;
using System.Web;
using System.Web.Mvc;

namespace MVCLucene
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionAttribute());
        }
    }
}
