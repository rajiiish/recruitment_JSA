using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] == null) && (Session["password"] == null))
            {
               // loginlbl.Text = "Already Registered Candidates:";
                loginclick.Visible = true;
                logoutclick.Visible = false;

                //registlbl.Text = "New Candidates:";
                registerbtn.Visible = true;
                viewpostbtn.Visible = false;

                // Response.Redirect("userlogin.aspx");
            }
            else
            {
                registlbl.ForeColor = System.Drawing.Color.DarkGreen;
                loginlbl.ForeColor = System.Drawing.Color.DarkGreen;

                string canreg = Session["can_regno"].ToString();
                loginlbl.Text = "Registration No:  " + canreg;
                loginclick.Visible = false;
                logoutclick.Visible = true;

                registlbl.Text = "Registration No: " + canreg;

                registerbtn.Visible = false;
                viewpostbtn.Visible = true;
            }

        }

        protected void loginclick_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidate_registration.aspx");
        }

        protected void logoutclick_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("homepage.aspx");
        }

        protected void viewpostbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("position_details.aspx");
        }
    }
}