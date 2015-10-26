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

public partial class topic_carrier090630_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LoadMessage();
        }
        catch
        { 
        
        }
    }

    protected void LoadMessage() 
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = "select top 20 TB_Message_Comment.id,TB_Message_Comment.UserID,TB_User.Realname,TB_Message_Comment.PostDate,TB_Message_Comment.EditDate,TB_Message_Comment.Data,TB_Message_Reply.Data as ReplyData,TB_Message_Reply.PostDate as ReplyPostDate,TB_Message_Comment.goodbad from TB_Message_Comment,TB_User,TB_Message_Reply where TB_Message_Comment.type=20090630 and TB_Message_Comment.UserID*=TB_User.UserID and TB_Message_Comment.id*=TB_Message_Reply.MessageID ORDER BY TB_Message_Comment.PostDate DESC";

        DataSet ds = new DataSet();
        ds = cn.mdb_ds(sql, "BBS");
        RptComment.DataSource = ds.Tables["BBS"].DefaultView;
        RptComment.DataBind();
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            string userid = "0";
            string message = "";
            if (TextBox1.Value.Length > 200)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('评论内容不能大于200字')", true);
            }
            else
            {
                check ck = new check();
                message = ck.CheckInput(TextBox1.Value);

                if (TextBox1.Value == "想发表自己的看法吗？写在这里吧。")
                {
                    message = "";
                }


                if (CheckBox1.Checked == true)
                {
                    userid = "0";
                }
                else
                {
                    if (Request.Cookies["user_id"] == null)
                    {
                        userid = "0";
                    }
                    else
                    {
                        if (Request.Cookies["user_id"].Value.ToString() == "")
                        {
                            userid = "0";
                        }
                        else
                        {
                            userid = Request.Cookies["user_id"].Value.ToString();
                        }
                    }
                }
                data_conn cn = new data_conn();
                DataSet ds = new DataSet();
                string sql = "";
                sql = "insert into TB_Message_Comment (UserID,PostDate,Data,type,BBSID,issuer,goodbad) values (" + userid + ",getdate(),'" + message + "',20090630," + "0,0," + RadioButtonList1.SelectedItem.Value + ")";

                //TextBox1.Value = sql;
                //ds = cn.mdb_ds(sql, "BBS");
                LoadMessage();
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('评论发布成功！')", true);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "movepos();", true);
                TextBox1.Value = "";
            }
        }
        catch
        { 
        
        }

    }
}
