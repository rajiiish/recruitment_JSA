using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MasterBody.Attributes.Add("style", "background-color: #E3ECFD");
            try
            {
                if ((Session["email"] == null) && (Session["password"] == null))
                {
                    userlogin.Visible = true;
                    register.Visible = true;
                    logout.Visible = false;
                    candidatename.Visible = false;
                    postapplied.Visible = false;
                   // Response.Redirect("userlogin.aspx");
                }
                else
                {
                    userlogin.Visible = false;
                    register.Visible = false;
                    logout.Visible = true;
                    candidatename.Visible = true;
                    postapplied.Visible = true;
                }
                
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

                Response.Write("<script>alert('problem here site ');</script>");

            }
        }

        

        protected void userlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidate_registration.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("userlogin.aspx");
        }

        

        protected void candidatename_Click(object sender, EventArgs e)
        {

        }

        protected void postapplied_Click(object sender, EventArgs e)
        {
            Response.Redirect("position_details.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("rms_admin.aspx");
        }
    }
}