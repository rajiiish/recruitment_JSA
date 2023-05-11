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
    public partial class education : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datashow();
            //if ((Session["email"] != null) && (Session["password"] != null))
            //{

            //    regid();

            //    if (!this.IsPostBack)
            //    {
            //        this.datashow();
            //    }
            //    loaddata();
            //    Response.Redirect("userlogin.aspx");
            //}
            //else
            //{
            //    Response.Redirect("userlogin.aspx");
            //}
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
            GridView1.Columns[0].Visible = false;
            Label2.Text = GridView1.Columns[0].ToString();
            
            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM educational"))
                        {
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
                    Label1.Text = ex.ToString();
                }

            }
        }
        private void addeducationdetails()
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string dbcanreg = regidlbl.Text;
                // string dbpcode = postDetailsdrop.Text;
                string dbappno = appidnolbl.Text;
                string dbcourse = coursedropdown.Text;
                string db1 = subjecttxt.Text;
                string db2 = institutetxt.Text;
                string db3 = pmarkstext.Text;
                string db4 = pyeartxt.Text;
                string db5 = clastxt.Text;



                //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                //  conn.Open();

                string insertquery = "insert into educational(can_regno, appregno, course, Subject, Institute, Pmarks, PassYear, Class) values(@canreg, @dbappno, @dbcourse, @dbfield1, @dbfield2, @dbfield3, @dbfield4, @dbfield5)";
                SqlCommand cmd = new SqlCommand(insertquery, conn);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                //cmd.Parameters.AddWithValue("@pcode", dbpcode);
                cmd.Parameters.AddWithValue("@dbappno", dbappno);
                cmd.Parameters.AddWithValue("@dbcourse", dbcourse);
                cmd.Parameters.AddWithValue("@dbfield1", db1);
                cmd.Parameters.AddWithValue("@dbfield2", db2);
                cmd.Parameters.AddWithValue("@dbfield3", db3);
                cmd.Parameters.AddWithValue("@dbfield4", db4);
                cmd.Parameters.AddWithValue("@dbfield5", db5);
                cmd.ExecuteNonQuery();
                datashow();

            }

        }
        protected void Addbutton_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                    addeducationdetails();
             
                            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int canregtext = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);
                SqlConnection conn = MySqlConnection.Recruitmentcon();

            {
                using (SqlCommand cmd = new SqlCommand("DELETE educational WHERE id = @canreg"))
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
    }
}
    
