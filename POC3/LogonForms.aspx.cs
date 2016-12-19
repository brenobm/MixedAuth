using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC3
{
    public partial class LogonForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (Request.IsAuthenticated && (HttpContext.Current.User.Identity is WindowsIdentity))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, HttpContext.Current.User.Identity.Name, DateTime.Now,
                    DateTime.Now.AddMinutes(30), true, "Internal");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;

                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.User.Identity.Name, true);
                FormsAuthentication.SetAuthCookie(HttpContext.Current.User.Identity.Name, true);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);
            }
        }
    }
}