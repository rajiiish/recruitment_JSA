using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace recruitment
{
    public partial class candidate_registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    can_regno_assign();
            //}
        }

       


        protected void regisration_btn_Click1(object sender, EventArgs e)
        {

                  



            if (CheckeMail())
            {
                Response.Write("<script> alert ('Email ID already used for registration');</script>");
            }

            else
            {
                datainsert();
            }
                     


        }

        public void can_regno_assign()
        {
            try
            {

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                                          
                //SqlCommand cmd = new SqlCommand("SELECT regno FROM rec_regno ", connection);
                //SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da1.Fill(ds);
                //string i = ds.Tables[0].Rows[0]["regno"].ToString();


                //int a = Convert.ToInt32(i);
                //int c = a + 1;
                //regnolbl.Text = c.ToString();


                SqlCommand cmd1 = new SqlCommand("UPDATE rec_regno SET regno=regno+1", connection);

                cmd1.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }

        }

        //public void update_reg_no()
        //{
        //    try
        //    {

        //        SqlConnection connection = MySqlConnection.Recruitmentcon();

        //        SqlCommand cmd1 = new SqlCommand("UPDATE rec_regno SET regno=regno+1", connection);

        //        cmd1.ExecuteNonQuery();

        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert ('" + ex.Message + "');</script>");

        //    }


        //}





        bool CheckeMail()
        {
            try
            {

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM rec_canreg WHERE email ='" + TextBox3.Text.Trim() + "' ";
                SqlCommand command = new SqlCommand(sql1, connection);

                SqlDataAdapter sa = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sa.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                              

            }

            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
                
            }
            return false;
        }
            

        public void validation()
        {
            if (TextBox1.Text == "")
            {
                Label1.Text = "* This Field Canot be Blank";

            }
                   

           else if (TextBox3.Text == "")
            {
                Label3.Text = "* Enter valid email id";
            }



            else if (TextBox4.Text == "")
            {
                Label4.Text = "* This Field Canot be Blank";
            }


            else if (TextBox5.Text == "")
            {
                Label5.Text = "* This Field Canot be Blank";
            }


            else if (TextBox6.Text == "")
            {
                Label6.Text = "* Enter valid Mobile Number";
            }



            else if (TextBox4.Text != TextBox5.Text)
            {
                Label5.Text = "* Password dont match";
            }

           


        }

        /* public void emptytext()
         {
             TextBox1.Text = "";
             TextBox2.Text = "";
             TextBox3.Text = "";
             TextBox4.Text = "";
             TextBox5.Text = "";
             TextBox6.Text = "";
         }*/


      


      
        public void datainsert()
        {
                                                                                                        
            if (txtVerificationCode.Text.ToLower() == Session["CaptchaVerify"].ToString())
            {

                SqlConnection con = MySqlConnection.Recruitmentcon();

                SqlCommand cmd = new SqlCommand("SELECT regno FROM rec_regno ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da1.Fill(ds);
                string i = ds.Tables[0].Rows[0]["regno"].ToString();



                string fname = TextBox1.Text;
                //  string lname = TextBox2.Text;
                string email = TextBox3.Text;


              //  string password1 = TextBox4.Text;

                string password1 = EncryptionHelper.Encrypt(TextBox5.Text);


                string password2 = TextBox5.Text;
                string mobile = TextBox6.Text;
                // string regno = regnolbl.Text;
                string photoid = "123456";
                string signid = "1234567";

                string can_regno = "CMC/JSA_STN/2025" + i;

                try
                {

                    string sql = "Insert into rec_canreg(fname,email,password,mobile,can_sno,can_regno,photoid,signid) values (@fname,@email,@password1,@mobile,@regno,@can_regno,@photoid,@signid)";
                    //string sql1 = "Insert into basicdetailsNew(can_regno) values (@can_regno)";

                    SqlConnection connection = MySqlConnection.Recruitmentcon();
                    SqlConnection connection1 = MySqlConnection.Recruitmentcon();

                    SqlCommand command = new SqlCommand(sql, connection);
                    // SqlCommand command1 = new SqlCommand(sql1, connection1);

                    command.CommandType = CommandType.Text;
                    //  command1.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@fname", fname.Trim());
                    //  command.Parameters.AddWithValue("@lname", lname);
                    command.Parameters.AddWithValue("@email", email.Trim());
                    command.Parameters.AddWithValue("@password1", password1.Trim());
                    command.Parameters.AddWithValue("@mobile", mobile.Trim());
                    command.Parameters.AddWithValue("@regno", i);
                    command.Parameters.AddWithValue("@can_regno", can_regno);
                    command.Parameters.AddWithValue("@photoid", photoid);
                    command.Parameters.AddWithValue("@signid", signid);

                    //  command1.Parameters.AddWithValue("@can_regno", can_regno);

                    command.ExecuteNonQuery();

                    can_regno_assign();

                    //  command1.ExecuteNonQuery();

                    Response.Write("<script> alert ('registration successfull');</script>");
                    Response.Redirect("reg_redirect.aspx");
                    //emptytext();
                }
                catch (Exception e)
                {

                    Label7.Text = e.Message.ToString();
                }
                con.Close();
            }
            else
            {
                lblCaptchaMessage.Text = "Please enter correct captcha !";
                lblCaptchaMessage.ForeColor = System.Drawing.Color.Red;
            }
}
        }



    }
