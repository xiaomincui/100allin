using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// GetRequest 的摘要说明
/// </summary>
public class GetRequest
{
	public GetRequest()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string GetRequestQueryString(string q, string d)
    {
        string outputstring = d;
        if (HttpContext.Current.Request.QueryString[q] != null)
        {
            if (HttpContext.Current.Request.QueryString[q].ToString() != "")
            {
                outputstring = HttpContext.Current.Request.QueryString[q].ToString();
            }
        }
        return outputstring;
    }//获得网页字符串参数QueryString，q是参数名，d是默认值

    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (HttpContext.Current.Request.Cookies[c] != null)
        {
            if (HttpContext.Current.Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = HttpContext.Current.Request.Cookies[c].Value.ToString();
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数，q是参数名，d是默认值
}
