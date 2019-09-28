using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessAccessLayer;
using BusinessObject;

namespace TS_Connect
{
    public partial class AddResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                AdminBAL _skillList = new AdminBAL();
                DataTable skill = _skillList.AdminSkillList();

                DropDownSkills.DataSource = skill;
                DropDownSkills.DataValueField = "sk_code";
                DropDownSkills.DataTextField = "sk_name";
                DropDownSkills.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DocUpload.HasFile)
                //{
                //    string strExtension = System.IO.Path.GetExtension(DocUpload.FileName);
                    //if (strExtension == ".docx" || strExtension == ".docm" || strExtension == ".pdf" || strExtension == ".xlsx" || strExtension == ".xlsm")
                    //{
                        AdminBAL _resourcesBAL = new AdminBAL();  //d

                        //string strname = DocUpload.FileName.ToString();
                        //string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        //DocUpload.SaveAs(Server.MapPath("~/Document/") + fileName + strname);
                        //string filename = System.IO.Path.GetFileName(DocUpload.FileName);
                 


                        AdminBO _addResources = new AdminBO   //d
                        {

                            ResCode = RCodeTextBox.Text,
                            ResDescription = RDesTextBox.Text,
                           // ResDocument = "~/Document/" + fileName + strname
                        };

                        int result = _resourcesBAL.AdminAddResources(_addResources);

                        if (result >= 1)
                        {
                            int result_skill = 1;

                            if (AddSkill.SelectedValue == "Yes")
                            {
                                AdminBO _addResourceSkills = new AdminBO    //d
                                {
                                    ResCode = RCodeTextBox.Text,
                                    SkillName = DropDownSkills.SelectedItem.Text,
                                    CompLevel = DropDownCompetency.SelectedItem.Value,
                                    Audience = DropDownIntendedAud.SelectedItem.Value
                                };

                                result_skill = _resourcesBAL.AdminAddResourceSkill(_addResourceSkills);

                                if (result_skill >= 1)
                                {
                                    lblFail.Text = "Resource Added Successfully";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ResourceAdded();", true);
                                }

                                else
                                {

                                    AdminBO delete = new AdminBO
                                    {
                                        ResCode = RCodeTextBox.Text
                                    };

                                    _resourcesBAL.AdminDeleteList(delete);
                                    lblFail.Text = "Deleted Failed";
                                }



                            }
                            else
                            {
                                lblFail.Text = "Resource Added Successfully";
                                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ResourceAdded();", true);
                            }

                        }
                        else
                        {
                            lblFail.Text = "Resource Code already Exists!";
                        }





                    //}
                    //else
                    //{
                    //    lblFail.Text = "Plz upload a valid document!!!!";
                    //}
                //}
                //else
                //{
                //    lblFail.Text = "Plz upload !!!!";
                //}
            }
            catch (Exception ex)
            {
                lblFail.Text = ex.ToString();
            }
        }
    }
}
