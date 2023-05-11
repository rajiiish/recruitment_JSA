using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((Session["s_adminuser"] == null) && (Session["s_adminpassword"] == null))
                {
                    adminloginlink.Visible = false;
                    logoutlink.Visible = false;
                    // Response.Redirect("userlogin.aspx");
                }
                else
                {
                    adminloginlink.Visible = false;
                    logoutlink.Visible = true;
                }   

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("rms_admin.aspx");
        }
    }
}