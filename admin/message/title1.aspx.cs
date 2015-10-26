using System;
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


            txttext.Focus();
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("SELECT * FROM TB_TOPBBS WHERE tid = 1", "bbs");
            txttitle.Value = ds.Tables["bbs"].Rows[0]["title"].ToString();
            txttext.Text = ds.Tables["bbs"].Rows[0]["indextxt"].ToString();
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




        string sql = "update TB_TOPBBS set title='" + txttitle.Value + "',alttxt='" + txttitle.Value + "',indextxt='" + txttext.Text + "',linkurl='" + txtimagelink.Value + "' where tid=1";


        data_conn cn = new data_conn();
        cn.mdb_exe(sql);








        this.Response.Redirect("../titlelist.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../titlelist.aspx");
    }

}
