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

public partial class accounts_login3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = Request.Cookies["user_name"].Value;
        Literal2.Text = "<a href=\"" + Request.Cookies["redirect_url"].Value + "\">不想申请普通会员，点此回到注册前页面</a>";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string filepath1 = "";
        string filepath2 = "";
        string filepath3 = "";
        string filepath4 = "";
        if (FileUpload1.FileName.ToString() != "")
        {
            filepath1 = "error";
            if (FileUpload1.PostedFile.ContentLength < 4194304)
            {
                filepath1 = Server.MapPath("/member/nvocc/") + Request.Cookies["user_id"].Value.ToString() + "_1.jpg";
            }
            else
            {
                MessageBox("", "企业营业执照图片超过4M，不能上传");
            }
        }

        if (FileUpload2.FileName.ToString() != "")
        {
            filepath2 = "error";
            if (FileUpload2.PostedFile.ContentLength < 4194304)
            {
                filepath2 = Server.MapPath("/member/nvocc/") + Request.Cookies["user_id"].Value.ToString() + "_2.jpg";
            }
            else
            {
                MessageBox("", "一代资质图片超过4M，不能上传");
            }
        }

        if (FileUpload3.FileName.ToString() != "")
        {
            filepath3 = "error";
            if (FileUpload3.PostedFile.ContentLength < 4194304)
            {
                filepath3 = Server.MapPath("/member/nvocc/") + Request.Cookies["user_id"].Value.ToString() + "_3.jpg";
            }
            else
            {
                MessageBox("", "无船承运人NVOCC资质图片超过4M，不能上传");
            }
        }

        if (FileUpload4.FileName.ToString() != "")
        {
            filepath4 = "error";
            if (FileUpload4.PostedFile.ContentLength < 4194304)
            {
                filepath4 = Server.MapPath("/member/nvocc/") + Request.Cookies["user_id"].Value.ToString() + "_4.jpg";
            }
            else
            {
                MessageBox("", "身份证图片超过4M，不能上传");
            }
        }

        if (filepath1 != "error" && filepath2 != "error" && filepath3 != "error" && filepath4 != "error")
        {
            if (filepath1 != "")
            {
                FileUpload1.SaveAs(filepath1);
            }
            if (filepath2 != "")
            {
                FileUpload2.SaveAs(filepath2);
            }
            if (filepath3 != "")
            {
                FileUpload3.SaveAs(filepath3);
            }
            if (filepath4 != "")
            {
                FileUpload4.SaveAs(filepath4);
            }
            Response.Redirect("/accounts/regsuccess.aspx");
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
}
