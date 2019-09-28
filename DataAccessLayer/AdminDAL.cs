using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BusinessObject;

namespace DataAccessLayer
{
    public class AdminDAL
    {
        public int AddResources(AdminBO obj)           //D
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_AddResource", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rescode", obj.ResCode);
                cmd.Parameters.AddWithValue("@resDesc", obj.ResDescription);
                //cmd.Parameters.AddWithValue("resDoc", obj.ResDocument);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;

            }
        }
        public int AddNewSkills(AdminBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_AddSkill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skName", obj.NewSkill);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;

            }
        }

        public int AddResourceSkill(AdminBO obj)        //D
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_AddSkillResource", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resCode", obj.ResCode);
                cmd.Parameters.AddWithValue("@skillName", obj.SkillName);
                cmd.Parameters.AddWithValue("@compLevel", obj.CompLevel);
                cmd.Parameters.AddWithValue("@audience", obj.Audience);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;

            }
        }

        public DataTable SkillList()
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_SkillList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable skillList = new DataTable();
                da.Fill(skillList);

                return skillList;

               

            }
        }

        public void DeleteList(AdminBO obj)
        {

            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" TS_CheckDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resCode", obj.ResCode);
                int result = cmd.ExecuteNonQuery();
                con.Close();



                

            }

        }

        public DataTable ResourceList()     //D
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ResourceTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                con.Close();

                return table;
            }
        }
        public DataTable SkillData(AdminBO obj)    //Data display skill
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_SkillData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resCode", obj.ResCode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                con.Close();
                DataRow dr = table.Rows[0];
                return table;
            }
        }
        public int SkillMapping(AdminBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_SkillMapping", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resCode", obj.ResCode);
                cmd.Parameters.AddWithValue("@skillName", obj.SkillName);
                cmd.Parameters.AddWithValue("@compLevel", obj.CompLevel);
                cmd.Parameters.AddWithValue("@audience", obj.Audience);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

        }
        public int DeleteResource(AdminBO obj)    //d
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DeleteResources", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resCode", obj.ResCode);
                cmd.Parameters.AddWithValue("@skills", obj.SkillName);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
      


    }
}
