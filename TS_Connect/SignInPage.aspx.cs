using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using DataAccessLayer;
using BusinessObject;
using System.Data;

namespace TS_Connect
{
    public partial class SignInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

          try
            {
                SignInBO _signInBO = new SignInBO();
                _signInBO.userId = txtBoxUser.Text;
                _signInBO.userPassword = txtBoxPassword.Text;
                SignInBAL signInBAL = new SignInBAL();
                //SignInDAL signIn = new SignInDAL();
                DataRow _dataRow = signInBAL.LogIn(_signInBO);
                if (_dataRow == null)
                {
                    lblStatus.Text = "Invalid User Name or Password";
                }
                else
                {
                    //Session _session = new Session
                    //{
                    //    Session_CategoryId = int.Parse(_dataRow["role_id"].ToString()),
                    //    Session_UserId = _dataRow["us_userId"].ToString(),
                    //    Session_FirstName = _dataRow["us_firstName"].ToString()
                    //};
                    Session["UserId"] = _dataRow["us_userId"].ToString();
                    Session["RoleId"] = _dataRow["role_id"].ToString();
                    Session["FirstName"] = _dataRow["us_firstname"].ToString();
                    switch (_dataRow["role_id"].ToString())
                    {
                        case "0":
                            Response.Redirect("~/HomePageUser.aspx"); break;
                        case "1":
                            Response.Redirect("~/HomePageUser.aspx"); break;
                        case "2":
                            Response.Redirect("~/HomePageAdmin.aspx"); break;
                        case "3":
                            Response.Redirect("~/SuperUser.aspx"); break;
                    }


                    //if(_session.Session_CategoryId == 3)
                    //{
                    //    Session["UserId"] = _session.Session_UserId;
                    //    Response.Redirect("~/SuperUser.aspx");
                    //}
                    //if (_session.Session_CategoryId == 2)
                    //{
                    //    Session["UserId"] = _session.Session_UserId;
                    //    Session["FirstName"] = _session.Session_FirstName;
                    //    Response.Redirect("~/HomePageAdmin.aspx");
                    //}
                    //if (_session.Session_CategoryId == 1 )
                    //{
                    //    Session["UserId"] = _session.Session_UserId;
                    //    Response.Redirect("~/HomePageUser.aspx");
                    //}
                    //if (_session.Session_CategoryId == 0)
                    //{
                    //    Session["UserId"] = _session.Session_UserId;
                    //    Response.Redirect("~/HomePageUser.aspx");
                    //}

                }

            }

           

            catch(Exception ex)
            {
                lblStatus.Text = "Invalid User Name or Password"+ex.Message;
            }


            //Session
        //    try
        //    {
        //        SignInBAL sign
        //        if (_user != null)
        //        {
        //            Session["Role"] = _user.Role;
        //            Session["UserId"] = _user.Id;
        //            Session["UserName"] = _user.UserName;
        //            switch (_user.Role)
        //            {
        //                case 1:
        //                    Response.Redirect("ShowMovieListAdmin.aspx");
        //                    break;
        //                case 2:
        //                    Response.Redirect("ShowMovieListCustomer.aspx");
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            Label1.Text = "Invalid User Details";
        //            Label1.ForeColor = System.Drawing.Color.Red;
        //        }
        //        txtBoxUserName.Text = txtBoxPassword.Text = string.Empty;
        //    }
        //    catch
        //    {

        //    }

        }
       
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUpPage.aspx");
        }
    }
}