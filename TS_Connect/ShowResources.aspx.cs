using BusinessAccessLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace TS_Connect
{
    public partial class ShowResources : System.Web.UI.Page
    {
        private string sortExpression;
        private SortDirection sortDirection;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["value"] == "Document")
                {
                    GetDocument();
                }
                if (Request.QueryString["value"] == "Archive")
                {
                    GetArchiveDocument();
                }
                if (Request.QueryString["value"] == "Teacher" || Request.QueryString["value"] == "Student")
                {
                    GetTSData();
                }
            }
            else
            {
                if (ViewState["SortExpression"] != null)
                    sortExpression = ViewState["SortExpression"].ToString();
                else
                    sortExpression = String.Empty;

                if (ViewState["SortDirection"] != null)
                {
                    if (Convert.ToInt32(ViewState["SortDirection"]) == (int)SortDirection.Ascending)
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Descending;
                    }
                }
            }
          
        }


        public void GetDocument()
        {
            DataTable document = new DataTable();
            if(ViewState["DocumentDS"] != null)
            {
               document = (DataTable)ViewState["DocumentDS"];
            }
            else
            {
                UserBAL doc = new UserBAL();
                document = doc.UserDocument(false);
                //grdDocument.DataSource = document;
                //grdDocument.DataBind();
                ViewState["DocumentDS"] = document;
            }
            String sort = String.Empty;
            if (null != sortExpression && String.Empty != sortExpression)
            {
                sort = String.Format("{0} {1}", sortExpression, (sortDirection == SortDirection.Descending) ? "DESC" : "ASC");
            }
            DataView dv = new DataView(document, String.Empty, sort, DataViewRowState.CurrentRows);
            grdDocument.DataSource = dv;
            grdDocument.DataBind();

        }

        public void GetArchiveDocument()
        {
            UserBAL doc = new UserBAL();
            DataTable archiveDoc = doc.UserDocument(true);
            gridArchiveDoc.DataSource = archiveDoc;
            gridArchiveDoc.DataBind();
        }
        public void GetTSData()
        {

            if (Request.QueryString["value"] == "Teacher")
            {
                DataTable teacherData = new DataTable();
                if (ViewState["TeacherDS"] != null)
                {
                    teacherData = (DataTable)ViewState["TeacherDS"];
                }
                else
                {
                    UserBO data = new UserBO
                    {
                        CategoryId = 0
                    };
                    UserBAL dataDisplay = new UserBAL();
                    teacherData = dataDisplay.StudentTeacherDetailsDisplay(data);
                    ViewState["TeacherDS"] = teacherData;
                }
                String sort = String.Empty;
                if (null != sortExpression && String.Empty != sortExpression)
                {
                    sort = String.Format("{0} {1}", sortExpression, (sortDirection == SortDirection.Descending) ? "DESC" : "ASC");
                }
                DataView dv = new DataView(teacherData, String.Empty, sort, DataViewRowState.CurrentRows);
                grdDocument.DataSource = dv;
                grdTS.DataSource = dv;
                grdTS.DataBind();
            }

            else if (Request.QueryString["value"] == "Student")
            {
                DataTable studentdata = new DataTable();
                if (ViewState["StudentDS"] != null)
                {
                    studentdata = (DataTable)ViewState["StudentDS"];
                }
                else
                {
                    UserBO data = new UserBO
                    {
                        CategoryId = 1
                    };
                    UserBAL dataDisplay = new UserBAL();
                    studentdata = dataDisplay.StudentTeacherDetailsDisplay(data);
                    ViewState["StudentDS"] = studentdata;
                }
                String sort = String.Empty;
                if (null != sortExpression && String.Empty != sortExpression)
                {
                    sort = String.Format("{0} {1}", sortExpression, (sortDirection == SortDirection.Descending) ? "DESC" : "ASC");
                }
                DataView dv = new DataView(studentdata, String.Empty, sort, DataViewRowState.CurrentRows);
                grdDocument.DataSource = dv;
                grdTS.DataSource = dv;
                grdTS.DataBind();
            }
               
               
            


        }
        protected void grdDocument_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = grdDocument.Rows[e.NewSelectedIndex];
            int docId = int.Parse((row.FindControl("lblId") as Label).Text);
            Session["Resource"] = "document";
            Response.Redirect("~/ShowResourceList.aspx?resource_value=" + docId, true);
        }

        protected void grdTS_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = grdTS.Rows[e.NewSelectedIndex];
            string userId = (row.FindControl("lblUserId") as Label).Text;
            string role = (row.FindControl("lblRole") as Label).Text;
            Session["Resource"] = role;
            Response.Redirect("~/ShowResourceList.aspx?resource_value=" + userId, true);
        }

        protected void grdDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = grdDocument.Rows[e.RowIndex];
                int archivePath = int.Parse((row.FindControl("lblId") as Label).Text);
                UserBAL archive = new UserBAL();
                int result = archive.ArchiveDocument(archivePath, true);
                if (result >= 1)
                {
                    Response.Redirect("~/ShowResources.aspx?value=Document");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridArchiveDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = gridArchiveDoc.Rows[e.RowIndex];
                int archivePath = int.Parse((row.FindControl("lblIdArch") as Label).Text);
                UserBAL archive = new UserBAL();
                int result = archive.ArchiveDocument(archivePath, false);
                if (result >= 1)
                {
                    Response.Redirect("~/ShowResources.aspx?value=Archive");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridArchiveDoc_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = grdDocument.Rows[e.NewSelectedIndex];
            int docId = int.Parse((row.FindControl("lblId") as Label).Text);
            Session["Resource"] = "Archive";
            Response.Redirect("~/ShowResourceList.aspx?resource_value=" + docId, true);
        }

        protected void archiveLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShowResources.aspx?value=Archive");
        }

        protected void grdDocument_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (String.Empty != sortExpression)
            {
                if (String.Compare(e.SortExpression, sortExpression, true) == 0)
                {
                    sortDirection =
                        (sortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
                }
                else
                {
                    sortDirection = SortDirection.Ascending;
                }
            }
            sortExpression = e.SortExpression;
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = (int)sortDirection;

            //rebind the grid
            GetDocument();
        }

        protected void grdDocument_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton btnSort;
               // Image image;
                //iterate through all the header cells
                foreach (TableCell cell in e.Row.Cells)
                {
                    //check if the header cell has any child controls
                    if (cell.HasControls())
                    {
                        //get reference to the button column
                        btnSort = (LinkButton)cell.Controls[0];
                       // image = new Image();
                        if (ViewState["SortExpression"] != null)
                        {
                            //see if the button user clicked on and the sortexpression in the viewstate are same
                            //this check is needed to figure out whether to add the image to this header column nor not
                            if (btnSort.CommandArgument == ViewState["SortExpression"].ToString())
                            {
                                //following snippet figure out whether to add the up or down arrow
                                //based on the sortdirection
                                if (Convert.ToInt32(ViewState["SortDirection"]) == (int)SortDirection.Ascending)
                                {
                                   // image.ImageUrl = "~/images/icons8-present-to-all-30.png";
                                }
                                else
                                {
                                  //  image.ImageUrl = "~/images/Down_Arrow_Icon.png";
                                }
                               // cell.Controls.Add(image);
                            }
                        }
                    }
                }
            }
        }

        protected void grdTS_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (String.Empty != sortExpression)
            {
                if (String.Compare(e.SortExpression, sortExpression, true) == 0)
                {
                    sortDirection =
                        (sortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
                }
                else
                {
                    sortDirection = SortDirection.Ascending;
                }
            }
            sortExpression = e.SortExpression;
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = (int)sortDirection;

            //rebind the grid
            GetTSData();
        }

        protected void grdTS_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton btnSort;
                // Image image;
                //iterate through all the header cells
                foreach (TableCell cell in e.Row.Cells)
                {
                    //check if the header cell has any child controls
                    if (cell.HasControls())
                    {
                        //get reference to the button column
                        btnSort = (LinkButton)cell.Controls[0];
                        // image = new Image();
                        if (ViewState["SortExpression"] != null)
                        {
                            //see if the button user clicked on and the sortexpression in the viewstate are same
                            //this check is needed to figure out whether to add the image to this header column nor not
                            if (btnSort.CommandArgument == ViewState["SortExpression"].ToString())
                            {
                                //following snippet figure out whether to add the up or down arrow
                                //based on the sortdirection
                                if (Convert.ToInt32(ViewState["SortDirection"]) == (int)SortDirection.Ascending)
                                {
                                    // image.ImageUrl = "~/images/icons8-present-to-all-30.png";
                                }
                                else
                                {
                                    //  image.ImageUrl = "~/images/Down_Arrow_Icon.png";
                                }
                                // cell.Controls.Add(image);
                            }
                        }
                    }
                }
            }
        }
    }
}