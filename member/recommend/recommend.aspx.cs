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

public partial class message_BBSList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null)
        {

            Response.Cookies["url"].Value = Request.Url.ToString();
            this.Response.Redirect("../../member/reg.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                Response.Cookies["url"].Value = Request.Url.ToString();
                this.Response.Redirect("../../member/reg.aspx");
            }
            else
            {
               
                data_conn cn = new data_conn();
                string sql = "select count(*) as recommend from TB_User where recommendUserID=" + this.Request.Cookies["user_id"].Value.ToString();
                
                DataSet ds = cn.mdb_ds(sql, "count");
                Label1.Text = ds.Tables["count"].Rows[0][0].ToString();

                
                sql = "select sum(mark) from TB_Mark where UserID=" + this.Request.Cookies["user_id"].Value.ToString();
                
                ds = cn.mdb_ds(sql, "mark");
                if (ds.Tables["mark"].Rows[0][0].ToString() == "")
                {
                    Label2.Text = "0";
                }
                else
                {
                    Label2.Text = ds.Tables["mark"].Rows[0][0].ToString();
                }
                TextBox1.Text = "http://www.100allin.com/member/reg.aspx?recommendUserID=" + this.Request.Cookies["user_id"].Value.ToString();
                
            }
        }
    }




}
