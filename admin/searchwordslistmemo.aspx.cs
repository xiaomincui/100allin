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

public partial class admin_searchwordslistmemo : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{
    string returnValue;
    protected void Page_Load(object sender, EventArgs e)
    {

        Button1.Attributes.Add("onclick", "txtsubmit();return false;");
        //LoadUser();
        if (Page.IsPostBack == false)
        {
            LoadList();
        }
    }


    public void LoadList()
    {
        data_conn cn = new data_conn();
        string sql = "select * from TB_SEA_SEARCHWORDS_Feedback where UserID=" + this.Request["id"] + " order by id desc";
        DataSet ds = cn.mdb_ds(sql, "bbs");

        Repeater1.DataSource = ds.Tables["bbs"].DefaultView;
        Repeater1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("opsuccess", "不能为空");
        }
        else
        {
            data_conn cn = new data_conn();
            cn.mdb_exe("insert into TB_SEA_SEARCHWORDS_Feedback (UserID,Postdate,detail) values (" + this.Request["id"] + ",getdate(),'" + TextBox1.Text + "')");
            MessageBox("opsuccess", "处理说明添加成功");
            Response.Write("<script>parent.history.go(-2);</script>");
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

        Response.Write("<script>parent.history.go(-2);</script>");
    }


    public string GetCallbackResult()
    {
        try
        {

            data_conn cn = new data_conn();
            cn.mdb_exe("insert into TB_SEA_SEARCHWORDS_Feedback (UserID,Postdate,detail) values (" + this.Request["id"] + ",getdate(),'" + returnValue + "')");
            cn.mdb_exe("update TB_SEA_SEARCHWORDS set SOP = 1 where sid = " + this.Request["id"]);
            LoadList();
            string returnstr = "<table cellspacing='0' cellpadding='3' rules='rows' bordercolor ='#D9D9D9' border='1' id='GridView1' style='border-width:1px;border-style:Solid;border-collapse:collapse; width:780px'>";
            returnstr = returnstr + RenderControl(Repeater1);
            returnstr = returnstr + "</table>";
            return returnstr;
        }
        catch (Exception e)
        {
            return "出错";
        }

    }

    public void RaiseCallbackEvent(String eventArgument)
    {
        returnValue = eventArgument; //客户端传递来的值不作处理
    }

    public string RenderControl(Control control)
    {
        System.IO.StringWriter writer1 = new System.IO.StringWriter(System.Globalization.CultureInfo.InvariantCulture);
        System.Web.UI.HtmlTextWriter writer2 = new System.Web.UI.HtmlTextWriter(writer1);
        control.RenderControl(writer2);
        writer2.Flush();
        writer2.Close();
        return writer1.ToString();
    }
}
