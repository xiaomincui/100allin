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
using System.Text;
using System.Text.RegularExpressions;

public partial class club_repaste_repaste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        login login1 = new login();
        login1.login();
    }

    protected void submitbtn_ServerClick(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string sql = "";


        string surl = url2.Value.Trim();
        string vurl = "";

        if (surl.IndexOf("http://") == -1)
        {
            surl = "http://" + surl;
        }

        sql = "SELECT * FROM TB_REPASTE_VIDEO WHERE '" + check1.CheckRecord(surl) + "' LIKE '%' + vtag + '%'";

        ds = cn.mdb_ds(sql, "video");

        if (ds.Tables["video"].Rows.Count > 0)
        {

            string regexp1 = ds.Tables["video"].Rows[0]["surl"].ToString();
            string regexp2 = ds.Tables["video"].Rows[0]["durl"].ToString();

            Match TitleMatch = Regex.Match(surl, regexp1, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            string urlkey = TitleMatch.Groups[1].Value.ToString();
            if (urlkey != "")
            {
                vurl = Regex.Replace(regexp2, "urlkey", urlkey);
            }
            
        }


        sql = "INSERT INTO TB_REPASTE_TOPIC (topic,txt,userid,url) VALUES ('" + check1.CheckInput(title.Value) + "','" + vurl + "<br/>" + check1.CheckRecord(HiddenField1.Value) + "'," + u + ",'" + check1.CheckInput(url2.Value) + "'); SELECT @@identity ";

        ds1 = cn.mdb_ds(sql, "topic");

        string redirect_tid = ds1.Tables["topic"].Rows[0][0].ToString();//获得转贴主记录的id号

        sql = "INSERT INTO TB_REPASTE_REPASTE (tid,userid) VALUES ('" + ds1.Tables["topic"].Rows[0][0].ToString() + "'," + u + "); SELECT @@identity ";

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

        string[] udetail;
        AllinUser AllinUser1 = new AllinUser();
        udetail = AllinUser1.GetUserDetail(u);

        string uhomeid = udetail[10];

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

        if (Radio2.Checked == true)
        {
            sql = "";
            if (answer1.Value != "")
            {
                DataSet ds_v = new DataSet();
                sql = "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer1.Value) + "',1," + redirect_tid + ");SELECT @@identity ";
                ds_v = cn.mdb_ds(sql,"vote");
                sql = "INSERT INTO TB_REPASTE_VIEW (userid,tid,voteid) VALUES (" + u + "," + redirect_tid + "," + ds_v.Tables["vote"].Rows[0][0].ToString() + ");";
            }

            if (answer2.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer2.Value) + "',0," + redirect_tid + ");";
            }

            if (answer3.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer3.Value) + "',0," + redirect_tid + ");";
            }

            if (answer4.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer4.Value) + "',0," + redirect_tid + ");";
            }

            if (answer5.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer5.Value) + "',0," + redirect_tid + ");";
            }

            if (answer6.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer6.Value) + "',0," + redirect_tid + ");";
            }

            if (answer7.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer7.Value) + "',0," + redirect_tid + ");";
            }

            if (answer8.Value != "")
            {
                sql += "INSERT INTO TB_REPASTE_VOTE (txt,vcount,tid) VALUES ('" + check1.CheckInput(answer8.Value) + "',0," + redirect_tid + ");";
            }
            cn.mdb_exe(sql);
        }

        Response.Redirect("detail.aspx?rid=" + redirect_rid);

    }


    public string UnixTimestamp()
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        return timeStamp.Substring(0, timeStamp.Length - 7);
    }
}
