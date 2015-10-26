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


public partial class usercontrols_userbottom100414 : System.Web.UI.UserControl
{
    public string isft;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            PageRecord();
        }
    }

    void PageRecord()
    {
        check ck = new check();
        string request;
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            request = "";
        }
        else
        {
            request = Request.ServerVariables["HTTP_REFERER"].ToString();
            request = ck.CheckRecord(request);
        }

        string page = Request.Url.ToString();
        page = ck.CheckRecord(page);

        string pagefile = Request.Url.AbsolutePath.ToString();
        pagefile = ck.CheckRecord(pagefile);




        string pagesql = "select pagearea from TB_PageArea where pageaddress = '" + pagefile + "'";
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(pagesql, "TB_PageArea");


        string pagearea = "";

        if (ds.Tables["TB_PageArea"].Rows.Count > 0)
        {
            pagearea = ds.Tables["TB_PageArea"].Rows[0][0].ToString();
        }



        string address = Page.Request.UserHostAddress;
        string address1 = Page.Request.UserHostAddress;


        if (this.Request.Cookies["user_id"] == null)
        {
            string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
            cn.mdb_exe(sql);

        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
            else
            {
                string a = this.Request.Cookies["user_id"].Value;
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (" + this.Request.Cookies["user_id"].Value + ",'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
        }

        try
        {
            if (this.Request.Cookies["user_id"] == null)
            {
                string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);

            }
            else
            {
                if (this.Request.Cookies["user_id"].Value == "")
                {
                    string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                    cn.mdb_exe(sql);
                }
                else
                {
                    string a = this.Request.Cookies["user_id"].Value;
                    string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (" + this.Request.Cookies["user_id"].Value + ",'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                    cn.mdb_exe(sql);
                }
            }
        }
        catch
        {

        }
    }

    public static string IPAddress
    {
        get
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1) //没有"."肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("\"", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                            && temparyip[i].Substring(0, 3) != "10."
                            && temparyip[i].Substring(0, 7) != "192.168"
                            && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i]; //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null; //代理中的内容 非IP，取IP 
                }
            }
            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null &&

            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ?

            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables

            ["REMOTE_ADDR"];
            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }
    }

    public static bool IsIPAddress(string str1)
    {
        if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
        string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
        Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
        return regex.IsMatch(str1);
    } 
}
