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

public partial class message_default : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {

        check ck = new check();
        string text = ck.CheckInput(this.TextBox1.Text);
        text = text.Replace("\r", "<br>");
        text = text.Replace(" ", "&nbsp");
        text = text.Replace("[img]", "<img src=\"");
        text = text.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
        text = text.Replace("[flash]", "<embed src=\"");
        text = text.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
        if (text == "")
        {
            MessageBox("", "正文不能为空");
            //Label2.Text = "正文不能为空";
        }
        else if (TextBox2.Text == "")
        {
            MessageBox("", "标题不能为空");
            //Label2.Text = "标题不能为空";
        }
        else if (TextBox2.Text.Length > 50)
        {
            MessageBox("", "标题不能超过50个字符");
            //Label2.Text = "标题不能超过50个字符";
        }
        else if (text.Length > 4000)
        {
            MessageBox("", "正文不能超过4000个字符");
            //Label2.Text = "正文不能超过4000个字符";
        }
        else
        {

            data_conn cn = new data_conn();


            cn.mdb_exe("insert into TB_BBS (UserID,title,Data,PostDate,UpdateDate,types) values (" + this.Request.Cookies["user_id"].Value + ",'" + TextBox2.Text + "','" + text + "',getdate(),getdate()," + DropDownList1.SelectedValue + ")");
            this.Response.Redirect("BBSList.aspx");
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

    protected void Page_Load(object sender, EventArgs e)
    {


        if (this.Request.Cookies["user_id"] == null)
        {

            Response.Cookies["url"].Value = Request.Url.ToString();
            this.Response.Redirect("../member/reg.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                Response.Cookies["url"].Value = Request.Url.ToString();
                this.Response.Redirect("../member/reg.aspx");
            }
        }

        DropDownList1.SelectedIndex = Convert.ToInt32(this.Request["types"]) - 1;
        
    }
}
