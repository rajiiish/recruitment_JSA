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
    public partial class AcacadmicQualificationsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                if (!IsPostBack)
                {
                    //SSLCGridPanel.Visible = false;
                    regid();
                    LoadSSLCDetails();
                    LoadHSCDetails();
                    LoadDIPDetails();
                    LoadUGDetails();
                    LoadPGDetails();
                    YesOrNo();
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

        protected void phddrop_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        private void YesOrNo()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        string sslcyesno = dr.GetValue(47).ToString();
                        string HSCyesno = dr.GetValue(48).ToString();

                        string DIPyesno = dr.GetValue(49).ToString();


                        string UGyesno = dr.GetValue(50).ToString();
                        string PGyesno = dr.GetValue(51).ToString();

                        string PHDyesno = dr.GetValue(52).ToString();



                        if (sslcyesno =="Yes")
                        {
                            SSCLAddpanel.Visible = false;
                            SSLCGridPanel.Visible = true;
                        }
                        else if (sslcyesno=="No")
                        {
                            SSCLAddpanel.Visible = true;
                            SSLCGridPanel.Visible = false;
                        }


                        if (HSCyesno == "Yes")
                        {
                            HSCAddpanel.Visible = false;
                            HSCGridPanel.Visible = true;
                        }
                        else if (HSCyesno == "No")
                        {
                            HSCAddpanel.Visible = true;
                            HSCGridPanel.Visible = false;
                        }

                        if (DIPyesno == "Yes")
                        {
                            DIPLOMAAddpanel.Visible = false;
                            DIPLOMAGridPanel.Visible = true;
                        }
                        else if (DIPyesno == "No")
                        {
                            DIPLOMAAddpanel.Visible = true;
                            DIPLOMAGridPanel.Visible = false;
                        }


                        if (UGyesno == "Yes")
                        {
                            UGAddpanel.Visible = false;
                            UGGridPanel.Visible = true;
                        }
                        else if (UGyesno == "No")
                        {
                            UGAddpanel.Visible = true;
                            UGGridPanel.Visible = false;
                        }
                        if (PGyesno == "Yes")
                        {
                            PGAddpanel.Visible = false;
                            PGGridPanel.Visible = true;
                        }
                        else if (PGyesno == "No")
                        {
                            PGAddpanel.Visible = true;
                            PGGridPanel.Visible = false;
                        }

                        if (PHDyesno == "Yes")
                        {
                            PhdPanel.Visible = false;
                            phdGridPanel.Visible = true;
                        }
                        else if (PHDyesno == "No")
                        {
                            PhdPanel.Visible = true;
                            phdGridPanel.Visible = false;
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
        private void AddSSLCDetails()
        {
          
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string sslcname = SSLClbl.Text;

            string sslcinst = SSLCinstitutetxt.Text;

            string sslcmark = SSLCpmarkstext.Text;

            string sslcyear = SSLCpyeartxt.Text;

            string sslcclass = SSLCCourseclass.Text;

            string sslcyesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET SSLCcourse = @sslcname, SSLCInstitute = @sslcinst, SSLCPmarks = @sslcmark, SSLCPassYear = @sslcyear, SSLCClass = @sslcclass, SSLC=@sslcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@sslcname", sslcname);
                    cmd1.Parameters.AddWithValue("@sslcinst", sslcinst);
                    cmd1.Parameters.AddWithValue("@sslcmark", sslcmark);
                    cmd1.Parameters.AddWithValue("@sslcyear", sslcyear);
                    cmd1.Parameters.AddWithValue("@sslcclass", sslcclass);
                    cmd1.Parameters.AddWithValue("@sslcyesno", sslcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadSSLCDetails();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void AddHSCDetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string hsccname = HSClable.Text;

            string hscspl = HSCsplstxt.Text;

            string hscsub = HSCsub.Text;

            string hsccinst = HSCinstitutetxt.Text;

            string hsccmark = HSCpmarkstext.Text;

            string hsccyear = HSCpyeartxt.Text;

            string hsccclass = HSCCourseclass.Text;

            string hsccyesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET HSCCcourse = @hsccname, HSCcoursename= @hscspl, HSCSubject=@hscsub, HSCInstitute = @hsccinst, HSCPmarks = @hsccmark, HSCPassYear = @hsccyear, HSCClass = @hsccclass, HSC=@hsccyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@hsccname", hsccname);
                    cmd1.Parameters.AddWithValue("@hscsub", hscsub);
                    cmd1.Parameters.AddWithValue("@hscspl", hscspl);
                    cmd1.Parameters.AddWithValue("@hsccinst", hsccinst);
                    cmd1.Parameters.AddWithValue("@hsccmark", hsccmark);
                    cmd1.Parameters.AddWithValue("@hsccyear", hsccyear);
                    cmd1.Parameters.AddWithValue("@hsccclass", hsccclass);
                    cmd1.Parameters.AddWithValue("@hsccyesno", hsccyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadHSCDetails();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void AddDIPLOMADetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string DIPLOMAcname = DIPLOMAlable.Text;

            string DIPLOMAspl = DIPLOMAsplstxt.Text;

            string DIPLOMAsub = DIPLOMAsubTXT.Text;

            string DIPLOMAcinst = DIPLOMAinstitutetxt.Text;

            string DIPLOMAcmark = DIPLOMApmarkstext.Text;

            string DIPLOMAcyear = DIPLOMApyeartxt.Text;

            string DIPLOMAcclass = DIPLOMACourseclass.Text;

            string DIPLOMAcyesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET DIPLOMACcourse = @DIPLOMAcname, DIPLOMAcoursename= @DIPLOMAspl, DIPLOMASubject=@DIPLOMAsub, DIPLOMAInstitute = @DIPLOMAcinst, DIPLOMAPmarks = @DIPLOMAcmark, DIPLOMAPassYear = @DIPLOMAcyear, DIPLOMAClass = @DIPLOMAcclass, DIPLOMA=@DIPLOMAcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@DIPLOMAcname", DIPLOMAcname);
                    cmd1.Parameters.AddWithValue("@DIPLOMAsub", DIPLOMAsub);
                    cmd1.Parameters.AddWithValue("@DIPLOMAspl", DIPLOMAspl);
                    cmd1.Parameters.AddWithValue("@DIPLOMAcinst", DIPLOMAcinst);
                    cmd1.Parameters.AddWithValue("@DIPLOMAcmark", DIPLOMAcmark);
                    cmd1.Parameters.AddWithValue("@DIPLOMAcyear", DIPLOMAcyear);
                    cmd1.Parameters.AddWithValue("@DIPLOMAcclass", DIPLOMAcclass);
                    cmd1.Parameters.AddWithValue("@DIPLOMAcyesno", DIPLOMAcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadDIPDetails();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void AddUGDetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string UGname = UGlable.Text;

            string UGspl = UGsplstxt.Text;

            string UGsub = UGsubTXT.Text;

            string UGcinst = UGinstitutetxt.Text;

            string UGcmark = UGpmarkstext.Text;

            string UGcyear = UGpyeartxt.Text;

            string UGcclass = UGCourseclass.Text;

            string UGcyesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET UGcourse = @UGname, UGcoursename= @UGspl, UGSubject=@UGsub, UGInstitute = @UGcinst, UGPmarks = @UGcmark, UGPassYear = @UGcyear, UGClass = @UGcclass, UG=@UGcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@UGname", UGname);
                    cmd1.Parameters.AddWithValue("@UGspl", UGspl);
                    cmd1.Parameters.AddWithValue("@UGsub", UGsub);
                    cmd1.Parameters.AddWithValue("@UGcinst", UGcinst);
                    cmd1.Parameters.AddWithValue("@UGcmark", UGcmark);
                    cmd1.Parameters.AddWithValue("@UGcyear", UGcyear);
                    cmd1.Parameters.AddWithValue("@UGcclass", UGcclass);
                    cmd1.Parameters.AddWithValue("@UGcyesno", UGcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadUGDetails();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }


        private void AddPGDetails()
        {

            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string PGcname = PGlable.Text;

            string PGspl = PGsplstxt.Text;

            string PGsub = PGsubTXT.Text;

            string PGcinst = PGinstitutetxt.Text;

            string PGcmark = PGpmarkstext.Text;

            string PGcyear = PGpyeartxt.Text;

            string PGcclass = PGCourseclass.Text;

            string PGcyesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET PGcourse = @PGcname, PGcoursename= @PGspl, PGSubject=@PGsub, PGInstitute = @PGcinst, PGPmarks = @PGcmark, PGPassYear = @PGcyear, PGClass = @PGcclass, PG=@PGcyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@PGcname", PGcname);
                    cmd1.Parameters.AddWithValue("@PGspl", PGspl);
                    cmd1.Parameters.AddWithValue("@PGsub", PGsub);
                    cmd1.Parameters.AddWithValue("@PGcinst", PGcinst);
                    cmd1.Parameters.AddWithValue("@PGcmark", PGcmark);
                    cmd1.Parameters.AddWithValue("@PGcyear", PGcyear);
                    cmd1.Parameters.AddWithValue("@PGcclass", PGcclass);
                    cmd1.Parameters.AddWithValue("@PGcyesno", PGcyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                    LoadPGDetails();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
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
                     

            string PGcyesno = "Yes";

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
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
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
                    //  YesOrNo();
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
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void DeletePHDetails()
        {
            string dbcanreg = regidlbl.Text;

            string dbappno = appidnolbl.Text;

            string PHDyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET PHDTitle = NULL, PHDPassYear=NULL, PHDSubject=NULL, PHDDetails = NULL, PHD=@PHDyesno WHERE appregno = @ddbappno and can_regno=@dcanreg";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@PHDyesno", PHDyesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    YesOrNo();
                    //  YesOrNo();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void LoadSSLCDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SSLC1.Text = dr.GetValue(53).ToString();
                        SSLC2.Text = dr.GetValue(54).ToString();
                        SSLC3.Text = dr.GetValue(55).ToString();
                        SSLC4.Text = dr.GetValue(56).ToString();
                        SSLC5.Text = dr.GetValue(57).ToString();

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

        private void LoadHSCDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HSC1.Text = dr.GetValue(58).ToString();
                        HSC2.Text = dr.GetValue(59).ToString();
                        HSC3.Text = dr.GetValue(60).ToString();
                        HSC4.Text = dr.GetValue(61).ToString();
                        HSC5.Text = dr.GetValue(62).ToString();
                        HSC6.Text = dr.GetValue(63).ToString();
                        HSC7.Text = dr.GetValue(64).ToString();

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

        private void LoadDIPDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DIP1.Text = dr.GetValue(65).ToString();
                        DIP2.Text = dr.GetValue(66).ToString();
                        DIP3.Text = dr.GetValue(67).ToString();
                        DIP4.Text = dr.GetValue(68).ToString();
                        DIP5.Text = dr.GetValue(69).ToString();
                        DIP6.Text = dr.GetValue(70).ToString();
                        DIP7.Text = dr.GetValue(71).ToString();

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

        private void LoadUGDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UG1.Text = dr.GetValue(72).ToString();
                        UG2.Text = dr.GetValue(73).ToString();
                        UG3.Text = dr.GetValue(74).ToString();
                        UG4.Text = dr.GetValue(75).ToString();
                        UG5.Text = dr.GetValue(76).ToString();
                        UG6.Text = dr.GetValue(77).ToString();
                        UG7.Text = dr.GetValue(78).ToString();

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

        private void LoadPGDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PG1.Text = dr.GetValue(79).ToString();
                        PG2.Text = dr.GetValue(80).ToString();
                        PG3.Text = dr.GetValue(81).ToString();
                        PG4.Text = dr.GetValue(82).ToString();
                        PG5.Text = dr.GetValue(83).ToString();
                        PG6.Text = dr.GetValue(84).ToString();
                        PG7.Text = dr.GetValue(85).ToString();

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

        private void LoadPHDDetails()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PHD1.Text = dr.GetValue(86).ToString();
                        PHD2.Text = dr.GetValue(87).ToString();
                        PHD3.Text = dr.GetValue(88).ToString();
                        PHD4.Text = dr.GetValue(89).ToString();
                        
                        

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

        protected void AddSSLCbutton_Click(object sender, EventArgs e)
        {
            AddSSLCDetails();
        }

        protected void SSLCDeletebtn_Click(object sender, EventArgs e)
        {
            DeleteSSLCDetails();
            LoadSSLCDetails();
        }

     
        protected void AddHSCbutton_Click1(object sender, EventArgs e)
        {
            AddHSCDetails();
           
        }
        protected void hscDeletebtn_Click(object sender, EventArgs e)
        {
            DeleteHSCDetails();
            LoadHSCDetails();
        }

     
        protected void UGDeletebtn_Click(object sender, EventArgs e)
        {
            DeleteUGDetails();
            LoadUGDetails();
        }


       
      
        protected void AddPGbutton_Click1(object sender, EventArgs e)
        {
            AddPGDetails();
        }

        protected void AddUGbutton_Click(object sender, EventArgs e)
        {
            AddUGDetails();
        }

        protected void UGDeletebtn_Click1(object sender, EventArgs e)
        {
            DeleteUGDetails();
            LoadUGDetails();
        }

        protected void PGDeletebtn_Click1(object sender, EventArgs e)
        {
            DeletePGDetails();
            LoadPGDetails();
        }

        protected void AddDIPLOMAbutton_Click(object sender, EventArgs e)
        {
            AddDIPLOMADetails();
            
        }

        protected void DIPLOMADeletebtn_Click(object sender, EventArgs e)
        {
            DeleteDIPLOMADetails();
            LoadDIPDetails();
        }

        protected void addPhdbtn_Click(object sender, EventArgs e)
        {
            AddPHDetails();
        }

        protected void deletePHdbtn_Click(object sender, EventArgs e)
        {
            DeletePHDetails();
            LoadPHDDetails();
        }

        protected void SaveEducationbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExperienceAdd.aspx");
        }
    }
}