using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using System.Data;
using System.Net;

namespace TS_Connect
{
    public partial class AdvanceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxKeyword.Text != "")
                {
                    UserBAL search = new UserBAL();
                    string keyWordId = dropDownKeyword.SelectedValue;
                    string keyWord = txtBoxKeyword.Text;
                    DataTable searchTable = search.AdvanceSearchTable(keyWordId, keyWord);
                    if (searchTable.Rows.Count>0)
                    {
                        gridViewSearch.DataSource = searchTable;
                        gridViewSearch.DataBind();
                    }
                    else
                    {
                        lblStatus.Text = "Document not found";
                    }
                }
                else
                {
                    lblStatus.Text = "please enter a keyword for search";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdvanceSearch.aspx");
        }

        protected void gridViewSearch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = gridViewSearch.Rows[e.NewSelectedIndex];
                string docPath = (row.FindControl("lblDocDocument") as Label).Text;
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
        }
    }
}