﻿using System;
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
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                adminName.Text = Session["FirstName"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/SignInPage.aspx");
            }

            try
            {
                if (Session["UserId"] != null)
                {
                    SignInBO imageBO = new SignInBO
                    {
                        userId = Session["UserId"].ToString()
                    };
                    SignInBAL imageBAL = new SignInBAL();
                    DataRow dr = imageBAL.Image(imageBO);
                    profileImage.ImageUrl = dr["details_image"].ToString();
                }
            }
            catch
            {

            }
        }

        protected void RList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RList.SelectedValue == "Student")
            {
                Response.Redirect("~/ShowResources.aspx?value=" + RList.SelectedValue);
            }
            else if (RList.SelectedValue == "Teacher")
            {
                Response.Redirect("~/ShowResources.aspx?value=" + RList.SelectedValue);
            }
            else if (RList.SelectedValue == "Document")
            {
                Response.Redirect("~/ShowResources.aspx?value=" + RList.SelectedValue);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/SignInPage.aspx");
        }
    }
}