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

public partial class usercontrols_usernew : System.Web.UI.UserControl
{
    public string chatowner = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUserNew();

        if (this.Request.Cookies["user_id"] != null)
        {
            chatowner = this.Request.Cookies["user_id"].Value.ToString();
        }
    }

    public void LoadUserNew()
    {
        //计算取出4位最新加入的会员
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //定义SQL语句，查询某一用户发布的3种运价及货盘各自的总数
        sql = sql + "SELECT ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "v_user_new ";
        ds = cn.mdb_ds(sql, "count");

        DataList1.DataSource = ds.Tables["count"].DefaultView;
        DataList1.DataBind();
    }

    
    public string ReplaceSomeWord(string w)
    {
        string w1 = "";
        string w2 = "";
        string w3 = "";

        try
        {
            if (w.Length <= 6)
            {
                if (w.Length <= 2)
                {
                    w1 = "**";
                }
                else
                {
                    int l2;
                    w1 = w.Substring(0, 2);
                    l2 = w.Substring(2, w.Length - 2).Length;
                    for (int i = 1; i <= l2; i++)
                    {
                        w2 = w2 + "*";
                    }   
                }

            }
            else
            {
                int l2;
                w1 = w.Substring(0, 2);
                l2 = w.Substring(2, w.Length - 6).Length;
                for (int i = 1; i <= l2; i++)
                {
                    w2 = w2 + "*";
                }
                w3 = w.Substring(w.Length - 4, 4);
            }
        }
        catch 
        { 
        
        }
        return w1 + w2 + w3;
    }//隐藏字符串内部分字符，只显示字符串的前2字符和最后4字符
}
