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

public partial class admin_userlist : System.Web.UI.Page
{
    protected void  Page_Load(object sender, EventArgs e)
{
        Page.Title = "傲赢网 - 我的办公室 - 整箱运价";



        check ck = new check();
        string a = ck.CheckNumber(this.Request["id"]);
        


        if (! Page.IsPostBack)
        {
            DataSet ds=trun(a);

            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Redirect("../search/err.aspx");
            }
            //try
            //{
            //    if((ds.Tables[0].Rows[0]["UserID2"].ToString() != Request.Cookies["user_id"].Value.ToString()) && (ds.Tables[0].Rows[0]["UserID"].ToString() != Request.Cookies["user_id"].Value.ToString()))
            //    {
            //        Response.Redirect("../search/err.aspx");
            //    }
            //}
            //catch(Exception t)
            //{
            //    Response.Redirect("../search/err.aspx");
            //}




            txtpostdate.Value = ds.Tables[0].Rows[0]["PostDate"].ToString().Split(' ')[0];
            TextBox16.Text = ds.Tables[0].Rows[0]["PostDate"].ToString().Split(' ')[1];
            

            TextBox1.Text = ds.Tables[0].Rows[0]["title"].ToString();

            txtenddate.Value = ds.Tables[0].Rows[0]["enddate"].ToString().Split(' ')[0];



            txtStartPost.Text = ds.Tables[0].Rows[0]["StartPort"].ToString();
            ddlhangxianmiaoshu.SelectedItem.Text = ds.Tables[0].Rows[0]["LINE"].ToString();
            txthit.Text = ds.Tables[0].Rows[0]["hits"].ToString();

            string memo  = ds.Tables[0].Rows[0]["memo"].ToString();
            memo = memo.Replace("<br>", "\r");
            memo = memo.Replace("&nbsp", " ");
            txtmemo.Text = memo;
            this.Hidden1.Value = ds.Tables[0].Rows[0]["UserID2"].ToString();
            


            AddStyleSheet(this.Page, "/css/list.css");
            GridView1.Attributes.Add("bordercolor ", "#D9D9D9");

            DataSet ds2;
            data_conn3 conn = new data_conn3();
            string sql;





            


            if (ds.Tables[0].Rows[0]["UserID2"].ToString() == "0" || ds.Tables[0].Rows[0]["UserID2"].ToString() == "")
            {
                sql = "select * from TB_User where UserID=" + ck.CheckNumber(ds.Tables[0].Rows[0]["UserID"].ToString());
            }
            else
            {
                sql = "select * from TB_User where UserID=" + ck.CheckNumber(ds.Tables[0].Rows[0]["UserID2"].ToString());

            }

            ds2 = conn.mdb_ds(sql, "table");
            txtname.Text = ds2.Tables["table"].Rows[0]["RealName"].ToString();
            txtCompanyName.Text = ds2.Tables["table"].Rows[0]["CompanyName"].ToString();
            txtAddress.Text = ds2.Tables["table"].Rows[0]["Address"].ToString();
            txtFax.Text = ds2.Tables["table"].Rows[0]["Fax"].ToString();
            txtMovePhone.Text = ds2.Tables["table"].Rows[0]["MovePhone"].ToString();
            txtPhone.Text = ds2.Tables["table"].Rows[0]["Phone"].ToString();
            txtPostNumber.Text = ds2.Tables["table"].Rows[0]["PostNumber"].ToString();
            txtUserEmail.Text = ds2.Tables["table"].Rows[0]["UserEmail"].ToString();


           ////判断是否为manager用户，是的话，显示选择用户按钮
           // DataSet ds3;
           // sql = "select * from TB_User where UserID=" + ck.CheckNumber(this.Request.Cookies["user_id"].Value.ToString());
           // ds3 = conn.mdb_ds(sql, "table");

            

            tt.InnerHtml = "<input type=\"button\" name=\"Submit\" value=\"选择用户\" onClick=\"javascript:window.open('../member/user_search1.asp','_blank','scrollbars=yes,width=420,height=600')\" id=\"Button2\" / >";
            this.Hidden1.Visible = true;
            




        }
}

    public DataSet trun(string id)
    {
        DataSet ds;
        string strSQL;
        strSQL = "select * from T_AIRINFO where id=" + id;
        data_conn3 tt=new data_conn3 ();
        ds = tt.mdb_ds(strSQL, "asdf");
        return ds;
    }


    protected void  Button1_Click1(object sender, EventArgs e)
    {
        check ck = new check();
        if (TextBox1.Text == "")
        {
            MessageBox("", "标题不能为空");
        }
        else if( txtenddate.Value == "")
        {
            MessageBox("", "有效日期不能为空");
        }
        else if(ddlhangxianmiaoshu.Text == "请选择")
        {
            MessageBox("", "请选择航线");
        }
        else if (txtStartPost.Text == "")
        {
            MessageBox("", "启运港不能为空");
        }
        else if (ck.CheckNumber1(this.txthit.Text) == "-1")
        {
            MessageBox("", "点击量不是数字");
        }
        else
        {
            
            string strSql;
            string meno = ck.CheckInput(txtmemo.Text);
            meno = meno.Replace("\r", "<br>");
            meno = meno.Replace(" ", "&nbsp");
            string time = txtpostdate.Value + " " + TextBox16.Text;
            data_conn3 data_conn = new data_conn3();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn = data_conn.mdb_conn();
             
            conn.Open();
            strSql = "update T_AIRINFO set title='" + ck.CheckInput(TextBox1.Text.Replace("'", "''")) + "',enddate='" + ck.CheckInput(txtenddate.Value.Replace("'", "''")) + "',StartPort='" + ck.CheckInput(txtStartPost.Text.Replace("'", "''")) + "',LINE='" + ck.CheckInput(ddlhangxianmiaoshu.Text.Replace("'", "''")) + "',memo='" + meno.Replace("'", "''") + "',PostDate='" + time.Replace("'", "''") + "',hits=" + this.txthit.Text + ",UserID2=" + this.Hidden1.Value + " where id=" + ck.CheckNumber(Request["id"]);
            System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSql, conn);


            myCommand.ExecuteNonQuery();
            //lblPostDate.Text = DateTime.Now.ToString();
            conn.Close();
            this.Response.Redirect("airlist.aspx");
        }
    }


    protected void  Button2_Click(object sender, EventArgs e)
    {
        if( TextBox4.Text == "")
        {
             MessageBox("", "目的港不能为空");
        }
        else
        {

            check ck = new check();
    
    
            string  strSql, value;

            data_conn3 data_conn = new  data_conn3 ();
            System.Data.SqlClient.SqlConnection conn=new System.Data.SqlClient.SqlConnection ();
            
            conn = data_conn.mdb_conn();
            conn.Open();

            value = ck.CheckNumber(Request["id"]) + ",'" + ck.CheckInput(TextBox4.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox5.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox6.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox7.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox8.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox9.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox10.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox11.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox12.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox13.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox14.Text.Replace("'", "''")) + "','" + ck.CheckInput(TextBox15.Text.Replace("'", "''")) + "'";
            strSql = "insert into T_AIRPRICE (AIRID,DestPort,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,price20gpAppend,Distance,departurewkd,memo) values (" + value + ")";

            
            System.Data.SqlClient.SqlCommand myCommand=new System.Data.SqlClient.SqlCommand (strSql, conn);
            

            myCommand.ExecuteNonQuery();
            conn.Close();
            GridView1.DataBind();
            if (this.GridView1.Rows.Count != 0)
            {
                this.head.Visible = false;
                this.GridView1.ShowHeader = true;


            }
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";
            this.TextBox10.Text = "";
            this.TextBox11.Text = "";
            this.TextBox12.Text = "";
            this.TextBox13.Text = "";
            this.TextBox14.Text = "";
            this.TextBox15.Text = "";
            updatePostDate();
        }
    }


    public void AddStyleSheet(Page page, string cssPath)
    {
        HtmlLink link = new HtmlLink();
        link.Href = cssPath;
        link.Attributes["rel"] = "stylesheet";
        link.Attributes["type"] = "text/css";
        page.Header.Controls.Add(link);
    }


    protected void  CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

        if (args.Value == "")
        {
            args.IsValid = false;
            MessageBox("", "目的港不能为空");
        }   
    }

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        this.GridView1.DataBind();
        if (this.GridView1.Rows.Count == 0)
        {
            this.head.Visible = true;
            this.GridView1.ShowHeader = false;
        }
        updatePostDate();
    }

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        updatePostDate();
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (this.GridView1.Rows.Count == 0)
        {
            this.head.Visible = true;
            this.GridView1.ShowHeader = false;
        }
        else
        {
            this.head.Visible = false;
            this.GridView1.ShowHeader = true;
        }
    }


    public void updatePostDate()
    {
        string  strSql;


        check ck = new check();
        data_conn3 data_conn = new  data_conn3 ();
        string time = txtpostdate.Value + " " + TextBox16.Text;
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        conn = data_conn.mdb_conn();
        conn.Open();
        strSql = "update T_AIRINFO set PostDate='" + time + "' where id=" + ck.CheckNumber(Request["id"]);
        System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSql, conn);
        myCommand.ExecuteNonQuery();
        conn.Close();
        //lblPostDate.Text = DateTime.Now.ToString();
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
