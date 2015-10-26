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

public partial class message_editRestore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        if (this.Request.Cookies["user_id"] == null)
        {
            Server.Transfer("/chatroom/plslog.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                Server.Transfer("/chatroom/plslog.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    data_conn cn = new data_conn();
                    DataSet ds = cn.mdb_ds("select TB_Message.*,UserName,UserPassword from TB_Message,TB_User where TB_Message.Userid=TB_User.Userid and TB_Message.id=" + ck.CheckNumber(this.Request["id"]), "table");

                    DataSet dstype = cn.mdb_ds("select TB_BBSList.id,TB_BBSList.name from TB_BBS,TB_BBSList where TB_BBS.types=TB_BBSList.id and TB_BBS.id=" + ds.Tables["table"].Rows[0]["BBSID"].ToString(), "type");
                    HyperLink1.Text = dstype.Tables["type"].Rows[0]["name"].ToString();
                    HyperLink1.NavigateUrl = "BBSListtype.aspx?types=" + dstype.Tables["type"].Rows[0]["id"].ToString();
                    if (ds.Tables["table"].Rows[0]["UserID"].ToString() == Request.Cookies["user_id"].Value.ToString())
                    {
                        string text = ds.Tables["table"].Rows[0]["Data"].ToString().Replace("<br>", "\r");
                        text = text.Replace("&nbsp", " ");
                        text = text.Replace("<img src=\"", "[img]");
                        text = text.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                        text = text.Replace("<embed src=\"", "[flash]");
                        text = text.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                        TextBox1.Text = text;
                    }
                    else
                    {
                        TextBox1.Text = "对不起，您只能修改自己发表的贴子";
                        Button1.Visible = false;
                        Response.Write("<script>window.setTimeout('parent.history.go(-2)',5000);</script>");
                    }
                }
            }
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        if (TextBox1.Text != "")
        {
            string text = this.TextBox1.Text.Replace("\r", "<br>");
            text = text.Replace(" ", "&nbsp");
            text = text.Replace("[img]", "<img src=\"");
            text = text.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text = text.Replace("[flash]", "<embed src=\"");
            text = text.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
            data_conn cn = new data_conn();

            cn.mdb_exe("update TB_Message set Data='" + text + "',EditDate=getdate() where id=" + ck.CheckNumber(this.Request["id"]));
            DataSet ds = cn.mdb_ds("select count(*) as count,MAX(BBSID) as BBSID from TB_Message where id<=" + ck.CheckNumber(this.Request["id"]) + " and BBSid in (select BBSID from TB_Message where id=" + ck.CheckNumber(this.Request["id"]) + ")", "table");

            string url = "BBSMessage.aspx?id=" + ds.Tables["table"].Rows[0]["BBSID"] + "&page=" + Convert.ToString((Convert.ToInt32(ds.Tables["table"].Rows[0]["count"]) / 10) + 1) + "#" + ck.CheckNumber(this.Request["id"]);

            this.Response.Redirect(url);
        }
        else
        {
            TextBox1.Text = "不能为空";
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.history.go(-2);</script>");
    }
}

