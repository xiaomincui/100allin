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

public partial class manage_user_adduser : System.Web.UI.Page
{
    public check ck = new check();
    public GetRequest GetRequest1 = new GetRequest();
    public string lid = "";
    public string userid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            userid = ck.CheckNumber(GetRequest1.GetRequestQueryString("id", "0"));


            if (userid != "0")
            {
                LoadRecord(userid);
            }
        }



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        userid = ck.CheckNumber(GetRequest1.GetRequestQueryString("id", "0"));

        string star_allin = ck.CheckInput(rbl_star_allin.SelectedValue); //输入方式

        string z_yingyezhizhao = "0";
        if (cb_z_yingyezhizhao.Checked == true)
        {
            z_yingyezhizhao = "1";
        }

        string z_shenfenzheng = "0";
        if (cb_z_shenfenzheng.Checked == true)
        {
            z_shenfenzheng = "1";
        }

        string z_nvocc = "0";
        if (cb_z_nvocc.Checked == true)
        {
            z_nvocc = "1";
        }

        string z_kongyuntongpai = "0";
        if (cb_z_kongyuntongpai.Checked == true)
        {
            z_kongyuntongpai = "1";
        }


        System.Threading.Thread.Sleep(1000);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        if (userid != "0")
        {
            sql = sql + "UPDATE TB_USER SET ";
            sql = sql + "star_allin = " + star_allin + ", ";
            sql = sql + "z_yingyezhizhao = '" + z_yingyezhizhao + "', ";
            sql = sql + "z_shenfenzheng = " + z_shenfenzheng + ", ";
            sql = sql + "z_nvocc = " + z_nvocc + ", ";
            sql = sql + "z_kongyuntongpai = " + z_kongyuntongpai + " ";
            sql = sql + "WHERE userid = " + userid + " ";

            cn.mdb_exe(sql);
            //Literal1.Text = sql;
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('编辑成功！');", true);
        }

    }

    protected void LoadRecord(string userid)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        //sql = "SELECT realname,companyname,phone,movephone,star_allin,z_yingyezhizhao,z_shenfenzheng,z_nvocc,z_kongyuntongpai FROM TB_USER WHERE userid = " + userid + " AND Regtime > '2010-4-15 0:00:00' ";
        sql = "SELECT CompanyType,realname,companyname,phone,movephone,star_allin,z_yingyezhizhao,z_shenfenzheng,z_nvocc,z_kongyuntongpai FROM TB_USER WHERE userid = " + userid + "";

        


        ds = cn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            GetRequest GetRequest1 = new GetRequest();
            if (GetRequest1.GetRequestCookies("admin_group", "3") == "3" || ds.Tables["user"].Rows[0]["CompanyType"].ToString() == "1")
            {
                Response.Redirect("userlist.aspx");
            }


            ltrRealname.Text = ds.Tables["user"].Rows[0]["realname"].ToString();
            ltrCompanyName.Text = ds.Tables["user"].Rows[0]["companyname"].ToString();
            ltrPhone.Text = ds.Tables["user"].Rows[0]["phone"].ToString();
            ltrMovephone.Text = ds.Tables["user"].Rows[0]["movephone"].ToString();
            rbl_star_allin.SelectedValue = ds.Tables["user"].Rows[0]["star_allin"].ToString();

            if (ds.Tables["user"].Rows[0]["z_yingyezhizhao"].ToString() == "1")
            {
                cb_z_yingyezhizhao.Checked = true;
            }
            if (ds.Tables["user"].Rows[0]["z_shenfenzheng"].ToString() == "1")
            {
                cb_z_shenfenzheng.Checked = true;
            }
            if (ds.Tables["user"].Rows[0]["z_nvocc"].ToString() == "1")
            {
                cb_z_nvocc.Checked = true;
            }
            if (ds.Tables["user"].Rows[0]["z_kongyuntongpai"].ToString() == "1")
            {
                cb_z_kongyuntongpai.Checked = true;
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('没有此记录！');", true);
        }
    }
}
