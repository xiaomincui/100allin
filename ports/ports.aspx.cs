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
            GetRequest g = new GetRequest();
            string name = g.GetRequestQueryString("name", "");
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_Y_Port where portname_en='" + name + "'", "ship");
            //Response.Write("select * from TB_Y_Port where portname_en='" + name + "'");
            if (ds.Tables["ship"].Rows.Count > 0)
            {
                Literal1.Text = ds.Tables["ship"].Rows[0]["country_en"].ToString() + "/" + ds.Tables["ship"].Rows[0]["country"].ToString() + "-" + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "/" + ds.Tables["ship"].Rows[0]["portname"].ToString();
                Literal4.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal2.Text = ds.Tables["ship"].Rows[0]["portname"].ToString();
                Literal10.Text = ds.Tables["ship"].Rows[0]["portNum"].ToString();
                Literal5.Text = ds.Tables["ship"].Rows[0]["Line"].ToString();
                Literal3.Text = ds.Tables["ship"].Rows[0]["country_en"].ToString();
                Literal11.Text = ds.Tables["ship"].Rows[0]["country"].ToString();

                //Literal7.Text = "<a href='http://localhost/ports/list---" + ds.Tables["ship"].Rows[0]["int_country"].ToString() + "-----1.html'>" + ds.Tables["ship"].Rows[0]["country_en"].ToString() + "/" + ds.Tables["ship"].Rows[0]["country"].ToString() + "</a> > " + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "/" + ds.Tables["ship"].Rows[0]["portname"].ToString();
                Literal6.Text = ds.Tables["ship"].Rows[0]["intro"].ToString();


                Literal8.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal13.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal15.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal17.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal19.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal21.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal23.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal25.Text = ds.Tables["ship"].Rows[0]["portname"].ToString() + ds.Tables["ship"].Rows[0]["portname_en"].ToString();

                Literal9.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal12.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal14.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal16.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal18.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal20.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal22.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();
                Literal24.Text = ds.Tables["ship"].Rows[0]["portname_en"].ToString();

                Littitle.Text = "<title>" + ds.Tables["ship"].Rows[0]["country"].ToString() + "-" + ds.Tables["ship"].Rows[0]["country_en"].ToString() + "-" + ds.Tables["ship"].Rows[0]["portname"].ToString() + "-" + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "-港口介绍,港口介绍-环球运费网</title>";
                Litkey.Text = "<meta name=\"keywords\" content=\"" + ds.Tables["ship"].Rows[0]["country"].ToString() + "港口," + ds.Tables["ship"].Rows[0]["country_en"].ToString() + " port," + ds.Tables["ship"].Rows[0]["portname"].ToString() + "," + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "," + ds.Tables["ship"].Rows[0]["portname"].ToString() + "港," + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "port,港口介绍,港口代码-环球运费网\" />";
                Litdes.Text = "<meta name=\"description\" content=\"" + ds.Tables["ship"].Rows[0]["country"].ToString() + "港口," + ds.Tables["ship"].Rows[0]["country_en"].ToString() + " port," + ds.Tables["ship"].Rows[0]["portname"].ToString() + "," + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "," + ds.Tables["ship"].Rows[0]["portname"].ToString() + "港," + ds.Tables["ship"].Rows[0]["portname_en"].ToString() + "ports介绍,港口代码,环球运费网提供最全面的" + ds.Tables["ship"].Rows[0]["portname"].ToString() + "港口信息\" />";

                //LoadHotShip();
            }
            else
            {

            }
        }
    }



    public void LoadHotShip()
    {
        //data_conn cn = new data_conn();
        //DataSet ds = cn.mdb_ds("select top 5 * from TB_Search_Ports order by Num desc", "hot");
        //Repeater2.DataSource = ds.Tables["hot"].DefaultView;
        //Repeater2.DataBind();
        //Repeater3.DataSource = ds.Tables["hot"].DefaultView;
        //Repeater3.DataBind();

    }

    //public void LoadLeft(string name_en_s)
    //{
    //    data_conn cn = new data_conn();
    //    if (name_en_s != "")
    //    {
    //        DataSet ds = cn.mdb_ds("select top 5 * from TB_BBS where title like '%" + name_en_s + "%'", "bbs");

    //        Repeater1.DataSource = ds.Tables["bbs"].DefaultView;
    //        Repeater1.DataBind();

    //        string strYear = DateTime.Now.Year.ToString();
    //        string strMonth = DateTime.Now.Month.ToString();


    //        DataSet ds = cn.mdb_ds("select top 1 * from TB_BAF where months='" + strYear + "-" + strMonth + "' and Carriers like '%" + name_en_s + "%'", "baf");
    //        if (ds.Tables["baf"].Rows.Count > 0)
    //        {
    //            Literal8.Text = "<a href='../baf/#anchor" + ds.Tables["baf"].Rows[0]["id"].ToString() + "'>" + strMonth + "月" + name_en_s + "最新BAF/CAF</a><br />";
    //        }
    //        ds = cn.mdb_ds("select top 1 * from TB_THC where months='" + strYear + "-" + strMonth + "' and Carriers='" + name_en_s + "'", "thc");
    //        if (ds.Tables["thc"].Rows.Count > 0)
    //        {
    //            Literal9.Text = "<a href='../thc/#anchor" + ds.Tables["thc"].Rows[0]["id"].ToString() + "'>" + strMonth + "月" + name_en_s + "最新THC</a><br />";
    //        }

    //        ds = cn.mdb_ds("select top 5 * from TB_Search_Ship order by Num desc", "hot");
    //        Repeater2.DataSource = ds.Tables["hot"].DefaultView;
    //        Repeater2.DataBind();

    //    }


    //}

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
