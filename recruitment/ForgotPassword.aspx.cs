using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace recruitment
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // pwdlbl.Visible = false;
        }

        protected void showPwd()
        {
            string username = string.Empty;
            string password = string.Empty;


            using (SqlConnection con = MySqlConnection.Recruitmentcon())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT email, password FROM rec_canreg WHERE email = @Email"))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Connection = con;

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            username = sdr["email"].ToString();
                            password = sdr["password"].ToString();
                            pwdlbl.Text = EncryptionHelper.Decrypt1(password);

                        }
                    }
                    con.Close();
                }
            }

        }
        protected void Sendmail()
        {

            string username = string.Empty;
            string password = string.Empty;

                       
            using (SqlConnection con = MySqlConnection.Recruitmentcon())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT email, password FROM rec_canreg WHERE email = @Email"))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Connection = con;
                    
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            username = sdr["email"].ToString();
                            password = sdr["password"].ToString();
                            pwdlbl.Text = EncryptionHelper.Decrypt1(password);

                        }
                    }
                    con.Close();
                }
            }
            string passwordDecrypt = EncryptionHelper.Decrypt1(password);

            if (!string.IsNullOrEmpty(password))
            {
                MailMessage mm = new MailMessage("csirmadrascomplex@gmail.com", txtEmail.Text.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("<br /> <h2> CSIR MADRAS COMPLEX </h2>, <h3> ONLINE APPLICATION 2024 </h3> <h4> Hi {0},<br /><br /> Your password is <strong> {1} </strong>.</h4><br /><br />Thank You. <br/> (Warning: Don't reply anything to this email)", username, pwdlbl.Text);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
               
                smtp.Timeout = 200000;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "csirmadrascomplex@gmail.com";
                NetworkCred.Password = "pgfpjilyhwjddtdq";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
              //  smtp.Port = 587;
                smtp.Send(mm);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Password has been sent to your email address. (Check the Spam folder in case of e-mail missing in the Inbox)";
                pwdlbl.Text = passwordDecrypt.ToString();
                //MailMessage mm = new MailMessage("cmcit@csircmc.res.in", txtEmail.Text.Trim());
                //mm.Subject = "Password Recovery";
                //mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
                //mm.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.mail.gov.in";
                //smtp.EnableSsl = true;
                //smtp.Timeout = 20000;
                //NetworkCredential NetworkCred = new NetworkCredential();
                //NetworkCred.UserName = "cmcit@csircmc.res.in";
                //NetworkCred.Password = "Csircmc@2021";
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 465;                
                //smtp.Send(mm);
                //lblMessage.ForeColor = Color.Green;
                //lblMessage.Text = "Password has been sent to your email address.";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "This email address does not match our records.";
                
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Sendmail();
           // showPwd();
        }
    }
}