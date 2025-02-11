using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace recruitment
{
    public partial class BasicInformationAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {
                if (!IsPostBack)
                {
                    regid();
                    AppCompletion();
                    loaddata();
                  //  PaymentOptionEnable();
                    armydrop();

                    pwd.Visible = false;
                    pwdDrop.Visible = false;
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

            loaddataBadicinformation();
            
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

        public void loaddata()
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
                SqlCommand cmd = new SqlCommand("select * from rec_canreg where can_regno= @canreg ", con);

                cmd.Parameters.AddWithValue("@canreg", dbcanreg);
                cmd.Parameters.AddWithValue("@appregno", appregno);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fullnametxt.Text = dr.GetValue(3).ToString();
                      //  lastnameText.Text = dr.GetValue(4).ToString();
                        emailText.Text = dr.GetValue(1).ToString();

                        mobileText.Text = dr.GetValue(4).ToString();

                        
                    }
                }
                else
                {
                    Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
                con.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        public void loaddataBadicinformation()
        {
           
            try
            {
                string canregdbtext = Convert.ToString(Session["can_regno"]);
                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT fullname, fathername, mothername, dateofbirth, sexuality, cast, marital, religion, csiremp,  pwd, ExArmy, ExServiceName, ExArmyService, placeborn, aadhaar, citizen,bankname,  paydate, paymode,email, mobile, presentaddress, paddresscity, paddressstate, paddresspincode, peraddress,paddressSameCheck FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);
               
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //  regidlbl.Text = dr.GetValue(0).ToString();
                        // appidnolbl.Text = dr.GetValue(1).ToString();
                        //applyhpostlbl.Text = dr.GetValue(2).ToString();

                        //  DateTime vdobText = Convert.ToDateTime(dobText.Text);


                        fullnametxt.Text = dr.GetValue(0).ToString();
                      //  lastnameText.Text = dr.GetValue(5).ToString();
                        fathernameText.Text = dr.GetValue(1).ToString();
                        mothernameText.Text = dr.GetValue(2).ToString();


                        dobText.Text = dr.GetValue(3).ToString();


                        genderDrop.SelectedValue = dr.GetValue(4).ToString();

                        castDrop.SelectedValue = dr.GetValue(5).ToString();
                        maritalDrop.SelectedValue = dr.GetValue(6).ToString();
                        religionText.Text = dr.GetValue(7).ToString();
                        csirDrop.SelectedValue = dr.GetValue(8).ToString();
                        pwdDrop.SelectedValue = dr.GetValue(9).ToString();
                        ArmyDrop.SelectedValue = dr.GetValue(10).ToString();
                        EssnQualficationTxt.Text = dr.GetValue(11).ToString();

                        if (ArmyDrop.SelectedValue == "ExArmy")
                        {
                            
                            EssnQualficationTxt.Enabled = false;
                        }
                        else if (ArmyDrop.SelectedValue == "JCO")
                        {
                            
                            EssnQualficationTxt.Enabled = false;
                        }

                        else if (ArmyDrop.SelectedValue == "Para-Military")
                        {

                            EssnQualficationTxt.Enabled = true;
                        }

                        else if (ArmyDrop.SelectedValue == "Others")
                        {
                            
                            EssnQualficationTxt.Enabled = true;
                        }

                         
                        ArmyService.Text = dr.GetValue(12).ToString();
                        placeofbirthtxt.Text = dr.GetValue(13).ToString();
                        aadhaarText.Text = dr.GetValue(14).ToString();
                        citizenDrop.Text = dr.GetValue(15).ToString();
                        

                    //    banknameText.Text = dr.GetValue(15).ToString();
                    //    paymentdateText.Text = dr.GetValue(16).ToString();
                    //    paymodeText.Text = dr.GetValue(17).ToString();
                        emailText.Text = dr.GetValue(19).ToString();
                        mobileText.Text = dr.GetValue(20).ToString();
                        preaddressText.Text = dr.GetValue(21).ToString();
                        precityText.Text = dr.GetValue(22).ToString();
                        prestateText.Text = dr.GetValue(23).ToString();
                        pincodeText.Text = dr.GetValue(24).ToString();
                        permaddressText.Text = dr.GetValue(25).ToString();

                        string checkbox = dr.GetValue(26).ToString();
                        if (checkbox == "Yes")
                        {
                            AddresSamecheck.Checked = true;
                        }

                        else if (checkbox == "No")
                        {
                            AddresSamecheck.Checked = false;
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


        private void validation()
        {
            addBasicdetails();
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

                    
                    string insertquery = "Update ApplicationSteps SET BasicInfo=@vyes, AdditionalInfo=@vno, Upload=@vno , AppFee = @vno  WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

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

        private void addBasicdetails()

        {
           

            //if (PaymentPanel.Visible == false)
            //{
            //    //banknameText.Text = "Payment Relaxation";
            //    //paymentdateText.Text = DateTime.Today.ToString("dd-MM-yyyy");
            //    //paymodeText.Text = "Payment Relaxation";

            //    banknameText.Text = "";
            //    paymentdateText.Text = DateTime.Today.ToString("dd-MM-yyyy");
            //    paymodeText.Text = "";
            //}

                string canregdbtest = Convert.ToString(Session["can_regno"]);

                string postcode1 = Convert.ToString(Session["S_appregno"]);

                string vcan_reg = regidlbl.Text;
                string vappidnolbl = appidnolbl.Text;
                string vapplyhpostlbl = applyhpostlbl.Text;
                string vfirstnameText = fullnametxt.Text;
                //  string vlastnameText = lastnameText.Text;
                string vfathernameText = fathernameText.Text;
                string vmothernameText = mothernameText.Text;
            
            DateTime vdobText = Convert.ToDateTime(dobText.Text);

                string vgenderDrop = genderDrop.SelectedValue.ToString();
                string vcastDrop = castDrop.SelectedValue.ToString();
                string vmaritalDrop = maritalDrop.SelectedValue.ToString();
                string vreligionText = religionText.Text;
                string vcsirDrop = csirDrop.SelectedValue.ToString();
                string vpwdDrop = pwdDrop.SelectedValue.ToString();
                string varmyDrop = ArmyDrop.SelectedValue.ToString();
                string essnQualfication = EssnQualficationTxt.Text;


            string varmyDropService = ArmyService.Text;
            if (varmyDrop == "Others")
            {
                ArmyService.Visible = true;
                servicelbl.Visible = true;
                EssnQualficationTxt.Enabled = true;
            }
            else
            {
                ArmyService.Visible = false;
                servicelbl.Visible = false;
                EssnQualficationTxt.Enabled = false;

            }

            string vplaceborn = placeofbirthtxt.Text;

                
                string vaadhaarText = aadhaarText.Text;

                string vcitizenDrop = citizenDrop.SelectedValue.ToString();

                //string vbanknameText = banknameText.Text;
                //DateTime vpaymentdateText = Convert.ToDateTime(paymentdateText.Text);
                //string vpaymodeText = paymodeText.Text;

                string vemailText = emailText.Text;
                string vmobileText = mobileText.Text;
                string vpreaddressText = preaddressText.Text;
                string vprecityText = precityText.Text;
                string vprestateText = prestateText.Text;
                string vpincodeText = pincodeText.Text;
                string vpermaddressText = permaddressText.Text;

                    string vsameaddress = AddresSamecheck.Checked ? "Yes" : "No";



            try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {




                        //  conn.ConnectionString = "@Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=&quot;C:/Users/RAJESH/AppData/Local/Microsoft/Microsoft SQL Server Local DB/Instances/MSSQLLocalDB/recruitmentdb.mdf&quot;;Integrated Security=True;Connect Timeout=30";
                        //  conn.Open();

                        //string insertquery1 = "insert into basicdetailsNew (postdetails,  firstname, lastname, fathername, dateofbirth, sexuality, cast, marital,religion, csiremp, pwd, aadhaar, citizen, bankname, paydate, paymode, email, mobile, presentaddress, paddresscity, paddressstate, paddresspincode, peraddress) values" +
                        //  " (@vapplyhpostlbl,@vfirstnameText,@vlastnameText,@vfathernameText,@vdobText,@vgenderDrop,@vcastDrop,@vmaritalDrop,@vreligionText,@vcsirDrop,@vpwdDrop,@vaadhaarText,@vcitizenDrop,@vbanknameText,@vpaymentdateText,@vpaymodeText,@vemailText,@vmobileText,@vpreaddressText,@vprecityText,@vprestateText,@vpincodeText,@vpermaddressText) WHERE vcan_reg= @vcan_reg AND appregno = @vappidnolbl";

                        string insertquery = "Update basicdetailsNew SET " +
                            //   "postdetails=@vapplyhpostlbl , " +
                            "fullname=@vfirstnameText, " +

                            "fathername=@vfathernameText, " +
                            "mothername=@vmothernameText, " +
                            
                            "dateofbirth=@vdobText, " +
                            "sexuality=@vgenderDrop, " +
                            "cast=@vcastDrop, " +
                            "marital=@vmaritalDrop," +
                            "religion=@vreligionText, " +
                            "csiremp=@vcsirDrop, " +
                            "pwd=@vpwdDrop, " +
                            "ExArmy=@varmyDrop, " +
                            "ExServiceName=@vessnQualfication, " +
                            "ExArmyService=@varmyDropService, " +
                            "placeborn=@vplaceborn, " +
                            
                            "aadhaar=@vaadhaarText, " +
                            "citizen=@vcitizenDrop, " +
                           
                            "email=@vemailText, " +
                            "mobile=@vmobileText, " +
                            "presentaddress=@vpreaddressText, " +
                            "paddresscity=@vprecityText, " +
                            "paddressstate=@vprestateText, " +
                            "paddresspincode=@vpincodeText, " +
                            "paddressSameCheck=@vsameaddress, " +
                            "peraddress=@vpermaddressText  WHERE appregno = @vappidnolbl";
                        SqlCommand cmd = new SqlCommand(insertquery, conn);

                        cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                        cmd.Parameters.AddWithValue("@vappidnolbl", postcode1);
                        cmd.Parameters.AddWithValue("@vapplyhpostlbl", vapplyhpostlbl);
                        cmd.Parameters.AddWithValue("@vfirstnameText", vfirstnameText);
                        //  cmd.Parameters.AddWithValue("@vlastnameText", vlastnameText);
                        cmd.Parameters.AddWithValue("@vfathernameText", vfathernameText);
                        cmd.Parameters.AddWithValue("@vmothernameText", vmothernameText);



                        cmd.Parameters.AddWithValue("@vdobText", vdobText.ToString("dd-MM-yyyy"));
                        cmd.Parameters.AddWithValue("@vgenderDrop", vgenderDrop);
                        cmd.Parameters.AddWithValue("@vcastDrop", vcastDrop);
                        cmd.Parameters.AddWithValue("@vmaritalDrop", vmaritalDrop);
                        cmd.Parameters.AddWithValue("@vreligionText", vreligionText);
                        cmd.Parameters.AddWithValue("@vcsirDrop", vcsirDrop);
                        cmd.Parameters.AddWithValue("@vpwdDrop", vpwdDrop);
                        cmd.Parameters.AddWithValue("@varmyDrop", varmyDrop);
                         cmd.Parameters.AddWithValue("@vessnQualfication", essnQualfication);
                    
                        cmd.Parameters.AddWithValue("@varmyDropService", varmyDropService);
                    cmd.Parameters.AddWithValue("@vplaceborn", vplaceborn);
                    


                        cmd.Parameters.AddWithValue("@vaadhaarText", vaadhaarText);
                        cmd.Parameters.AddWithValue("@vcitizenDrop", vcitizenDrop);
                       
                        cmd.Parameters.AddWithValue("@vemailText", vemailText);
                        cmd.Parameters.AddWithValue("@vmobileText", vmobileText);
                        cmd.Parameters.AddWithValue("@vpreaddressText", vpreaddressText);
                        cmd.Parameters.AddWithValue("@vprecityText", vprecityText);
                        cmd.Parameters.AddWithValue("@vprestateText", vprestateText);
                        cmd.Parameters.AddWithValue("@vpincodeText", vpincodeText);
                        cmd.Parameters.AddWithValue("@vsameaddress", vsameaddress);
                        cmd.Parameters.AddWithValue("@vpermaddressText", vpermaddressText);                  


                    cmd.ExecuteNonQuery();
                    stepsComplete();

                    conn.Close();
                }
                

            
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }
        }

        private void UpdatePhdDetails()
        {
            if (pwdDrop.SelectedValue == "No")
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {
                    string dbcanreg = regidlbl.Text;
                    string dbappno = appidnolbl.Text;

                    string vEmptyText = "";


                    string insertquery1 = "UPDATE basicdetailsNew SET pwdPercent = @vEmptyText, pwdCatagory=@vEmptyText WHERE appregno = @dbappno and can_regno=@canreg";
                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);
                    cmd1.Parameters.AddWithValue("@canreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@dbappno", dbappno);
                    cmd1.Parameters.AddWithValue("@vEmptyText", vEmptyText);
                    cmd1.ExecuteNonQuery();
                }
            }
        }
        protected void SaveDetails_Click(object sender, EventArgs e)
        {
            if (dobText.Text == "")
            {
                Response.Write("<script>alert('Enter Date Of Birth')</script>");
            }

            else if (genderDrop.SelectedIndex == -1)
            {
                genvallbl.Text = "*";

            }

            else if (citizenDrop.SelectedIndex == 2)
            {
                Response.Write("<script>alert('Only Indian Citizen are allowed to apply this post')</script>");
            }
            else


            {
                validation();
                UpdatePhdDetails();
                Response.Redirect("Candidate_Home.aspx");
            }
            
            // Response.Write<script>alert('sucessfull')</script>");

        }


              
        private void armydrop()
        {

            
        }
        protected void genderDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
           // PaymentOptionEnable();
        }

        protected void castDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

           // PaymentOptionEnable();

        }

        protected void pwdDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
           // PaymentOptionEnable();
        }

        protected void csirDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   PaymentOptionEnable();
        }
        protected void ArmyDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
      
           if (ArmyDrop.SelectedValue == "ExArmy")
            {
                ArmyService.Visible = true;
                ArmyService.Text = "";
                servicelbl.Visible = false;
                EssnQualficationTxt.Enabled = false;
                EssnQualficationTxt.Text = "Ex-Servicemen";

            }
            else if (ArmyDrop.SelectedValue == "JCO")
            {
                ArmyService.Visible = true;
                ArmyService.Text = "";
                servicelbl.Visible = false;
                EssnQualficationTxt.Enabled = false;
                EssnQualficationTxt.Text = "JCO";

            }

            else if (ArmyDrop.SelectedValue == "Para-Military")
            {

                ArmyService.Visible = true;
                ArmyService.Text = "";
                servicelbl.Visible = true;
                EssnQualficationTxt.Enabled = true;
                EssnQualficationTxt.Text = "";
            }

            else if (ArmyDrop.SelectedValue == "Others")
            {
                ArmyService.Visible = true;
                ArmyService.Text = "";
                servicelbl.Visible = true;
                EssnQualficationTxt.Enabled = true;
                EssnQualficationTxt.Text = "";
            }
            // armydrop();

        }


    
        protected void AddresSamecheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AddresSamecheck.Checked)
            {
                string line1 = preaddressText.Text;
                string line2 = precityText.Text;
                string line3 = prestateText.Text;
                string line4 = pincodeText.Text;

                string fulladd = line1 + "," + " " + line2 + "," + " " + line3 + "," + " " + line4;
                permaddressText.Text = fulladd;
            }
            else
            {
                permaddressText.Text = "";
            }
                       
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }
}