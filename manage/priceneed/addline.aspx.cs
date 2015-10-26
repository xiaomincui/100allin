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

public partial class manage_priceneed_addline : System.Web.UI.Page
{
    public check ck = new check();
    public GetRequest GetRequest1 = new GetRequest();
    public string lid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txt_lstartport.Attributes.Add("onkeyup", "autowords(this.id,event);");
            txt_lstartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}");

            for (int i = 0; i < rbl_lftype.Items.Count; i++)
            {
                rbl_lftype.Items[i].Attributes.Add("onclick", "selectftype();");
            }

            rbl_line2.Attributes.Add("style", "display:none;");


            lid = ck.CheckNumber(GetRequest1.GetRequestQueryString("id", "0"));


            if (lid != "0")
            {
                LoadRecord(lid);
            }
        }



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lid = ck.CheckNumber(GetRequest1.GetRequestQueryString("id", "0"));

        string startport = ck.CheckInput(txt_lstartport.Text); //起运港
        string line = ""; //航线
        string lftype = ck.CheckInput(rbl_lftype.SelectedValue); //运价类型
        if (lftype == "10")
        {
            line = ck.CheckInput(rbl_line2.SelectedValue);
        }
        else
        {
            line = ck.CheckInput(rbl_line1.SelectedValue);
        }
        
        string ltime = DateTime.Now.ToString(); //更新时间
        string ltype = ck.CheckInput(rbl_ltype.SelectedValue); //输入方式
        string lorder = ck.CheckInput(rbl_order.SelectedValue); //优先级别，默认为3
        string lhot = ck.CheckNumber1(txt_hot.Text); //热度，默认为0
        string lhidden = ck.CheckInput(rbl_hidden.SelectedValue);

        string success = "1";//检测标志位，0为失败，1为成功

        if (lhot == "-1")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('热度必须是数字！')", true);
            success = "0";
        }

        if (startport == "")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('必须填写起运港！')", true);
            success = "0";
        }

        if (success == "1")
        {
            System.Threading.Thread.Sleep(1000);

            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";

            if (lid == "0")
            {
                sql = sql + "INSERT INTO TB_LOST_LINE ";
                sql = sql + "( ";
                sql = sql + "startport, ";
                sql = sql + "line, ";
                sql = sql + "ltime, ";
                sql = sql + "ltype, ";
                sql = sql + "lftype, ";
                sql = sql + "lorder, ";
                sql = sql + "lhot, ";
                sql = sql + "lhidden ";
                sql = sql + ") ";
                sql = sql + "VALUES ";
                sql = sql + "( ";
                sql = sql + "'" + startport + "', ";
                sql = sql + "'" + line + "', ";
                sql = sql + "'" + ltime + "', ";
                sql = sql + "" + ltype + ", ";
                sql = sql + "" + lftype + ", ";
                sql = sql + "" + lorder + ", ";
                sql = sql + "" + lhot + ", ";
                sql = sql + "" + lhidden + " ";
                sql = sql + ") ";

                cn.mdb_exe(sql);
                //Literal1.Text = sql;
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "addConfirm();", true);

                rbl_ltype.SelectedIndex = 0;
                txt_lstartport.Text = "";
                rbl_lftype.SelectedIndex = 0;
                rbl_line1.SelectedIndex = 0;
                rbl_line2.SelectedIndex = 0;
                rbl_order.SelectedIndex = 2;
                txt_hot.Text = "";
                rbl_hidden.SelectedIndex = 0;
            }
            else
            {
                sql = sql + "UPDATE TB_LOST_LINE SET ";
                sql = sql + "startport = '" + startport + "', ";
                sql = sql + "line = '" + line + "', ";
                sql = sql + "ltype = " + ltype + ", ";
                sql = sql + "lftype = " + lftype + ", ";
                sql = sql + "lorder = " + lorder + ", ";
                sql = sql + "lhot = " + lhot + ", ";
                sql = sql + "lhidden = " + lhidden + " ";
                sql = sql + "WHERE lid = " + lid + " ";

                cn.mdb_exe(sql);
                //Literal1.Text = sql;
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('编辑成功！');", true);
            }
        }
    }

    protected void LoadRecord(string lid) 
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
 
        string sql = "";
        sql = "SELECT * FROM TB_LOST_LINE WHERE lid = " + lid;

        ds = cn.mdb_ds(sql, "line");

        if (ds.Tables["line"].Rows.Count > 0)
        {
            rbl_ltype.SelectedValue = ds.Tables["line"].Rows[0]["ltype"].ToString();
            txt_lstartport.Text = ds.Tables["line"].Rows[0]["startport"].ToString();
            rbl_lftype.SelectedValue = ds.Tables["line"].Rows[0]["lftype"].ToString();

            if (ds.Tables["line"].Rows[0]["lftype"].ToString() == "10")
            {
                rbl_line2.SelectedValue = ds.Tables["line"].Rows[0]["line"].ToString();
                rbl_line2.Attributes.Remove("style");
                rbl_line1.Attributes.Add("style", "display:none;");
            }
            else
            {
                rbl_line1.SelectedValue = ds.Tables["line"].Rows[0]["line"].ToString();
            }
            
            rbl_order.SelectedValue = ds.Tables["line"].Rows[0]["lorder"].ToString();
            txt_hot.Text = ds.Tables["line"].Rows[0]["lhot"].ToString();
            rbl_hidden.SelectedValue = ds.Tables["line"].Rows[0]["lhidden"].ToString();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('没有此记录！');", true);
        }
    }
}
