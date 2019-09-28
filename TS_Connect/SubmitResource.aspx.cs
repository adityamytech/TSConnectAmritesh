using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessObject;

namespace TS_Connect
{
    public partial class SubmitResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (uploadCoverPage.HasFile && uploadFile.HasFile)
                {
                    string strExtensionFile = System.IO.Path.GetExtension(uploadFile.FileName);
                    string strExtensionCover = System.IO.Path.GetExtension(uploadCoverPage.FileName);
                    if ((strExtensionCover == ".jpg" || strExtensionCover == ".jpeg" || strExtensionCover == ".png" || strExtensionCover == ".bmp") && (strExtensionFile == ".docx" || strExtensionFile == ".docm" || strExtensionFile == ".pdf" || strExtensionFile == ".xlsx" || strExtensionFile == ".xlsm"))
                    {
                        string strname = uploadFile.FileName.ToString();
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        uploadFile.SaveAs(Server.MapPath("~/Document/") + fileName + strname);
                        string filename = System.IO.Path.GetFileName(uploadFile.FileName);
                        //string strFile = uploadFile.FileName.ToString();
                        //string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        //uploadFile.SaveAs(Server.MapPath("~/Documents/") + fileName + strFile);
                        //string docFileName = System.IO.Path.GetFileName(uploadFile.FileName);
                        //string strname = uploadCoverPage.FileName.ToString();
                        //string coverPageName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        //uploadCoverPage.SaveAs(Server.MapPath("~/Images/") + coverPageName + strname);
                        //string coverFileName = System.IO.Path.GetFileName(uploadCoverPage.FileName);
                        DocumentBO uploadDoc = new DocumentBO
                        {
                            ResourceId = txtBoxResCode.Text,
                            Title = txtBoxTitle.Text,
                            Author = txtBoxAuthor.Text,
                            Subject = txtBoxSubject.Text,
                            Year = int.Parse(txtBoxYear.Text),
                            CoverPage = "s",
                            // CoverPage = "~/Images/" + coverFileName + strname,
                            File = "~/Documents/" + fileName + strname,
                            UploadedOn = DateTime.Now,
                            UploadedBy = Session["UserId"].ToString(),
                            Description= txtBoxDesc.Text
                        };
                        UserBAL uploadDocument = new UserBAL();
                        int result = uploadDocument.AddDocuments(uploadDoc);
                        if (result >= 1)
                        {
                            lblStatus.Text = "Uploaded Successfully!";
                        }
                        else
                        {
                            lblStatus.Text = "Resource Does not exist";
                        }
                    }
                }
                else
                {
                    lblStatus.Text = "Please fill the mandatory fields!";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}