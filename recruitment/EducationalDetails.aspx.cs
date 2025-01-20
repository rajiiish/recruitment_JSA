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
    public partial class EducationTechnician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                
                if (!IsPostBack)
                {
                    regid();
                    loadeducationSSLC();
                    loadeducationHSC();
                    loadeducationITI();
                    loadeducationDIPLOMA();
                    loadeducationUG();
                    loadeducationPG();
                    LoadPHDDetails();
                    LoadGATEDetails();
                    LoadExtraEduacation();
                    YesOrNo();

                    PhdLable.Visible = false;
                    GateLbl.Visible = false;
                    phddrop.Visible = false;
                    GateQualDrop.Visible = false;

                    if (phddrop.SelectedValue == "No")
                    {
                        PhdPanel.Visible = false;
                        
                    }

                    if (GateQualDrop.SelectedValue == "No")
                    {
                        GateQualPanel.Visible = false;

                    }
                }
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

        }

        private void YesOrNo()
        {
            try
            {
                
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



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

                        phddrop.SelectedValue = PHDyesno;
                        GateQualDrop.SelectedValue = GATEyesno;



                        if (sslcyesno == "Yes" && HSCyesno == "Yes" && ITIyesno == "Yes")
                        {
                            schoolHeadRow.Visible = true;
                           
                        }
                        else if (sslcyesno == "Yes" && HSCyesno == "No")
                        {
                            schoolHeadRow.Visible = true;
                        }

                        else if (sslcyesno == "No" && HSCyesno == "Yes")
                        {
                            schoolHeadRow.Visible = true;
                        }

                        else if (sslcyesno == "No" && HSCyesno == "No" && ITIyesno == "No")
                        {
                            schoolHeadRow.Visible = false;
                            SchoolEducationPanel.Visible = false;
                        }

                        if (sslcyesno == "Yes" && HSCyesno == "Yes" && DIPyesno == "Yes" && UGyesno == "Yes" && PGyesno == "Yes")
                        {
                           
                            Addlbl.Visible = false;
                            //AddFormPanel.Visible = false;
                        }

                        if (sslcyesno == "No" && HSCyesno == "No" && ITIyesno == "No" && DIPyesno == "No" && UGyesno == "No" && PGyesno == "No")
                        {
                            noentryRow.Visible = true;
                            NoEntrylbl.Text = "Please Add Educational Qualification Details from SSLC/SSC/10th onwards!!";
                        }

                        if (DIPyesno == "Yes" || UGyesno == "Yes")
                        {
                            collegHeadRow.Visible = true;

                        }
                        else if (DIPyesno == "No" && UGyesno == "No" && PGyesno == "No")
                        {
                            collegHeadRow.Visible = false;
                            CollegeEducationPanel.Visible = false;

                        }

                        if (phddrop.SelectedValue == "Yes")
                        {
                            PhdPanel.Visible = true;
                          


                        }
                        else if (phddrop.SelectedValue == "No")
                        {
                            PhdPanel.Visible = false;
                            
                        }


                        if (GateQualDrop.SelectedValue == "Yes")
                        {
                            GateQualPanel.Visible = true;



                        }
                        else if (GateQualDrop.SelectedValue == "No")
                        {
                            GateQualPanel.Visible = false;

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
        private void SSLC_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
              //  string dbcoursename = nameofdegree.Text;
            //    string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;
                string sslcyesno = "Yes";

               
                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
                string insertquery = "UPDATE basicdetailsNew SET SSLCcourse = @dbcourse, SSLCInstitute = @db2, SSLCPmarks = @db3, SSLCPassYear = @db4, SSLCClass = @db5, SSLC=@sslcyesno WHERE appregno = @dbappno and can_regno=@canreg";

            //    string insertquery = "insert into educational(can_regno, appregno, course, coursename, Subject, Institute, Pmarks, PassYear, Class) values(@canreg, @dbappno, @dbcourse, @dbcoursename, @dbfield1, @dbfield2, @dbfield3, @dbfield4, @dbfield5)";
                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
             //   cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

            //    cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@db2", db2);
                cmd.Parameters.AddWithValue("@db3", db3);
                cmd.Parameters.AddWithValue("@db4", db4);
                cmd.Parameters.AddWithValue("@db5", db5);
                cmd.Parameters.AddWithValue("@sslcyesno", sslcyesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }

        private void HSC_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
                string dbcoursename = nameofdegree.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;

                string yesno = "Yes";

                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
                string insertquery = "UPDATE basicdetailsNew SET HSCCcourse = @dbcourse, HSCcoursename= @dbcoursename, HSCSubject=@dbfield1, HSCInstitute = @dbfield2, HSCPmarks = @dbfield3, HSCPassYear = @dbfield4, HSCClass = @dbfield5, HSC=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.Parameters.AddWithValue("@yesno", yesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }

        private void ITI_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
                string dbcoursename = nameofdegree.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;

                string yesno = "Yes";

                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
                string insertquery = "UPDATE basicdetailsNew SET ITICcourse = @dbcourse, ITIcoursename= @dbcoursename, ITISubject=@dbfield1, ITIInstitute = @dbfield2, ITIPmarks = @dbfield3, ITIPassYear = @dbfield4, ITIClass = @dbfield5, ITI=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.Parameters.AddWithValue("@yesno", yesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }


        private void DIPLOMA_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
                string dbcoursename = nameofdegree.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;

                string yesno = "Yes";

                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
             //   string insertquery1 = "UPDATE basicdetailsNew SET HSCCcourse = @dbcourse, HSCcoursename= @dbcoursename, HSCSubject=@dbfield1, HSCInstitute = @dbfield2, HSCPmarks = @dbfield3, HSCPassYear = @dbfield4, HSCClass = @dbfield5, HSC=@yesno WHERE appregno = @dbappno and can_regno=@canreg";
                string insertquery = "UPDATE basicdetailsNew SET DIPLOMACcourse = @dbcourse, DIPLOMAcoursename= @dbcoursename, DIPLOMASubject=@dbfield1, DIPLOMAInstitute = @dbfield2, DIPLOMAPmarks = @dbfield3, DIPLOMAPassYear = @dbfield4, DIPLOMAClass = @dbfield5, DIPLOMA=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.Parameters.AddWithValue("@yesno", yesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }

        private void UG_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
                string dbcoursename = nameofdegree.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;

                string yesno = "Yes";

                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
                //   string insertquery1 = "UPDATE basicdetailsNew SET HSCCcourse = @dbcourse, HSCcoursename= @dbcoursename, HSCSubject=@dbfield1, HSCInstitute = @dbfield2, HSCPmarks = @dbfield3, HSCPassYear = @dbfield4, HSCClass = @dbfield5, HSC=@yesno WHERE appregno = @dbappno and can_regno=@canreg";
              //  string insertquery2 = "UPDATE basicdetailsNew SET DIPLOMACcourse = @dbcourse, DIPLOMAcoursename= @dbcoursename, DIPLOMASubject=@dbfield1, DIPLOMAInstitute = @dbfield1, DIPLOMAPmarks = @dbfield1, DIPLOMAPassYear = @dbfield1, DIPLOMAClass = @dbfield1, DIPLOMA=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                string insertquery = "UPDATE basicdetailsNew SET UGcourse = @dbcourse, UGcoursename= @dbcoursename, UGSubject=@dbfield1, UGInstitute = @dbfield2, UGPmarks = @dbfield3, UGPassYear = @dbfield4, UGClass = @dbfield5, UG=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.Parameters.AddWithValue("@yesno", yesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }

        private void PG_Education_Add()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;


                string dbcourse = coursedropdown.Text;
                string dbcoursename = nameofdegree.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = Courseclass.Text;

                string yesno = "Yes";

                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();
                //   string insertquery1 = "UPDATE basicdetailsNew SET HSCCcourse = @dbcourse, HSCcoursename= @dbcoursename, HSCSubject=@dbfield1, HSCInstitute = @dbfield2, HSCPmarks = @dbfield3, HSCPassYear = @dbfield4, HSCClass = @dbfield5, HSC=@yesno WHERE appregno = @dbappno and can_regno=@canreg";
                //  string insertquery2 = "UPDATE basicdetailsNew SET DIPLOMACcourse = @dbcourse, DIPLOMAcoursename= @dbcoursename, DIPLOMASubject=@dbfield1, DIPLOMAInstitute = @dbfield1, DIPLOMAPmarks = @dbfield1, DIPLOMAPassYear = @dbfield1, DIPLOMAClass = @dbfield1, DIPLOMA=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                string insertquery = "UPDATE basicdetailsNew SET PGcourse = @dbcourse, PGcoursename= @dbcoursename, PGSubject=@dbfield1, PGInstitute = @dbfield2, PGPmarks = @dbfield3, PGPassYear = @dbfield4, PGClass = @dbfield5, PG=@yesno WHERE appregno = @dbappno and can_regno=@canreg";

                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbcoursename", dbcoursename);

                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.Parameters.AddWithValue("@yesno", yesno);
                cmd.ExecuteNonQuery();
                Response.Redirect("EducationalDetails.aspx");
                YesOrNo();
                conn.Close();
            }


        }

        private void AddPHDetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string PHDtitle = phdtxt1.Text;

            string PHDyear = phdtxt2.Text;

            string PHDsub = phdtxt3.Text;

            string PHDdetails = phdtxt4.Text;


            string PGcyesno = phddrop.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET PHDTitle = @PHDtitle, PHDPassYear= @PHDyear, PHDSubject=@PHDsub, PHDDetails = @PHDdetails, PHD=@PGcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@PHDtitle", PHDtitle);
                    cmd1.Parameters.AddWithValue("@PHDyear", PHDyear);
                    cmd1.Parameters.AddWithValue("@PHDsub", PHDsub);
                    cmd1.Parameters.AddWithValue("@PHDdetails", PHDdetails);

                    cmd1.Parameters.AddWithValue("@PGcyesno", PGcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadPHDDetails();
                   // YesOrNo();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void AddGATEetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string GATEmarks = GateMarkstxt.Text;

            string GATEyear = Gatepassyeartxt.Text;

            string GATEsub = GatebranchDrop.SelectedItem.ToString();

            string vGATEbranch = GatebranchDrop.SelectedValue.ToString();

            string yesno = GateQualDrop.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET GATEmarks = @vGATEmarks, GATEPassYear= @vGATEyear, GATEsub=@vGATEsub, GATEbranch=@vGATEbranch, GATE=@yesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@vGATEmarks", GATEmarks);
                    cmd1.Parameters.AddWithValue("@vGATEyear", GATEyear);
                    cmd1.Parameters.AddWithValue("@vGATEsub", GATEsub);
                    cmd1.Parameters.AddWithValue("@vGATEbranch", vGATEbranch);

                    cmd1.Parameters.AddWithValue("@yesno", yesno);

                   

                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadGATEDetails();
                   // YesOrNo();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void loadeducationSSLC()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLCcourse,SSLCInstitute,SSLCPmarks,SSLCPassYear,SSLCClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and SSLC = 'Yes' ";

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

                        //connection.Close();
                    }
                }
                else
                {
                    sslcRow.Visible = false;
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

        private void loadeducationHSC()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT HSCCcourse, HSCcoursename, HSCSubject, HSCInstitute, HSCPmarks, HSCPassYear, HSCClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and HSC = 'Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hsc1.Text = dr.GetValue(0).ToString();
                        hsc2.Text = dr.GetValue(1).ToString();
                        hsc3.Text = dr.GetValue(2).ToString();

                        hsc4.Text = dr.GetValue(3).ToString();
                        hsc5.Text = dr.GetValue(4).ToString();
                        hsc6.Text = dr.GetValue(5).ToString();
                        hsc7.Text = dr.GetValue(6).ToString();

                     //   connection.Close();
                    }
                }
                else
                {
                    hscRow.Visible = false;
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

        private void loadeducationITI()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT ITICcourse, ITIcoursename, ITISubject, ITIInstitute, ITIPmarks, ITIPassYear, ITIClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and ITI = 'Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ITI1.Text = dr.GetValue(0).ToString();
                        ITI2.Text = dr.GetValue(1).ToString();
                        ITI3.Text = dr.GetValue(2).ToString();

                        ITI4.Text = dr.GetValue(3).ToString();
                        ITI5.Text = dr.GetValue(4).ToString();
                        ITI6.Text = dr.GetValue(5).ToString();
                        ITI7.Text = dr.GetValue(6).ToString();

                        // connection.Close();
                    }
                }
                else
                {
                    ITIRow.Visible = false;
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

        private void loadeducationDIPLOMA()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT DIPLOMACcourse, DIPLOMAcoursename, DIPLOMASubject, DIPLOMAInstitute, DIPLOMAPmarks, DIPLOMAPassYear, DIPLOMAClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and DIPLOMA = 'Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dip1.Text = dr.GetValue(0).ToString();
                        dip2.Text = dr.GetValue(1).ToString();
                        dip3.Text = dr.GetValue(2).ToString();

                        dip4.Text = dr.GetValue(3).ToString();
                        dip5.Text = dr.GetValue(4).ToString();
                        dip6.Text = dr.GetValue(5).ToString();
                        dip7.Text = dr.GetValue(6).ToString();
                     //   connection.Close();

                    }
                }
                else
                {
                    dipRow.Visible = false;
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


        private void loadeducationUG()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT UGcourse,UGcoursename,UGSubject,UGInstitute,UGPmarks,UGPassYear,UGClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and UG = 'Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ug1.Text = dr.GetValue(0).ToString();
                        ug2.Text = dr.GetValue(1).ToString();
                        ug3.Text = dr.GetValue(2).ToString();

                        ug4.Text = dr.GetValue(3).ToString();
                        ug5.Text = dr.GetValue(4).ToString();
                        ug6.Text = dr.GetValue(5).ToString();
                        ug7.Text = dr.GetValue(6).ToString();
                      //  connection.Close();

                    }
                }
                else
                {
                    ugRow.Visible = false;
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


        private void loadeducationPG()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT PGcourse , PGcoursename, PGSubject, PGInstitute, PGPmarks, PGPassYear, PGClass FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and PG = 'Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pg1.Text = dr.GetValue(0).ToString();
                        pg2.Text = dr.GetValue(1).ToString();
                        pg3.Text = dr.GetValue(2).ToString();

                        pg4.Text = dr.GetValue(3).ToString();
                        pg5.Text = dr.GetValue(4).ToString();
                        pg6.Text = dr.GetValue(5).ToString();
                        pg7.Text = dr.GetValue(6).ToString();

                       // connection.Close();
                    }
                }
                else
                {
                    pgRow.Visible = false;
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

        private void LoadPHDDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT PHDTitle, PHDPassYear, PHDSubject, PHDDetails  FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and PHD='Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        phdtxt1.Text = dr.GetValue(0).ToString();
                        phdtxt2.Text = dr.GetValue(1).ToString();
                        phdtxt3.Text = dr.GetValue(2).ToString();
                        phdtxt4.Text = dr.GetValue(3).ToString();
                      //  PhdDisplayPanel.Visible = true;
                     //   PhdPanel.Visible = false;

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

        private void LoadGATEDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT GATEmarks, GATEPassYear, GATEbranch FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext and GATE='Yes' ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GateMarkstxt.Text = dr.GetValue(0).ToString();
                        Gatepassyeartxt.Text = dr.GetValue(1).ToString();
                        GatebranchDrop.SelectedValue = dr.GetValue(2).ToString();
                       
                        //  GATEDisplayPanel.Visible = true;
                        //   GATEPanel.Visible = false;

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

        private void LoadExtraEduacation()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT *FROM AddQualfications WHERE can_regno = @canregdbtest and appregno = @appregnotext";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Qualf1.Text = dr.GetValue(2).ToString();
                        Qualf2.Text = dr.GetValue(3).ToString();
                        Qualf3.Text = dr.GetValue(4).ToString();
                        Qualf4.Text = dr.GetValue(5).ToString();

                        Qualf5.Text = dr.GetValue(6).ToString();
                        Qualf6.Text = dr.GetValue(7).ToString();
                        Qualf7.Text = dr.GetValue(8).ToString();
                        Qualf8.Text = dr.GetValue(9).ToString();

                        Qualf9.Text = dr.GetValue(10).ToString();
                        Qualf10.Text = dr.GetValue(11).ToString();
                        Qualf11.Text = dr.GetValue(12).ToString();
                        Qualf12.Text = dr.GetValue(13).ToString();

                        Qualf13.Text = dr.GetValue(14).ToString();
                        Qualf14.Text = dr.GetValue(15).ToString();
                        Qualf15.Text = dr.GetValue(16).ToString();
                        Qualf16.Text = dr.GetValue(17).ToString();

                        //  GATEDisplayPanel.Visible = true;
                        //   GATEPanel.Visible = false;

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


        private void DeleteSSLCDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string sslcyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET SSLCcourse = NULL , SSLCInstitute = NULL , SSLCPmarks =NULL , SSLCPassYear = NULL , SSLCClass =NULL , SSLC=@sslcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@sslcyesno", sslcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                   
                      YesOrNo();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void DeleteHSCDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string HSCyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET HSCCcourse = NULL, HSCcoursename=NULL, HSCSubject=NULL, HSCInstitute = NULL, HSCPmarks = NULL, HSCPassYear = NULL, HSCClass = NULL, HSC=@HSCyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@HSCyesno", HSCyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                      YesOrNo();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void DeleteITIDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string ITIyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET ITICcourse = NULL, ITIcoursename=NULL, ITISubject=NULL, ITIInstitute = NULL, ITIPmarks = NULL, ITIPassYear = NULL, ITIClass = NULL, ITI=@ITIyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@ITIyesno", ITIyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    YesOrNo();
                    conn.Close();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void DeleteDIPLOMADetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string DIPLOMAyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET DIPLOMACcourse = NULL, DIPLOMAcoursename=NULL, DIPLOMASubject=NULL, DIPLOMAInstitute = NULL, DIPLOMAPmarks = NULL, DIPLOMAPassYear = NULL, DIPLOMAClass = NULL, DIPLOMA=@DIPLOMAyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@DIPLOMAyesno", DIPLOMAyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    YesOrNo();
                    conn.Close();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void DeleteUGDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string UGyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET UGcourse = NULL, UGcoursename=NULL, UGSubject=NULL, UGInstitute = NULL, UGPmarks = NULL, UGPassYear = NULL, UGClass = NULL, UG=@UGyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@UGyesno", UGyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    YesOrNo();
                    conn.Close();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void DeletePGDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string PGyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET PGcourse = NULL, PGcoursename=NULL, PGSubject=NULL, PGInstitute = NULL, PGPmarks = NULL, PGPassYear = NULL, PGClass = NULL, PG=@PGyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@PGyesno", PGyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    YesOrNo();
                    conn.Close();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        protected void Addbutton_Click(object sender, EventArgs e)
        {
            if (coursedropdown.SelectedValue== "SSC/SSLC/10th")
                {

                if (sslcRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";
                }
                else
                {
                    SSLC_Education_Add();
                    loadeducationSSLC();
                    noentryRow.Visible = false;
                }
               
            }
            else if (coursedropdown.SelectedValue == "HSC/PUC/12th")
            {
                if (hscRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";

                }
                else
                {
                    HSC_Education_Add();
                    loadeducationHSC();
                    noentryRow.Visible = false;
                }
                
            }
            else if (coursedropdown.SelectedValue == "ITI")
            {
                if (ITIRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";

                }
                else
                {
                    ITI_Education_Add();
                    loadeducationITI();
                    noentryRow.Visible = false;
                }
            }
            else if (coursedropdown.SelectedValue == "DIPLOMA")
            {
                if (dipRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";

                }
                else
                {
                    DIPLOMA_Education_Add();
                    loadeducationDIPLOMA();
                    noentryRow.Visible = false;
                }
            }
            else if (coursedropdown.SelectedValue == "UG")
            {
                if (ugRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";

                }
                else
                {
                    UG_Education_Add();
                    loadeducationUG();
                    noentryRow.Visible = false;
                }
            }

            else if (coursedropdown.SelectedValue == "PG")
            {
                if (pgRow.Visible == true)
                {
                    EducationErrorinAddLbl.Text = "Record Already Added";

                }
                else
                {
                    PG_Education_Add();
                    loadeducationPG();
                    noentryRow.Visible = false;
                }
            }
        }

       

  

        protected void sscdelete_Click(object sender, ImageClickEventArgs e)
        {
            DeleteSSLCDetails();
            loadeducationSSLC();
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void hscdelete_Click(object sender, ImageClickEventArgs e)
        {
            DeleteHSCDetails();
            loadeducationHSC();
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void ITIDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteITIDetails();
            loadeducationITI();
            Response.Redirect("EducationalDetails.aspx");
        }
        protected void dipdelete_Click(object sender, ImageClickEventArgs e)
        {
            DeleteDIPLOMADetails();
            loadeducationDIPLOMA();
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void ugdelete_Click(object sender, ImageClickEventArgs e)
        {
            DeleteUGDetails();
            loadeducationUG();
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void pgdelete_Click(object sender, ImageClickEventArgs e)
        {
            DeletePGDetails();
            loadeducationPG();
            Response.Redirect("EducationalDetails.aspx");
        }

        protected void coursedropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursedropdown.SelectedValue == "SSC/SSLC/10th")
            {
                subjecttxt.Text = "SSC/SSLC/10th";
                nameofdegree.Text = "SSC/SSLC/10th";
                DegreeNamelbl.Text = "Specialization";
                MainSubjectlbl.Text = "Main Subject";             

                subjecttxt.Enabled = false;
                nameofdegree.Enabled = false;

             //   nameofdegree.Text = "";
             //   subjecttxt.Text = "";
                institutetxt.Text = "";
                pmarkstext.Text = "";
                pyeartxt.Text = "";
                Courseclass.SelectedIndex = 0;
               
            }

            else if (coursedropdown.SelectedValue == "HSC/PUC/12th")
            {

                nameofdegree.Text = "HSC/PUC/12th";
                DegreeNamelbl.Text = "Specialization";
                MainSubjectlbl.Text = "Main Subject";
                nameofdegree.Enabled = false;
                subjecttxt.Enabled = true;

              //  nameofdegree.Text = "";
                subjecttxt.Text = "";
                institutetxt.Text = "";
                pmarkstext.Text = "";
                pyeartxt.Text = "";
                Courseclass.SelectedIndex = 0;

            }
            else if (coursedropdown.SelectedValue == "DIPLOMA")
            {
                DegreeNamelbl.Text = "Name of the Diploma";
                MainSubjectlbl.Text = "Main Subject in Diploma";
                
                subjecttxt.Enabled = true;
                nameofdegree.Enabled = true;

                nameofdegree.Text = "";
                subjecttxt.Text = "";
                institutetxt.Text = "";
                pmarkstext.Text = "";
                pyeartxt.Text = "";
                Courseclass.SelectedIndex = 0;
            }
            else if (coursedropdown.SelectedValue == "UG")
            {
                DegreeNamelbl.Text = "Name of the UG Degree";
                MainSubjectlbl.Text = "Main Subjects in UG Degree";
               
                subjecttxt.Enabled = true;
                nameofdegree.Enabled = true;

                nameofdegree.Text = "";
                subjecttxt.Text = "";
                institutetxt.Text = "";
                pmarkstext.Text = "";
                pyeartxt.Text = "";
                Courseclass.SelectedIndex = 0;
            }
            else if (coursedropdown.SelectedValue == "PG")
            {
                DegreeNamelbl.Text = "Name of the PG Degree";
                MainSubjectlbl.Text = "Main Subjects in PG Degree";
                
                subjecttxt.Enabled = true;
                nameofdegree.Enabled = true;

                nameofdegree.Text = "";
                subjecttxt.Text = "";
                institutetxt.Text = "";
                pmarkstext.Text = "";
                pyeartxt.Text = "";
                Courseclass.SelectedIndex = 0;
            }
            else
            {
                nameofdegree.Enabled = true;
                subjecttxt.Enabled = true;
                nameofdegree.Text = "";
                subjecttxt.Text = "";

            }
            EducationErrorinAddLbl.Text = "";
            
        }

        protected void phddrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phddrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for Phd Details');</script>");
                PhdPanel.Visible = false;
            }

            else if (phddrop.SelectedValue == "Yes")
            {
                PhdPanel.Visible = true;
               
            }
            else if (phddrop.SelectedValue == "No")
            {

                PhdPanel.Visible = false;
                phdtxt1.Text = "";
                phdtxt2.Text = "";
                phdtxt3.Text = "";
                phdtxt4.Text = "";


            }
        }

        private void stepsComplete()
        {
            string canregdbtest = Convert.ToString(Session["can_regno"]);
            string vappidnolbl = Convert.ToString(Session["S_appregno"]);
            string vyes = "Yes";
            string vno = "No";
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {


                    string insertquery = "Update ApplicationSteps SET Education=@vyes , Upload=@vno WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";
                    SqlCommand cmd = new SqlCommand(insertquery, conn);
                    cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);
                    cmd.Parameters.AddWithValue("@vyes", vyes);
                    cmd.Parameters.AddWithValue("@vno", vno);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }
        }

       
        private void ExtraEduacation()
        {
            string canregdbtest = Convert.ToString(Session["can_regno"]);
            string vappidnolbl = Convert.ToString(Session["S_appregno"]);
            
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {


                    string insertquery = "Update AddQualfications SET Q1_Type=@vQ1_Type, Q1_Name=@vQ1_Name, Q1_InstUnistyColl = @vQ1_InstUnistyColl, Q1_Year = @vQ1_Year, Q2_Type=@vQ2_Type, Q2_Name=@vQ2_Name, Q2_InstUnistyColl = @vQ2_InstUnistyColl, Q2_Year = @vQ2_Year, Q3_Type=@vQ3_Type, Q3_Name=@vQ3_Name, Q3_InstUnistyColl = @vQ3_InstUnistyColl, Q3_Year = @vQ3_Year, Q4_Type=@vQ4_Type, Q4_Name=@vQ4_Name, Q4_InstUnistyColl = @vQ4_InstUnistyColl, Q4_Year = @vQ4_Year  WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);
                    cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);

                    cmd.Parameters.AddWithValue("@vQ1_Type", Qualf1.Text);
                    cmd.Parameters.AddWithValue("@vQ1_Name", Qualf2.Text);
                    cmd.Parameters.AddWithValue("@vQ1_InstUnistyColl", Qualf3.Text);
                    cmd.Parameters.AddWithValue("@vQ1_Year", Qualf4.Text);

                    cmd.Parameters.AddWithValue("@vQ2_Type", Qualf5.Text);
                    cmd.Parameters.AddWithValue("@vQ2_Name", Qualf6.Text);
                    cmd.Parameters.AddWithValue("@vQ2_InstUnistyColl", Qualf7.Text);
                    cmd.Parameters.AddWithValue("@vQ2_Year", Qualf8.Text);

                    cmd.Parameters.AddWithValue("@vQ3_Type", Qualf9.Text);
                    cmd.Parameters.AddWithValue("@vQ3_Name", Qualf10.Text);
                    cmd.Parameters.AddWithValue("@vQ3_InstUnistyColl", Qualf11.Text);
                    cmd.Parameters.AddWithValue("@vQ3_Year", Qualf12.Text);

                    cmd.Parameters.AddWithValue("@vQ4_Type", Qualf13.Text);
                    cmd.Parameters.AddWithValue("@vQ4_Name", Qualf14.Text);
                    cmd.Parameters.AddWithValue("@vQ4_InstUnistyColl", Qualf15.Text);
                    cmd.Parameters.AddWithValue("@vQ4_Year", Qualf16.Text);

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
            if (sslcRow.Visible == false)
            {
                Response.Write("<script> alert ('Enter 10th or Equivalent Details');</script>");
            }
            //else if (hscRow.Visible == false)
            //{
            //    Response.Write("<script> alert ('Enter 12th or Equivalent Details');</script>");

            //}
            else if (((applyhpostlbl.Text == "Technical Assistant (IT)") || (applyhpostlbl.Text == "Technical Assistant (Civil)")) && ((dipRow.Visible == false)))
            {
                Response.Write("<script> alert ('Enter Diploma or Equivalent Details');</script>");

            }
            else 
            {
                AddPHDetails();
                AddGATEetails();
                stepsComplete();
                ExtraEduacation();
                Response.Redirect("Candidate_Home.aspx");

            }

        }

        protected void GateQualDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GateQualDrop.SelectedValue == "0")

            {
                Response.Write("<script> alert ('Select Yes or No for GATE Score');</script>");
                GateQualPanel.Visible = false;
            }

            else if (GateQualDrop.SelectedValue == "Yes")
            {
                GateQualPanel.Visible = true;

            }
            else if (GateQualDrop.SelectedValue == "No")
            {

                GateQualPanel.Visible = false;
                GateMarkstxt.Text = "";
                Gatepassyeartxt.Text = "";
                GatebranchDrop.SelectedValue = "0";
               
            }
        }

       
        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }
}