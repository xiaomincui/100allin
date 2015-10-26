using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;


public partial class news_newsjson : System.Web.UI.Page
{
    private string resultType = "json";
    protected void Page_Load(object sender, EventArgs e)
    {
        //获取请求的参数  
        if (!String.IsNullOrEmpty(Request.QueryString["resultType"]))
        {

            resultType = Request.QueryString["resultType"].ToLower() == "html" ? "html" : "json";
        }
        string html = GetResult(resultType);

        //清空缓冲区  
        Response.Clear();
        //将字符串写入响应输出流  
        Response.Write(html);
        //将当前所有缓冲的输出发送的客户端，并停止该页执行  
        Response.End();
    }

    private string GetResult(string resultType)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string p = "2";

        if (!String.IsNullOrEmpty(Request.QueryString["page"]))
        {
            p = ck.CheckInput(Request.QueryString["page"].ToString());
        }

        int ps = (Convert.ToInt32(p) - 1) * 10;

        string sql = "";
        sql = "SELECT TOP 10 * ";
        sql += "FROM ";
        sql += "( ";
        sql += "SELECT * FROM TB_BBS ";
        sql += "WHERE TYPES = 5";
        sql += ") AS T ";
        sql += "WHERE id NOT IN ";
        sql += "(SELECT TOP " + ps.ToString() + " id ";
        sql += "FROM ";
        sql += "TB_BBS ";
        sql += "WHERE TYPES = 5";
        sql += "ORDER BY id DESC ";
        sql += ") ";
        sql += "ORDER BY id DESC ";

        ds = cn.mdb_ds(sql, "news");
        Response.Write(sql);

        string result = "";
        if (resultType == "html")
        {

            //返回的html  
            result = @"<ul><li id=""1"">1</li><li id=""2"">2</li></ul>";
        }
        else if (resultType == "json")
        {
            //返回的json数据  
            result = @"[
";
            for (int i = 0; i < ds.Tables["news"].Rows.Count; i++)
            {
                result += @"{""id"":""" + ds.Tables["news"].Rows[i]["id"].ToString() + @"""";
                result += @",";
                result += @"""postdate"":""" + Convert.ToDateTime(ds.Tables["news"].Rows[i]["postdate"].ToString()).ToString("yyyy年M月d日") + @"""";
                result += @",";
                result += @"""title"":""" + ds.Tables["news"].Rows[i]["title"].ToString() + @"""";
                result += @",";
                result += @"""content"":""" + InputText(GetContentSummary(ds.Tables["news"].Rows[i]["data"].ToString(), 500, false)) + @"""";
                //result += @"""content"":""" + GetJsonString(ds.Tables["news"].Rows[i]["data"].ToString()) + @"""";
                //result += @"""content"":""……<span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span><span style=\""font-size:14px;\""></span>""";
                result += @"}";
                if (i < ds.Tables["news"].Rows.Count - 1)
                {
                    result += @",";
                }
                result += @"  
";      
            }
            result += @"]";            
//            result +=@"{""pkid"":""0001"",""ProvinceId"":""BJ"",""CityName"":""北京"",""CityNameEn"":""Beijing"",""PostCode"":""010"",""isHotCity"":false},  
// {""pkid"":""0002"",""ProvinceId"":""TJ"",""CityName"":""天津"",""CityNameEn"":""Tianjin"",""PostCode"":""022"",""isHotCity"":false}]";

        }
        return result;
    }

    public static string GetContentSummary(string content, int length, bool StripHTML)
    {
        if (string.IsNullOrEmpty(content) || length == 0)
            return "";
        if (StripHTML)
        {
            Regex re = new Regex("<[^>]*>");
            content = re.Replace(content, "");
            content = content.Replace("　", "").Replace(" ", "");
            if (content.Length <= length)
                return content;
            else
                return content.Substring(0, length) + "……";
        }
        else
        {
            if (content.Length <= length)
                return content;

            int pos = 0, npos = 0, size = 0;
            bool firststop = false, notr = false, noli = false;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                if (pos >= content.Length)
                    break;
                string cur = content.Substring(pos, 1);
                if (cur == "<")
                {
                    string next = content.Substring(pos + 1, 3).ToLower();
                    if (next.IndexOf("p") == 0 && next.IndexOf("pre") != 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                    }
                    else if (next.IndexOf("/p") == 0 && next.IndexOf("/pr") != 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                            sb.Append("<br/>");
                    }
                    else if (next.IndexOf("br") == 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                            sb.Append("<br/>");
                    }
                    else if (next.IndexOf("img") == 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                        {
                            sb.Append(content.Substring(pos, npos - pos));
                            size += npos - pos + 1;
                        }
                    }
                    else if (next.IndexOf("li") == 0 || next.IndexOf("/li") == 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                        {
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        else
                        {
                            if (!noli && next.IndexOf("/li") == 0)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                                noli = true;
                            }
                        }
                    }
                    else if (next.IndexOf("tr") == 0 || next.IndexOf("/tr") == 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                        {
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        else
                        {
                            if (!notr && next.IndexOf("/tr") == 0)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                                notr = true;
                            }
                        }
                    }
                    else if (next.IndexOf("td") == 0 || next.IndexOf("/td") == 0)
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        if (size < length)
                        {
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        else
                        {
                            if (!notr)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                        }
                    }
                    else
                    {
                        npos = content.IndexOf(">", pos) + 1;
                        sb.Append(content.Substring(pos, npos - pos));
                    }
                    if (npos <= pos)
                        npos = pos + 1;
                    pos = npos;
                }
                else
                {
                    if (size < length)
                    {
                        sb.Append(cur);
                        size++;
                    }
                    else
                    {
                        if (!firststop)
                        {
                            sb.Append("……");
                            firststop = true;
                        }
                    }
                    pos++;
                }

            }
            return sb.ToString();
        }
    }

    public static string GetJsonString(string content)
    {
        string s = "";
        s = content;
        s = s.Replace("\"", "\\\"");
        s = s.Replace("\r\n", "<br>");
        s = s.Replace("\0", "");
        //s = s.Replace("<","&lt;");
        //s = s.Replace(">", "&gt;");
        return s;
    }


    public static string InputText(string text)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        text = Regex.Replace(text, "[\\s]{2,}", "");    //two or more spaces
        //text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);    //any other tags
        text = text.Replace("\"", "\\\"");
        text = text.Replace("\r\n", "<br>");
        text = text.Replace("\n", "<br>");
        text = text.Replace("\r", "<br>");
        text = text.Replace("'", "");
        text = text.Replace("%", "");
        //text = text.Replace("_", "");
        return text;
    }
}