using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace ElectroestimuladorWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //server data
            Session["DbUser"] = "ignacio";
            Session["DbPassword"] = "catolica2019";
            Session["strServer"] = "201.131.41.25";
            Session["DbPort"] = "3306";
            Session["DbName"] = "Elec";
            Session["StrCon"] = "Server = " + Session["strServer"] + "; Port =" + Session["DbPort"] + "; Database =" + Session["DbName"] + "; Uid =" + Session["DbUser"] + "; Pwd =" + Session["DbPassword"] + "; ";

            //User data
            Session["strUserAccount"] = "";
            Session["strPassword"] = "";
            Session["strUserID"] = "";
            Session["strUser"] = "";
            Session["strUserKind"] = "";

            //Procedures data
            Session["strBodyPartId"] = "";
            Session["strPersonId"] = "";
            Session["strInjuryId"] = "";
            Session["strWaveId"] = "";
            Session["strTreatmentId"] = "";
            Session["strBodyPart"] = "";
            Session["strPerson"] = "";
            Session["strInjury"] = "";
            Session["strWave"] = "";
            Session["strTreatmentId"] = "";
            Session["strImageId"] = "";
            Session["ErrorCounter"] = "0";
        }
    }
}