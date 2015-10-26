using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class getkey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string address = Page.Request.UserHostAddress;
        Response.Write(address);
    }


    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = key(TextBox1.Text);
    }
}