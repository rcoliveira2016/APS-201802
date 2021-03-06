﻿using APS.Presentation.Web.Helpers.Attributes;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AutenticacaoWebMVC());
        }
    }
}
