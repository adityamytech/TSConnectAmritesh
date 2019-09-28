using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessObject;
using System.Data;
using System.Collections;

namespace TS_Connect
{
    public partial class AddSkills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_resCode"] != null)
            {
                RCodeTextBox.Text = Request.QueryString["_resCode"];
                HiddenField1.Value = RCodeTextBox.Text;
                GetData();
            }

            if (!IsPostBack)
            {

                AdminBAL _skillList = new AdminBAL();
                DataTable skill = _skillList.AdminSkillList();

                dropDownSkills.DataSource = skill;
                dropDownSkills.DataValueField = "sk_name";
                dropDownSkills.DataTextField = "sk_name";

                dropDownSkills.DataBind();
              dropDownSkills.Items.Insert(skill.Rows.Count, new ListItem { Text = "Others", Value = "Others" });


            }
        }

        public void GetData()
        {
            try
            {
                AdminBO _skillDataBO = new AdminBO
                {
                    ResCode = RCodeTextBox.Text
                };
                AdminBAL _skillDataBAL = new AdminBAL();
                DataTable tableSkill = _skillDataBAL.AdminSkillData(_skillDataBO);
                DataRow dr = tableSkill.Rows[0];
                if (dr == null)
                {
                    lblStatus.Text = "Resource Code Does Not exist";
                }
                else
                {
                    HiddenField1.Value = RCodeTextBox.Text;
                    lblResourceDesc.Text = dr["res_description"].ToString();
                    gridViewSkills.DataSource = tableSkill;
                    gridViewSkills.DataBind();

                    DropDownIntendedAud.Items.Add(dr["skRes_audience"].ToString());
                    ArrayList audience = new ArrayList { "Student", "Teacher", "Both" };
                    foreach (string k in audience)
                    {
                        DropDownIntendedAud.Items.Add(k);
                    }
                    dropDownBoxComp.Items.Add(dr["skRes_compLevel"].ToString());
                    ArrayList comp = new ArrayList { "Beginner", "Intermediate", "Advance" };
                    foreach (string k in comp)
                    {
                        dropDownBoxComp.Items.Add(k);
                    }


                }

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Resource Code Does Not exist exception";
            }



        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = RCodeTextBox.Text;
            GetData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropDownSkills.Text == "Others")
                {


                    {
                        if (txtBoxSkill.Text.Length >= 1)  
                        {
                            AdminBO _addSkill = new AdminBO
                            {
                                NewSkill = txtBoxSkill.Text
                            };
                            AdminBAL _addSkillBAL = new AdminBAL();
                            int result = _addSkillBAL.AdminAddNewSkill(_addSkill);
                            if (result >= 1)  
                            {
                                AdminBO _skillMappingBO = new AdminBO
                                {
                                    ResCode = RCodeTextBox.Text,
                                 
                                    Audience = DropDownIntendedAud.Text,
                                    CompLevel = dropDownBoxComp.Text,
                                    SkillName = txtBoxSkill.Text
                                  
                                };
                                AdminBAL _skillMappingBAL = new AdminBAL();
                                int result_Map = _skillMappingBAL.AdminSkillMapping(_skillMappingBO);
                                if (result_Map >= 1)  
                                {
                                    lblStatus.Text = "Skill Mapped Successfully";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Skillsadded();", true);
                                }
                                else  
                                {
                                 
                                }
                            }
                            else  
                            {
                                lblStatus.Text = "Skill Already Exist Please Select from Drop Down";
                            }
                        }
                        else  
                        {
                            lblStatus.Text = "Please Enter new Skill Name";
                        }

                    }

                }
                else
                {
                    AdminBO _skillMappingBO = new AdminBO
                    {
                        ResCode = RCodeTextBox.Text,
                        Audience = DropDownIntendedAud.Text,
                        CompLevel = dropDownBoxComp.Text,
                        SkillName = dropDownSkills.Text
                      
                    };
                    AdminBAL _skillMappingBAL = new AdminBAL();
                    int result_Map = _skillMappingBAL.AdminSkillMapping(_skillMappingBO);
                    if (result_Map >= 1)
                    {
                        lblStatus.Text = "Skills Mapped Successfully";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Skillsadded();", true);
                    }
                    else
                    {
                        lblStatus.Text = "Upload Mapping Wt Unsuccessfull";
                    }
                }

                if (Request.QueryString["_resCode"] != null)
                {
                   // Response.Redirect("~/ResourceList.aspx");
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SkillMapped();", true);
                }
                else
                {
                    lblStatus.Text = "Something went wrong.Please try again.";
                }

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Skill Already Exist Exception";
            }


        }

    }
}