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
    public partial class EducationAdd : System.Web.UI.Page
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
                    coursedropdown.SelectedIndex = 0;
                    //PhdPanel.Visible = false;
                   // TechPanel.Visible = false;
                }
               
            }
            else
            {
                Response.Redirect("userlogin.aspx");
            }
        }
        bool Checkeducation()
        {
            try
            {
                string appregno = Convert.ToString(Session["S_appregno"]);
                string dbcanreg = Convert.ToString(Session["can_regno"]);

                string course = coursedropdown.SelectedValue;

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT * FROM educational where course=@course and appregno=@appregno";


                SqlCommand command = new SqlCommand(sql1, connection);

                command.Parameters.AddWithValue("@course", course);
                command.Parameters.AddWithValue("@canreg", dbcanreg);

                command.Parameters.AddWithValue("@appregno", appregno);

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

        protected void Addbutton_Click(object sender, EventArgs e)
        {
            if(Checkeducation())
            {
                Response.Write("<script> alert ('Qualification already added, Please add remaining Qualification');</script>");
            }

            else
            {
                textboxvalidation();
            }

           
           
        }

             

        

        private void textboxvalidation()
        {
            if (coursedropdown.SelectedValue == "--Select--")
            {
                Response.Write("<script> alert ('Select Qualification Name');</script>");
             //   validatelbl.Text = "Select Qualification Name ";
            }

            else if (subjecttxt.Text == "")
            {
                Response.Write("<script> alert ('Subject Name Should not be Empty');</script>");
               // validatelbl.Text = "Subject Name Should not be Empty";
            }

            else if (institutetxt.Text == "")
            {
                Response.Write("<script> alert ('Institute Name Should not be Empty');</script>");
                //validatelbl.Text = "Institute Name Should not be Empty";
            }


            else if (pmarkstext.Text == "")
            {
                Response.Write("<script> alert ('Marks Should not be Empty');</script>");
                //validatelbl.Text = "Marks Should not be Empty";
            }

            else if (pyeartxt.Text == "")
            {
                Response.Write("<script> alert ('Passed Year Should not be Empty');</script>");
                //validatelbl.Text = "Passed Year Should not be Empty";
            }

            else if (Courseclass.Text == "--Select--")
            {
                Response.Write("<script> alert ('Class Name Should not be Empty');</script>");
               // validatelbl.Text = "Class Name Should not be Empty";
            }


            else
            {
                validatelbl.Text = "";
                education();
            }
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
            }



            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM educational where can_regno=@canreg and appregno=@appregno"))
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
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

            }
        }

        

        private void education()
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



                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();

                string insertquery = "insert into educational(can_regno, appregno, course, coursename, Subject, Institute, Pmarks, PassYear, Class) values(@canreg, @dbappno, @dbcourse, @dbcoursename, @dbfield1, @dbfield2, @dbfield3, @dbfield4, @dbfield5)";
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
                cmd.ExecuteNonQuery();
                datashow();

            }


        }

        private void UpdateMarksinBasicTable()
        {

        }


        protected void SaveEducationbtn_Click(object sender, EventArgs e)
        {
            string count = countlbl.Text;
            int maxrecord = int.Parse(count);

            if (maxrecord == 0)
            {
               // errorlbl.Text = "You should have minimum two ";
                Response.Write("<script> alert ('Add Essential Education Details');</script>");

            }

            else if (maxrecord == 1)
            {
                errorlbl.Text = "You have added only one recrod ";

            }

            else if (maxrecord >= 2)
            {
                errorlbl.Text = "You added enogh ";
                Response.Redirect("ExperienceAdd.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
              int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            //int rowIndex = Convert.ToInt32(((LinkButton)sender).Attributes["id"].ToString());

            int idtodelete = Convert.ToInt32(GridView1.DataKeys[rowindex].Value);


          

            // int canregtext = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);

            SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE educational WHERE id = @canreg"))
                {
                    cmd.Parameters.AddWithValue("@canreg", idtodelete);
                    cmd.Connection = conn;
                    //con.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.datashow();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            countlbl.Text = GridView1.Rows.Count.ToString();
        }

        protected void coursedropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {

              //  string valueToCompare = GridView1.Rows[0].Cells[0].Text;

              ////  string cellvalue = GridView1.Rows[i].Cells[0].Text;

              //  errorlbl.Text = valueToCompare;

              //  if (valueToCompare == coursedropdown.SelectedValue)

              //  {
              //      Addbutton.Enabled = false;
              //  }
              //  
              if (coursedropdown.SelectedValue == "SSC/SSLC/10th")
                {
                    subjecttxt.Text = "SSC/SSLC/10th";
                    nameofdegree.Text = "SSC/SSLC/10th";
                    subjecttxt.Enabled = false;
                    nameofdegree.Enabled = false;


                }

               else if (coursedropdown.SelectedValue == "HSC/PUC/12th")
                {

                    nameofdegree.Text = "HSC/PUC/12th";
                    nameofdegree.Enabled = false;
                    subjecttxt.Enabled = true;
                    subjecttxt.Text = "";

                }

              else
                {
                    nameofdegree.Enabled = true;
                    subjecttxt.Enabled = true;
                    nameofdegree.Text = "";
                    subjecttxt.Text = "";

                }

               
             

                

            }
        }

       

 

       

       

        protected void phddrop_SelectedIndexChanged1(object sender, EventArgs e)
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
    }
}
