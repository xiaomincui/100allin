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

public partial class poll_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (this.Request.Cookies["user_id"] == null)
        {

            
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {

            }
            else
            {
                data_conn cn = new data_conn();
                DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies["user_id"].Value.ToString() + "", "user");
                username.Value = ds.Tables["user"].Rows[0]["UserName"].ToString();
                Email.Value = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        if (this.Request.Cookies["vote"] == null)
        {

            if (RadioButtonList1.SelectedValue != "" && RadioButtonList2.SelectedValue != "" && RadioButtonList3.SelectedValue != "" && RadioButtonList4.SelectedValue != "" && RadioButtonList5.SelectedValue != "")
            {
                Response.Cookies["vote"].Value = "1";
                Response.Cookies["vote"].Expires = DateTime.Now.AddDays(365);
                data_conn cn = new data_conn();
                string sql = "insert into TB_Poll (choice_1,choice_2,choice_3,choice_4,choice_5,advice,Username,Email) values (" + RadioButtonList1.SelectedValue + "," + RadioButtonList2.SelectedValue + "," + RadioButtonList3.SelectedValue + "," + RadioButtonList4.SelectedValue + "," + RadioButtonList5.SelectedValue + ",'" + advice.Value + "','" + username.Value + "','" + Email.Value + "')";
                cn.mdb_exe(sql);
                
                
                Response.Redirect("VoteReturn.aspx");
            }
            else
            {
                MessageBox("对不起，您有选项未选择", "对不起，您有选项未选择");
            }
        }
        else
        {
            if (this.Request.Cookies["vote"].Value.ToString() == "")
            {
                if (RadioButtonList1.SelectedValue != "" && RadioButtonList2.SelectedValue != "" && RadioButtonList3.SelectedValue != "" && RadioButtonList4.SelectedValue != "" && RadioButtonList5.SelectedValue != "")
                {
                    Response.Cookies["vote"].Value = "1";
                    Response.Cookies["vote"].Expires = DateTime.Now.AddDays(365);
                    data_conn cn = new data_conn();
                    string sql = "insert into TB_Poll (choice_1,choice_2,choice_3,choice_4,choice_5,advice,Username,Email) values (" + RadioButtonList1.SelectedValue + "," + RadioButtonList2.SelectedValue + "," + RadioButtonList3.SelectedValue + "," + RadioButtonList4.SelectedValue + "," + RadioButtonList5.SelectedValue + ",'" + advice.Value + "','" + username.Value + "','" + Email.Value + "')";
                    cn.mdb_exe(sql);

                    Response.Redirect("VoteReturn.aspx");
                }
                else
                {
                    MessageBox("对不起，您有选项未选择", "对不起，您有选项未选择");
                }
            }
            else
            {
               
                Confirm("", "您已经投过票了，是否要查看投票结果");

            }

            
        }



        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("VoteReturn.aspx");
    }

    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected void Confirm(string strKey, string strInfo)
    {
        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {

            string strjs = "if(!confirm('" + strInfo + "')) { window.close();}else{window.location.href='VoteReturn.aspx';}";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }
}
