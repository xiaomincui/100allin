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

public partial class products_buy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetRequest GetRequest1 = new GetRequest();
            string type = "0";
            type = GetRequest1.GetRequestQueryString("type", "0");

            if (type == "1")
            {
                CheckBox1.Checked = true;
            }

            //Response.Write("11");
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        check check1 = new check();


        string pro1 = check1.CheckInput(CheckBox1.Checked == true ? "1" : "0");
        //Response.Write(pro1 + ":" + pro2 + ":" + pro3 + ":" +pro4);


        string userid = check1.CheckInput(GetRequest1.GetRequestQueryString("user_id", "0"));
        string companyname = check1.CheckInput(TextBox1.Text);
        string realname = check1.CheckInput(TextBox2.Text);
        string gender = RadioButtonList1.SelectedValue;
        string rank = check1.CheckInput(TextBox3.Text);
        string phone = check1.CheckInput(TextBox4.Text + "-" + TextBox7.Text + "-" + TextBox8.Text);
        string movephone = check1.CheckInput(TextBox5.Text);
        string useremail = check1.CheckInput(TextBox6.Text);


        if (pro1 == "0")
        {
            MessageBox("", "您好！请至少选择一件产品");
        }
        else
        {
            if (companyname == "" | realname == "" | gender == "" | rank == "" | TextBox7.Text == "" | TextBox8.Text == "" | movephone == "" | useremail == "")
            {
                MessageBox("", "您好！请将表格填写完整");
            }
            else
            {
                data_conn cn = new data_conn();
                string sql = "";
                sql += "INSERT INTO TB_PRODUCTS_APPLY ";
                sql += "(";
                sql += "pro7,";
                sql += "userid,";
                sql += "companyname,";
                sql += "realname,";
                sql += "gender,";
                sql += "rank,";
                sql += "phone,";
                sql += "movephone,";
                sql += "useremail ";
                sql += ") VALUES (";
                sql += "" + pro1 + ",";
                sql += "" + userid + ",";
                sql += "'" + companyname + "',";
                sql += "'" + realname + "',";
                sql += "'" + gender + "',";
                sql += "'" + rank + "',";
                sql += "'" + phone + "',";
                sql += "'" + movephone + "',";
                sql += "'" + useremail + "' ";
                sql += ")";

                cn.mdb_exe(sql);
                Response.Redirect("success.aspx");
            }
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
