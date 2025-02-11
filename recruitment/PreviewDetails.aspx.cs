using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace recruitment
{
    public partial class PreviewDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if ((Session["email"] != null) && (Session["password"] != null))
            {

                regid();
                AppCompletionSteps();
                loadbasicdetails();
                YesOrNo();
                loadeducation();
                //loadeducationphd();
                loadexperience();
                loadotherinfordetails();
                PhotoFileexitCheck();
                SignFileexitCheck();
                Signpic.Visible = false;
                ApplicationSubmittedCheck();
                
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

            applyhpostlbl.Text = Convert.ToString(Session["postname"]);

            string appregno = Convert.ToString(Session["S_appregno"]);
            string dbcanreg = Convert.ToString(Session["can_regno"]);


            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
        }


        private void YesOrNo()
        {
            try
            {

                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
             //   string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,GATE FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";


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

                        //string PHDyesno = dr.GetValue(6).ToString();

                        //string GATEyesno = dr.GetValue(7).ToString();


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

                        //if (PHDyesno == "No")
                        //{
                        //    phdtable.Visible = false;
                        //    phdTitleRow.Visible = false;
                        //    phdRow.Visible = false;
                        //    phdlabl.Visible = true;

                        //}
                        //else if (PHDyesno == "Yes")
                        //{
                        //    phdtable.Visible = true;
                        //    phdTitleRow.Visible = true;
                        //    phdRow.Visible = true;
                        //    phdlabl.Visible = false;
                        //}

                        //if (GATEyesno == "No")
                        //{
                        //    GATEtable.Visible = false;
                        //    GATETitleRow.Visible = false;
                        //    GATERow.Visible = false;
                        //    GATElabl.Visible = true;

                        //}
                        //else if (GATEyesno == "Yes")
                        //{
                        //    GATEtable.Visible = true;
                        //    GATETitleRow.Visible = true;
                        //    GATERow.Visible = true;
                        //    GATElabl.Visible = false;
                        //}

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
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
            //    string sql1 = "SELECT SSLCcourse,SSLCInstitute,SSLCPmarks,SSLCPassYear,SSLCClass, HSCCcourse, HSCcoursename, HSCSubject, HSCInstitute, HSCPmarks, HSCPassYear, HSCClass, ITICcourse, ITIcoursename, ITISubject, ITIInstitute, ITIPmarks, ITIPassYear, ITIClass, DIPLOMACcourse, DIPLOMAcoursename, DIPLOMASubject, DIPLOMAInstitute, DIPLOMAPmarks, DIPLOMAPassYear, DIPLOMAClass, UGcourse,UGcoursename,UGSubject,UGInstitute,UGPmarks,UGPassYear,UGClass,PGcourse,PGcoursename, PGSubject, PGInstitute,PGPmarks, PGPassYear, PGClass, GATEmarks,GATEPassYear,GATEsub FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";
                string sql1 = "SELECT SSLCcourse,SSLCInstitute,SSLCPmarks,SSLCPassYear,SSLCClass, HSCCcourse, HSCcoursename, HSCSubject, HSCInstitute, HSCPmarks, HSCPassYear, HSCClass, ITICcourse, ITIcoursename, ITISubject, ITIInstitute, ITIPmarks, ITIPassYear, ITIClass, DIPLOMACcourse, DIPLOMAcoursename, DIPLOMASubject, DIPLOMAInstitute, DIPLOMAPmarks, DIPLOMAPassYear, DIPLOMAClass, UGcourse,UGcoursename,UGSubject,UGInstitute,UGPmarks,UGPassYear,UGClass,PGcourse,PGcoursename, PGSubject, PGInstitute,PGPmarks, PGPassYear, PGClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";


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

                        //gate1.Text = dr.GetValue(40).ToString();
                        //gate2.Text = dr.GetValue(41).ToString();
                        //gate3.Text = dr.GetValue(42).ToString();





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

        //private void loadeducationphd()
        //{
        //    try
        //    {
        //        string canregdbtext = Convert.ToString(Session["can_regno"]);

        //        string appregnotext = Convert.ToString(Session["S_appregno"]);



        //        SqlConnection connection = MySqlConnection.Recruitmentcon();
        //        string sql1 = "SELECT PHDTitle, PHDPassYear, PHDSubject, PHDDetails FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

        //        SqlCommand command = new SqlCommand(sql1, connection);
        //        command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
        //        command.Parameters.AddWithValue("@appregnotext", appregnotext);

        //        SqlDataReader dr = command.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                phd1.Text = dr.GetValue(0).ToString();
        //                phd2.Text = dr.GetValue(1).ToString();
        //                phd3.Text = dr.GetValue(2).ToString();
        //                phd4.Text = dr.GetValue(3).ToString();

        //            }
        //        }
        //        else
        //        {
        //            // Response.Redirect("position_details.aspx");
        //            // Response.Write("<script>alert('Invalid credentials');</script>");


        //        }
        //    }




        //    catch (Exception ex)
        //    {
        //        Response.Write("<script> alert ('" + ex.Message + "');</script>");

        //    }
        //}

        private void loadexperience()
        {
            string appregno = Convert.ToString(Session["S_appregno"]);
            string dbcanreg = Convert.ToString(Session["can_regno"]);

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
                                        //Response.Redirect("ExperienceAdd.aspx");
                                        Explable.Visible = true;
                                    }
                                    else
                                    {
                                        Explable.Visible = false;
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

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                //SqlCommand cmd = new SqlCommand("select fullname, fathername, mothername, dateofbirth, sexuality, cast, marital, religion, csiremp, " +
                //    " pwd,pwdPercent,pwdCatagory, ExArmy, ExArmyService, placeborn, aadhaar, citizen,bankname,  paydate, paymode,email, mobile, presentaddress," +
                //    " paddresscity, paddressstate, paddresspincode, peraddress,paddressSameCheck from basicdetailsNew where can_regno= '" + regidlbl.Text.Trim() + "' and appregno= '" + appidnolbl.Text.Trim() + "'", con);


                SqlCommand cmd = new SqlCommand("select fullname, fathername, mothername, dateofbirth, sexuality, cast, marital, religion, csiremp, " +
                   " pwd,pwdPercent,pwdCatagory, ExArmy, ExServiceName, ExArmyService, placeborn, aadhaar, citizen,bankname,  paydate, paymode,email, mobile, presentaddress," +
                   " paddresscity, paddressstate, paddresspincode, peraddress,paddressSameCheck from basicdetailsNew where can_regno= '" + regidlbl.Text.Trim() + "' and appregno= '" + appidnolbl.Text.Trim() + "'", con);

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

                        var pwdyesno = dr.GetValue(9).ToString();

                        if (pwdyesno == "No")
                        {
                         pwdcatlbl1.Text = dr.GetValue(9).ToString();
                         pwdcatlbl2.Text = "";
                         pwdcatlbl3.Text = "";
                         pwdtypelbl.Text = "";
                         pwdpctlbl.Text = "";

                        }
                        else if (pwdyesno == "Yes")
                        {
                            pwdcatlbl1.Text =  dr.GetValue(9).ToString() + ",";
                            pwdcatlbl2.Text = dr.GetValue(10).ToString() +",";
                            pwdcatlbl3.Text = dr.GetValue(11).ToString();
                        }

                      //  var exarmy = dr.GetValue(12).ToString();



                        //if (exarmy == "No")
                        //{
                        //    armylbl.Text = "No";
                        //    armylblservice.Text = "";
                        //    PrdServicelbl.Text = "";

                        //}
                        //else if (exarmy == "Yes")
                        {
                            armylbl.Text = dr.GetValue(13).ToString() + "," + " ";

                            armylblservice.Text = dr.GetValue(14).ToString();

                        }

                        placebornlbl.Text = dr.GetValue(15).ToString();
                        aadhaarlbl.Text = dr.GetValue(16).ToString();
                        citizenlbl.Text = dr.GetValue(17).ToString();
                        bankreflbl.Text = dr.GetValue(18).ToString();
                        string paymentdatetxt = bankreflbl.Text;

                        if (paymentdatetxt == "")
                        {
                            paydatelbl.Text = "";


                        }
                        else
                        {
                            paydatelbl.Text = dr.GetValue(19).ToString();
                        }

                        paymodelbl.Text = dr.GetValue(20).ToString();
                        emaillbl.Text = dr.GetValue(21).ToString();
                        mobilelbl.Text = dr.GetValue(22).ToString();

                        string paddress = dr.GetValue(23).ToString() + ", " + dr.GetValue(24).ToString() + ", " + dr.GetValue(25).ToString() + ", " + dr.GetValue(26).ToString();
                        presentaddlbl.Text = paddress;
                        permaddlbl.Text = dr.GetValue(27).ToString();
                        
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
        private void loadotherinfordetails()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
            //    SqlCommand cmd = new SqlCommand("select IsForignVist,UnderBond,MinJoiningMonth,IsRelativeCSIR,ReName,ReDesign,ReType,ReLab,Ref1Full,Ref2Full,PermentGovtStaff,ClaimingAgeRelax,AgeRelaxCatagory from basicdetailsNew where can_regno= '" + regidlbl.Text.Trim() + "' and appregno= '" + appidnolbl.Text.Trim() + "'", con);

                SqlCommand cmd = new SqlCommand("select IsForignVist,UnderBond,IsRelativeCSIR,ReName,ReDesign,ReType,ReLab,Ref1Full,Ref2Full,PermentGovtStaff,ClaimingAgeRelax,AgeRelaxCatagory from basicdetailsNew where can_regno= '" + regidlbl.Text.Trim() + "' and appregno= '" + appidnolbl.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        forignvisitlbl.Text = dr.GetValue(0).ToString();
                        bondlbl.Text = dr.GetValue(1).ToString();
                      //  joinglbl.Text = dr.GetValue(2).ToString();                       

                        relativelbl.Text = dr.GetValue(2).ToString();
                        string relative = "Name:"+dr.GetValue(3).ToString() + ", " + "Designation:" + dr.GetValue(4).ToString() + ", " + "Relationship:"+ dr.GetValue(5).ToString() + ", " + "Lab Name:"+ dr.GetValue(6).ToString();
                        relativdetaillbl.Text = relative;

                        
                        Referencelbl1.Text = dr.GetValue(7).ToString();
                        Referencelbl2.Text = dr.GetValue(8).ToString();
                        govtserventlbl.Text = dr.GetValue(9).ToString();
                        Agerelxlbl1.Text = dr.GetValue(10).ToString();
                        Agerelxlbl2.Text = dr.GetValue(11).ToString();



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

        public void PhotoFileexitCheck()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where can_regno= '" + regidlbl.Text.Trim()  + "'", con);
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
                    Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


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


        public void ApplicationSubmittedCheck()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select IsCompleted from basicdetailsNew where can_regno = '" + regidlbl.Text.Trim() + "' and appregno = '" + appidnolbl.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string iscompleted = dr.GetValue(0).ToString();

                        if (iscompleted == "Yes")
                        {
                            CompleteApplication.Visible = false;
                            submitveifylbl.Visible = false;
                            goBackbtn.Visible = false;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }



        }
        protected void CompleteApplication_Click(object sender, EventArgs e)
        {
            try
            {
                string appregno = Convert.ToString(Session["S_appregno"]);
                string dbcanreg = Convert.ToString(Session["can_regno"]);
                string yesno = "Yes";
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {
                    string insertquery = "Update basicdetailsNew SET IsCompleted='Yes' where can_regno=@canreg AND appregno=@appreg";
                    SqlCommand cmd = new SqlCommand(insertquery, conn);

                    cmd.Parameters.AddWithValue("@yes", yesno);
                    cmd.Parameters.AddWithValue("@appreg", appregno);
                    cmd.Parameters.AddWithValue("@canreg", dbcanreg);


                    cmd.ExecuteNonQuery();

                    Response.Redirect("position_details.aspx");

                }
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
              //  string sql1 = "SELECT can_regno,appregno,BasicInfo,Education,Experienced,Profession,AdditionalInfo,Upload,AppFee FROM ApplicationSteps WHERE can_regno = @canregdbtest and appregno = @appregnotext ";
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
                   //     string ProffessionComplete = dr.GetValue(5).ToString();
                        string AdditionalComplete = dr.GetValue(5).ToString();
                        string UploadComplete = dr.GetValue(6).ToString();
                        string AppComplete = dr.GetValue(7).ToString();

                        if ((BasicComplete == "No") || (EducationComplete =="No") || (ExperienceComplete == "No") || (AdditionalComplete == "No") || (UploadComplete == "No") || (AppComplete == "No" ) )
                        {
                            Response.Redirect("Candidate_Home.aspx");
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

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }

        protected void printButton_Click(object sender, EventArgs e)
        {

        }
    }
}