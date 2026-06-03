using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;


namespace recruitment
{
    public partial class educationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null))
            {
                regid();
                loaddata();
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("userlogin.aspx");
            }
        }
        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);
            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
        }


        public void loaddata()
        {
            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where can_regno='" + regidlbl.Text.Trim() + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        firstName.Text = dr.GetValue(3).ToString();
                        lastName.Text = dr.GetValue(4).ToString();
                        email.Text = dr.GetValue(1).ToString();


                    }
                }
                else
                {
                    Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}