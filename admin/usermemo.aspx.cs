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




public partial class admin_userlist : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{

    string returnValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + this.Request["id"], "useridlist");

        TextBox2.Text = ds.Tables["useridlist"].Rows[0]["importer"].ToString();

        switch (Convert.ToInt32(ds.Tables["useridlist"].Rows[0]["verify"]))
        {

            case 0:
                this.radio0.Checked = true;
                break;
            case 1:
                this.radio1.Checked = true;
                break;
            case 2:
                this.radio2.Checked = true;
                break;
            default:
                break;

        }
        
        bntsub.Attributes.Add("onclick", "window.open('/admin/report/user_meno.aspx?id=" + this.Request["id"] + "','report','');return false;");
        Button1.Attributes.Add("onclick", "txtsubmit();return false;");
        //Button3.Attributes.Add("onclick", "txtsubmit2();return false;");
        //LoadUser();
        if (Page.IsPostBack == false)
        {
            LoadList();
        }
    }


    public void LoadList()
    {
        data_conn cn = new data_conn();
        string sql = "select * from TB_Feedback where UserID=" + this.Request["id"] + " order by id desc";
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
            cn.mdb_exe("insert into TB_Feedback (UserID,Postdate,detail) values (" + this.Request["id"] + ",getdate(),'" + TextBox1.Text + "','");
            
            MessageBox("opsuccess", "成功");
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
            string returnstr = "";
            string[] strarray = returnValue.Split('|');
            if (strarray[0] == "submit")
            {
                DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + this.Request["id"], "importer");
                if (ds.Tables["importer"].Rows[0]["importer"].ToString() == "")
                {
                    cn.mdb_exe("update TB_User set importer='" + Server.UrlDecode(Request.Cookies["admin_name"].Value) + "' where UserID=" + this.Request["id"]);

                    returnstr = Server.UrlDecode(Request.Cookies["admin_name"].Value) + "";
                }
                else
                {
                    returnstr = ds.Tables["importer"].Rows[0]["importer"].ToString() + "";
                }
                cn.mdb_exe("insert into TB_Feedback (UserID,Postdate,detail) values (" + this.Request["id"] + ",getdate(),'" + strarray[1] + "')");

                LoadList();
                returnstr += "<table cellspacing='0' cellpadding='3' rules='rows' bordercolor ='#D9D9D9' border='1' id='GridView1' style='border-width:1px;border-style:Solid;border-collapse:collapse; width:780px'>";
                returnstr = returnstr + RenderControl(Repeater1);
                returnstr = returnstr + "</table>";
            }
            else if (strarray[0] == "check")
            {
                
                cn.mdb_exe("update TB_User set verify=" + strarray[1] + " where UserID=" + this.Request["id"].ToString());
                switch (strarray[1])
                {

                    case "0":
                        returnstr = "<input runat='server' type='radio' id='radio0' onclick='CheckBox1_CheckedChanged(0)' checked value = 'a' />待定";
                        returnstr += "<input runat='server' type='radio' id='radio1' onclick='CheckBox1_CheckedChanged(1)' value = 'b' />正确";
                        returnstr += "<input runat='server' type='radio' id='radio2' onclick='CheckBox1_CheckedChanged(2)' value = 'c' />错误";
                        break;
                    case "1":
                        returnstr = "<input runat='server' type='radio' id='radio0' onclick='CheckBox1_CheckedChanged(0)'  value = 'a' />待定";
                        returnstr += "<input runat='server' type='radio' id='radio1' onclick='CheckBox1_CheckedChanged(1)' checked value = 'b' />正确";
                        returnstr += "<input runat='server' type='radio' id='radio2' onclick='CheckBox1_CheckedChanged(2)' value = 'c' />错误";
                        break;
                    case "2":
                        returnstr = "<input runat='server' type='radio' id='radio0' onclick='CheckBox1_CheckedChanged(0)' value = 'a' />待定";
                        returnstr += "<input runat='server' type='radio' id='radio1' onclick='CheckBox1_CheckedChanged(1)' value = 'b' />正确";
                        returnstr += "<input runat='server' type='radio' id='radio2' onclick='CheckBox1_CheckedChanged(2)' checked value = 'c' />错误";
                        break;
                    default:
                        break;

                }
                
            }
            
            return returnstr;
        }
        catch (Exception e)
        {
            return "asdfasdf";
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
    //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    //{
    //    data_conn cn = new data_conn();
    //    if (this.CheckBox1.Checked == true)
    //    {
    //        cn.mdb_exe("update TB_User set verify=1 where UserID=" + this.Request["id"].ToString());
    //    }
    //    else
    //    {
    //        cn.mdb_exe("update TB_User set verify=0 where UserID=" + this.Request["id"].ToString());
    //    }

    //}
}
