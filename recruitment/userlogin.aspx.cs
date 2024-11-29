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
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TextBox1.Text.Trim();
                string password = EncryptionHelper.Decrypt(TextBox2.Text.Trim());

                SqlConnection con = MySqlConnection.Recruitmentcon();
                //SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where email='" + username + "' AND password='" + password + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["email"] = dr.GetValue(1).ToString();
                        Session["password"] = dr.GetValue(2).ToString();
                        Session["fname"] = dr.GetValue(3).ToString();
                        Session["can_regno"] = dr.GetValue(6).ToString();

                        //Response.Redirect("test.aspx");
                        //Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "');</script>");
                    }

                    Response.Redirect("position_details.aspx");
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