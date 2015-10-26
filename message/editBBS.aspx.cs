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

public partial class message_editBBS : System.Web.UI.Page
{


    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
            if (TextBox1.Text == "")
            {
                Label2.Text = "正文不能为空";
            }
            else if (TextBox2.Text == "")
            {
                Label2.Text = "标题不能为空";
            }
            else if (TextBox2.Text.Length > 50)
            {

                Label2.Text = "标题不能超过50个字符";

            }
            else if (TextBox1.Text.Length > 4000)
            {
                Label2.Text = "正文不能超过4000个字符";
            }
            else
            {
                string text1 = ck.CheckInput(this.TextBox1.Text);
                text1 = text1.Replace("\r", "<br>");
                text1 = text1.Replace(" ", "&nbsp");
                text1 = text1.Replace("[img]", "<img src=\"");
                text1 = text1.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
                text1 = text1.Replace("[flash]", "<embed src=\"");
                text1 = text1.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");


                string text2 = ck.CheckInput(this.TextBox2.Text);

                text2 = text2.Replace("\r", "<br>");
                text2 = text2.Replace(" ", "&nbsp");
                text2 = text2.Replace("[img]", "<img src=\"");
                text2 = text2.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
                text2 = text2.Replace("[flash]", "<embed src=\"");
                text2 = text2.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
                data_conn cn = new data_conn();

                cn.mdb_exe("update TB_BBS set Data='" + text1 + "',title='" + text2 + "',EditDate=getdate() where id=" + ck.CheckNumber(this.Request["id"]));

                string url = "BBSMessage.aspx?id=" + ck.CheckNumber(this.Request["id"]) + "&page=1";

                this.Response.Redirect(url);
            }

        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select TB_BBS.*,UserName,UserPassword,TB_BBSList.id as typeID,TB_BBSList.name from TB_BBS,TB_User,TB_BBSList where TB_BBS.Userid=TB_User.Userid and TB_BBSList.id=TB_BBS.types and TB_BBS.id=" + ck.CheckNumber(this.Request["id"]), "table");

            HyperLink1.Text = ds.Tables["table"].Rows[0]["name"].ToString();
            HyperLink1.NavigateUrl = "BBSListtype.aspx?types=" + ds.Tables["table"].Rows[0]["typeID"].ToString();
            if (ds.Tables["table"].Rows[0]["UserID"].ToString() == Request.Cookies["user_id"].Value.ToString())
            {
                string text1 = ds.Tables["table"].Rows[0]["Data"].ToString().Replace("<br>", "\r");
                text1 = text1.Replace("&nbsp", " ");
                text1 = text1.Replace("<img src=\"", "[img]");
                text1 = text1.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text1 = text1.Replace("<embed src=\"", "[flash]");
                text1 = text1.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                TextBox1.Text = text1;
                string text2 = ds.Tables["table"].Rows[0]["title"].ToString().Replace("<br>", "\r");
                text2 = text2.Replace("&nbsp", " ");
                text2 = text2.Replace("<img src=\"", "[img]");
                text2 = text2.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text2 = text2.Replace("<embed src=\"", "[flash]");
                text2 = text2.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                TextBox2.Text = text2;
            }
            else
            {
                Button1.Visible = false;
                TextBox1.Text = "对不起，您只能修改自己发表的贴子";
                Response.Write("<script>window.setTimeout('parent.history.go(-1)',5000);</script>");
                
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.history.go(-2);</script>");
    }
}

