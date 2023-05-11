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
    public partial class admin1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //  datashow();

            //  p_appnolbl.Text = "TA-CIVIL1008";
            // loadbasicdetails();
            //loadexperience();
            //loadeducation();

            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    gridviewload();
                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }
            
            

        }


       

        private void gridviewload()
        {

            string vpostcode = DropDownList1.SelectedValue.ToString();

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM [basicdetailsNew] WHERE ([postcode] = @postcode) or ([postcode] = @postcode)"))
                        {
                            
                            cmd.Parameters.AddWithValue("@postcode", vpostcode);

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
       
    }
}