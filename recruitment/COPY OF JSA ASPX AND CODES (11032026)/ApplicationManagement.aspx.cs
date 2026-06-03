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
using System.Net;

namespace recruitment
{
    public partial class ApplicationManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    LoadRecordsByAll();

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }
        }
        private void LoadRecordsByAll()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();
            string vshortlistd = ShortlistDrop.SelectedValue.ToString();

            

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted,can_regno FROM basicdetailsNew WHERE postcode = @postcode AND IsCompleted=@vsubmitted AND IsShortlisted=@vshortlistd"))
                        {

                            cmd.Parameters.AddWithValue("@postcode", vpostcode);
                            cmd.Parameters.AddWithValue("@vsubmitted", vsubmitted);
                            cmd.Parameters.AddWithValue("@vshortlistd", vshortlistd);


                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    PostWiseGridView1.DataSource = dt;
                                    PostWiseGridView1.DataBind();

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {

                    Response.Write("<script> alert ('" + ex.Message + "');</script>");
                    //  Response.Write("<script> alert ('No Record to Load');</script>");

                }

            }
        }

        private void LoadRecordsByAllSearch()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();
            string vsearchTxt = SearchLiketxt.Text.Trim();
            string appregno = SearchLiketxt.Text.Trim();

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted,can_regno FROM basicdetailsNew WHERE fullname LIKE '%' + @vsearchTxt + '%' OR appregno LIKE '%' + @appregno + '%'"))
                        {

                            cmd.Parameters.AddWithValue("@postcode", vpostcode);
                            cmd.Parameters.AddWithValue("@vsubmitted", vsubmitted);
                            cmd.Parameters.AddWithValue("@vsearchTxt", vsearchTxt);
                            cmd.Parameters.AddWithValue("@appregno", appregno);


                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    PostWiseGridView1.DataSource = dt;
                                    PostWiseGridView1.DataBind();

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {

                    Response.Write("<script> alert ('" + ex.Message + "');</script>");
                    //  Response.Write("<script> alert ('No Record to Load');</script>");

                }

            }
        }
        private void YesOrNo()
        {
            try
            {

                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = appregnolbl3.Text;



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,GATE FROM basicdetailsNew WHERE appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
              //  command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
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
        protected void ExportBtn_Click(object sender, EventArgs e)
        {

        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            LoadRecordsByAll();
        }

        protected void FinalShortBtn_Click(object sender, EventArgs e)
        {
            string dbcanreg = canregno1.Text;

            string dbappno = appregnolbl1.Text;

            string yesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsShortlisted = @yesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@yesno", yesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    //  PostWiseGridView1();
                    LoadRecordsByAll();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        protected void PopupFinalRejectBtn_Click(object sender, EventArgs e)
        {
            string dbcanreg = canregno1.Text;

            string dbappno = appregnolbl2.Text;

            string Shortyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsShortlisted = @Shortyesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);
                    cmd1.Parameters.AddWithValue("@Shortyesno", Shortyesno);
                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    //  PostWiseGridView1();
                    LoadRecordsByAll();

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        protected void ShortlistLbtn_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            appregnolbl1.Text = PostWiseGridView1.Rows[rowindex].Cells[0].Text;

            ModalPopupExtender1.Show();
        }

        protected void RejecLinkClick_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            appregnolbl2.Text = PostWiseGridView1.Rows[rowindex].Cells[0].Text;

            ModalPopupExtender2.Show();
        }

        protected void PreviewClicklinbtn_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            appregnolbl3.Text = PostWiseGridView1.Rows[rowindex].Cells[0].Text;
            regidlbl.Text = PostWiseGridView1.Rows[rowindex].Cells[20].Text;

            ModalPopupExtender3.Show();
            loadbasicdetails();
            loadexperience();
            loadeducation();
            loadotherinfordetails();
            PhotoFileexitCheck();
            DisplayDocPreference();
            YesOrNo();
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
                    Response.Write("<script> alert ('No Record to Load');</script>");
                  //  Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                SqlCommand cmd = new SqlCommand("select fullname, fathername, mothername, dateofbirth, sexuality, cast, marital, religion, csiremp, " +
                    " pwd,pwdPercent,pwdCatagory, ExArmy, ExArmyService, placeborn, aadhaar, citizen,bankname,  paydate, paymode,email, mobile, presentaddress," +
                    " paddresscity, paddressstate, paddresspincode, peraddress,paddressSameCheck from basicdetailsNew where  appregno= '" + appregnolbl3.Text.Trim() + "'", con);
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
                     Response.Write("<script>alert('Invalid Details, Contact CMC IT Dept.');</script>");
                    //Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        private void loadexperience()
        {
            string appregno = appregnolbl3.Text;
        //    string dbcanreg = Convert.ToString(Session["can_regno"]);

            // GridView1.Columns[0].Visible = false;
            //Label2.Text = GridView1.Columns[0].ToString();


            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT employer,designation,emptype,joindate,leavedate,totalexp FROM experience where appregno=@appregno"))
                        {
                           // cmd.Parameters.AddWithValue("@canreg", dbcanreg);
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

        private void loadeducation()
        {
            try
            {
               // string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = appregnolbl3.Text;
              


                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLCcourse,SSLCInstitute,SSLCPmarks,SSLCPassYear,SSLCClass, HSCCcourse, HSCcoursename, HSCSubject, HSCInstitute, HSCPmarks, HSCPassYear, HSCClass, ITICcourse, ITIcoursename, ITISubject, ITIInstitute, ITIPmarks, ITIPassYear, ITIClass, DIPLOMACcourse, DIPLOMAcoursename, DIPLOMASubject, DIPLOMAInstitute, DIPLOMAPmarks, DIPLOMAPassYear, DIPLOMAClass, UGcourse,UGcoursename,UGSubject,UGInstitute,UGPmarks,UGPassYear,UGClass,PGcourse,PGcoursename, PGSubject, PGInstitute,PGPmarks, PGPassYear, PGClass, GATEmarks,GATEPassYear,GATEsub FROM basicdetailsNew WHERE  appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
               // command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
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

                    //    gate1.Text = dr.GetValue(40).ToString();
                     //   gate2.Text = dr.GetValue(41).ToString();
                     //   gate3.Text = dr.GetValue(42).ToString();





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

        private void loadotherinfordetails()
        {

            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select IsForignVist,UnderBond,MinJoiningMonth,IsRelativeCSIR,ReName,ReDesign,ReType,ReLab,Ref1Full,Ref2Full,PermentGovtStaff,ClaimingAgeRelax,AgeRelaxCatagory from basicdetailsNew where  appregno= '" + appregnolbl3.Text.Trim() + "'", con);
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
                        //relativdetaillbl.Text = relative;


                        //Referencelbl1.Text = dr.GetValue(8).ToString();
                        //Referencelbl2.Text = dr.GetValue(9).ToString();
                        govtserventlbl.Text = dr.GetValue(10).ToString();
                        Agerelxlbl1.Text = dr.GetValue(11).ToString();
                        Agerelxlbl2.Text = dr.GetValue(12).ToString();



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

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ModalPopupExtender4_DataBinding(object sender, EventArgs e)
        {

        }

        private void DisplayDocPreference()
        {
            try
            {

                string canregdbtext = regidlbl.Text;
                string appregnotext = appregnolbl3.Text;


                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,IsExperienced,ExArmy,PermentGovtStaff,pwd, IsUploadComplete FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

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

                        //    string Communityyesno = dr.GetValue(6).ToString();
                        string Experienceyesno = dr.GetValue(7).ToString();
                        string ExServicemanyesno = dr.GetValue(8).ToString();
                        string NOCyesno = dr.GetValue(9).ToString();
                        string PWDyesno = dr.GetValue(10).ToString();
                        string IsComplete = dr.GetValue(11).ToString();

                        //if (IsComplete == "Yes")
                        //{
                        //    Response.Redirect("PreviewDetails.aspx");

                        //}



                        if (HSCyesno == "Yes")
                        {
                            HSCTableRow.Visible = true;

                        }
                        else if (HSCyesno == "No")
                        {

                            HSCTableRow.Visible = false;
                        }

                        if (ITIyesno == "Yes")
                        {
                            IITTableRow.Visible = true;

                        }
                        else if (ITIyesno == "No")
                        {

                            IITTableRow.Visible = false;
                        }
                        ////////////////////////////////////
                        if (DIPyesno == "Yes")
                        {
                            DIPTableRow.Visible = true;

                        }
                        else if (DIPyesno == "No")
                        {

                            DIPTableRow.Visible = false;
                        }
                        /////////////////////////////////
                        if (UGyesno == "Yes")
                        {
                            UGTableRow.Visible = true;

                        }
                        else if (UGyesno == "No")
                        {

                            UGTableRow.Visible = false;
                        }
                        ////////////////////////////////
                        if (PGyesno == "Yes")
                        {
                            PGTableRow.Visible = true;

                        }
                        else if (PGyesno == "No")
                        {

                            PGTableRow.Visible = false;
                        }



                        //if (PHDyesno == "Yes")
                        //{
                        //    PHDTableRow.Visible = true;

                        //}
                        //else if (UGyesno == "No")
                        //{

                        //    PHDTableRow.Visible = false;
                        //}

                        //if (Communityyesno == "Yes")
                        //{
                        //    CommunityTableRow.Visible = true;

                        //}
                        //else if (Communityyesno == "No")
                        //{

                        //    CommunityTableRow.Visible = false;
                        //}
                        //////////////////////////////
                        if (Experienceyesno == "Yes")
                        {
                            ExperienceTableRow.Visible = true;

                        }
                        else if (Experienceyesno == "No")
                        {

                            ExperienceTableRow.Visible = false;
                        }
                        ///////////////////////////
                        if (ExServicemanyesno == "Yes")
                        {
                            ExServicemanTableRow.Visible = true;

                        }
                        else if (ExServicemanyesno == "No")
                        {

                            ExServicemanTableRow.Visible = false;
                        }
                        /////////////////////////////////
                        if (NOCyesno == "Yes")
                        {
                            NOCTableRow.Visible = true;

                        }
                        else if (NOCyesno == "No")
                        {

                            NOCTableRow.Visible = false;
                        }
                        //////////////////////////////////
                        if (PWDyesno == "Yes")
                        {
                            PWDTableRow.Visible = true;

                        }
                        else if (PWDyesno == "No")
                        {

                            PWDTableRow.Visible = false;
                        }

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
        protected void ssc_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void hsc_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_HSC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void ITI_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_ITI" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void DIP_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_DIP" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void UG_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_UG" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void PG_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_PG" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void Community_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_Community" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void Experience_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_Experience" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void ExServiceman_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_ExServiceman" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void NOC_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_NOC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void PWD_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_PWD" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadRecordsByAllSearch();
        }
    }
    
}