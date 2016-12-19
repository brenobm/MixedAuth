using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogManager.GetLogger(typeof(Default)).Info("oi");
            BtnLogout.Click += BtnLogout_Click;
        }

        void BtnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}