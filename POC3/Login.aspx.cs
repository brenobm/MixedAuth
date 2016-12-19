using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += btnLogin_Click;
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, "usuarioTeste", DateTime.Now,
                DateTime.Now.AddMinutes(30), true, "ExternalUser");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Expires = tkt.Expiration;

            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);

            string strRedirect;
            strRedirect = Request["ReturnUrl"];
            if (strRedirect == null)
                strRedirect = "~/Default.aspx";
            Response.Redirect(strRedirect, true);
        }
    }
}