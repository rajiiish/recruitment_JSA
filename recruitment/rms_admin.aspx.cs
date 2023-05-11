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
    public partial class rms_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text.Trim();
            string pwd = pwdTxt.Text.Trim();



            try
            {
                
                SqlConnection con = MySqlConnection.Recruitmentcon();
                //SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_adminlogin where adminuser = @username AND adminpassword= @pwd", con);

                cmd.Parameters.AddWithValue("@username", username);

                cmd.Parameters.AddWithValue("@pwd", pwd);

                SqlDataReader dr = cmd.ExecuteReader();
               
               
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["s_adminuser"] = dr.GetValue(1).ToString();
                        Session["s_adminpassword"] = dr.GetValue(2).ToString();
                        

                        //Response.Redirect("test.aspx");
                        //Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "');</script>");
                    }

                    Response.Redirect("DashboardAdmin.aspx");
                }
                else
                {
                    Label1.Text = "Enter correct login details";
                    // Response.Write("<script>alert('Invalid credentials');</script>");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
            }

        }
    }
    
}