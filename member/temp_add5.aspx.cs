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

public partial class demo_cargo_temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Random rd = new Random();
        string rdnumber = Convert.ToInt32((10000 * rd.NextDouble())).ToString();

        Session["cargo_a"] = rdnumber;

        if (this.Request["id"] != null)
        {
            if (this.Request["id"].ToString() != "")
            {
                Response.Redirect("temp_add_air.aspx?id=" + Request["id"].ToString());
            }
            else
            {
                Response.Redirect("temp_add_air.aspx");
            }

        }
        else
        {
            Response.Redirect("temp_add_air.aspx");
        }
    }
}
