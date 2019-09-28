using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessAccessLayer;
using System.Data;

namespace TS_Connect
{
    public partial class SuperUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetData();
        }

        public void GetData()
        {
            SuperUserBAL approvalList = new SuperUserBAL();
            DataSet _data = approvalList.ApprovalData();
            grdApprovalList.DataSource = _data;
            grdApprovalList.DataBind();
        }
        protected void grdApprovalList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = grdApprovalList.Rows[e.RowIndex];
                string userId = (row.FindControl("lblId") as Label).Text;
                UserBO _reject = new UserBO();
                _reject.UserId = userId;
                SuperUserBAL _adminRejection = new SuperUserBAL();
                int result = _adminRejection.AdminReject(_reject);
                if (result >= 3)
                {
                    lblStatus.Text = "Update Successfull";
                }
                else
                {
                    lblStatus.Text = "Update Failed";
                }
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Update Failed";
            }
            GetData();
        }

        protected void grdApprovalList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            try
            {
                GridViewRow row = grdApprovalList.Rows[e.NewSelectedIndex];
                string userId = (row.FindControl("lblId") as Label).Text;
                UserBO _approval = new UserBO();
                _approval.UserId = userId;
                SuperUserBAL _adminApproval = new SuperUserBAL();
                int result = _adminApproval.AdminApproval(_approval);
                if (result >= 2)
                {
                    lblStatus.Text = userId +" Approved Successfully!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Approved();", true);
                }
                else
                {
                    lblStatus.Text = "Update Failed";
                }
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Update Failed";
            }
            GetData();
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/SignInPage.aspx");
        }
    }
}

