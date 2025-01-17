﻿using Autofac;
using Autofac.Integration.Mvc;
using Ictshop.APITiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ictshop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Application["HomNay"] = 0;
            Application["HomQua"] = 0;
            Application["TuanNay"] = 0;
            Application["TuanTruoc"] = 0;
            Application["ThangNay"] = 0;
            Application["ThangTruoc"] = 0;
            Application["TatCa"] = 0;
            Application["visitors_online"] = 0;
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 150;
            Application.Lock();
            Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            Application.UnLock();
            try
            {
                var item = Ictshop.Common.Common.ThongKe();
                if (item != null)
                {
                    Application["HomNay"] = int.Parse("0" + item.HomNay.ToString("#,###"));
                    Application["HomQua"] = int.Parse("0" + item.HomQua.ToString("#,###"));
                    Application["TuanNay"] = int.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["TuanTruoc"] = int.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["ThangNay"] = int.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["ThangTruoc"] = int.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["TatCa"] = (int.Parse(item.TatCa.ToString())).ToString("#,###");
                }

            }
            catch { }

        }
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
        }


    }
  }

