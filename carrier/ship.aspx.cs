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
using System.Text.RegularExpressions;
using System.Text;

public partial class ship_ship : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRequest g=new GetRequest ();
            string id=g.GetRequestQueryString("id","");
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_Ship where id="+id, "ship");

            Literal1.Text = ds.Tables["ship"].Rows[0]["name_cn_s"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_cn"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_en"].ToString();
            Literal2.Text = ds.Tables["ship"].Rows[0]["name_cn"].ToString();
            Literal3.Text = ds.Tables["ship"].Rows[0]["Website"].ToString();
            Literal4.Text = ds.Tables["ship"].Rows[0]["cargotail"].ToString();
            Literal5.Text = ds.Tables["ship"].Rows[0]["contact"].ToString();
            Literal6.Text = ds.Tables["ship"].Rows[0]["introduction"].ToString();

            Literal7.Text = ds.Tables["ship"].Rows[0]["name_cn_s"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_cn"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "/" + ds.Tables["ship"].Rows[0]["name_en"].ToString();

            Littitle.Text = "<title>" + ds.Tables["ship"].Rows[0]["name_cn_s"].ToString() + "-" + ds.Tables["ship"].Rows[0]["name_cn"].ToString() + "-" + ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "-" + ds.Tables["ship"].Rows[0]["name_en"].ToString() + "-联系方式-公司介绍-环球运费网</title>";
            Litkey.Text = "<meta name=\"keywords\" content=\"" + ds.Tables["ship"].Rows[0]["name_cn_s"].ToString() + "," + ds.Tables["ship"].Rows[0]["name_cn"].ToString() + "," + ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "," + ds.Tables["ship"].Rows[0]["name_en"].ToString() + ",船公司信息,船公司联系方式,船公司网站,船公司介绍-环球运费网\" />";
            Litdes.Text = "<meta name=\"description\" content=\"" + ds.Tables["ship"].Rows[0]["name_cn_s"].ToString() +ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "船公司的联系方式和介绍,环球运费网提供最新最全面的" + ds.Tables["ship"].Rows[0]["name_en_s"].ToString() + "船公司信息\" />";

            LoadLeft(ds.Tables["ship"].Rows[0]["name_en_s"].ToString());
        }
    }

    public void LoadLeft(string name_en_s)
    {
        data_conn cn = new data_conn();
        if (name_en_s != "")
        {
            DataSet ds = cn.mdb_ds("select top 5 * from TB_BBS where title like '%" + name_en_s + "%'", "bbs");

            Repeater1.DataSource = ds.Tables["bbs"].DefaultView;
            Repeater1.DataBind();

            string strYear = DateTime.Now.Year.ToString();
            string strMonth = DateTime.Now.Month.ToString();

            
            ds = cn.mdb_ds("select top 1 * from TB_BAF where months='" + strYear + "-" + strMonth + "' and Carriers  like '%" + name_en_s + "%'", "baf");
            if (ds.Tables["baf"].Rows.Count > 0)
            {
                Literal8.Text = "<a href='../baf/#anchor" + ds.Tables["baf"].Rows[0]["id"].ToString() + "'>" + strMonth + "月" + name_en_s + "最新BAF/CAF</a><br />";
            }
            ds = cn.mdb_ds("select top 1 * from TB_THC where months='" + strYear + "-" + strMonth + "' and Carriers='" + name_en_s + "'", "thc");
            if (ds.Tables["thc"].Rows.Count > 0)
            {
                Literal9.Text = "<a href='../thc/#anchor" + ds.Tables["thc"].Rows[0]["id"].ToString() + "'>" + strMonth + "月" + name_en_s + "最新THC</a><br />";
            }

            ds = cn.mdb_ds("select top 5 * from TB_Search_Ship order by Num desc", "hot");
            Repeater2.DataSource = ds.Tables["hot"].DefaultView;
            Repeater2.DataBind();

        }


    }

    public string GetFirstString(string stringToSub,int length)
    {
        Regex regex=new Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }
            if(nLength >length )
            {
                isCut = true;
                break;
            }
        }
        return sb.ToString();
    }



}
