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

public partial class club_repaste_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Button1.Attributes.Add("onclick", "setSubmitButton('1');");
            check check1 = new check();
            GetRequest GetRequest1 = new GetRequest();
            string rid = "";
            rid = check1.CheckNumber(GetRequest1.GetRequestQueryString("rid", "1"));

            string u = "";
            u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";
            sql += "SELECT * FROM V_REPASTE_INDEX WHERE rid = " + rid + " ";
            ds = cn.mdb_ds(sql, "repaste");


            Literal1.Text = ds.Tables["repaste"].Rows[0]["topic"].ToString();
            Literal2.Text = ds.Tables["repaste"].Rows[0]["txt"].ToString();
            Literal3.Text = ds.Tables["repaste"].Rows[0]["realname1"].ToString();
            Literal4.Text = ds.Tables["repaste"].Rows[0]["ttime"].ToString();
            Literal5.Text = ds.Tables["repaste"].Rows[0]["repaste_count"].ToString();
            Literal6.Text = ds.Tables["repaste"].Rows[0]["hit_count"].ToString();

            Literal7.Text = "<a href=\"other.aspx?uid=" + ds.Tables["repaste"].Rows[0]["userid2"].ToString() + "\">" + ds.Tables["repaste"].Rows[0]["realname2"].ToString() + "的转帖</a>";

            if (ds.Tables["repaste"].Rows[0]["url"].ToString() != "")
            {
                Literal9.Text = "原贴网址：" + ds.Tables["repaste"].Rows[0]["url"].ToString();
            }


            //if (u == ds.Tables["repaste"].Rows[0]["userid2"].ToString() | u == ds.Tables["repaste"].Rows[0]["userid1"].ToString())
            //{
            //    LinkButton1.Visible = false;
            //}

            //Response.Write(u + "," + ds.Tables["repaste"].Rows[0]["userid2"].ToString());

            HiddenField1.Value = ds.Tables["repaste"].Rows[0]["tid"].ToString();

            if (u == ds.Tables["repaste"].Rows[0]["userid2"].ToString())
            {
                LinkButton2.Visible = true;
            }


            sql = "SELECT TOP 20 * FROM V_REPASTE_COMMIT WHERE tid = " + ds.Tables["repaste"].Rows[0]["tid"].ToString() + " ORDER BY cid DESC";

            ds = cn.mdb_ds(sql, "commit");
            Repeater1.DataSource = ds.Tables["commit"].DefaultView;
            Repeater1.DataBind();


            sql = "SELECT * FROM V_REPASTE_VOTE WHERE tid = " + HiddenField1.Value + " ORDER BY vcount DESC";

            ds = cn.mdb_ds(sql, "vote");
            Repeater2.DataSource = ds.Tables["vote"].DefaultView;
            Repeater2.DataBind();

            if (ds.Tables["vote"].Rows.Count > 0)
            {
                Literal8.Text = ds.Tables["vote"].Rows[0]["s"].ToString();
            }
            else
            {
                Literal8.Text = "0";
            }


            if (u == "0")
            {
                PlaceHolder1.Visible = false;
                PlaceHolder3.Visible = true;
                LinkButton1.Visible = false;
            }
            else
            {
                PlaceHolder1.Visible = true;
                PlaceHolder3.Visible = false;
            }

            sql = "SELECT * FROM V_REPASTE_VIEW WHERE tid = " + HiddenField1.Value + " ORDER BY vid DESC";

            ds = cn.mdb_ds(sql, "view");
            Repeater3.DataSource = ds.Tables["view"].DefaultView;
            Repeater3.DataBind();


            sql = "SELECT count(*) FROM TB_REPASTE_REPASTE WHERE tid = " + HiddenField1.Value;
            ds = cn.mdb_ds(sql, "repastecount");

            Literal5.Text = ds.Tables["repastecount"].Rows[0][0].ToString();

            sql = "UPDATE TB_REPASTE_TOPIC SET hit_count = hit_count + 1 WHERE tid = " + HiddenField1.Value;
            cn.mdb_exe(sql);

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();
        string rid = "";
        rid = check1.CheckNumber(GetRequest1.GetRequestQueryString("rid", "1"));

        string tid = "";
        tid = check1.CheckNumber(HiddenField1.Value);//tid在隐藏域内

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql += "INSERT INTO TB_REPASTE_COMMIT (txt,userid,tid) VALUES ('" + check1.CheckInput(TEXTAREA1.Value) + "'," + u + "," + tid + ");SELECT @@identity";
        ds = cn.mdb_ds(sql, "commit");

        Response.Redirect("detail.aspx?rid=" + rid + "#comment" + ds.Tables["commit"].Rows[0][0].ToString());
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        repaste();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        deleterepaste();
    }

    public string UnixTimestamp()
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        return timeStamp.Substring(0, timeStamp.Length - 7);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        if (u == "0")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您还未登录，不能发表观点');", true);
        }
        else
        {
            data_conn cn = new data_conn();
            string sql = "";
            sql = "UPDATE TB_REPASTE_VOTE SET vcount = vcount + 1 WHERE vid = " + HiddenField3.Value;

            sql += ";DELETE FROM TB_REPASTE_VIEW WHERE userid = " + u + " AND tid = " + HiddenField1.Value + ";INSERT INTO TB_REPASTE_VIEW (userid,tid,voteid) VALUES (" + u + "," + HiddenField1.Value + "," + HiddenField3.Value + ");";

            cn.mdb_exe(sql);

            sql = "SELECT * FROM V_REPASTE_VOTE WHERE tid = " + HiddenField1.Value + " ORDER BY vcount DESC";
            DataSet ds = new DataSet();

            ds = cn.mdb_ds(sql, "vote");
            Repeater2.DataSource = ds.Tables["vote"].DefaultView;
            Repeater2.DataBind();

            if (ds.Tables["vote"].Rows.Count > 0)
            {
                Literal8.Text = ds.Tables["vote"].Rows[0]["s"].ToString();
            }
            else
            {
                Literal8.Text = "0";
            }

            sql = "SELECT * FROM V_REPASTE_VIEW WHERE tid = " + HiddenField1.Value + " ORDER BY vid DESC";

            ds = cn.mdb_ds(sql, "view");
            Repeater3.DataSource = ds.Tables["view"].DefaultView;
            Repeater3.DataBind();

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "repasteConfirm();", true);
        }

    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        if (u == "0")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您还未登录，不能发表观点');", true);
        }
        else
        {
            data_conn cn = new data_conn();
            string sql = "";
            sql = "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(TextBox1.Text) + "',1," + HiddenField1.Value + ");SELECT @@identity;";
            DataSet ds_v = new DataSet();
            ds_v = cn.mdb_ds(sql,"vote");

            sql = "DELETE FROM TB_REPASTE_VIEW WHERE userid = " + u + " AND tid = " + HiddenField1.Value + ";INSERT INTO TB_REPASTE_VIEW (userid,tid,voteid) VALUES (" + u + "," + HiddenField1.Value + "," + ds_v.Tables["vote"].Rows[0][0].ToString() + ");";
            cn.mdb_exe(sql);

            sql = "SELECT * FROM V_REPASTE_VOTE WHERE tid = " + HiddenField1.Value + " ORDER BY vcount DESC";
            DataSet ds = new DataSet();

            ds = cn.mdb_ds(sql, "vote");
            Repeater2.DataSource = ds.Tables["vote"].DefaultView;
            Repeater2.DataBind();

            if (ds.Tables["vote"].Rows.Count > 0)
            {
                Literal8.Text = ds.Tables["vote"].Rows[0]["s"].ToString();
            }
            else
            {
                Literal8.Text = "0";
            }

            sql = "SELECT * FROM V_REPASTE_VIEW WHERE tid = " + HiddenField1.Value + " ORDER BY vid DESC";

            ds = cn.mdb_ds(sql, "view");
            Repeater3.DataSource = ds.Tables["view"].DefaultView;
            Repeater3.DataBind();

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "repasteConfirm();", true);
        }


    }//添加其它互动观点


    protected void Button4_Click(object sender, EventArgs e)
    {
        repaste();
    }//添加观点后转贴


    public void repaste()
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        string tid = "";
        tid = check1.CheckNumber(HiddenField1.Value);//tid在隐藏域内

        string[] udetail;
        AllinUser AllinUser1 = new AllinUser();
        udetail = AllinUser1.GetUserDetail(u);

        string uhomeid = udetail[10];

        data_conn cn = new data_conn();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string sql = "";

        sql = "INSERT INTO TB_REPASTE_REPASTE (tid,userid) VALUES ('" + tid + "'," + u + "); SELECT @@identity ";

        ds2 = cn.mdb_ds(sql, "paste");

        string redirect_rid = ds2.Tables["paste"].Rows[0][0].ToString();//获得转贴的id号


        sql = "SELECT TOP 4 * FROM V_REPASTE_INDEX WHERE userid2 = " + u + " ORDER BY rid DESC";

        ds2 = cn.mdb_ds(sql, "index");



        string body_template = "";

        for (int i = 0; i < ds2.Tables["index"].Rows.Count; i++)
        {
            body_template = body_template + "<a href=\"/club/repaste/detail.aspx?rid=" + ds2.Tables["index"].Rows[i]["rid"].ToString() + "\">" + check1.CheckRecord(ds2.Tables["index"].Rows[i]["topic"].ToString()) + "</a><br/>";
            if (i == ds2.Tables["index"].Rows.Count - 1)
            {
                body_template += "<div style=\"width:98%;text-align:right;\"><a href=\"/club/repaste/other.aspx?uid=" + u + "\">查看TA的全部转贴>></a></div>";
            }
        }

        mysqldata_conn mysqlcn = new mysqldata_conn();

        sql = "select uc_members.uid,uc_members.username,uchome_space.name from uc_members left join uchome_space on uc_members.uid = uchome_space.uid where uc_members.uid = " + uhomeid;

        ds2 = mysqlcn.mdb_ds(sql, "uc");

        string uhomename = "";

        if (ds2.Tables["uc"].Rows[0]["name"].ToString() == "")
        {
            uhomename = ds2.Tables["uc"].Rows[0]["username"].ToString();
        }
        else
        {
            uhomename = ds2.Tables["uc"].Rows[0]["name"].ToString();
        }

        sql = "DELETE FROM uchome_feed WHERE appid = 1 AND icon = 'repaste' AND uid = " + uhomeid + ";INSERT INTO uchome_feed (appid,icon,uid,username,dateline,friend,hash_data,title_template,body_template) VALUES (1,'repaste'," + uhomeid + ",'" + uhomename + "'," + UnixTimestamp() + ",0,'" + UnixTimestamp() + "','<b>{actor}</b> 转贴给大家','" + body_template + "')";

        //Response.Write(sql);
        mysqlcn.mdb_exe(sql);


        ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.GetType(), "提示", "alert('转贴成功');", true);
    }//转贴


    public void deleterepaste()
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        string tid = "";
        tid = check1.CheckNumber(HiddenField1.Value);//tid在隐藏域内

        string rid = "";
        rid = check1.CheckNumber(GetRequest1.GetRequestQueryString("rid", "1"));


        string[] udetail;
        AllinUser AllinUser1 = new AllinUser();
        udetail = AllinUser1.GetUserDetail(u);

        string uhomeid = udetail[10];


        data_conn cn = new data_conn();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string sql = "";

        sql = "DELETE FROM TB_REPASTE_REPASTE WHERE rid = " + rid;

        cn.mdb_exe(sql);

        ds2 = cn.mdb_ds(sql, "paste");


        sql = "SELECT TOP 4 * FROM V_REPASTE_INDEX WHERE userid2 = " + u + " ORDER BY rid DESC";

        ds2 = cn.mdb_ds(sql, "index");

        string body_template = "";

        for (int i = 0; i < ds2.Tables["index"].Rows.Count; i++)
        {
            body_template = body_template + "<a href=\"/club/repaste/detail.aspx?rid=" + ds2.Tables["index"].Rows[i]["rid"].ToString() + "\">" + check1.CheckRecord(ds2.Tables["index"].Rows[i]["topic"].ToString()) + "</a><br/>";
            if (i == ds2.Tables["index"].Rows.Count - 1)
            {
                body_template += "<div style=\"width:98%;text-align:right;\"><a href=\"/club/repaste/other.aspx?uid=" + u + "\">查看TA的全部转贴>></a></div>";
            }
        }
        


        mysqldata_conn mysqlcn = new mysqldata_conn();

        sql = "select uc_members.uid,uc_members.username,uchome_space.name from uc_members left join uchome_space on uc_members.uid = uchome_space.uid where uc_members.uid = " + uhomeid;

        ds2 = mysqlcn.mdb_ds(sql, "uc");

        string uhomename = "";

        if (ds2.Tables["uc"].Rows[0]["name"].ToString() == "")
        {
            uhomename = ds2.Tables["uc"].Rows[0]["username"].ToString();
        }
        else
        {
            uhomename = ds2.Tables["uc"].Rows[0]["name"].ToString();
        }

        sql = "UPDATE uchome_feed SET body_template = '" + body_template + "' WHERE appid = 1 AND icon = 'repaste' AND uid = " + uhomeid + " ";

        //Response.Write(sql);
        mysqlcn.mdb_exe(sql);

        Response.Redirect("index.aspx?tip=delete");
    }//转贴

}
