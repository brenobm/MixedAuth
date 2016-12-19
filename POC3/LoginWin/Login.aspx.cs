using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC3.LoginWin
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILog log = LogManager.GetLogger("FooLog");
            log4net.Config.XmlConfigurator.Configure();
            log.Info("OI");
            btnLogin.Click += btnLogin_Click;
        }

        void btnLogin_Click(object sender, EventArgs e)
        {

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, User.Identity.Name, DateTime.Now,
                    DateTime.Now.AddMinutes(30), true, "ExternalUser");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;

                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(User.Identity.Name, true);
                FormsAuthentication.SetAuthCookie(User.Identity.Name, true);
                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "~/Default.aspx";
                Response.Redirect(strRedirect, true);
            }
            else
            {
                Response.Redirect("~/LoginWeb/Login.aspx", true);
            }
        }
    }
}