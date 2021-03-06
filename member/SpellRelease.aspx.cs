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

public partial class member_SpellRelease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        if (Request.Cookies["user_id"] != null && Request.Cookies["user_id"].Value != "")
        {
            DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies["user_id"].Value, "user");
            if (Convert.ToInt32(ds.Tables["user"].Rows[0]["time_limiter"]) == 1)
            {
                if (ds.Tables["user"].Rows[0]["time_limit_lcl"] != DBNull.Value)
                {
                    if (Convert.ToDateTime(ds.Tables["user"].Rows[0]["time_limit_lcl"]).AddDays(1) > DateTime.Now)
                    {
                        Response.Redirect("ReleaseFail.aspx");
                    }
                }
            }
        }
        else
        {
            Response.Redirect("../accounts/login.aspx");
        }


        Random rd = new Random();
        string rdnumber = Convert.ToInt32((10000 * rd.NextDouble())).ToString();

        Session["SpellRelease"] = rdnumber; string parameter = "";
        for (int i = 0; i < Request.QueryString.Count; i++)
        {
            if (Request.QueryString[i].ToString() != "")
            {
                if (parameter != "")
                {
                    parameter += "&";
                }
                parameter += Request.QueryString.Keys[i].ToString() + "=" + Request.QueryString[i].ToString();
            }

        }
        if (parameter != "")
        {
            parameter = "?" + parameter;
        }
        Response.Redirect("SpellRelease_1.aspx" + parameter);
    }
}
