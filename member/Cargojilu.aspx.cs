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

public partial class member_temp_add_air : System.Web.UI.Page
{
    check ck = new check();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select TB_BBS.*,UserName,UserPassword,TB_BBSList.id as typeID,TB_BBSList.name from TB_BBS,TB_User,TB_BBSList where TB_BBS.Userid=TB_User.Userid and TB_BBSList.id=TB_BBS.types and TB_BBS.id=" + ck.CheckNumber(this.Request["id"]), "table");



            

            if (ds.Tables["table"].Rows[0]["UserID"].ToString() == Request.Cookies["user_id"].Value.ToString())
            {
                string text1 = ds.Tables["table"].Rows[0]["Data"].ToString().Replace("<br>", "\r");
                text1 = text1.Replace("<img src=\"", "[img]");
                text1 = text1.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text1 = text1.Replace("<embed src=\"", "[flash]");
                text1 = text1.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                content.Value = text1;
                string text2 = ds.Tables["table"].Rows[0]["title"].ToString().Replace("<br>", "\r");
                text2 = text2.Replace("&nbsp", " ");
                text2 = text2.Replace("<img src=\"", "[img]");
                text2 = text2.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text2 = text2.Replace("<embed src=\"", "[flash]");
                text2 = text2.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                Text1.Value = text2;
            }
            else
            {
                Button1.Visible = false;
                //TextBox1.Text = "对不起，您只能修改自己发表的贴子";
                Response.Write("<script>window.setTimeout('parent.history.go(-1)',5000);</script>");

            }
        }
    }


    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        if (this.Request["id"] != null)
        {
            if (this.Request["id"].ToString() != "")
            {
                update();
            }
            else
            {
                //this.Response.Write("insert");
                insert();
            }

        }
        else
        {
            insert();
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

    public void insert()
    {
        check ck = new check();
        

    }


    public void update()
    {
        
    }

    public int tureToInt(bool t)
    {
        if (t)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string text = ck.CheckSqlWords(this.content.Value);

        if (text == "")
        {
            MessageBox("", "正文不能为空");
            //Label2.Text = "正文不能为空";
        }
        else if (Text1.Value == "")
        {
            MessageBox("", "标题不能为空");
            //Label2.Text = "标题不能为空";
        }
        else if (Text1.Value.Length > 50)
        {
            MessageBox("", "标题不能超过50个字符");
            //Label2.Text = "标题不能超过50个字符";
        }
        else
        {


            string text1 = ck.CheckSqlWords(content.Value);
            text1 = text1.Replace("'", "''");
            text1 = text1.Replace("\r", "<br>");
            text1 = text1.Replace("[img]", "<img src=\"");
            text1 = text1.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text1 = text1.Replace("[flash]", "<embed src=\"");
            text1 = text1.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");


            string text2 = ck.CheckInput(Text1.Value);

            text2 = text2.Replace("\r", "<br>");
            text2 = text2.Replace(" ", "&nbsp");
            text2 = text2.Replace("[img]", "<img src=\"");
            text2 = text2.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text2 = text2.Replace("[flash]", "<embed src=\"");
            text2 = text2.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
            data_conn cn = new data_conn();

            string ifvideo = "0";
            string ifimg = "0";


            if (text.IndexOf("<embed") != -1 || text.IndexOf("<EMBED") != -1)
            {
                ifvideo = "1";
            }

            if (text.IndexOf("<img") != -1 || text.IndexOf("<IMG") != -1)
            {
                ifimg = "1";
            }


            cn.mdb_exe("update TB_BBS set Data='" + text1 + "',title='" + text2 + "',EditDate=getdate(),ifvideo=" + ifvideo + ",ifimg=" + ifimg + " where id=" + ck.CheckNumber(this.Request["id"]));



            string url = "cargolist.aspx";

            this.Response.Redirect(url);

        }
    }

}
