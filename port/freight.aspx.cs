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

public partial class port_freight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrBg.Text = Request.QueryString["port"].ToString();

        string[] city_array = new string[8];
        city_array[0] = "深圳,shenzhen,广东省-深圳市";
        city_array[1] = "上海,shanghai,上海市-上海市";
        city_array[2] = "青岛,qingdao,山东省-青岛市";
        city_array[3] = "天津,tianjin,天津市-天津市";
        city_array[4] = "宁波,ningbo,浙江省-宁波市";
        city_array[5] = "大连,dalian,辽宁省-大连市";
        city_array[6] = "广州,guangzhou,广东省-广州市";
        city_array[7] = "厦门,xiamen,福建省-厦门市";

        string[] LineHotArray = new string[10];
        LineHotArray[0] = "全部,0";
        LineHotArray[1] = "美加线,1";
        LineHotArray[2] = "欧地线,2";
        LineHotArray[3] = "中南美线,3";
        LineHotArray[4] = "日韩线,4";
        LineHotArray[5] = "近洋线,5";
        LineHotArray[6] = "非洲线,6";
        LineHotArray[7] = "澳洲线,7";
        LineHotArray[8] = "中东印巴线,8";
        LineHotArray[9] = "红海线,9";

        string port = "";
        string portch = "";
        string line = "";

        for (int i = 0; i < city_array.Length; i++)
        {
            if (city_array[i].Split(',')[1] == Request.QueryString["port"].ToString())
            {
                port = city_array[i].Split(',')[1];
                portch = city_array[i].Split(',')[0];
                ltrPort1.Text = portch;
                ltrPort2.Text = portch;
                ltrTitle.Text = portch;
                ltrKey.Text = "<meta name=\"keywords\" content=\"" + portch + "港\" />";

                ltrOther1.Text = port;
                ltrOther2.Text = port;
                ltrOther3.Text = port;
                ltrOther4.Text = port;
                ltrOther5.Text = port;
                ltrOther6.Text = port;
                ltrOther7.Text = port;
                ltrOther8.Text = port;
                ltrOther9.Text = port;

                ltrOther1c.Text = portch;
                ltrOther2c.Text = portch;
                ltrOther3c.Text = portch;
                ltrOther4c.Text = portch;
                ltrOther5c.Text = portch;
                ltrOther6c.Text = portch;
                ltrOther7c.Text = portch;
                ltrOther8c.Text = portch;
                ltrOther9c.Text = portch;
            }
        }

        line = LineHotArray[Convert.ToInt32(Request.QueryString["line"].ToString())].Split(',')[0];
        ltrLine1.Text = line;
        ltrLine2.Text = line;

        ltrDesc.Text = "<meta name=\"description\" content=\"" + ltrTitle.Text + "港至" + ltrLine2.Text + "各港口整箱运价查询，拼箱运价查询\" />";

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        sql = "";
        sql += "SELECT '<a href=\"/lcl/list-" + port + "-' + TB_City.CityName + '--" + LineHotArray[Convert.ToInt32(Request.QueryString["line"].ToString())].Split(',')[1] + "-0-0-----1.html\" target=\"_blank\">' + TB_City.CityName + '</a>' AS Portlink ";
        sql += "FROM TB_City INNER JOIN TB_YunJiaInfo ON TB_City.CityName = TB_YunJiaInfo.DestPort INNER JOIN TB_YunJia ON TB_YunJiaInfo.YunJiaID = TB_YunJia.id ";
        sql += "WHERE (TB_City.Line = '" + line + "') AND (TB_YunJia.StartPort LIKE '%" + port + "%' OR TB_YunJia.StartPort LIKE '%" + portch + "%') AND TB_YunJia.yunjialeixing = 9 ";
        sql += "GROUP BY TB_City.CityName ";
        sql += "ORDER BY TB_City.CityName ";


        ds = cn.mdb_ds(sql,"port");

        table1.DataSource = ds.Tables["port"].DefaultView;
        table1.DataBind();

        sql = "";
        sql += "SELECT '<a href=\"/fcl/list-" + port + "-' + TB_City.CityName + '--" + LineHotArray[Convert.ToInt32(Request.QueryString["line"].ToString())].Split(',')[1] + "-0-0-----1.html\" target=\"_blank\">' + TB_City.CityName + '</a>' AS Portlink ";
        sql += "FROM TB_City INNER JOIN TB_YunJiaInfo ON TB_City.CityName = TB_YunJiaInfo.DestPort INNER JOIN TB_YunJia ON TB_YunJiaInfo.YunJiaID = TB_YunJia.id ";
        sql += "WHERE (TB_City.Line = '" + line + "') AND (TB_YunJia.StartPort LIKE '%" + port + "%' OR TB_YunJia.StartPort LIKE '%" + portch + "%') AND TB_YunJia.yunjialeixing = 8 ";
        sql += "GROUP BY TB_City.CityName ";
        sql += "ORDER BY TB_City.CityName ";

        ds = cn.mdb_ds(sql, "port");

        table2.DataSource = ds.Tables["port"].DefaultView;
        table2.DataBind();

    }
}
