using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class UserDAL
    {
        public int AddDocument(DocumentBO userObj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_UpdateDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coverPage", userObj.CoverPage);
                cmd.Parameters.AddWithValue("@title", userObj.Title);
                cmd.Parameters.AddWithValue("@subject", userObj.Subject);
                cmd.Parameters.AddWithValue("@author", userObj.Author);
                cmd.Parameters.AddWithValue("@year", userObj.Year);
                cmd.Parameters.AddWithValue("@file", userObj.File);
                cmd.Parameters.AddWithValue("@resourceId", userObj.ResourceId);
                cmd.Parameters.AddWithValue("@uploadedBy", userObj.UploadedBy);
                cmd.Parameters.AddWithValue("@uploadedOn", userObj.UploadedOn);
                cmd.Parameters.AddWithValue("@description", userObj.Description);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
        public DataTable AdvanceSearch(string keyWordId, string keyWord)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_AdvanceSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keywordId", keyWordId);
                cmd.Parameters.AddWithValue("@keyword", keyWord);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable searchTable = new DataTable();
                data.Fill(searchTable);
                con.Close();
                return searchTable;
            }
        }
        public DataTable ScheduleTable()
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ScheduleTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable scheduleTable = new DataTable();
                data.Fill(scheduleTable);
                con.Close();
                return scheduleTable;
            }

        }
        public int AddSchedule(DocumentBO docBo, ScheduleBO schBO)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_AddSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@batchId", schBO.BatchId);
                cmd.Parameters.AddWithValue("@userId", docBo.UploadedBy);
                cmd.Parameters.AddWithValue("@DateFrom", schBO.StartFrom);
                cmd.Parameters.AddWithValue("@dateTo", schBO.EndOn);
                cmd.Parameters.AddWithValue("@timeSlot", schBO.TimeSlot);
                cmd.Parameters.AddWithValue("@Subject", schBO.Subject);
                cmd.Parameters.AddWithValue("@notes", docBo.File);
                cmd.Parameters.AddWithValue("@uploadedOn", docBo.UploadedOn);
                cmd.Parameters.AddWithValue("@desc", docBo.Description);
                int result = cmd.ExecuteNonQuery();
                return result;

            }
        }
        public DataTable ListSkills()
        {

            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ListSkills", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter list = new SqlDataAdapter(cmd);
                DataTable skillList = new DataTable();
                list.Fill(skillList);
                con.Close();
                return skillList;
            }
            }
        public DataTable MapSkillList(string skillName)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_MapSkills", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skillName", skillName);
                SqlDataAdapter list = new SqlDataAdapter(cmd);
                DataTable mapSkillList = new DataTable();
                list.Fill(mapSkillList);
                con.Close();
                return mapSkillList;
            }
            }


        public DataTable DocList(bool archiveStatus)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DocList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@archiveStatus", archiveStatus);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                return document;
            }
        }

        public DataTable DocDisplay(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DocDisplay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.DocumentId);
               // cmd.Parameters.AddWithValue("@archive", archive);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                return document;
            }
        }

        public DataTable Student_Teacher_ListDisplay(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DisplayStudent_Teacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleId", obj.CategoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                return document;
            }
        }

        public DataTable Teacher_DataDisplay(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DisplayTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                return document;
            }
        }

        public DataTable Student_DataDisplay(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_DisplayStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                return document;
            }
        }

        public DataRow UserProfile(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_UserProfile ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable document = new DataTable();
                da.Fill(document);
                DataRow dr = document.Rows[0];
                con.Close();
                return dr;
            }
        }

        public int EditUser(UserBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_UserProfileUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);

                cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                cmd.Parameters.AddWithValue("@lastName", obj.LastName);

                cmd.Parameters.AddWithValue("@age", obj.Age);
                cmd.Parameters.AddWithValue("@gender", obj.Gender);
                cmd.Parameters.AddWithValue("@contact", obj.ContactNumber);
                //cmd.Parameters.AddWithValue("@img", obj.userImage);
                cmd.Parameters.AddWithValue("@image", obj.Image);

                cmd.Parameters.AddWithValue("@updateOn", obj.UpdatedOn);

                cmd.Parameters.AddWithValue("@dob", obj.DOB);
                cmd.Parameters.AddWithValue("@emailId", obj.Email);
                cmd.Parameters.AddWithValue("@specification", obj.description);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
        public int ArchiveDocument(int docId, bool archive)
        {

            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ArchiveDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@docId", docId);
                cmd.Parameters.AddWithValue("@archiveStatus", archive);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }

         public int Enroll(UserBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_Enroll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                cmd.Parameters.AddWithValue("@batchId", obj.BatchId);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

        }

        public DataTable ScheduleTeacher(UserBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ScheduleTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable scheduleTable = new DataTable();
                data.Fill(scheduleTable);
                con.Close();
                return scheduleTable;
            }

        }

        public DataTable ScheduleStudent(UserBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_ScheduleStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable scheduleTable = new DataTable();
                data.Fill(scheduleTable);
                con.Close();
                return scheduleTable;
            }

        }

    }
}
