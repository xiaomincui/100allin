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

public partial class usercontrols_ratetran20090731 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "";
        sql = "select ratesimple from TB_NEWRATE";
        DataSet ds = new DataSet();
        data_conn cn = new data_conn();
        ds = cn.mdb_ds(sql, "bbs");

        string[] ratexxs = new string[4];

        string ratexx;
        ratexx = ds.Tables["bbs"].Rows[0][0].ToString();

        ratexxs = ratexx.Split('|');

        Label3.Text = (Convert.ToDouble(ratexxs[0]) / 100).ToString();
        Label4.Text = (Convert.ToDouble(ratexxs[1]) / 100).ToString();
        Label5.Text = ratexxs[2];
        Label6.Text = ratexxs[3];
    }
}
