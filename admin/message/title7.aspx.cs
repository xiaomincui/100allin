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
using System.Web.Security;

public partial class admin_userlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadUser();
        if (Page.IsPostBack == false)
        {


            
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("SELECT * FROM TB_TOPBBS WHERE tid = 7", "bbs");
            txttitle.Value = ds.Tables["bbs"].Rows[0]["alttxt"].ToString();
            txtimagelink.Value = ds.Tables["bbs"].Rows[0]["linkurl"].ToString();
        }
    }



   

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {




        string sql = "update TB_TOPBBS set alttxt='" + txttitle.Value + "',linkurl='" + txtimagelink.Value + "' where tid=7";


        data_conn cn = new data_conn();
        cn.mdb_exe(sql);




        if (FileUpload1.FileName != "")
        {
            string filepath = Server.MapPath("../../images/bbs/") + "/pic2.jpg";
            FileUpload1.SaveAs(filepath);

        }




        this.Response.Redirect("../titlelist.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../titlelist.aspx");
    }

}
