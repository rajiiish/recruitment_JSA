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
    public partial class basicinformation : System.Web.UI.Page
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

            appidnolbl.Text = Convert.ToString(Session["S_appregno"]);

            postDetailsdrop.Text = Convert.ToString(Session["postname"]);
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
                        firstname.Text = dr.GetValue(3).ToString();
                        lastname.Text = dr.GetValue(4).ToString();
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

        //public void can_appno_assign()
        //{
        //    try
        //    {

        //        SqlConnection connection = MySqlConnection.Recruitmentcon();

        //        SqlCommand cmd = new SqlCommand("SELECT applicant_count FROM appno ", connection);
        //        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da1.Fill(ds);
        //        string i = ds.Tables[0].Rows[0]["applicant_count"].ToString();
        //        int a = Convert.ToInt32(i);
        //        int c = a + 1;
        //        appidnolbl.Text = c.ToString();


        //        SqlCommand cmd1 = new SqlCommand("UPDATE appno SET applicant_count=applicant_count+1", connection);

        //        cmd1.ExecuteNonQuery();

        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert ('" + ex.Message + "');</script>");

        //    }

        //}
        public void bascidetailsentry()
        {

           
            string firstName = firstname.Text;
            string lastName = lastname.Text;
            string dob = dateofbirth.Text;
            string fathername = fatherName.Text;
            string postdetails = postDetailsdrop.Text;
            string presentaddress = presentAddress.Text;
            string peraddress = permenAddress.Text;
            string appregnotext = appidnolbl.Text;
          //  string applicant_id = "APPID/20" + appregnotext;
            string canregno = regidlbl.Text;
            

            try
            {

                string sql = "UPDATE basicdetails SET firstName=@firstName,lastName=@lastName,dateofbirth=@dateofbirth,fathername=@fathername," +
                    "presentaddress=@presentaddress, peraddress=@peraddress where appregno=appregnotext";

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
             //   command.Parameters.AddWithValue("@can_regno", canregno);
               // command.Parameters.AddWithValue("@appregno", appregnotext);
               // command.Parameters.AddWithValue("@pcode", applicant_id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dateofbirth", dob);
                command.Parameters.AddWithValue("@fathername", fathername);
                //command.Parameters.AddWithValue("@postdetails", postdetails);
                command.Parameters.AddWithValue("@presentaddress", presentaddress);
                command.Parameters.AddWithValue("@peraddress", peraddress);
               

                


                command.ExecuteNonQuery();
                Response.Write("<script> alert ('Basic Details Saved successfull');</script>");
                Response.Redirect("AddEducationDetails.aspx");
                //emptytext();
            }
            catch (Exception e)
            {

                submitlable.Text = e.Message.ToString();
            }
        }
        protected void continue_Click(object sender, EventArgs e)
        {
            bascidetailsentry();
        }
    }
 
}