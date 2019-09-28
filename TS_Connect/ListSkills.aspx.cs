using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;

namespace TS_Connect
{
    public partial class ListSkills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBAL skillList = new UserBAL();
            gridViewSkills.DataSource = skillList.ListSkillsBal();
            gridViewSkills.DataBind();
        }

        protected void gridViewSkills_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gridViewSkills.Rows[e.NewSelectedIndex];
            string skillName = (row.FindControl("lblSkillName") as Label).Text;
            gridDisplayhide.Value = skillName;
            UserBAL mapSkills = new UserBAL();
            gridViewResource.DataSource = mapSkills.MapSkillListBAL(skillName);
            gridViewResource.DataBind();
        }
    }
}