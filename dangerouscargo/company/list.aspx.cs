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

public partial class dangerouscargo_company_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        string port = GetRequest1.GetRequestQueryString("port","1");

        if (port.ToString().ToLower() == "shanghai")
        {
            PlaceHolder1.Visible = true;
        }

        if (port.ToString().ToLower() == "ningbo")
        {
            PlaceHolder2.Visible = true;
        }

        if (port.ToString().ToLower() == "tianjin")
        {
            PlaceHolder3.Visible = true;
        }

        if (port.ToString().ToLower() == "dalian")
        {
            PlaceHolder4.Visible = true;
        }
    }
}
