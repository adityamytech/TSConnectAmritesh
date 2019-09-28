using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BusinessObject;
using BusinessAccessLayer;

namespace TS_Connect
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProfileImage.ImageUrl = "~/Images/Fotolia_188161178_XS-6.jpg";
            txtBoxUserid.Text = "";
            txtBoxPassword.Text = "";
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxAge.Text = "";
            txtBoxContact.Text = "";
            txtBoxAns.Text = "";
            txtBoxEmail.Text = "";
        }

        protected void testBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImageUpload.HasFile)
                {
                    string strExtension = System.IO.Path.GetExtension(ImageUpload.FileName);
                    if (strExtension == ".jpg" || strExtension == ".jepg" || strExtension == ".jpg" || strExtension == ".png" || strExtension == ".bmp")
                    {
                        string strname = ImageUpload.FileName.ToString();
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        ImageUpload.SaveAs(Server.MapPath("~/Images/") + fileName + strname);
                        string filename = System.IO.Path.GetFileName(ImageUpload.FileName);
                        lblUploaded.Text = "Image Uploaded successfully";
                        string gender;
                        string category;
                        int categoryId;
                        bool active = true;
                        if (RoleList.SelectedValue == "Customer")
                        {
                            category = DropDownCategory.SelectedValue;
                            categoryId = DropDownCategory.SelectedIndex;
                            active = true; ;
                        }
                        else
                        {
                            category = "Admin";
                            categoryId = 2;
                            active = false;
                        }
                        if (radioBtnFemale.Checked)
                        {
                            gender = "Female";
                        }
                        else
                        {
                            gender = "Male";
                        }
                        SignUpBO _signup = new SignUpBO
                        {
                            UserId = txtBoxUserid.Text,
                            Password = txtBoxPassword.Text,
                            FirstName = txtBoxFirstName.Text,
                            LastName = txtBoxLastName.Text,
                            Age = int.Parse(txtBoxAge.Text),
                            ContactNumber = txtBoxContact.Text,
                            Category = category,
                            CategoryId = categoryId,
                            SecurityQuestionId = DropDownListQuestion.SelectedIndex,
                            SecurityAnswer = txtBoxAns.Text,
                            Gender = gender,
                            UpdatedOn = DateTime.Now,
                            IsActive = active,
                            DOB = DateTime.Parse(txtBoxDOB.Text),
                            Email = txtBoxEmail.Text,
                            Image = "~/Images/" + fileName + strname
                        };
                        SignUpBAL signUpBAL = new SignUpBAL();
                        int result = signUpBAL.Register(_signup);
                        if (result > 1)
                        {
                            if (RoleList.SelectedValue == "Admin")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SignUpAdminAlert();", true);
                                lblStatus.Text = "";
                            }
                            else if (RoleList.SelectedValue == "Customer")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SignUpUserAlert();", true);
                                lblStatus.Text = "";
                            }
                        }
                        else
                        {
                            lblStatus.Text = "User Name already exist";

                        }
                    }
                    else
                    {
                        lblUploaded.Text = "Plz Upload Valid image!!";
                    }
                }
                else
                {
                    lblUploaded.Text = "Plz upload the image!!!!";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}
