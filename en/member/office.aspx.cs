﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class en_office : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null)
        {
            Response.Redirect("../sign.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                Response.Redirect("../sign.aspx");
            }
        }

        LitUserName.Text = Request.Cookies["realname"].Value;

    }
}
