using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ttt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] LineHotArray = new string[10];
        LineHotArray[0] = "全部,0";
        LineHotArray[1] = "美加线,1";
        LineHotArray[2] = "非洲线,6";
        LineHotArray[3] = "中东印巴线,8";
        LineHotArray[4] = "中南美线,3";
        LineHotArray[5] = "欧地线,2";
        LineHotArray[6] = "日韩线,4";
        LineHotArray[7] = "近洋线,5";
        LineHotArray[8] = "澳洲线,7";
        LineHotArray[9] = "红海线,9";


        string[] city_array = new string[8];
        city_array[0] = "深圳,shenzhen,广东省-深圳市";
        city_array[1] = "上海,shanghai,上海市-上海市";
        city_array[2] = "青岛,qingdao,山东省-青岛市";
        city_array[3] = "天津,tianjin,天津市-天津市";
        city_array[4] = "宁波,ningbo,浙江省-宁波市";
        city_array[5] = "大连,dalian,辽宁省-大连市";
        city_array[6] = "广州,guangzhou,广东省-广州市";
        city_array[7] = "厦门,xiamen,福建省-厦门市";


        string[] typelist = new string[18];
        typelist[0] = "美加线,8,meijia_fcl,fcl,1";
        typelist[1] = "美加线,9,meijia_lcl,lcl,1";
        typelist[2] = "欧地线,8,oudi_fcl,fcl,2";
        typelist[3] = "欧地线,9,oudi_lcl,lcl,2";
        typelist[4] = "中南美线,8,zhongnanmei_fcl,fcl,3";
        typelist[5] = "中南美线,9,zhongnanmei_lcl,lcl,3";
        typelist[6] = "日韩线,8,rihan_fcl,fcl,4";
        typelist[7] = "日韩线,9,rihan_lcl,lcl,4";
        typelist[8] = "近洋线,8,jinyang_fcl,fcl,5";
        typelist[9] = "近洋线,9,jinyang_lcl,lcl,5";
        typelist[10] = "非洲线,8,feizhou_fcl,fcl,6";
        typelist[11] = "非洲线,9,feizhou_lcl,lcl,6";
        typelist[12] = "澳洲线,8,aozhou_fcl,fcl,7";
        typelist[13] = "澳洲线,9,aozhou_lcl,lcl,7";
        typelist[14] = "中东印巴线,8,yinba_fcl,fcl,8";
        typelist[15] = "中东印巴线,9,yinba_lcl,lcl,8";
        typelist[16] = "红海线,8,honghai_fcl,fcl,9";
        typelist[17] = "红海线,9,honghai_lcl,lcl,9";

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        for (int i = 0; i < typelist.Length; i++)
        {
            Response.Write("string[] " + typelist[i].Split(',')[2] + " = new string[8];");
            Response.Write("<br/>");
            for (int j = 0; j < city_array.Length; j++)
            {
                string sqllist = "";
                sqllist = "";
                sqllist += "SELECT TOP 10 '<a href=\\\"/" + typelist[i].Split(',')[3] + "/list-" + city_array[j].Split(',')[1] + "-' + TB_YunJiaInfo.DestPort + '--" + typelist[i].Split(',')[4] + "-0-0-----1.html\\\" target=\\\"_blank\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
                sqllist += "FROM TB_YunJia INNER JOIN ";
                sqllist += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
                sqllist += "WHERE (TB_YunJia.StartPort LIKE '%" + city_array[j].Split(',')[0] + "%' OR ";
                sqllist += "TB_YunJia.StartPort LIKE '%" + city_array[j].Split(',')[1] + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
                sqllist += "(TB_YunJia.hangxianmiaoshu = '" + typelist[i].Split(',')[0] + "') AND (TB_YunJia.yunjialeixing = " + typelist[i].Split(',')[1] + ") ";
                sqllist += "GROUP BY TB_YunJiaInfo.DestPort ";
                sqllist += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

                ds = cn.mdb_ds(sqllist, "port");

                string str = "";

                for (int k = 0; k < ds.Tables["port"].Rows.Count; k++)
                {
                    str = str + ds.Tables["port"].Rows[k]["PortLink"].ToString() + " ";
                }

                str = str + "<a href=\\\"/port/" + city_array[j].Split(',')[1] + "/freight/" + typelist[i].Split(',')[4] + "/\\\" target=\\\"_blank\\\">[更多]</a>";

                str = Server.HtmlEncode(str);

                Response.Write("" + typelist[i].Split(',')[2] + "[" + j.ToString() + "] = \"" + str + "\";");                

                Response.Write("<br/>");
            }

            Response.Write("<br/>");
            




        }

        




        //string city = "";
        //string citych = "";

        //for (int i = 0; i < city_array.Length; i++)
        //{
        //    if (city_array[i].Split(',')[1] == Request.QueryString["port"].ToString())
        //    {
        //        city = city_array[i].Split(',')[1];
        //        citych = city_array[i].Split(',')[0];
        //    }
        //}



        //data_conn cn = new data_conn();
        //DataSet ds = new DataSet();

        
        //string sql = "";

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--1-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '美加线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater1.DataSource = ds.Tables["port"].DefaultView;
        //Repeater1.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--1-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '美加线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater2.DataSource = ds.Tables["port"].DefaultView;
        //Repeater2.DataBind();



        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--2-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '欧地线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater3.DataSource = ds.Tables["port"].DefaultView;
        //Repeater3.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--2-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '欧地线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater4.DataSource = ds.Tables["port"].DefaultView;
        //Repeater4.DataBind();


        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--3-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '中南美线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater5.DataSource = ds.Tables["port"].DefaultView;
        //Repeater5.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--3-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '中南美线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater6.DataSource = ds.Tables["port"].DefaultView;
        //Repeater6.DataBind();


        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--4-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '日韩线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater7.DataSource = ds.Tables["port"].DefaultView;
        //Repeater7.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--4-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '日韩线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater8.DataSource = ds.Tables["port"].DefaultView;
        //Repeater8.DataBind();



        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--5-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '近洋线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater9.DataSource = ds.Tables["port"].DefaultView;
        //Repeater9.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--5-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '近洋线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater10.DataSource = ds.Tables["port"].DefaultView;
        //Repeater10.DataBind();


        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--6-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '非洲线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater11.DataSource = ds.Tables["port"].DefaultView;
        //Repeater11.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--6-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '非洲线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater12.DataSource = ds.Tables["port"].DefaultView;
        //Repeater12.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--7-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '澳洲线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater13.DataSource = ds.Tables["port"].DefaultView;
        //Repeater13.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--7-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '澳洲线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater14.DataSource = ds.Tables["port"].DefaultView;
        //Repeater14.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--8-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '中东印巴线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater15.DataSource = ds.Tables["port"].DefaultView;
        //Repeater15.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--8-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '中东印巴线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater16.DataSource = ds.Tables["port"].DefaultView;
        //Repeater16.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/fcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--9-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '红海线') AND (TB_YunJia.yunjialeixing = 8) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater17.DataSource = ds.Tables["port"].DefaultView;
        //Repeater17.DataBind();

        //sql = "";
        //sql += "SELECT TOP 10 '<a href=\\\"/lcl/list-" + city + "-' + TB_YunJiaInfo.DestPort + '--9-0-0-----1.html\\\">' + TB_YunJiaInfo.DestPort + '</a>' AS PortLink, COUNT(TB_YunJiaInfo.DestPort) AS c ";
        //sql += "FROM TB_YunJia INNER JOIN ";
        //sql += "TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID ";
        //sql += "WHERE (TB_YunJia.StartPort LIKE '%" + citych + "%' OR ";
        //sql += "TB_YunJia.StartPort LIKE '%" + city + "%') AND (TB_YunJiaInfo.DestPort <> '') AND ";
        //sql += "(TB_YunJia.hangxianmiaoshu = '红海线') AND (TB_YunJia.yunjialeixing = 9) ";
        //sql += "GROUP BY TB_YunJiaInfo.DestPort ";
        //sql += "ORDER BY c DESC, TB_YunJiaInfo.DestPort ";

        //ds = cn.mdb_ds(sql, "port");

        //Repeater18.DataSource = ds.Tables["port"].DefaultView;
        //Repeater18.DataBind();
    }
}
