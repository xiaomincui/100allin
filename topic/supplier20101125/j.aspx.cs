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

public partial class topic_supplier20101125_j : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        SymmetricMethod ss = new SymmetricMethod();
        check ck = new check();

        string uid = "0";
        uid = ck.CheckNumber(GetRequest1.GetRequestQueryString("uid", ""));

        Response.Redirect("join.aspx?uid=" + ss.Encrypto(uid));
    }
}
