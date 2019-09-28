using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BusinessObject;
using System.IO;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class SignUpDAL
    {
        public int SignUp(SignUpBO obj)
        {
            string connection = ConfigurationManager.ConnectionStrings["TSConnect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TS_signUp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", obj.UserId);
                cmd.Parameters.AddWithValue("@password", Encrypt(obj.Password.Trim()));
                cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                cmd.Parameters.AddWithValue("@roleId", obj.CategoryId);
                cmd.Parameters.AddWithValue("@type", obj.Category);
                cmd.Parameters.AddWithValue("@age", obj.Age);
                cmd.Parameters.AddWithValue("@gender", obj.Gender);
                cmd.Parameters.AddWithValue("@contact", obj.ContactNumber);
                //cmd.Parameters.AddWithValue("@img", obj.userImage);
                cmd.Parameters.AddWithValue("@image", obj.Image);
                cmd.Parameters.AddWithValue("@securityId", obj.SecurityQuestionId);
                cmd.Parameters.AddWithValue("@securityAnswer", obj.SecurityAnswer);
                cmd.Parameters.AddWithValue("@updatedOn", obj.UpdatedOn);
                cmd.Parameters.AddWithValue("@isActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@dob", obj.DOB);
                cmd.Parameters.AddWithValue("@emailId", obj.Email);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
