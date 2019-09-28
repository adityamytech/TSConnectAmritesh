using BusinessAccessLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS_Connect
{
    public partial class ProfileUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hiddenStatus.Value = "Edit";
            if (!IsPostBack)
            {
                GetData();
            }
        }


        public void GetData()
        {
            UserBO profile = new UserBO
            {
                UserId = Session["UserId"].ToString()
            };
            UserBAL profileBAL = new UserBAL();
            DataRow dr = profileBAL.UserProfile(profile);
            txtBoxAge.Text = dr["details_age"].ToString();
            txtBoxContact.Text = dr["details_contact"].ToString();
            txtBoxDOB.Text = DateTime.Parse(dr["details_dateOfBirth"].ToString()).ToString("MM/dd/yyyy");
            txtBoxEmailId.Text = dr["details_emailID"].ToString();
            txtBoxFirstName.Text = dr["us_firstName"].ToString();
            txtBoxLastName.Text = dr["us_lastName"].ToString();
            profileImage.ImageUrl = dr["details_image"].ToString();

            if (Session["RoleId"].ToString() == "1")
            {
                txtSpecialization.Text = dr["Student_specialization"].ToString();
            }
            if (Session["RoleId"].ToString() == "0")
            {
                txtSpecialization.Text = dr["Teacher_specialization"].ToString();
            }
            if (dr["details_gender"].ToString() == "Male")
            {
                radioMale.Checked = true;
            }
            else
            {
                radioFemale.Checked = true;
            }


            // _dataRow["us_userId"].ToString();
            //
            //select TS_User. , TS_User. ,TS_Details.details_age,TS_Details.details_contact,TS_Details.details_emailID,TS_Details.details_dateOfBirth,TS_Details.details_image,TS_Details.details_gender,TS_TeacherDetails.
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtBoxFirstName.ReadOnly = false;
            txtBoxLastName.ReadOnly = false;
            txtBoxAge.ReadOnly = false;
            txtBoxContact.ReadOnly = false;
            txtBoxDOB.ReadOnly = false;
            txtBoxEmailId.ReadOnly = false;
            radioMale.Enabled = true;
            radioFemale.Enabled = true;
            txtSpecialization.BackColor = System.Drawing.Color.White;
            txtBoxFirstName.BackColor = System.Drawing.Color.White;
            txtBoxLastName.BackColor = System.Drawing.Color.White;
            txtBoxAge.BackColor = System.Drawing.Color.White;
            txtBoxContact.BackColor = System.Drawing.Color.White;
            txtBoxEmailId.BackColor = System.Drawing.Color.White;
            txtBoxDOB.BackColor = System.Drawing.Color.White;
            hiddenStatus.Value = "Update";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string gender;
                if (radioFemale.Checked)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Male";
                }
                string strExtension = System.IO.Path.GetExtension(ImageUpload.FileName);
                if (strExtension == ".jpg" || strExtension == ".jepg" || strExtension == ".jpg" || strExtension == ".png" || strExtension == ".bmp")
                {
                    string strname = ImageUpload.FileName.ToString();
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    ImageUpload.SaveAs(Server.MapPath("~/Images/") + fileName + strname);
                    string filename = System.IO.Path.GetFileName(ImageUpload.FileName);
                    UserBO updateProfile = new UserBO
                    {
                        UserId = Session["UserId"].ToString(),
                        Image = "~/Images/" + fileName + strname,
                        description = txtSpecialization.Text,
                        FirstName = txtBoxFirstName.Text,
                        LastName = txtBoxLastName.Text,
                        Age = int.Parse(txtBoxAge.Text),
                        ContactNumber = txtBoxContact.Text,
                        Email = txtBoxEmailId.Text,
                        DOB = DateTime.Parse(txtBoxDOB.Text),
                        UpdatedOn = DateTime.Now,
                        Gender = gender
                    };
                    UserBAL update = new UserBAL();
                    int result = update.EditProfileUser(updateProfile);
                    if (result >= 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "UpdateProfileAlert();", true);
                    }

                }
                else
                {
                    UserBO profile = new UserBO
                    {
                        UserId = Session["UserId"].ToString()
                    };
                    UserBAL profileBAL = new UserBAL();
                    DataRow dr = profileBAL.UserProfile(profile);
                    UserBO updateProfile = new UserBO
                    {
                        UserId = Session["UserId"].ToString(),
                        Image = dr["details_image"].ToString(),
                        description = txtSpecialization.Text,
                        FirstName = txtBoxFirstName.Text,
                        LastName = txtBoxLastName.Text,
                        Age = int.Parse(txtBoxAge.Text),
                        ContactNumber = txtBoxContact.Text,
                        Email = txtBoxEmailId.Text,
                        DOB = DateTime.Parse(txtBoxDOB.Text),
                        UpdatedOn = DateTime.Now,
                        Gender = gender

                    };
                    UserBAL update = new UserBAL();
                    int result = update.EditProfileUser(updateProfile);
                    if (result >= 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "UpdateProfileAlert();", true);
                    }
                    else
                    {
                        lblStatus.Text = "Updated failed";
                    }
                }

                GetData();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }


        }
    }
}