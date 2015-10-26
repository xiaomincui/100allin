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
using System.Text.RegularExpressions;
using System.Text;

public partial class news_news_list : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadNews();
            //LoadNewBBS();
        }
    }

    public void LoadNews()
    {
        try
        {

            check ck = new check();
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();

            string p = "0";

            if (Request.QueryString["page"] != null)
            {
                p = ck.CheckInput(Request.QueryString["page"].ToString());
            }

            int ps = (Convert.ToInt32(p) - 1) * 20;

            string sql = "";
            sql = "SELECT TOP 20 * ";
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

            //Response.Write(sql);
            //Response.Write("<br/>");
            //Response.Write(Request.Url.ToString());
            Repeater4.DataSource = ds.Tables["news"].DefaultView;
            Repeater4.DataBind();

            sql = "";
            sql = "SELECT COUNT(*) FROM TB_BBS WHERE TYPES = 5";

            ds = cn.mdb_ds(sql, "newscount");

            
            
            string base_url = "/news/1/2/" + "list_";
            string end_url = ".html";

            int cp = Convert.ToInt32(p);
            int tp = 1;
            int count = Convert.ToInt32(ds.Tables["newscount"].Rows[0][0].ToString());

            if (count % 20 > 0 || count == 0)
            {
                tp = count / 20 + 1;
            }
            else
            {
                tp = count / 20;
            }


            string s = "";
            if (cp == 1)
            {
                s = s + "<span class=\"disabled\"><<</span>";
                s = s + "<span class=\"disabled\"><</span>";
                pagecontrol_prev = "<span class=\"disabled\"><</span>";
                s = s + "<span class=\"selected\">1</span>";
                for (int i = 2; i <= (tp < 10 ? tp : 10); i++)
                {
                    s = s + "<a href=\"" + base_url + "" + i + end_url + "\"><span>" + i + "</span></a>";
                }
            }
            else
            {
                s = s + "<a href=\"" + base_url + "1" + end_url + "\"><span class=\"button\"><<</span></a>";
                s = s + "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span class=\"button\"><</span></a>";
                pagecontrol_prev = "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span class=\"button\"><</span></a>";
                for (int i = (cp <= 5 ? 1 : (tp - cp < 5 ? (tp - 9 < 1 ? 1 : tp - 9) : cp - 4)); i <= cp - 1; i++)
                {
                    s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
                }

                s = s + "<span class=\"selected\">" + cp + "</span>";

                for (int i = cp + 1; i <= (cp + 5 >= tp ? tp : (cp <= 5 ? (tp >= 10 ? 10 : tp) : cp + 5)); i++)
                {
                    s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
                }
            }


            if (cp == tp)
            {
                s = s + "<span class=\"disabled\">></span>";
                pagecontrol_next = "<span class=\"disabled\">></span>";
                s = s + "<span class=\"disabled\">>></span>";
            }
            else
            {
                s = s + "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span class=\"button\">></span></a>";
                pagecontrol_next = "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span class=\"button\">></span></a>";
                s = s + "<a href=\"" + base_url + tp + end_url + "\"><span class=\"button\">>></span></a>";
            }
            pagecontrol_string = s;


            sql = "select ratesimple from TB_NEWRATE";
            ds = cn.mdb_ds(sql, "rate");

            string[] ratexxs = new string[4];

            string ratexx;
            ratexx = ds.Tables["rate"].Rows[0][0].ToString();

            ratexxs = ratexx.Split('|');

            try
            {
                ltrRate1.Text = (Convert.ToDouble(ratexxs[0]) / 100).ToString();
                ltrRate2.Text = (100 / Convert.ToDouble(ratexxs[0])).ToString("f4");
                //ltrRate3.Text = Math.Round((Convert.ToDouble(ratexxs[2])), 4).ToString("f4");
                //ltrRate4.Text = Math.Round((Convert.ToDouble(ratexxs[3])), 4).ToString("f3");
            }
            catch
            {

            }

            sql = "select top 8 ";
            sql = sql + "id,title,postdate ";
            sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY newid() ";
            ds = cn.mdb_ds(sql, "bbs");
            RptaHangYunDongTai.DataSource = ds.Tables["bbs"].DefaultView;
            RptaHangYunDongTai.DataBind();
        }
        catch
        {

        }

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


    public string bbsstyle(int r)
    {
        string s = "4";
        if (r <= 3)
        {
            return (r + 1).ToString();
        }
        else
        {
            return s;
        }

    }
}
