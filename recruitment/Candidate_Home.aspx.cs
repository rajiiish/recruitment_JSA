using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace recruitment
{
    public partial class Candidate_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                if (!IsPostBack)
                {
                    regid();
                    AppCompletion();
                    AppCompletionSteps();
                    

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("userlogin.aspx");
            }

            PreviewPanel1.Visible = true;
            //tickimg1.Visible = true;
            //tickimg2.Visible = true;
            //tickimg3.Visible = true;
            //tickimg4.Visible = true;
            //tickimg5.Visible = true;
            //tickimg6.Visible = true;
        }

        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);

            appidnolbl.Text = Convert.ToString(Session["S_appregno"]);

            applyhpostlbl.Text = Convert.ToString(Session["postname"]);
            
        }

        private void AppCompletion()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);
                string appregnotext = Convert.ToString(Session["S_appregno"]);

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT IsCompleted FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string complete = dr.GetValue(0).ToString();

                        if (complete == "Yes")
                        {
                            Response.Redirect("position_details.aspx");
                        }

                    }
                }
                else
                {

                    Response.Redirect("position_details.aspx");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }

        }

        private void AppCompletionSteps()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);
                string appregnotext = Convert.ToString(Session["S_appregno"]);

                SqlConnection connection = MySqlConnection.Recruitmentcon();
             //   string sql1 = "SELECT can_regno,appregno,BasicInfo,Education,Experienced,Profession,AdditionalInfo,Upload,AppFee FROM ApplicationSteps WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                string sql1 = "SELECT can_regno,appregno,BasicInfo,Education,Experienced,AdditionalInfo,Upload,AppFee FROM ApplicationSteps WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string BasicComplete = dr.GetValue(2).ToString();
                        string EducationComplete = dr.GetValue(3).ToString();
                        string ExperienceComplete = dr.GetValue(4).ToString();
                     //   string ProffessionComplete = dr.GetValue(5).ToString();
                        string AdditionalComplete = dr.GetValue(5).ToString();
                        string UploadComplete = dr.GetValue(6).ToString();
                        string AppComplete = dr.GetValue(7).ToString();

                        if (BasicComplete == "No")
                        {
                            pbtn1.Enabled = true;
                            pbtn2.Enabled = false;
                            pbtn3.Enabled = false;
                      //      pbtn4.Enabled = false;
                            pbtn5.Enabled = false;
                            pbtn6.Enabled = false;
                            pbtn7.Enabled = false;

                            tickimg1.Visible = false;
                            tickimg2.Visible = false;
                            tickimg3.Visible = false;
                    //        tickimg4.Visible = false;
                            tickimg5.Visible = false;
                            tickimg6.Visible = false;
                            tickimg7.Visible = false;

                            PreviewApplication.Enabled = false;

                        }
                        else if ((BasicComplete == "Yes") && (EducationComplete == "No"))
                        {
                            pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = false;
                     //       pbtn4.Enabled = false;
                            pbtn5.Enabled = false;
                            pbtn6.Enabled = false;
                            pbtn7.Enabled = false;

                            tickimg1.Visible = true;
                            tickimg2.Visible = false;
                            tickimg3.Visible = false;
                     //       tickimg4.Visible = false;
                            tickimg5.Visible = false;
                            tickimg6.Visible = false;
                            tickimg7.Visible = false;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn3.BackColor = System.Drawing.Color.DarkMagenta;
                    //        pbtn4.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn5.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn6.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn7.BackColor = System.Drawing.Color.DarkMagenta;
                            PreviewApplication.Enabled = false;
                        }
                        else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "No"))
                        {
                            pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = true;
                      //      pbtn4.Enabled = false;
                            pbtn5.Enabled = false;
                            pbtn6.Enabled = false;
                            pbtn7.Enabled = false;

                            tickimg1.Visible = true;
                            tickimg2.Visible = true;
                            tickimg3.Visible = false;
                    //        tickimg4.Visible = false;
                            tickimg5.Visible = false;
                            tickimg6.Visible = false;
                            tickimg7.Visible = false;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.Green;
                            pbtn3.BackColor = System.Drawing.Color.DarkMagenta;
                     //       pbtn4.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn5.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn6.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn7.BackColor = System.Drawing.Color.DarkMagenta;


                            PreviewApplication.Enabled = false;
                        }
                        //else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (ProffessionComplete == "No"))


                        //{
                        //    pbtn1.Enabled = true;
                        //    pbtn2.Enabled = true;
                        //    pbtn3.Enabled = true;
                        //    pbtn4.Enabled = true;
                        //    pbtn5.Enabled = false;
                        //    pbtn6.Enabled = false;
                        //    pbtn6.Enabled = false;

                        //    tickimg1.Visible = true;
                        //    tickimg2.Visible = true;
                        //    tickimg3.Visible = true;
                        //    tickimg4.Visible = false;
                        //    tickimg5.Visible = false;
                        //    tickimg6.Visible = false;
                        //    tickimg7.Visible = false;

                        //    pbtn1.BackColor = System.Drawing.Color.Green;
                        //    pbtn2.BackColor = System.Drawing.Color.Green;
                        //    pbtn3.BackColor = System.Drawing.Color.Green;
                        //    pbtn4.BackColor = System.Drawing.Color.DarkMagenta;
                        //    pbtn5.BackColor = System.Drawing.Color.DarkMagenta;
                        //    pbtn6.BackColor = System.Drawing.Color.DarkMagenta;
                        //    pbtn7.BackColor = System.Drawing.Color.DarkMagenta;

                        //    PreviewApplication.Enabled = false;
                        //}

                     //   else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (ProffessionComplete == "Yes") && (AdditionalComplete == "No"))
                        else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes")  && (AdditionalComplete == "No"))

                                {
                                    pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = true;
                    //        pbtn4.Enabled = true;
                            pbtn5.Enabled = true;
                            pbtn6.Enabled = false;
                            pbtn6.Enabled = false;

                            tickimg1.Visible = true;
                            tickimg2.Visible = true;
                            tickimg3.Visible = true;
                 //           tickimg4.Visible = true;
                            tickimg5.Visible = false;
                            tickimg6.Visible = false;
                            tickimg7.Visible = false;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.Green;
                            pbtn3.BackColor = System.Drawing.Color.Green;
                     //       pbtn4.BackColor = System.Drawing.Color.Green;
                            pbtn5.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn6.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn7.BackColor = System.Drawing.Color.DarkMagenta;

                            PreviewApplication.Enabled = false;
                        }
                 //       else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (ProffessionComplete == "Yes") && (AdditionalComplete == "Yes") && (UploadComplete == "No"))
                        else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes")  && (AdditionalComplete == "Yes") && (UploadComplete == "No"))

                                {
                                    pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = true;
                    //        pbtn4.Enabled = true;
                            pbtn5.Enabled = true;
                            pbtn6.Enabled = true;
                            pbtn7.Enabled = false;

                            tickimg1.Visible = true;
                            tickimg2.Visible = true;
                            tickimg3.Visible = true;
                 //           tickimg4.Visible = true;
                            tickimg5.Visible = true;
                            tickimg6.Visible = false;
                            tickimg7.Visible = false;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.Green;
                            pbtn3.BackColor = System.Drawing.Color.Green;
                   //         pbtn4.BackColor = System.Drawing.Color.Green;
                            pbtn5.BackColor = System.Drawing.Color.Green;
                            pbtn6.BackColor = System.Drawing.Color.DarkMagenta;
                            pbtn7.BackColor = System.Drawing.Color.DarkMagenta;

                            PreviewApplication.Enabled = false;
                        }

                   //     else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (ProffessionComplete == "Yes") && (AdditionalComplete == "Yes") && (UploadComplete == "Yes") && (AppComplete == "No"))
                        else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes")  && (AdditionalComplete == "Yes") && (UploadComplete == "Yes") && (AppComplete == "No"))

                                {
                                    pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = true;
                //            pbtn4.Enabled = true;
                            pbtn5.Enabled = true;
                            pbtn6.Enabled = true;
                            pbtn7.Enabled = true;

                            tickimg1.Visible = true;
                            tickimg2.Visible = true;
                            tickimg3.Visible = true;
                 //           tickimg4.Visible = true;
                            tickimg5.Visible = true;
                            tickimg6.Visible = true;
                            tickimg7.Visible = false;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.Green;
                            pbtn3.BackColor = System.Drawing.Color.Green;
                       //     pbtn4.BackColor = System.Drawing.Color.Green;
                            pbtn5.BackColor = System.Drawing.Color.Green;
                            pbtn6.BackColor = System.Drawing.Color.Green;
                            pbtn7.BackColor = System.Drawing.Color.DarkMagenta;


                            PreviewApplication.Enabled = false;
                        }

                  //      else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (ProffessionComplete == "Yes") && (AdditionalComplete == "Yes") && (UploadComplete == "Yes") && (AppComplete == "Yes"))

                        else if ((BasicComplete == "Yes") && (EducationComplete == "Yes") && (ExperienceComplete == "Yes") && (AdditionalComplete == "Yes") && (UploadComplete == "Yes") && (AppComplete == "Yes"))
                        {
                            pbtn1.Enabled = true;
                            pbtn2.Enabled = true;
                            pbtn3.Enabled = true;
            //                pbtn4.Enabled = true;
                            pbtn5.Enabled = true;
                            pbtn6.Enabled = true;
                            pbtn7.Enabled = true;

                            tickimg1.Visible = true;
                            tickimg2.Visible = true;
                            tickimg3.Visible = true;
                //            tickimg4.Visible = true;
                            tickimg5.Visible = true;
                            tickimg6.Visible = true;
                            tickimg7.Visible = true;

                            pbtn1.BackColor = System.Drawing.Color.Green;
                            pbtn2.BackColor = System.Drawing.Color.Green;
                            pbtn3.BackColor = System.Drawing.Color.Green;
                  //          pbtn4.BackColor = System.Drawing.Color.Green;
                            pbtn5.BackColor = System.Drawing.Color.Green;
                            pbtn6.BackColor = System.Drawing.Color.Green;
                            pbtn7.BackColor = System.Drawing.Color.Green;

                            PreviewApplication.Enabled = true;
                        }
                    }
                }
                else
                {

                    Response.Redirect("position_details.aspx");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }

        }
        protected void PersonalDetailsLinkBtn_Click(object sender, EventArgs e)
        {
                PreviewPanel1.Visible = true;
            
            if (PreviewPanel1.Visible == true)
            {
                PreviewPanel1.Visible = true;
                PreviewPanel2.Visible = false;
                PreviewPanel3.Visible = false;
            //    PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = false;
                PreviewPanel6.Visible = false;
                PreviewPanel7.Visible = false;
            }

        }

        protected void EducationDetailsLinkBtn_Click(object sender, EventArgs e)
        {
               PreviewPanel2.Visible = true;
            if (PreviewPanel2.Visible == true)
            {
                PreviewPanel1.Visible = false;
                PreviewPanel2.Visible = true;
                PreviewPanel3.Visible = false;
         //       PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = false;
                PreviewPanel6.Visible = false;
                PreviewPanel7.Visible = false;
            }

        }

        protected void ExperienceDetailsLinkBtn_Click(object sender, EventArgs e)
        {
            PreviewPanel3.Visible = true;
            if (PreviewPanel3.Visible == true)
            {
                PreviewPanel1.Visible = false;
                PreviewPanel2.Visible = false;
                PreviewPanel3.Visible = true;
         //       PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = false;
                PreviewPanel6.Visible = false;
                PreviewPanel7.Visible = false;
            }
        }

        //protected void ProfessionDetailsLinkBtn_Click(object sender, EventArgs e)
        //{
        //    PreviewPanel4.Visible = true;
        //    if (PreviewPanel4.Visible == true)
        //    {
        //        PreviewPanel1.Visible = false;
        //        PreviewPanel2.Visible = false;
        //        PreviewPanel3.Visible = false;
        //        PreviewPanel4.Visible = true;
        //        PreviewPanel5.Visible = false;
        //        PreviewPanel6.Visible = false;
        //        PreviewPanel7.Visible = false;
        //    }

        //}

        protected void OtherInfoDetailsLinkBtn_Click(object sender, EventArgs e)
        {
            PreviewPanel5.Visible = true;
            if (PreviewPanel5.Visible == true)
            {
                PreviewPanel1.Visible = false;
                PreviewPanel2.Visible = false;
                PreviewPanel3.Visible = false;
        //        PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = true;
                PreviewPanel6.Visible = false;
                PreviewPanel7.Visible = false;
            }
        }

        protected void FilesUploadDetailsLinkBtn_Click(object sender, EventArgs e)
        {
            PreviewPanel6.Visible = true;
            if (PreviewPanel6.Visible == true)
            {
                PreviewPanel1.Visible = false;
                PreviewPanel2.Visible = false;
                PreviewPanel3.Visible = false;
     //           PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = false;
                PreviewPanel6.Visible = true;
                PreviewPanel7.Visible = false;
            }
        }

        protected void PaymentDetailsLinkBtn_Click(object sender, EventArgs e)
        {
            PreviewPanel7.Visible = true;
            if (PreviewPanel7.Visible == true)
            {
                PreviewPanel1.Visible = false;
                PreviewPanel2.Visible = false;
                PreviewPanel3.Visible = false;
         //       PreviewPanel4.Visible = false;
                PreviewPanel5.Visible = false;
                PreviewPanel6.Visible = false;
                PreviewPanel7.Visible = true;
            }
            
        }


        protected void pbtn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BasicInformationAdd.aspx");
        }

        protected void pbtn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void pbtn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExperienceAdd.aspx");
        }

       

        protected void pbtn5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInformations.aspx");
        }

        protected void pbtn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadpdf.aspx");
        }

        protected void pbtn7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }

       
        protected void PreviewApplication_Click1(object sender, EventArgs e)
        {
            Response.Redirect("PreviewDetails.aspx");
        }
    }
}