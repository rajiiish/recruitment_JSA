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
using System.Globalization;

namespace recruitment
{
    public partial class AddInformations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
               

                if (!IsPostBack)
                {
                    
                    regid();                    
                    AppCompletion();
                    datashow();
                    YesOrNo();

                    JoinTimeLable.Visible = false;
                    JoiningTimetxt.Visible = false;
                    if (countryvisitdrop.SelectedValue=="No")
                    {
                       
                        countrypanel.Visible = false;
                    }

                    if (GridView1.Rows.Count > 0)
                    {
                        countrypanel.Visible = true;
                    }

                    if (RelativeDrop.SelectedValue == "No")
                    {

                        relativepanel.Visible = false;
                    }


                    if (pwddrop.SelectedValue == "Yes")
                    {

                        pwddrop.Enabled = false;
                        pwdpanel.Visible = true;
                    }

                    if (pwddrop.SelectedValue == "No")
                    {

                        pwddrop.Enabled = false;
                        pwdpanel.Visible = false;
                    }

                    if ((AgeRlxClaimDrop.SelectedValue == "No") || (AgeRlxClaimDrop.SelectedValue == "0"))
                    {                       
                        RelaxationPanel.Visible = false;
                    }


                }
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("userlogin.aspx");
            }




            DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
            DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

            if (countryvisitdrop.SelectedValue == "0")

            {
                countrypanel.Visible = false;
            }

        }

        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);

            appidnolbl.Text = Convert.ToString(Session["S_appregno"]);

            applyhpostlbl.Text = Convert.ToString(Session["postname"]);



            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
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

        private void totalduration()
        {

            DateTime startDate = Convert.ToDateTime(fromtxt.Text);
            DateTime endDate = Convert.ToDateTime(totxt.Text);

            TimeSpan objTimeSpan = endDate - startDate;

            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;
            totaldaystxt.Text = (string.Format("{0} years, {1} months, {2} days", years, months, days));

        }
        protected void fromtxt_TextChanged(object sender, EventArgs e)
        {
            totxt.Text = "";
        }

        protected void totxt_TextChanged(object sender, EventArgs e)
        {
            if (fromtxt.Text != "" && totxt.Text != "")
            {
                totalduration();
            }

            else
            {
                Response.Write("<script> alert ('Please Add From and To Date');</script>");

            }

        }



        protected void Addbutton_Click(object sender, EventArgs e)
        {
            addforignvisit();
            UpdateForeignVisitYesNo();

        }

        protected void countryvisitdrop_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (countryvisitdrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Forign Visit Details');</script>");
                countrypanel.Visible = false;
            }

            else if (countryvisitdrop.SelectedValue == "Yes")
            {
                countrypanel.Visible = true;
            }
            else if (countryvisitdrop.SelectedValue == "No")
            {
                if (GridView1.Rows.Count > 0)
                {
                    Response.Write("<script> alert ('You Already Added Forign Visit Details, Please Delete, if you are selecting the option - No ');</script>");
                    countrypanel.Visible = true;

                }
                else
                {
                    countrypanel.Visible = false;
                }
                
            }
        }

        private void YesOrNo()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT IsForignVist,UnderBond,IsRelativeCSIR,ReName,ReDesign,ReType,ReLab,Ref1,Ref2,Ref3,Ref4,Ref5,Ref6,TermsCondition,pwd,PermentGovtStaff,pwdPercent,pwdCatagory,ClaimingAgeRelax,AgeRelaxCatagory FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        countryvisitdrop.SelectedValue = dr.GetValue(0).ToString();
                        bonddrop.SelectedValue = dr.GetValue(1).ToString();
                    //    JoiningTimetxt.Text = dr.GetValue(2).ToString();
                        RelativeDrop.SelectedValue = dr.GetValue(2).ToString();


                        RelativeNametxt.Text = dr.GetValue(3).ToString();
                        PresentDesignationtxt.Text = dr.GetValue(4).ToString();
                        RelationTypetxt.Text = dr.GetValue(5).ToString();                       
                        NameCSIRtxt.Text = dr.GetValue(6).ToString();

                        NameRef1.Text = dr.GetValue(7).ToString();
                        OccupRef1.Text = dr.GetValue(8).ToString();
                        AddressRef1.Text = dr.GetValue(9).ToString();

                        NameRef2.Text = dr.GetValue(10).ToString();
                        OccupRef2.Text = dr.GetValue(11).ToString();
                        AddressRef2.Text = dr.GetValue(12).ToString();
                      

                        string checkbox = dr.GetValue(13).ToString();

                        pwddrop.SelectedValue = dr.GetValue(14).ToString();
                        permGovtDrop.SelectedValue = dr.GetValue(15).ToString();
                        pwdpercttxt.Text = dr.GetValue(16).ToString();
                        pwdtypedrop.SelectedValue = dr.GetValue(17).ToString();
                        AgeRlxClaimDrop.SelectedValue = dr.GetValue(18).ToString();
                        AgeRlxConfDrop.SelectedValue = dr.GetValue(19).ToString();

                        if (checkbox =="Yes")
                        {
                            termsandcondtionCheck.Checked = true;
                        }

                        else if (checkbox=="No")
                        {
                            termsandcondtionCheck.Checked = false;
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
        private void datashow()
        {
            // GridView1.Columns[0].Visible = false;
            //Label2.Text = GridView1.Columns[0].ToString();
            string appregno = Convert.ToString(Session["S_appregno"]);
            string dbcanreg = Convert.ToString(Session["can_regno"]);

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM forignvisit where can_regno=@canreg and appregno=@appregno"))
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
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                        conn.Close();
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert (" + ex.Message + "');</script>");

                }
                
            }
        }

        private void UpdateForeignVisitYesNo()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {              
                string dbcanreg = regidlbl.Text;
                string dbappno = appidnolbl.Text;

                string vIsVisited = countryvisitdrop.SelectedValue.ToString();
                string insertquery1 = "UPDATE basicdetailsNew SET IsForignVist = @vIsVisited WHERE appregno = @dbappno and can_regno=@canreg";
                SqlCommand cmd1 = new SqlCommand(insertquery1, conn);
                cmd1.Parameters.AddWithValue("@canreg", dbcanreg);
                cmd1.Parameters.AddWithValue("@dbappno", dbappno);
                cmd1.Parameters.AddWithValue("@vIsVisited", vIsVisited);
                cmd1.ExecuteNonQuery();
            }
        }

        private void addforignvisit()
        {
            if (String.IsNullOrEmpty(countrytxt.Text))

            {
                Response.Write("<script> alert ('Please Add Country Name ');</script>");

            }



            else if (String.IsNullOrEmpty(fromtxt.Text))
            {
                Response.Write("<script> alert ('Please Add From Date');</script>");

            }

            else if (String.IsNullOrEmpty(totxt.Text))
            {
                Response.Write("<script> alert ('Please Add To Date');</script>");

            }

            else if (String.IsNullOrEmpty(visitdetailstxt.Text))
            {
                Response.Write("<script> alert ('Please Add Purpose of the visit');</script>");

            }

            else
            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                      
                        // string expcount = regidlbl.Text + 1;
                        string dbcanreg = regidlbl.Text;
                        // string dbpcode = postDetailsdrop.Text;
                        string dbappno = appidnolbl.Text;
                        string vcountryname = countrytxt.Text;

                        string visitdetails = visitdetailstxt.Text;

                        string vIsVisited = countryvisitdrop.SelectedValue.ToString();


                        DateTime fromdate1 = Convert.ToDateTime(fromtxt.Text);


                        DateTime todate1 = Convert.ToDateTime(totxt.Text);





                        string fromdate = fromdate1.ToString("dd/MM/yyyy");

                        string todate = todate1.ToString("dd/MM/yyyy");
                        string totaldays = totaldaystxt.Text;



                        //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                        //  conn.Open();

                        string insertquery = "insert into forignvisit(can_regno, appregno, country, fromdate, todate, totaldays, visitdetails) values (@canreg, @dbappno, @vcountryname,  @fromdate, @todate, @totaldays,@visitdetails)";
                      //  string insertquery1 = "UPDATE basicdetailsNew SET IsForignVist = @vIsVisited WHERE appregno = @ddbappno and can_regno=@dcanreg";



                        SqlCommand cmd = new SqlCommand(insertquery, conn);
                     //   SqlCommand cmd1 = new SqlCommand(insertquery1, conn);





                        cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                        //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                        cmd.Parameters.AddWithValue("@dbappno", dbappno);


                        cmd.Parameters.AddWithValue("@vcountryname", vcountryname);
                        cmd.Parameters.AddWithValue("@fromdate", fromdate);
                        cmd.Parameters.AddWithValue("@todate", todate);
                        cmd.Parameters.AddWithValue("@totaldays", totaldays);
                        cmd.Parameters.AddWithValue("@visitdetails", visitdetails);


//                        cmd1.Parameters.AddWithValue("@canreg", dbcanreg);
///                        cmd1.Parameters.AddWithValue("@dbappno", dbappno);
//                        cmd1.Parameters.AddWithValue("@vIsVisited", vIsVisited);


                        cmd.ExecuteNonQuery();
                     //   cmd1.ExecuteNonQuery();

                        datashow();
                       
                        countrytxt.Text = "";
                        fromtxt.Text = "";
                        totxt.Text = "";
                        totaldaystxt.Text = "";
                        visitdetailstxt.Text = "";
                        conn.Close();
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert (" + ex.Message + "');</script>");
                }
            }

        }

        private void UpdateBasicDetailsTable()
        {
            string vIsVisited = countryvisitdrop.SelectedValue.ToString();
            string vIsBond = bonddrop.SelectedValue.ToString();
            string vIsRelative = RelativeDrop.SelectedValue.ToString();
            string vIsGovStaff = permGovtDrop.SelectedValue.ToString();
            string vPwdPercent = pwdpercttxt.Text.ToString();

            string vPwdCatagory = pwdtypedrop.SelectedValue.ToString();
            string vageRelxClaim = AgeRlxClaimDrop.SelectedValue.ToString();
            string vClaimCatagory = AgeRlxConfDrop.SelectedValue.ToString();





          //  string vMinJoiningMonth = JoiningTimetxt.Text.ToString();

            string vReName = RelativeNametxt.Text;
            string vReDesign = PresentDesignationtxt.Text;
            string vReType = RelationTypetxt.Text;
            string vReLab = NameCSIRtxt.Text;
            string vRelativeDetails = vReName + "," + " " + vReDesign + "," + " " + vReType + "," + " " + vReLab;


            string vRef1 = NameRef1.Text;
            string vRef2 = OccupRef1.Text;
            string vRef3 = AddressRef1.Text;
            string vRef1Full = vRef1 + "," + " " + vRef2 + "," + " " + vRef3;

            string vRef4 = NameRef2.Text;
            string vRef5 = OccupRef2.Text;
            string vRef6 = AddressRef2.Text;
            string vRef2Full = vRef4 + "," + " " + vRef5 + "," + " " + vRef6;

            string terms = termsandcondtionCheck.Checked ? "Yes" : "No";

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {
                                        
                    string insertquery1 = "UPDATE basicdetailsNew SET IsForignVist = @dIsVisited, UnderBond=@dIsBond, PermentGovtStaff=@vIsGovStaff, pwdPercent=@vPwdPercent, pwdCatagory=@vPwdCatagory, ClaimingAgeRelax=@vageRelxClaim,AgeRelaxCatagory=@vClaimCatagory, IsRelativeCSIR=@dIsRelative,ReName = @dReName, ReDesign=@dReDesign, ReType=@dReType, ReLab=@dReLab, RelativeCSIRDetail=@dRelativeDetails, Ref1 = @dRef1, Ref2=@dRef2, Ref3=@dRef3, Ref1Full=@dRef1Full, Ref4=@dRef4, Ref5=@dRef5, Ref6=@dRef6, Ref2Full=@dRef2Full,TermsCondition=@terms  WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@dIsVisited", vIsVisited);
                    cmd1.Parameters.AddWithValue("@dIsBond", vIsBond);
                    cmd1.Parameters.AddWithValue("@vIsGovStaff", vIsGovStaff);
                    cmd1.Parameters.AddWithValue("@vPwdPercent", vPwdPercent);
                    cmd1.Parameters.AddWithValue("@vPwdCatagory", vPwdCatagory);
                    cmd1.Parameters.AddWithValue("@vageRelxClaim", vageRelxClaim);
                    cmd1.Parameters.AddWithValue("@vClaimCatagory", vClaimCatagory);




                 //   cmd1.Parameters.AddWithValue("@dMinJoiningMonth", vMinJoiningMonth);
                    cmd1.Parameters.AddWithValue("@dIsRelative", vIsRelative);


                    cmd1.Parameters.AddWithValue("@dReName", vReName);
                    cmd1.Parameters.AddWithValue("@dReDesign", vReDesign);
                    cmd1.Parameters.AddWithValue("@dReType", vReType);
                    cmd1.Parameters.AddWithValue("@dReLab", vReLab);
                    cmd1.Parameters.AddWithValue("@dRelativeDetails", vRelativeDetails);


                    cmd1.Parameters.AddWithValue("@dRef1", vRef1);
                    cmd1.Parameters.AddWithValue("@dRef2", vRef2);
                    cmd1.Parameters.AddWithValue("@dRef3", vRef3);
                    cmd1.Parameters.AddWithValue("@dRef1Full", vRef1Full);

                    cmd1.Parameters.AddWithValue("@dRef4", vRef4);
                    cmd1.Parameters.AddWithValue("@dRef5", vRef5);
                    cmd1.Parameters.AddWithValue("@dRef6", vRef6);
                    cmd1.Parameters.AddWithValue("@dRef2Full", vRef2Full);
                    cmd1.Parameters.AddWithValue("@terms", terms);

                    



                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Deletebtn_forign_Click(object sender, EventArgs e)
        {
            //   int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            //    int canregtext = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);


            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            //int rowIndex = Convert.ToInt32(((LinkButton)sender).Attributes["id"].ToString());

            int canregtext = Convert.ToInt32(GridView1.DataKeys[rowindex].Value);

            SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE from forignvisit WHERE id = @canreg"))
                {
                    cmd.Parameters.AddWithValue("@canreg", canregtext);
                    cmd.Connection = conn;
                    //con.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.datashow();
        }

        private void stepsComplete()
        {
            string canregdbtest = Convert.ToString(Session["can_regno"]);
            string vappidnolbl = Convert.ToString(Session["S_appregno"]);
            string vyes = "Yes";
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {


                    string insertquery = "Update ApplicationSteps SET AdditionalInfo=@vyes WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);

                    cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);
                    cmd.Parameters.AddWithValue("@vyes", vyes);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }
        }

        protected void SaveEducationbtn_Click(object sender, EventArgs e)
        {

            if (countryvisitdrop.SelectedValue == "0")
            {
                Response.Write("<script> alert ('Please Select Yes Or No');</script>");
            }

           else if (GridView1.Rows.Count > 0 && countryvisitdrop.SelectedValue=="No")
            {
                Response.Write("<script> alert ('Please Check Forign Visit Details');</script>");
            }

            else if (GridView1.Rows.Count == 0 && countryvisitdrop.SelectedValue == "Yes")
            {
                Response.Write("<script> alert ('Please Add Forign Visit Details');</script>");
            }

            else if (bonddrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Bond Catagory');</script>");
            }

            //else if (String.IsNullOrEmpty(JoiningTimetxt.Text))

            //{
            //    Response.Write("<script> alert ('Enter Minimum Joining Period');</script>");
            //}

            else if (bonddrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Relative Working CSIR Catagory');</script>");
            }

            else if (RelativeDrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Relative Working CSIR Catagory');</script>");
            }

            else if (!termsandcondtionCheck.Checked)

            {
                Response.Write("<script> alert ('Please Accept the Declaration');</script>");
            }


            //else if (RelativeDrop.SelectedValue == "Yes")

            //{
            //    if (String.IsNullOrEmpty(RelativeNametxt.Text))
            //    {
            //        Response.Write("<script> alert ('Enter Name of Relative Working in CSIR Catagory');</script>");
            //    }

            //    else if (String.IsNullOrEmpty(PresentDesignationtxt.Text))
            //    {
            //        Response.Write("<script> alert ('Enter Designation of Relative Working in CSIR Catagory');</script>");
            //    }
            //    else if (String.IsNullOrEmpty(RelationTypetxt.Text))
            //    {
            //        Response.Write("<script> alert ('Enter Relative Type of Relative Working in CSIR Catagory');</script>");
            //    }

            //    else if (String.IsNullOrEmpty(NameCSIRtxt.Text))
            //    {
            //        Response.Write("<script> alert ('Enter Name of the CSIR Lab of Relative Working in CSIR Catagory');</script>");
            //    }

            //    else { UpdateBasicDetailsTable(); }


            //}

            else


              
            {
                UpdateBasicDetailsTable();
                stepsComplete();

                Response.Redirect("candidate_Home.aspx");
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                countryvisitdrop.Enabled = false;
            }
            else if (GridView1.Rows.Count == 0)
            {
                countryvisitdrop.Enabled = true;
            }
        }

        protected void bonddrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bonddrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Bond Catagory');</script>");
            }

            
        }

        protected void RelativeDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RelativeDrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Relative Working in CSIR Catagory');</script>");
                relativepanel.Visible = false;
            }

            else if (RelativeDrop.SelectedValue == "Yes")
            {
                relativepanel.Visible = true;
            }
            else if (RelativeDrop.SelectedValue == "No")
            {
               
              relativepanel.Visible = false;
                RelativeNametxt.Text = "";
                PresentDesignationtxt.Text = "";
                RelationTypetxt.Text = "";
                NameCSIRtxt.Text = "";


            }

           
        }

        protected void pwddrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pwddrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for PWD Catagory');</script>");
                pwdpanel.Visible = false;
            }

            else if (pwddrop.SelectedValue == "Yes")
            {
                pwdpanel.Visible = true;
            }
            else if (pwddrop.SelectedValue == "No")
            {

                pwdpanel.Visible = false;
               
                pwdpercttxt.Text = "";
                pwdtypedrop.SelectedIndex = 0;



            }
        }

        protected void AgeRlxClaimDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            if (AgeRlxClaimDrop.SelectedValue == "Yes")
            {
                RelaxationPanel.Visible = true;
            }
            else if (AgeRlxClaimDrop.SelectedValue == "No")
            {

                RelaxationPanel.Visible = false;
                             

            }
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }
}