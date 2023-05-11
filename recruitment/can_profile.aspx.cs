using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace recruitment
{
    public partial class can_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    Panel1.Visible = false;
                    PrePanel.Visible = false;

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }
            
        }


        private void YesOrNo()
        {
            try
            {

               

                string canregdbtext = regidlbl.Text;

                string appregnotext = appidnolbl.Text;


                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,GATE FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string sslcyesno = dr.GetValue(0).ToString();
                        string HSCyesno = dr.GetValue(1).ToString();
                        string ITIyesno = dr.GetValue(2).ToString();

                        string DIPyesno = dr.GetValue(3).ToString();


                        string UGyesno = dr.GetValue(4).ToString();
                        string PGyesno = dr.GetValue(5).ToString();

                        string PHDyesno = dr.GetValue(6).ToString();

                        string GATEyesno = dr.GetValue(7).ToString();


                        if (sslcyesno == "No")
                        {
                            sslcRow.Visible = false;

                        }
                        else if (sslcyesno == "Yes")
                        {
                            sslcRow.Visible = true;
                        }

                        if (HSCyesno == "No")
                        {
                            hscRow.Visible = false;

                        }
                        else if (HSCyesno == "Yes")
                        {
                            hscRow.Visible = true;
                        }

                        if (ITIyesno == "No")
                        {
                            ITIRow.Visible = false;

                        }
                        else if (ITIyesno == "Yes")
                        {
                            ITIRow.Visible = true;
                        }

                        if (DIPyesno == "No")
                        {
                            dipRow.Visible = false;

                        }
                        else if (DIPyesno == "Yes")
                        {
                            dipRow.Visible = true;
                        }

                        if (UGyesno == "No")
                        {
                            ugRow.Visible = false;

                        }
                        else if (UGyesno == "Yes")
                        {
                            ugRow.Visible = true;
                        }

                        if (PGyesno == "No")
                        {
                            pgRow.Visible = false;

                        }
                        else if (PGyesno == "Yes")
                        {
                            pgRow.Visible = true;
                        }

                        if (PHDyesno == "No")
                        {
                            phdtable.Visible = false;
                            phdTitleRow.Visible = false;
                            phdRow.Visible = false;
                            phdlabl.Visible = true;

                        }
                        else if (PHDyesno == "Yes")
                        {
                            phdtable.Visible = true;
                            phdTitleRow.Visible = true;
                            phdRow.Visible = true;
                            phdlabl.Visible = false;
                        }

                        if (GATEyesno == "No")
                        {
                            GATEtable.Visible = false;
                            GATETitleRow.Visible = false;
                            GATERow.Visible = false;
                            GATElabl.Visible = true;

                        }
                        else if (GATEyesno == "Yes")
                        {
                            GATEtable.Visible = true;
                            GATETitleRow.Visible = true;
                            GATERow.Visible = true;
                            GATElabl.Visible = false;
                        }

                    }
                }
                else
                {
                    // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
                connection.Close();
            }




            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }

        }
        private void loadeducation()
        {
            try
            {
                string canregdbtext = regidlbl.Text; 

                string appregnotext = appidnolbl.Text;



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLCcourse,SSLCInstitute,SSLCPmarks,SSLCPassYear,SSLCClass, HSCCcourse, HSCcoursename, HSCSubject, HSCInstitute, HSCPmarks, HSCPassYear, HSCClass, ITICcourse, ITIcoursename, ITISubject, ITIInstitute, ITIPmarks, ITIPassYear, ITIClass, DIPLOMACcourse, DIPLOMAcoursename, DIPLOMASubject, DIPLOMAInstitute, DIPLOMAPmarks, DIPLOMAPassYear, DIPLOMAClass, UGcourse,UGcoursename,UGSubject,UGInstitute,UGPmarks,UGPassYear,UGClass,PGcourse,PGcoursename, PGSubject, PGInstitute,PGPmarks, PGPassYear, PGClass, GATEmarks,GATEPassYear,GATEsub FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ssl1.Text = dr.GetValue(0).ToString();
                        ssl2.Text = "-";
                        ssl3.Text = "-";

                        ssl4.Text = dr.GetValue(1).ToString();
                        ssl5.Text = dr.GetValue(2).ToString();
                        ssl6.Text = dr.GetValue(3).ToString();
                        ssl7.Text = dr.GetValue(4).ToString();

                        hsc1.Text = dr.GetValue(5).ToString();
                        hsc2.Text = dr.GetValue(6).ToString();
                        hsc3.Text = dr.GetValue(7).ToString();
                        hsc4.Text = dr.GetValue(8).ToString();
                        hsc5.Text = dr.GetValue(9).ToString();
                        hsc6.Text = dr.GetValue(10).ToString();
                        hsc7.Text = dr.GetValue(11).ToString();

                        ITI1.Text = dr.GetValue(12).ToString();
                        ITI2.Text = dr.GetValue(13).ToString();
                        ITI3.Text = dr.GetValue(14).ToString();
                        ITI4.Text = dr.GetValue(15).ToString();
                        ITI5.Text = dr.GetValue(16).ToString();
                        ITI6.Text = dr.GetValue(17).ToString();
                        ITI7.Text = dr.GetValue(18).ToString();

                        dip1.Text = dr.GetValue(19).ToString();
                        dip2.Text = dr.GetValue(20).ToString();
                        dip3.Text = dr.GetValue(21).ToString();
                        dip4.Text = dr.GetValue(22).ToString();
                        dip5.Text = dr.GetValue(23).ToString();
                        dip6.Text = dr.GetValue(24).ToString();
                        dip7.Text = dr.GetValue(25).ToString();

                        ug1.Text = dr.GetValue(26).ToString();
                        ug2.Text = dr.GetValue(27).ToString();
                        ug3.Text = dr.GetValue(28).ToString();
                        ug4.Text = dr.GetValue(29).ToString();
                        ug5.Text = dr.GetValue(30).ToString();
                        ug6.Text = dr.GetValue(31).ToString();
                        ug7.Text = dr.GetValue(32).ToString();

                        pg1.Text = dr.GetValue(33).ToString();
                        pg2.Text = dr.GetValue(34).ToString();
                        pg3.Text = dr.GetValue(35).ToString();
                        pg4.Text = dr.GetValue(36).ToString();
                        pg5.Text = dr.GetValue(37).ToString();
                        pg6.Text = dr.GetValue(38).ToString();
                        pg7.Text = dr.GetValue(39).ToString();

                        gate1.Text = dr.GetValue(40).ToString();
                        gate2.Text = dr.GetValue(41).ToString();
                        gate3.Text = dr.GetValue(42).ToString();





                    }
                }
                else
                {
                    // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }




            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }


        }
        private void loadeducationphd()
        {
            try
            {
                string canregdbtext = regidlbl.Text;

                string appregnotext = appidnolbl.Text;


                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT PHDTitle, PHDPassYear, PHDSubject, PHDDetails FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        phd1.Text = dr.GetValue(0).ToString();
                        phd2.Text = dr.GetValue(1).ToString();
                        phd3.Text = dr.GetValue(2).ToString();
                        phd4.Text = dr.GetValue(3).ToString();

                    }
                }
                else
                {
                    // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }




            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }
        }

        private void loadexperience()
        {
            string appregno = regidlbl.Text;

            string dbcanreg = appidnolbl.Text;

         
            // GridView1.Columns[0].Visible = false;
            //Label2.Text = GridView1.Columns[0].ToString();


            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT employer,designation,emptype,joindate,leavedate,totalexp FROM experience where can_regno=@canreg and appregno=@appregno"))
                        {
                            cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                            cmd.Parameters.AddWithValue("@appregno", appregno);
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView2.DataSource = dt;
                                    GridView2.DataBind();

                                    int rowCount = GridView2.Rows.Count;

                                    if (rowCount == 0)
                                    {
                                      //  Response.Redirect("ExperienceAdd.aspx");
                                    }
                                    else
                                    {
                                        GridView2.DataBind();

                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

            }


        }
        private void loadbasicdetails()
        {

            string appregno = appidnolbl.Text;
            string dbcanreg = regidlbl.Text;
            

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select fullname, fathername, mothername, dateofbirth, sexuality, cast, marital, religion, csiremp, " +
                    " pwd,pwdPercent,pwdCatagory, ExArmy, ExArmyService, placeborn, aadhaar, citizen,bankname,  paydate, paymode,email, mobile, presentaddress," +
                    " paddresscity, paddressstate, paddresspincode, peraddress,paddressSameCheck from basicdetailsNew where can_regno= @canreg and appregno= @appregno", con);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                cmd.Parameters.AddWithValue("@appregno", appregno);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fullnamelbl.Text = dr.GetValue(0).ToString();
                        fathernamelbl.Text = dr.GetValue(1).ToString();
                        mothernamelbl.Text = dr.GetValue(2).ToString();
                        doblbl.Text = dr.GetValue(3).ToString();
                        genderlbl.Text = dr.GetValue(4).ToString();
                        categorylbl.Text = dr.GetValue(5).ToString();
                        maritallbl.Text = dr.GetValue(6).ToString();
                        religionlbl.Text = dr.GetValue(7).ToString();
                        csiremplbl.Text = dr.GetValue(8).ToString();
                        pwdcatlbl1.Text = dr.GetValue(9).ToString();
                        pwdcatlbl2.Text = dr.GetValue(10).ToString();
                        pwdcatlbl3.Text = dr.GetValue(11).ToString();

                        armylbl.Text = dr.GetValue(12).ToString();
                        armylblservice.Text = dr.GetValue(13).ToString();
                        placebornlbl.Text = dr.GetValue(14).ToString();
                        aadhaarlbl.Text = dr.GetValue(15).ToString();
                        citizenlbl.Text = dr.GetValue(16).ToString();

                        bankreflbl.Text = dr.GetValue(17).ToString();
                        string paymentdatetxt = bankreflbl.Text;

                        if (paymentdatetxt == "")
                        {
                            paydatelbl.Text = "";
                        }
                        else
                        {
                            paydatelbl.Text = dr.GetValue(18).ToString();
                        }

                        paymodelbl.Text = dr.GetValue(19).ToString();
                        emaillbl.Text = dr.GetValue(20).ToString();
                        mobilelbl.Text = dr.GetValue(21).ToString();

                        string paddress = dr.GetValue(22).ToString() + ", " + dr.GetValue(23).ToString() + ", " + dr.GetValue(24).ToString() + ", " + dr.GetValue(25).ToString();
                        presentaddlbl.Text = paddress;
                        permaddlbl.Text = dr.GetValue(26).ToString();

                    }
                }
                else
                {
                   // Response.Redirect("position_details.aspx");
                     Response.Write("<script>alert('Invalid Basic Details');</script>");


                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
        private void loadotherinfordetails()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select IsForignVist,UnderBond,MinJoiningMonth,IsRelativeCSIR,ReName,ReDesign,ReType,ReLab,Ref1Full,Ref2Full,PermentGovtStaff,ClaimingAgeRelax,AgeRelaxCatagory from basicdetailsNew where can_regno= '" + regidlbl.Text.Trim() + "' and appregno= '" + appidnolbl.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        forignvisitlbl.Text = dr.GetValue(0).ToString();
                        bondlbl.Text = dr.GetValue(1).ToString();
                        joinglbl.Text = dr.GetValue(2).ToString();

                        relativelbl.Text = dr.GetValue(3).ToString();
                        string relative = dr.GetValue(4).ToString() + ", " + dr.GetValue(5).ToString() + ", " + dr.GetValue(6).ToString() + ", " + dr.GetValue(7).ToString();
                        relativdetaillbl.Text = relative;


                        Referencelbl1.Text = dr.GetValue(8).ToString();
                        Referencelbl2.Text = dr.GetValue(9).ToString();
                        govtserventlbl.Text = dr.GetValue(10).ToString();
                        Agerelxlbl1.Text = dr.GetValue(11).ToString();
                        Agerelxlbl2.Text = dr.GetValue(12).ToString();



                    }
                }
                else
                {
                   // Response.Redirect("position_details.aspx");
                     Response.Write("<script>alert('Invalid Other Info');</script>");


                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        public void PhotoFileexitCheck()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where can_regno= '" + regidlbl.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string photoid = dr.GetValue(7).ToString();
                        string photoname = Server.MapPath("~/files/photos/" + regidlbl.Text.ToString() + "_" + photoid + "_PHOTO" + ".jpg");
                        photo.ImageUrl = "~/files/photos/" + regidlbl.Text.ToString() + "_" + photoid + "_PHOTO" + ".jpg";
                    }
                }
                else
                {
                  //  Response.Redirect("position_details.aspx");
                     Response.Write("<script>alert('Invalid photo');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }

        public void SignFileexitCheck()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where can_regno= '" + regidlbl.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string signid = dr.GetValue(8).ToString();
                        string signname = Server.MapPath("~/files/signatures/" + regidlbl.Text.ToString() + "_" + signid + "_SIGN" + ".jpg");
                        Signpic.ImageUrl = "~/files/signatures/" + regidlbl.Text.ToString() + "_" + signid + "_SIGN" + ".jpg";
                    }
                }
                else
                {
                    // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }



        private void SearchbyAppno()
        {
            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select can_regno, appregno ,postdetails from basicdetailsNew where appregno= '" + searchtxt.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())                    {


                        regidlbl.Text = dr.GetValue(0).ToString();
                        appidnolbl.Text = dr.GetValue(1).ToString();
                        applyhpostlbl.Text = dr.GetValue(2).ToString();

                        YesOrNo();
                        loadbasicdetails();
                        loadeducation();
                        loadeducationphd();
                        loadexperience();
                        loadotherinfordetails();
                        PhotoFileexitCheck();
                        SignFileexitCheck();
                        
                        PrePanel.Visible = true;
                        Panel1.Visible = true;
                    }
                }
                else
                {
                     Response.Write("<script>alert('Invalid Application Number');</script>");
                    Panel1.Visible = false;
                    PrePanel.Visible = false;

                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
      
        protected void searchbyid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchtxt.Text))
            {
                Response.Write("Please enter Application ID to search");
                Panel1.Visible = false;
                PrePanel.Visible = false;
            }
            else
            {
                SearchbyAppno();
                
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Employer Name / Office Name ";
                e.Row.Cells[1].Text = "Designation / Post Held  ";
                e.Row.Cells[2].Text = "Type of Employment ";
                e.Row.Cells[3].Text = "Date of Joining";
                e.Row.Cells[4].Text = "Date of relieving";
                e.Row.Cells[5].Text = "Total Experience";
            }
        }
    }
}