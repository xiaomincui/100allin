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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class PostBack_Port : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //定义个字符串用保存从数据库返回的数据
        string aa = "";
        //先清空输出的东西
        Response.Clear();
        string strArgument = Pagebase.Get("action");
        if (strArgument == "")
        {
            strArgument = Pagebase.Post("action");
        }
        if (strArgument != null && strArgument != "")
        {
            switch (strArgument)
            {
                case "GetProt":
                    if (Regex.IsMatch(Pagebase.Get("tar").Trim(), @"^\d+$") == true) { } else {aa = "输入有误！请重新输入！"; return; }/*防止Javascript注入攻击*/
                    string pos = Pagebase.Get("obj");
                    SqlDataReader sdr = null;
                    string tar = "", strSQL = ""; ;
                    if (pos == "txtStartport")
                    {
                        tar = Pagebase.jiemi(Pagebase.Get("tar"));
                        strSQL = "SELECT [CityName],[CityNameCH] FROM [dbo].[TB_CHINACITY] WHERE (CityName LIKE N'" + tar + "%') or (CityNameCH LIKE N'" + tar + "%')  ORDER BY CityName";
                        sdr = GetData.GetReaders(strSQL);
                        aa += "[";
                        while (sdr.Read())
                        {
                            aa += "{\"CN\":\"" + sdr["CityName"].ToString() + "\", \"CNCH\":\"" + sdr["CityNameCH"].ToString() + "\"},";
                        }
                        aa += "{}]";
                        sdr.Dispose();
                    }
                    if (pos == "txtDestport")
                    {
                        tar = Pagebase.jiemi(Pagebase.Get("tar"));
                        strSQL = "SELECT CityName, CityNameCH, Country, CountryCH FROM dbo.TB_City WHERE (CityName LIKE N'" + tar + "%') OR (CityNameCH LIKE N'" + tar + "%') ORDER BY CityName";
                        sdr = GetData.GetReaders(strSQL);
                        aa += "[";
                        while (sdr.Read())
                        {
                            aa += "{\"CN\":\"" + sdr["CityName"].ToString() + "\", \"CNCH\":\"" + sdr["CityNameCH"].ToString();
                            aa += "\", \"Country\":\"" + sdr["Country"].ToString() + "\", \"CountryCH\":\"" + sdr["CountryCH"].ToString() + "\"},";
                        }
                        aa += "{}]";
                        sdr.Dispose();
                    }
                    break;
                default:
                    break;
            }
        }
        //把从数据库得到的信息输出到客户端
        Response.Write(aa);
        //输出完成关闭Response,以免造成不必要的输出
        Response.Flush();
        Response.Close();
    }
}
