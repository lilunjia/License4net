using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication_LisenceFileTest
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
           
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            LicenseChecker lc = new LicenseChecker();
            string message = string.Empty;
            bool isCheck = lc.Check(this.Server.MapPath("~/授权文件[北京客户].dat"), out message);
            if (!isCheck)
            {   
                this.Response.Write(message);
                this.Response.End();
            }
        }
    }
}