using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace recruitment.DataLayers
{
    public class BasicDetailsEntity
    {
        public string can_regno { get; set; }

        public string appregno { get; set; }

        public string fullname { get; set; }

        public string fathername { get; set; }

        public string mothername { get; set; }

        public string dateofbirth { get; set; }

        public string sexuality { get; set; }

        public string cast { get; set; }

        public string marital { get; set; }

        public string religion { get; set; }

        public string csiremp { get; set; }

        public string pwd { get; set; }

        public string ExArmy { get; set; }

        public string ExArmyService { get; set; }

        public string placeborn { get; set; }

        public string aadhaar { get; set; }

        public string citizen { get; set; }

        public string bankname { get; set; }

        public string paydate { get; set; }

        public string paymode { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }

        public string presentaddress { get; set; }

        public string paddresscity { get; set; }

        public string paddressstate { get; set; }

        public string paddresspincode { get; set; }

        public string peraddress { get; set; }

        public string paddressSameCheck { get; set; }

    }
    public class BasicDetailsDataAccessLayer
    {
        public static List<BasicDetailsEntity> GetDetails(string canregp, string appregp)
        {
            List<BasicDetailsEntity> BasicList = new List<BasicDetailsEntity>();

            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE can_regno = @canregdb and appregno = @appregdb", conn);

                SqlParameter parameter = new SqlParameter();
                SqlParameter parameter1 = new SqlParameter();

                parameter.ParameterName = "@canregdb";
                parameter.Value = canregp;
                cmd.Parameters.Add(parameter);


                parameter1.ParameterName = "@appregdb";
                parameter1.Value = appregp;
                cmd.Parameters.Add(parameter1);


                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BasicDetailsEntity BasicEn = new BasicDetailsEntity();                  
                    BasicEn.can_regno = rdr["can_regno"].ToString();
                    BasicEn.appregno = rdr["appregno"].ToString();
                    BasicEn.fullname = rdr["fullname"].ToString();
                    BasicEn.fathername = rdr["fathername"].ToString();
                    BasicEn.mothername = rdr["mothername"].ToString();
                    BasicEn.dateofbirth = rdr["dateofbirth"].ToString();
                    BasicEn.sexuality = rdr["sexuality"].ToString();
                    BasicEn.cast = rdr["cast"].ToString();
                    BasicEn.marital = rdr["marital"].ToString();
                    BasicEn.religion = rdr["religion"].ToString();
                    BasicEn.csiremp = rdr["csiremp"].ToString();
                    BasicEn.pwd = rdr["pwd"].ToString();
                    BasicEn.ExArmy = rdr["ExArmy"].ToString();                    
                    BasicEn.ExArmyService = rdr["ExArmyService"].ToString();
                    BasicEn.aadhaar = rdr["aadhaar"].ToString();
                    BasicEn.citizen = rdr["citizen"].ToString();
                    BasicEn.bankname = rdr["bankname"].ToString();
                    BasicEn.paydate = rdr["paydate"].ToString();
                    BasicEn.paymode = rdr["paymode"].ToString();
                    BasicEn.email = rdr["email"].ToString();
                    BasicEn.mobile = rdr["mobile"].ToString();
                    BasicEn.presentaddress = rdr["presentaddress"].ToString();
                    BasicEn.paddresscity = rdr["paddresscity"].ToString();
                    BasicEn.paddressstate = rdr["paddressstate"].ToString();
                    BasicEn.paddresspincode = rdr["paddresspincode"].ToString();
                    BasicEn.peraddress = rdr["peraddress"].ToString();
                    BasicEn.paddressSameCheck = rdr["paddressSameCheck"].ToString();
                    BasicEn.paymode = rdr["paymode"].ToString();
                
                    BasicList.Add(BasicEn);
                }
            }
            return BasicList;
        }

        public static void updateBasicDetails(string can_regno, string appregno, string fullname, string fathername, string mothername, string dateofbirth, string sexuality,string cast,  string marital, string religion, string csiremp, string pwd, string ExArmy,

        string ExArmyService,  string placeborn,    string aadhaar,  string citizen, string bankname,string paydate, string paymode,

        string email, string mobile, string presentaddress, string paddresscity, string paddressstate,  string paddresspincode, string peraddress,

        string paddressSameCheck)
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
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

                


                SqlParameter parm1 = new SqlParameter("@vfirstnameText", fullname);
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@vfathernameText", fathername);
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@vmothernameText", mothername);
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@vdobText", dateofbirth);
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@vgenderDrop", sexuality);
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@vcastDrop", cast);
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@vmaritalDrop", marital);
                cmd.Parameters.Add(parm7);

                SqlParameter parm8 = new SqlParameter("@vreligionText", religion);
                cmd.Parameters.Add(parm8);

                SqlParameter parm9 = new SqlParameter("@vcsirDrop", csiremp);
                cmd.Parameters.Add(parm9);

                SqlParameter parm10 = new SqlParameter("@vpwdDrop", pwd);
                cmd.Parameters.Add(parm10);

                SqlParameter parm11 = new SqlParameter("@varmyDrop", ExArmy);
                cmd.Parameters.Add(parm11);

                SqlParameter parm12 = new SqlParameter("@varmyDropService", ExArmyService);
                cmd.Parameters.Add(parm12);

                SqlParameter parm13 = new SqlParameter("@vplaceborn", placeborn);
                cmd.Parameters.Add(parm13);

                SqlParameter parm14 = new SqlParameter("@vaadhaarText", aadhaar);
                cmd.Parameters.Add(parm14);

                SqlParameter parm15 = new SqlParameter("@vcitizenDrop", citizen);
                cmd.Parameters.Add(parm15);

                SqlParameter parm16 = new SqlParameter("@vemailText", email);
                cmd.Parameters.Add(parm16);

                SqlParameter parm17 = new SqlParameter("@vmobileText", mobile);
                cmd.Parameters.Add(parm17);

                SqlParameter parm18 = new SqlParameter("@vpreaddressText", presentaddress);
                cmd.Parameters.Add(parm18);

                SqlParameter parm19 = new SqlParameter("@vprecityText", paddresscity);
                cmd.Parameters.Add(parm19);

                SqlParameter parm20 = new SqlParameter("@vprestateText", paddressstate);
                cmd.Parameters.Add(parm20);

                SqlParameter parm21 = new SqlParameter("@vpincodeText", paddresspincode);
                cmd.Parameters.Add(parm21);

                SqlParameter parm22 = new SqlParameter("@vsameaddress", paddressSameCheck);
                cmd.Parameters.Add(parm22);

                SqlParameter parm23 = new SqlParameter("@vpermaddressText", peraddress);
                cmd.Parameters.Add(parm23);


                SqlParameter parm24 = new SqlParameter("@vappidnolbl", appregno);
                cmd.Parameters.Add(parm24);



            //    SqlParameter parm = new SqlParameter("@vappidnolbl", can_regno);
              //  cmd.Parameters.Add(parm);

                cmd.ExecuteNonQuery();

            }

        }

        
    }
}