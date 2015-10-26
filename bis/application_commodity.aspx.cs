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

public partial class biz_application_commodity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string txtshipout,txtshipin,txtshipinout,txtair;

        if(chkshipout.Checked)
        {
            txtshipout="1";
        }
        else
        {
            txtshipout="0";
        }

        if(chkshipin.Checked)
        {
            txtshipin="1";
        }
        else
        {
            txtshipin="0";
        }

        if(chkshipinout.Checked)
        {
            txtshipinout="1";
        }
        else
        {
            txtshipinout="0";
        }

        if(chkair.Checked)
        {
            txtair="1";
        }
        else
        {
            txtair="0";
        }

        string portfolio,declarer,checker;
        if (txtportfolio.Value != "")
        {
            portfolio=txtportfolio.Value;
        }
        else
        {
            portfolio="null";
        }

        if (txtdeclarer.Value != "")
        {
            declarer = txtdeclarer.Value;
        }
        else
        {
            declarer="null";
        }

        if (txtchecker.Value != "")
        {
            checker=txtchecker.Value;
        }
        else
        {
            checker="null";
        }


        cn.mdb_exe("insert into TB_Commodity (typeshipout,typeshipin,typeshipinout,typeair,city,portfolio,declarer,checker,linkmen,phone,company,description) values (" + txtshipout + "," + txtshipin + "," + txtshipinout + "," + txtair + ",'" + txtcity.Value + "'," + portfolio + "," + declarer + "," + checker + ",'" + txtlinkmen.Value + "','" + txtphone.Value + "','" + txtcompany.Value + "','" + txtdescription.Value + "')");
        this.Response.Redirect("commodity.aspx");
    }
}

