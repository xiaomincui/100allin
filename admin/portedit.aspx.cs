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

public partial class admin_portedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            LoadRecord();
        }
        
    }

    protected void LoadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "select * from TB_City where id = " + Request.QueryString["id"].ToString();

        ds = cn.mdb_ds(sql,"tb_city");
        txtCityName.Text = ds.Tables["tb_city"].Rows[0]["CityName"].ToString();
        txtCityNameCH.Text = ds.Tables["tb_city"].Rows[0]["CityNameCH"].ToString();
        txtCountry.Text = ds.Tables["tb_city"].Rows[0]["Country"].ToString();
        txtCountryCH.Text = ds.Tables["tb_city"].Rows[0]["CountryCH"].ToString();
        txtLine.Text = ds.Tables["tb_city"].Rows[0]["Line"].ToString();
        txtMapsLinks.Text = ds.Tables["tb_city"].Rows[0]["MapsLinks"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = sql + "update TB_City set ";
        sql = sql + "CityName = '" + txtCityName.Text + "', ";
        sql = sql + "CityNameCH = '" + txtCityNameCH.Text + "', ";
        sql = sql + "Country = '" + txtCountry.Text + "', ";
        sql = sql + "CountryCH = '" + txtCountryCH.Text + "', ";
        sql = sql + "Line = '" + txtLine.Text + "', ";
        sql = sql + "MapsLinks = '" + txtMapsLinks.Text + "' ";
        sql = sql + "where id = " + Request.QueryString["id"].ToString();

        cn.mdb_exe(sql);
    }
}
