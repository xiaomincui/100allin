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

public partial class member_useredit1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //displayDiv();
            GetUserInfo();
        }

    }

    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (Request.Cookies[c] != null)
        {
            if (Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = Request.Cookies[c].Value.ToString();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    public void GetUserInfo()
    {

        check ck = new check();
        string id = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + id, "user");



        TextBox1.Text = ds.Tables["user"].Rows[0]["introduction"].ToString();


    }












    protected void Button8_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();


        if (FileUpload1.FileName.ToString() != "")
        {

            if (FileUpload1.FileName.ToString().Substring(FileUpload1.FileName.ToString().Length - 4, 4) != ".jpg" && FileUpload1.FileName.ToString().Substring(FileUpload1.FileName.ToString().Length - 4, 4) != ".bmp" && FileUpload1.FileName.ToString().Substring(FileUpload1.FileName.ToString().Length - 4, 4) != ".JPG" && FileUpload1.FileName.ToString().Substring(FileUpload1.FileName.ToString().Length - 4, 4) != ".BMP")
            {
                MessageBox("公司照片格式错误", "公司照片格式错误");
                return;
            }
            string filepath;
            filepath = Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + "(old).jpg";
            FileUpload1.SaveAs(filepath);
            ThumbnailImage thumbnailimage = new ThumbnailImage();
            thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + ".jpg", 256, 256);

            cn.mdb_exe("update TB_User set Login2_Head=1 where UserId=" + Request.Cookies["user_id"].Value.ToString());
        }




        if (FileUpload2.FileName.ToString() != "")
        {

            if (FileUpload2.FileName.ToString().Substring(FileUpload2.FileName.ToString().Length - 4, 4) != ".jpg" && FileUpload2.FileName.ToString().Substring(FileUpload2.FileName.ToString().Length - 4, 4) != ".bmp")
            {
                MessageBox("个人头像格式错误", "个人头像格式错误");
                return;
            }
            string filepath;
            filepath = Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + "(old).jpg";
            FileUpload2.SaveAs(filepath);
            ThumbnailImage thumbnailimage = new ThumbnailImage();
            thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + ".jpg", 256, 256);

            cn.mdb_exe("update TB_User set HeadURL=1 where UserId=" + Request.Cookies["user_id"].Value.ToString());
        }


        string sql = "update TB_User set sign='" + TextBox1.Text + "',User_Level=2 where UserID=" + this.Request.Cookies["user_id"].Value.ToString();
        cn.mdb_exe(sql);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert('修改成功');window.location.href='useredit1.aspx'", true);
        //this.Response.Redirect("useredit1.aspx");
        //displayDiv();
    }
}
