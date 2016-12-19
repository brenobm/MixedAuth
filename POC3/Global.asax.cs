using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace POC3
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //LogManager.GetLogger(typeof(Global)).Info("0-" + HttpContext.Current.User.Identity.IsAuthenticated);
            //LogManager.GetLogger(typeof(Global)).Info("1-" + HttpContext.Current.User.Identity.Name);
            //LogManager.GetLogger(typeof(Global)).Info("2-" + HttpContext.Current.User.Identity.AuthenticationType);

            //LogManager.GetLogger(typeof(Global)).Info("3-" + Request.LogonUserIdentity.Name);

            //if (Request.IsAuthenticated && (HttpContext.Current.User.Identity is WindowsIdentity))
            //{
            //    FormsAuthenticationTicket tkt;
            //    string cookiestr;
            //    HttpCookie ck;
            //    tkt = new FormsAuthenticationTicket(1, HttpContext.Current.User.Identity.Name, DateTime.Now,
            //        DateTime.Now.AddMinutes(30), true, "ExternalUser");
            //    cookiestr = FormsAuthentication.Encrypt(tkt);
            //    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            //    ck.Expires = tkt.Expiration;

            //    ck.Path = FormsAuthentication.FormsCookiePath;
            //    Response.Cookies.Add(ck);
            //}
        }
    }
}