using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class SuperUserDAL
    {
        public DataSet ApprovalList()
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Approval_DisplayData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet table = new DataSet();
                da.Fill(table);
                con.Close();
                return table;
            }
        }

        public int UpdateAdmin(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Approve_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                int result = cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable table = new DataTable();
                //da.Fill(table);
                con.Close();
                return result;
                //r/*eturn table;*/
            }
        }

        public int RejectAdmin(UserBO obj)
        {
            using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = TS-Connect; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                int result = cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable table = new DataTable();
                //da.Fill(table);
                con.Close();
                return result;
                //r/*eturn table;*/
            }
        }
    }
}
