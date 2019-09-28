using BusinessAccessLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS_Connect
{
    public partial class ShowResourceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Resource"].ToString() == "document" || Session["Resource"].ToString()=="Archive")
                {
                    GetDocumentData();
                }
                else if (Session["Resource"].ToString() == "Student")
                {
                    GetStudentData();
                }
                else if (Session["Resource"].ToString() == "Teacher")
                {
                    GetTeacherData();
                }
            }
        }

        public void GetDocumentData()
        {
            UserBO docDisplay = new UserBO
            {
                DocumentId = int.Parse(Request.QueryString["resource_value"])
            };
            UserBAL display = new UserBAL();
            DataTable document = display.UserDocumentDisplay(docDisplay);
            grdDocumentDisplay.DataSource = document;
            grdDocumentDisplay.DataBind();
        }

        public void GetStudentData()
        {
            UserBO StudentDetails = new UserBO
            {
                UserId = Request.QueryString["resource_value"]
            };
            UserBAL _StudentDetails = new UserBAL();
            DataTable details = _StudentDetails.StudentDetailsDisplay(StudentDetails);
            grdStudent.DataSource = details;
            grdStudent.DataBind();
        }

        public void GetTeacherData()
        {
            UserBO teacherDetails = new UserBO
            {
                UserId = Request.QueryString["resource_value"]
            };
            UserBAL _teacherDetails = new UserBAL();
            DataTable details = _teacherDetails.TeacherDetailsDisplay(teacherDetails);
            grdTeacher.DataSource = details;
            grdTeacher.DataBind();

            UserBO schedule = new UserBO
            {
                UserId = Request.QueryString["resource_value"]
            };
            UserBAL scheduleList = new UserBAL();
            grdTeacherSchedule.DataSource = scheduleList.ScheduleTeacher(schedule);
            grdTeacherSchedule.DataBind();
            grdTSchedule.DataSource = scheduleList.ScheduleTeacher(schedule);
            grdTSchedule.DataBind();
            //grdTeacherScheduleEn.DataSource = scheduleList.ScheduleTeacher(schedule);
            //grdTeacherScheduleEn.DataBind();
        }


        protected void grdDocumentDisplay_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = grdDocumentDisplay.Rows[e.NewSelectedIndex];
                string docPath = (row.FindControl("lblFileDownload") as Label).Text;
                string strURL = docPath;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
                //WebClient wc = new WebClient();

                //wc.DownloadFile(docPath, "C:\\downloads");
            }
            catch (Exception ex)
            {
            }


            //GridViewRow row = grdDocumentDisplay.Rows[e.NewSelectedIndex];
            ////string docPath = (row.FindControl("lblFileDownload") as Label).Text;
            //string docPath = "~/Documents/20190928143240CTKDO008_DevOps Aware Certificate.pdf";
            //string strURL = docPath;
            //WebClient req = new WebClient();
            //HttpResponse response = HttpContext.Current.Response;
            //response.Clear();
            //response.ClearContent();
            //response.ClearHeaders();
            //response.Buffer = true;
            //response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
            //byte[] data = req.DownloadData(Server.MapPath(strURL));
            //response.BinaryWrite(data);
            //response.End();
        }

        protected void grdTeacher_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdTeacherSchedule_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = grdTeacherSchedule.Rows[e.NewSelectedIndex];
                string batchId = (row.FindControl("lblBatchId") as Label).Text;
                UserBO enrollBO = new UserBO
                {
                    UserId = Session["UserId"].ToString(),
                    BatchId = batchId
                };
                UserBAL enrollBAL = new UserBAL();
                int result = enrollBAL.Enroll(enrollBO);
                if (result >= 1)
                {
                    lblStatus.Text = "Successfully Enrolled";
                    // lblStaus = "Successfully Enrolled";
                }
                else
                {
                    lblStatus.Text = "Already Enrolled";
                    //   lblStaus = "Fail to Enrolle";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                // lblStatus = ex.me
            }
        }
    }
}