using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using System.Data;
using BusinessAccessLayer;
using System.Net;

namespace TS_Connect
{
    public partial class ResourceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            GetData();
        }

        public void GetData()
        {
            AdminBAL resourceList = new AdminBAL();
            DataTable _data = resourceList.AdminResourceTable();
            grdResourceList.DataSource = _data;
            grdResourceList.DataBind();
        }

        protected void grdResourceList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = grdResourceList.Rows[e.RowIndex];
                string res_Code = (row.FindControl("lblResCode") as Label).Text;
                string skill_name = (row.FindControl("lblSkills") as Label).Text;
                AdminBO deleteBO = new AdminBO
                {
                    ResCode = res_Code,
                    SkillName = skill_name
                };
                AdminBAL deleteBAL = new AdminBAL();
                int result = deleteBAL.AdminDeleteResource(deleteBO);
            
            }
            catch (Exception ex)
            {
               
            }
            GetData();
        }


        protected void grdResourceList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = grdResourceList.Rows[e.NewSelectedIndex];
            string res_Code = (row.FindControl("lblResCode") as Label).Text;

            Response.Redirect("~/AddSkills.aspx?_resCode=" + res_Code);
        }

        ////protected void lblDoc_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        string strURL = "~/Document/20190922160016truYum-ado.net-specification.docx";
        ////        WebClient req = new WebClient();
        ////        HttpResponse response = HttpContext.Current.Response;
        ////        response.Clear();
        ////        response.ClearContent();
        ////        response.ClearHeaders();
        ////        response.Buffer = true;
        ////        response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
        ////        byte[] data = req.DownloadData(Server.MapPath(strURL));
        ////        response.BinaryWrite(data);
        ////        response.End();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////    }

        ////}

     
    }
}