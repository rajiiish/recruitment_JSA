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
    public partial class ProfessionalAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                if (!IsPostBack)
                {
                    YesOrNo();
                    PublishDatashow();
                    PatentDatashow();
                    LoadAddExtraInfo();
                    
                    regid();
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



            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
        }
        private void UpdateBasicCheck()
        {
            string dbcanreg = Convert.ToString(Session["can_regno"]);

            string dbappno = Convert.ToString(Session["S_appregno"]);

            string yesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsUploadComplete = @yesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@yesno", yesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void YesOrNo()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT IsResearchPub,IsPatent FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        ResearchpubDrop.SelectedValue = dr.GetValue(0).ToString();
                        PatentDrop.SelectedValue = dr.GetValue(1).ToString();

                        string rpub = ResearchpubDrop.SelectedValue.ToString();
                        string pat   = PatentDrop.SelectedValue.ToString();



                        if (rpub == "Yes")
                        {                           
                            ResearchPanel.Visible = true;

                        }

                        else if (rpub == "No")
                        {
                            ResearchPanel.Visible = false;

                        }

                         if (pat == "Yes")
                        {
                           
                            PatentPanel.Visible = true;

                        }

                        else if (pat == "No")
                        {
                            
                            PatentPanel.Visible = false;

                        }
                    }
                }
                else
                {                   // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
                connection.Close();
            }




            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }

        }

        private void AddPulication()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {
                   
                    // string dbpcode = postDetailsdrop.Text;
                    string dbappno = appidnolbl.Text;
                    string dbcanreg = regidlbl.Text;

                    string pubyear = publicationYeartxt.Text;
                    string jourtype = JournalTypetxtdrop.Text;
                    string nopapers = NoofPaperstxt.Text;
                    string cif = CIFtxt.Text;

                   


                    string insertquery = "insert into ResearchPulication(can_regno, appregno, Yearofpublish, JournalType, NoPapers, CIF) values(@canreg, @dbappno, @pubyear, @jourtype, @nopapers, @cif)";
                   

                    SqlCommand cmd = new SqlCommand(insertquery, conn);
                    
                    cmd.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd.Parameters.AddWithValue("@canreg", dbcanreg);

                    cmd.Parameters.AddWithValue("@pubyear", pubyear);
                    cmd.Parameters.AddWithValue("@jourtype", jourtype);

                    cmd.Parameters.AddWithValue("@nopapers", nopapers);
                    cmd.Parameters.AddWithValue("@cif", cif);

                    
                    cmd.ExecuteNonQuery();                  

                    UpdateRpub();
                    PublishDatashow();
                    publicationYeartxt.Text = "";
                    JournalTypetxtdrop.SelectedIndex = 0;
                    NoofPaperstxt.Text = "";
                    CIFtxt.Text = "";
                    conn.Close();
                   
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        

        public void PublishDatashow()
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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM ResearchPulication where can_regno=@canreg and appregno=@appregno"))
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
                                    PublishGridView1.DataSource = dt;
                                    PublishGridView1.DataBind();
                                    conn.Close();
                                }
                            }
                        }
                    }
                    
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert (" + ex.Message + "');</script>");

                }

            }
        }

        protected void AddResearchPub_Click(object sender, EventArgs e)
        {
            AddPulication();

        }

        protected void ResPublicationDeletebtn_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;          

            int vid = Convert.ToInt32(PublishGridView1.DataKeys[rowindex].Value);

            SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE ResearchPulication WHERE id = @vid"))
                {
                    cmd.Parameters.AddWithValue("@vid", vid);
                    cmd.Connection = conn;
                    //con.Open();
                    cmd.ExecuteNonQuery();

                    
                    UpdateRpub();
                    YesOrNo();
                    conn.Close();
                }
            }
            this.PublishDatashow();
        }

        private void UpdateRpub()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    // string dbpcode = postDetailsdrop.Text;
                    string dbappno = appidnolbl.Text;
                    string dbcanreg = regidlbl.Text;
                    string yesno = ResearchpubDrop.SelectedValue.ToString();
                    string insertquery1 = "UPDATE basicdetailsNew SET IsResearchPub = @yesno WHERE appregno = @dbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@yesno", yesno);
                    cmd1.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd1.Parameters.AddWithValue("@canreg", dbcanreg);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        private void UpdatePatent()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    // string dbpcode = postDetailsdrop.Text;
                    string dbappno = appidnolbl.Text;
                    string dbcanreg = regidlbl.Text;                                       
                    string yesno = PatentDrop.SelectedValue.ToString();
                    string insertquery1 = "UPDATE basicdetailsNew SET IsPatent = @yesno WHERE appregno = @dbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);
                    
                    cmd1.Parameters.AddWithValue("@yesno", yesno);                   
                    cmd1.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd1.Parameters.AddWithValue("@canreg", dbcanreg);                   
                    cmd1.ExecuteNonQuery();                    
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
    

        private void AddPatents()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    // string dbpcode = postDetailsdrop.Text;
                    string dbappno = appidnolbl.Text;
                    string dbcanreg = regidlbl.Text;

                    string vPatentYear = PatentYeartxt.Text;
                    string vNoPatents = NoPatenttxt.Text;
                    string vNoPatentsGranted = NoPatentsGrantedtxt.Text;
                    string yesno = PatentDrop.SelectedValue.ToString();                  

                    string insertquery = "insert into Patents(can_regno, appregno, PatentYear, NoPatents, NoPatentsGranted) values(@canreg, @dbappno, @vPatentYear, @vNoPatents, @vNoPatentsGranted)";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);
                    cmd.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd.Parameters.AddWithValue("@canreg", dbcanreg);

                    cmd.Parameters.AddWithValue("@vPatentYear", vPatentYear);
                    cmd.Parameters.AddWithValue("@vNoPatents", vNoPatents);

                    cmd.Parameters.AddWithValue("@vNoPatentsGranted", vNoPatentsGranted);
                    
                    cmd.ExecuteNonQuery();
                    
                    UpdatePatent();
                    PatentDatashow();

                    PatentYeartxt.Text = "";
                    NoPatenttxt.Text = "";
                    NoPatentsGrantedtxt.Text = "";
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }
        public void PatentDatashow()
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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Patents where can_regno=@canreg and appregno=@appregno"))
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
                                    PatentGridView1.DataSource = dt;
                                    PatentGridView1.DataBind();
                                    conn.Close();
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert (" + ex.Message + "');</script>");

                }

            }
        }
       

        protected void AddPatent_Click1(object sender, EventArgs e)
        {
            AddPatents();
        }

        protected void DeletePatentlink_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            int vid = Convert.ToInt32(PatentGridView1.DataKeys[rowindex].Value);

            SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE Patents WHERE id = @vid"))
                {
                    cmd.Parameters.AddWithValue("@vid", vid);
                    cmd.Connection = conn;
                    //con.Open();
                    cmd.ExecuteNonQuery();

                   
                    UpdatePatent();
                    YesOrNo();
                    conn.Close();
                }
            }
            this.PatentDatashow();
        }

        public void LoadAddExtraInfo()
        {

            string appregno = Convert.ToString(Session["S_appregno"]);
            string dbcanreg = Convert.ToString(Session["can_regno"]);
            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from ExtraInfo where can_regno= @canreg ", con);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                cmd.Parameters.AddWithValue("@appregno", appregno);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TechnolgyDevtxt.Text = dr.GetValue(2).ToString();
                        
                        Awardstxt.Text = dr.GetValue(3).ToString();

                        membershiptxt.Text = dr.GetValue(4).ToString();


                    }
                }
                else
                {
                  //  Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
        private void AddExtraInfo()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    // string dbpcode = postDetailsdrop.Text;
                    string dbappno = appidnolbl.Text;
                    string dbcanreg = regidlbl.Text;

                    string vNoTechDev = TechnolgyDevtxt.Text;
                    string vAwards = Awardstxt.Text;
                    string vMember = membershiptxt.Text;

                    
                    string insertquery = "Update ExtraInfo SET NoTechnologyDevloped = @vNoTechDev, AwardsPrizes = @vAwards, Membership = @vMember WHERE  appregno = @dbappno and can_regno=@canreg";
                    SqlCommand cmd = new SqlCommand(insertquery, conn);



                    cmd.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd.Parameters.AddWithValue("@canreg", dbcanreg);

                    cmd.Parameters.AddWithValue("@vNoTechDev", vNoTechDev);
                    cmd.Parameters.AddWithValue("@vAwards", vAwards);

                    cmd.Parameters.AddWithValue("@vMember", vMember);

                    cmd.ExecuteNonQuery();
                    LoadAddExtraInfo();
                    conn.Close();

                   

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
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


                    string insertquery = "Update ApplicationSteps SET Profession=@vyes WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

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
        protected void SaveDetails_Click(object sender, EventArgs e)
        {
            if ((PublishGridView1.Rows.Count == 0) && (ResearchpubDrop.SelectedValue == "Yes"))
            {
                Response.Write("<script> alert ('Check and Add atlest one Publication Details');</script>");
            }

          else  if ((PatentGridView1.Rows.Count == 0) && (PatentDrop.SelectedValue == "Yes"))
            {
                Response.Write("<script> alert ('Check and Add atlest one Patent Details');</script>");
            }


            else
            {
                AddExtraInfo();
                stepsComplete();
                UpdateRpub();
                UpdatePatent();

                Response.Redirect("candidate_Home.aspx");
            }
        }

        protected void ResearchpubDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResearchpubDrop.SelectedValue == "Yes")
            {
                ResearchPanel.Visible = true;
            }
            else if (ResearchpubDrop.SelectedValue == "No")
            {
                ResearchPanel.Visible = false;
            }
        }

        protected void PatentDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PatentDrop.SelectedValue == "Yes")
            {
                PatentPanel.Visible = true;
            }
            else if (PatentDrop.SelectedValue == "No")
            {
                PatentPanel.Visible = false;
            }
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }

        
 }
