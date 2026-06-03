using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment
{
    public partial class FilterCatagory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                   

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }
        }
    }
}