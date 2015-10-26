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
            


            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_IMGIndex where id=3", "index");

            txtimagelink.Value = ds.Tables["index"].Rows[0]["txtlink"].ToString();
            
            
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




        string sql = "update TB_IMGIndex set txtlink='" + txtimagelink.Value + "' where id=3";


        data_conn cn = new data_conn();
        cn.mdb_exe(sql);






        if (FileUpload1.FileName != "")
        {
            string filepath = Server.MapPath("../images/index/") + "/pic_3.gif";
            FileUpload1.SaveAs(filepath);

        }

        this.Response.Redirect("titlelist.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("titlelist.aspx");
    }

}
