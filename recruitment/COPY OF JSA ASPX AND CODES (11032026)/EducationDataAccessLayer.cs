using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace recruitment
{
    public class Education
    {

        public int id { get; set; }
        public string can_regno { get; set; }
        public string appregno { get; set; }
        public string course { get; set; }
        public string Subject { get; set; }

        public string Institute { get; set; }

        public string Pmarks { get; set; }
        public string PassYear { get; set; }
        public string Class { get; set; }

    }


    public class EducationDataAccessLayer
    {
        public static List<Education> GetAllEducationsData()
        {
            List<Education> listEducation = new List<Education>();
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {

              
                SqlCommand cmd = new SqlCommand("SELECT * FROM educational ", conn);

               
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Education edu = new Education();
                    edu.id = Convert.ToInt32(rdr["id"]);
                    edu.can_regno = rdr["can_regno"].ToString();
                    edu.appregno = rdr["appregno"].ToString();

                    edu.course = rdr["course"].ToString();
                    edu.Subject = rdr["Subject"].ToString();
                    edu.Institute = rdr["Institute"].ToString();
                    edu.Pmarks = rdr["Pmarks"].ToString();
                    edu.PassYear = rdr["PassYear"].ToString();
                    edu.Class = rdr["Class"].ToString();
                    listEducation.Add(edu);
                }



            }
            return listEducation;
        }
        public static void updateEducation(int id, String can_regno, String appregno, String course, String Subject, String Institute, String Pmarks, String PassYear, String Class)
        {
            using(SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                string updatequery = "update educational SET can_regno=@can_regno, appregno=@appregno, " +
                    "course=@course, Subject=@Subject, Institute=@Institute, Pmarks=@Pmarks, PassYear=@PassYear, Class=@Class where id =@id";

                SqlCommand cmd = new SqlCommand( updatequery, conn);
                 
                SqlParameter parm = new SqlParameter("@id", id);
                cmd.Parameters.Add(parm);

                
                SqlParameter parm1 = new SqlParameter("@can_regno", can_regno);
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@appregno", appregno);
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@course", course);
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@Subject", Subject);
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@Institute", Institute);
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@Pmarks", Pmarks);
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@PassYear", PassYear);
                cmd.Parameters.Add(parm7);

                SqlParameter parm8 = new SqlParameter("@Class", Class);
                cmd.Parameters.Add(parm8);


                cmd.ExecuteNonQuery();

            }

        }


        public static void deleteEducation(int id)
        {
            using (SqlConnection conn = MySqlConnection.Recruitmentcon())
            {
                SqlCommand cmd = new SqlCommand("Delete  FROM educational where id = @id", conn);
                SqlParameter parm = new SqlParameter("@id", id);
                cmd.Parameters.Add(parm);
               
                cmd.ExecuteNonQuery();
                
            }

        }
    }
}