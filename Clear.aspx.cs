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

public partial class Clear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool t = false;
        HttpCookieCollection i = Request.Cookies;
        for (int j = 0; j < i.Count; j++)
        {
            Response.Write(i[j].Name.ToString());
            Response.Write(":");

            Response.Write("<br/>");
            Response.Cookies[i[j].Name].Expires = DateTime.Now.AddDays(-1);

        }
    }

    //public static bool DeleteCookie(string CookieName)
    //{
    //    HttpCookie MyCo;
    //    if (_strPageDomain != null && _strPageDomain != "")
    //    {
    //        MyCo = HttpContext.Current.Request.Cookies["UserID"];
    //        if (System.Web.HttpContext.Current.Request.ServerVariables.ToString().IndexOf(_strPageDomain) >= 0 && MyCo != null)
    //        {
    //            MyCo.Domain = _strPageDomain;
    //            MyCo.Expires = DateTime.Now.AddHours(-24); //关键是这一句
    //            HttpContext.Current.Response.Cookies.Add(MyCo);

    //        }
    //    }
    //    else
    //    {
    //        MyCo = HttpContext.Current.Request.Cookies["UserID"];
    //        if (MyCo != null)
    //        {
    //            MyCo.Expires = DateTime.Now.AddHours(-48);
    //            HttpContext.Current.Response.Cookies.Add(MyCo);
    //        }

    //    }
    //}
}
