using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessObject;
using System.Data;

namespace TS_Connect
{
    public partial class TeacherSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
                GetSchedule();
        }

        public void GetSchedule()
        {
            DataTable data = new DataTable();
            if (Session["RoleId"].ToString() == "0")
            {
                
                UserBO schedule = new UserBO
                {
                    UserId = Session["userId"].ToString()
                };
                UserBAL scheduleList = new UserBAL();
                data = scheduleList.ScheduleTable();
                if (data == null)
                {
                    lblStatus.Text = "Please Add Schedule";
                }
                else
                {
                    gridScheduleList.DataSource = data;
                    gridScheduleList.DataBind();
               
                }
               
            }

            else if (Session["RoleId"].ToString() == "1")
            {
                UserBO schedule = new UserBO
                {
                    UserId = Session["userId"].ToString()
                };
                UserBAL scheduleList = new UserBAL();
                data = scheduleList.ScheduleStudent(schedule);
                if(data == null)
                {
                    lblStatus.Text = "Not enrolled in any classes !! Please Enroll";
                }
                else
                {
                    gridScheduleStudent.DataSource = data;
                    gridScheduleStudent.DataBind();
                  
                }
            }
               
              
        }
        protected void btnAddSchedule_Click(object sender, EventArgs e)
        {
            hiddenSchedule.Value = "Show";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (uploadNotes.HasFile)
                {
                    string strExtension = System.IO.Path.GetExtension(uploadNotes.FileName);
                    if (strExtension == ".docx" || strExtension == ".doc" || strExtension == ".pdf" || strExtension == ".xlsx" || strExtension == ".xlsm")
                    {
                        AdminBAL _resourcesBAL = new AdminBAL();

                        string strname = uploadNotes.FileName.ToString();
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        uploadNotes.SaveAs(Server.MapPath("~/Images/Uploaded Documents") + fileName + strname);
                        string filename = System.IO.Path.GetFileName(uploadNotes.FileName);
                        if(DateTime.Parse(txtBoxFrom.Text)>=DateTime.Now && DateTime.Parse(txtBoxTo.Text)>=DateTime.Now)
                        {
                            if(DateTime.Parse(txtBoxFrom.Text) <= DateTime.Parse(txtBoxTo.Text))
                            {
                                ScheduleBO schedule = new ScheduleBO
                                {
                                    StartFrom = DateTime.Parse(txtBoxFrom.Text),
                                    EndOn = DateTime.Parse(txtBoxTo.Text),
                                    BatchId = txtBoxId.Text,
                                    Subject = txtBoxSubject.Text,
                                    TimeSlot = dropDownTime.SelectedValue
                                };
                                DocumentBO notes = new DocumentBO
                                {
                                    Subject = txtBoxSubject.Text,
                                    UploadedBy = Session["UserId"].ToString(),
                                    UploadedOn = DateTime.Now,
                                    File = "~/Images/Uploaded Documents" + fileName + strname,
                                    Description = txtBoxDesc.Text
                                };
                                UserBAL scheduleList = new UserBAL();
                                int result = scheduleList.AddScheduleBAL(notes, schedule);
                                if (result >= 1)
                                {
                                    lblStatus.Text = "Schedule Added Successfully!! Pls Refresh the Page";
                                    hiddenSchedule.Value = "";
                                }
                                else
                                {
                                    lblStatus.Text = "BatchID already exists!!";
                                }
                            } 
                            else
                            {
                                lblStatus.Text = "End date should be after start date !!";
                            }
                          
                        }
                        else
                        {
                            lblStatus.Text = "Schedule for Past Dates are not allowed";
                        }
                       
                    }
                }
                else
                {
                    lblStatus.Text = "Please Upload Notes";
                }
            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
            }
           
            
        }
    }
}