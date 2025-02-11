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
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                if (!IsPostBack)
                {
                    loaddataBadicinformation();
                    YesOrNo();
                    regid();

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

            
        }
        private void YesOrNo()
        {
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT sexuality,cast,csiremp,pwd,ExArmy FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string gender  = dr.GetValue(0).ToString();
                        string cast = dr.GetValue(1).ToString();
                        string csiremp = dr.GetValue(2).ToString();
                        string pwd = dr.GetValue(3).ToString();
                        string exarmy = dr.GetValue(4).ToString();


                        if ((gender == "Female") || (cast == "SC") || (cast == "ST") || (csiremp == "Yes") || (pwd == "Yes") || (exarmy == "ExArmy") || (exarmy == "JCO"))

                     //    if ( (gender == "Female") || (cast == "SC") || (cast == "ST") || (csiremp == "Yes") || (pwd == "Yes") || (exarmy == "ExArmy") || (exarmy == "JCO") )
                        {
                            PaymentPanel.Visible = false;
                        }

                        else 
                        {
                            PaymentPanel.Visible = true;
                            PaymentPanelNotification.Visible = true;
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


                    string insertquery = "Update ApplicationSteps SET AppFee=@vyes WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

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

        public void loaddataBadicinformation()
        {

            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT  bankname,  paydate, paymode FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        banknameText.Text = dr.GetValue(0).ToString();
                        paymentdateText.Text = dr.GetValue(1).ToString();
                        paymodeText.SelectedValue= dr.GetValue(2).ToString();

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

        bool CheckBankRefNumber()
        {
            try
            {

                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "select bankname from basicdetailsNew where bankname='" + banknameText.Text.Trim() + "'";
                SqlCommand command = new SqlCommand(sql1, connection);

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

        
        private void addBasicdetails()

        {
            if (PaymentPanel.Visible == false)
            {
                banknameText.Text = "";
                paymentdateText.Text = DateTime.Today.ToString("dd-MM-yyyy");
                // paymodeText.Text = "";
                AcctDetailsPanel.Visible = false;
            }

            else
            {
               // paymodeText.Text = "SBI Collect";
            }

            string vcan_reg = regidlbl.Text;
            string vappidnolbl = appidnolbl.Text;           
          
            string vbanknameText = banknameText.Text;
            DateTime vpaymentdateText = Convert.ToDateTime(paymentdateText.Text);
            string vpaymodeText = paymodeText.SelectedValue;
           
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery = "Update basicdetailsNew SET bankname=@vbanknameText, paydate=@vpaymentdateText, paymode=@vpaymodeText WHERE appregno = @vappidnolbl";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);
                    cmd.Parameters.AddWithValue("@vcan_reg", vcan_reg);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);   
                  
                    cmd.Parameters.AddWithValue("@vbanknameText", vbanknameText);
                    cmd.Parameters.AddWithValue("@vpaymentdateText", vpaymentdateText.ToString("dd-MM-yyyy"));
                    cmd.Parameters.AddWithValue("@vpaymodeText", vpaymodeText);
                   
                    cmd.ExecuteNonQuery();
                    stepsComplete();
                    Response.Redirect("Candidate_Home.aspx");
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
            

            if (CheckBankRefNumber())
            {

                try
                {
                    string canregdbtext = Convert.ToString(Session["can_regno"]);

                    string appregnotext = Convert.ToString(Session["S_appregno"]);

                    string reftxt = banknameText.Text.Trim();

                    SqlConnection connection = MySqlConnection.Recruitmentcon();
                    string sql1 = "SELECT  bankname,  paydate, paymode FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                    SqlCommand command = new SqlCommand(sql1, connection);
                    command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                    command.Parameters.AddWithValue("@appregnotext", appregnotext);

                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())                   
                        {
                            string dbRefname = dr.GetValue(0).ToString();

                            if (dbRefname  == reftxt)
                            {
                                addBasicdetails();
                            }

                            else
                            {
                                PaymentErrorlbl.Text = "Payment Reference Details already filled for another post.";

                            }

                        }
                    }
                   
                    connection.Close();
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

               
            }
            else
            {
                addBasicdetails();
            }
            //Response.Redirect("Candidate_Home.aspx");
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }

        protected void castDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void paymodeText_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}