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
    public partial class ExperienceAdd : System.Web.UI.Page
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

                    if (expdetailsdrop.SelectedValue == "No")
                    {

                        exppanel.Visible = false;
                    }

                    if (GridView1.Rows.Count > 0)
                    {
                        exppanel.Visible = true;
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

            //datetimelbl.Text = serverTime.ToString("dd/MM/yyyy");
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
                string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string complete = dr.GetValue(27).ToString();

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
        private void duration()
        {


            if (fromtxt.Text != "" && totxt.Text != "")
            {
                DateTime fm = Convert.ToDateTime(fromtxt.Text);
                DateTime to = Convert.ToDateTime(totxt.Text);

                TimeSpan objTimeSpan = to - fm;

               

                int Years = to.Year - fm.Year;
                int month = to.Month - fm.Month;
                double Days = to.Day - fm.Day;
               // double Days = Convert.ToDouble(objTimeSpan.TotalDays);

                
                
                totalexptxt.Text = Years + "  Year  " + month + "  Months " + Days + "  Days";


            }
        }
        private void UpdateBasicDetailsTable()
        {
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {
                    string IsExperienced = expdetailsdrop.SelectedValue.ToString();

                    string dbcanreg = regidlbl.Text;

                    string dbappno = appidnolbl.Text;

                    string insertquery1 = "UPDATE basicdetailsNew SET IsExperienced=@IsExperienced  WHERE appregno = @dbappno";
                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);

                    cmd1.Parameters.AddWithValue("@IsExperienced", IsExperienced);

                    cmd1.Parameters.AddWithValue("@canreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@dbappno", dbappno);

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

        private void YesOrNo()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT IsExperienced FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        expdetailsdrop.SelectedValue = dr.GetValue(0).ToString();
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
            totalexptxt.Text = (string.Format("{0} years, {1} months, {2} days", years, months, days));

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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM experience where can_regno=@canreg and appregno=@appregno"))
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

        private void addexp()
        {
            if (String.IsNullOrEmpty(employertxt.Text))

            {
                Response.Write("<script> alert ('Please Add Employer Name ');</script>");

            }

            else if (String.IsNullOrEmpty(designationtxt.Text))
            {
                Response.Write("<script> alert ('Please Add Designation / Position / Grade Details');</script>");

            }

            else if (emptypetxt.SelectedIndex == 0)
            {
                Response.Write("<script> alert ('Please Select Type of Employment');</script>");

            }


            else if (String.IsNullOrEmpty(fromtxt.Text))
            {
                Response.Write("<script> alert ('Please Add From Date');</script>");

            }

            else if (String.IsNullOrEmpty(totxt.Text))
            {
                Response.Write("<script> alert ('Please Add To Date');</script>");

            }

            //else if (String.IsNullOrEmpty(expbrieftxt.Text))
            //{
            //    Response.Write("<script> alert ('Please Add Nature of Work');</script>");

            //}

            else
            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        string expcount = regidlbl.Text + 1;
                        string dbcanreg = regidlbl.Text;
                        // string dbpcode = postDetailsdrop.Text;
                        string dbappno = appidnolbl.Text;
                        string employ = employertxt.Text;
                        string design = designationtxt.Text;
                        string emptyp = emptypetxt.Text;
                        string expdetails = expbrieftxt.Text;


                        DateTime fromdate1 = Convert.ToDateTime(fromtxt.Text);


                        DateTime todate1 = Convert.ToDateTime(totxt.Text);





                        string fromdate = fromdate1.ToString("dd/MM/yyyy");

                        string todate = todate1.ToString("dd/MM/yyyy");
                        string totalexp = totalexptxt.Text;



                        //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                        //  conn.Open();

                        string insertquery = "insert into experience(can_regno, appregno, employer, designation, emptype, joindate, leavedate, totalexp,expdetails) values(@canreg, @dbappno, @employ, @design, @emptyp, @fromdate, @todate, @totalexp,@expdetails)";
                        SqlCommand cmd = new SqlCommand(insertquery, conn);

                        cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                        //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                        cmd.Parameters.AddWithValue("@dbappno", dbappno);
                        cmd.Parameters.AddWithValue("@employ", employ);
                        cmd.Parameters.AddWithValue("@design", design);

                        cmd.Parameters.AddWithValue("@emptyp", emptyp);
                        cmd.Parameters.AddWithValue("@fromdate", fromdate);
                        cmd.Parameters.AddWithValue("@todate", todate);
                        cmd.Parameters.AddWithValue("@totalexp", totalexp);
                        cmd.Parameters.AddWithValue("@expdetails", expdetails);
                        
                        cmd.ExecuteNonQuery();
                        datashow();
                        UpdateBasicDetailsTable();

                        employertxt.Text = "";
                        designationtxt.Text = "";
                        emptypetxt.Text = "";
                        fromtxt.Text = "";
                        totxt.Text = "";
                        expbrieftxt.Text = "";
                        conn.Close();
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert (" + ex.Message + "');</script>");
                }
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Addbutton_Click(object sender, EventArgs e)
        {
            addexp();
        }

        protected void totxt_TextChanged(object sender, EventArgs e)
        {
            // duration();
            if (fromtxt.Text != "" && totxt.Text != "")
            {
                totalduration();
            }

            else
            {
                Response.Write("<script> alert ('Please Add From and To Dates for Experience');</script>");

            }

                
        }

        protected void fromtxt_TextChanged(object sender, EventArgs e)
        {
            // duration();
            //   totalduration();
            totxt.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
         //   int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        //    int canregtext = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);


            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            //int rowIndex = Convert.ToInt32(((LinkButton)sender).Attributes["id"].ToString());

            int canregtext = Convert.ToInt32(GridView1.DataKeys[rowindex].Value);

            SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE experience WHERE id = @canreg"))
                {
                    cmd.Parameters.AddWithValue("@canreg", canregtext);
                    cmd.Connection = conn;
                    //con.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.datashow();
            conn.Close();
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


                    string insertquery = "Update ApplicationSteps SET Experienced=@vyes, AdditionalInfo=@vno, Upload =@vno  WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

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
        protected void SaveEducationbtn_Click(object sender, EventArgs e)
        {
            if (expdetailsdrop.SelectedValue == "0")
            {
                Response.Write("<script> alert ('Please Select Yes Or No');</script>");
            }

            else if (GridView1.Rows.Count > 0 && expdetailsdrop.SelectedValue == "No")
            {
                Response.Write("<script> alert ('Please Check Experience Details');</script>");
            }

            else if (GridView1.Rows.Count == 0 && expdetailsdrop.SelectedValue == "Yes")
            {
                Response.Write("<script> alert ('Please Add Experience Details');</script>");
            }

            else

            {
                UpdateBasicDetailsTable();
                stepsComplete();
                Response.Redirect("Candidate_Home.aspx");
            }
        }


           
      

        protected void expdetailsdrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expdetailsdrop.SelectedValue == "0")

            {
                exppanel.Visible = false;
            }

            else if (expdetailsdrop.SelectedValue == "Yes")
            {
                exppanel.Visible = true;
            }
            else if (expdetailsdrop.SelectedValue == "No")
            {
                if (GridView1.Rows.Count > 0)
                {
                    Response.Write("<script> alert ('You Already Added Experience Details, Please Delete, if you are selecting the option - No ');</script>");
                    exppanel.Visible = true;

                }
                else
                {
                    exppanel.Visible = false;
                }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                expdetailsdrop.Enabled = false;
            }
            else if (GridView1.Rows.Count == 0)
            {
                expdetailsdrop.Enabled = true;
            }
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }
}