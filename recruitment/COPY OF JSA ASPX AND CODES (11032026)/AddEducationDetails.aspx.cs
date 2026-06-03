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
    public partial class AddEducationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null))
            {
                if (!IsPostBack)
                {
                    regid();
                   // loaddata();
                    GridView1.DataKeyNames = new string[1] { "id" };
                    countlbl.Text = GridView1.Rows.Count.ToString();
                }
                //loaddataBadicinformation(); 
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

           // loaddataBadicinformation();

            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
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
                string db5 = DropDownList2.Text;



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
                

            }

        }
        protected void Addbutton_Click(object sender, EventArgs e)
        {
            if (subjecttxt.Text == "")
            {
                Response.Write("<script>alert('Enter Subject Details')</script>");
                validatelbl.Text = "Enter Subject";
            }

            else if (institutetxt.Text == "")
            {
                validatelbl.Text = "Enter institute";
            }

            else if (pmarkstext.Text == "")
            {
                validatelbl.Text = "Enter Marks";
            }

            else
            {
                addeducationdetails();
                GridView1.DataBind();
            }
        }

        protected void SaveEducationbtn_Click(object sender, EventArgs e)
        {
            string count = countlbl.Text;
            int maxrecord = int.Parse(count);
            
            if (maxrecord == 0)
            {
                errorlbl.Text = "You should have minimum two ";

            }

            else if (maxrecord == 1)
            {
                errorlbl.Text = "You have added only one recrod ";

            }

            else if (maxrecord >= 2)
            {
                errorlbl.Text = "You added enogh ";
                Response.Redirect("PDFupload.aspx");
            }


        }

      
      
      

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            countlbl.Text = GridView1.Rows.Count.ToString();
        }
    }
}