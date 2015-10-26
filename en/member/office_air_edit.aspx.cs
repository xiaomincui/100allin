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
using System.Data.SqlClient;

public partial class en_office_sent : System.Web.UI.Page
{
    check check = new check();

    public DataSet trun(string id)
    {
        DataSet ds;
        string strSQL = "select * from T_AIRINFO where id=" + id;
        data_conn3 tt = new data_conn3();
        ds = tt.mdb_ds(strSQL, "asdf");
        return ds;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "环球运费网 - 我的办公室 - 整箱运价";
        if (this.Request.Cookies["user_id"] == null)
        {
            Response.Redirect("../sign.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                Response.Redirect("../sign.aspx");
            }
        }

        if (!IsPostBack)
        {
            string a = check.CheckNumber(Request["id"]);
            DataSet ds = trun(a);

            txtTitle.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables[0].Rows[0]["title"].ToString());
            labnow.Text = ds.Tables[0].Rows[0]["PostDate"].ToString().Split(' ')[0];

            DateTime dt = DateTime.Now;
            DateTime startMonth = dt.AddDays(1 - dt.Day);
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);



            DateTime aaa = DateTime.ParseExact(ds.Tables[0].Rows[0]["enddate"].ToString().Split(' ')[0], "yyyy-M-d", null);

            if (aaa > DateTime.Now)
            {
                BasicDatePicker1_TextBox.Value = ds.Tables[0].Rows[0]["enddate"].ToString().Split(' ')[0];
            }
            else
            {
                if (DateTime.Now.Day >= 15)
                {
                    BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(' ')[0];
                }
                else
                {
                    BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15";
                }
            }


            txtStart.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables[0].Rows[0]["StartPort"].ToString());
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["line"].ToString();

            string memo = ds.Tables[0].Rows[0]["memo"].ToString();
            memo = memo.Replace("<br>", "\n");
            memo = memo.Replace("&nbsp", " ");
            txtRemark.Value = HttpContext.Current.Server.HtmlDecode(memo);

            data_conn conn = new data_conn();
            DataSet dsyunjia = conn.mdb_ds("select * from T_AIRPRICE where AIRID=" + a, "yunjia");
            DataRow row = dsyunjia.Tables["yunjia"].NewRow();
            row["DestPort"] = "";
            row["PRICE_M"] = "";
            row["PRICE_N"] = "";
            row["PRICE_P45"] = "";
            row["PRICE_P100"] = "";
            row["PRICE_P300"] = "";
            row["PRICE_P500"] = "";
            row["PRICE_P1000"] = "";
            row["price20gpAppend"] = "";
            row["Distance"] = "";
            row["DepartureWkd"] = "";
            row["memo"] = "";

            dsyunjia.Tables["yunjia"].Rows.Add(row);

            Repeater1.DataSource = dsyunjia.Tables["yunjia"].DefaultView;
            Repeater1.DataBind();

        }
        else
        {
            RepeaterDataBind();
        }
    }

   


    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected string ExecoutID(string cmdtext,SqlParameter[] paras)
    {
        SqlCommand cmd=new SqlCommand ();
        data_conn3 data_conn = new data_conn3();
        SqlConnection conn = new SqlConnection();
        conn = data_conn.mdb_conn();
        conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdtext;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        string newid = String.Empty;
        if (paras.Length > 0)
        {
            for (int i = 0; i < paras.Length; i++)
            {
                cmd.Parameters.Add(paras[i]);
            }
        }
        cmd.ExecuteNonQuery();
        if (paras.Length > 0)
        {
            for (int i = 0; i < paras.Length; i++)
            {
                if (paras[i].Direction == ParameterDirection.Output)
                {
                    newid = Convert.ToString(paras[i].Value);
                }
            }
        }

        conn.Close();
        return newid;
    }



    public void RepeaterDataBind()
    {
        string strsubmit = this.hidsubmit.Value;
        //string[] strarray = strsubmit.Split("sdfgyuio");
        string[] strarray = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase);
        DataTable dt = new DataTable();

        dt.Columns.Add("DestPort");
        dt.Columns.Add("PRICE_M");
        dt.Columns.Add("PRICE_N");
        dt.Columns.Add("PRICE_P45");
        dt.Columns.Add("PRICE_P100");
        dt.Columns.Add("PRICE_P300");
        dt.Columns.Add("PRICE_P500");
        dt.Columns.Add("PRICE_P1000");
        dt.Columns.Add("price20gpAppend");
        dt.Columns.Add("Distance");
        dt.Columns.Add("DepartureWkd");
        dt.Columns.Add("memo");

        if (strarray.Length == 1)
        {
            
            for (int i = 0; i < 15; i++)
            {
                DataRow row = dt.NewRow();
                if (Request["DestPort"] != "" && i == 0)
                {
                    row["DestPort"] = Request["DestPort"];
                }
                else
                {
                    row["DestPort"] = "";
                }
                row["PRICE_M"] = "";
                row["PRICE_N"] = "";
                row["PRICE_P45"] = "";
                row["PRICE_P100"] = "";
                row["PRICE_P300"] = "";
                row["PRICE_P500"] = "";
                row["PRICE_P1000"] = "";
                row["price20gpAppend"] = "";
                row["Distance"] = "";
                row["DepartureWkd"] = "";
                row["memo"] = "";

                dt.Rows.Add(row);
            }

            
        }
        else
        {
            for (int i = 0; i < strarray.Length - 1; i++)
            {
                //string[] strrow = strarray[i].Split("qwerhjkl");
                string[] strrow = Regex.Split(strarray[i], "qwerhjkl", RegexOptions.IgnoreCase);
                DataRow row = dt.NewRow();

                

                row["DestPort"] = strrow[0];
                row["PRICE_M"] = strrow[1];
                row["PRICE_N"] = strrow[2];
                row["PRICE_P45"] = strrow[3];
                row["PRICE_P100"] = strrow[4];
                row["PRICE_P300"] = strrow[5];
                row["PRICE_P500"] = strrow[6];
                row["PRICE_P1000"] = strrow[7];
                row["price20gpAppend"] = strrow[8];
                row["Distance"] = strrow[9];
                row["DepartureWkd"] = strrow[10];
                row["memo"] = strrow[11];


                dt.Rows.Add(row);
            }
            


        }

        Repeater1.DataSource = dt.DefaultView;
        Repeater1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (WordsIScn(hidsubmit.Value) || WordsIScn(txtTitle.Text) || WordsIScn(txtStart.Text) || WordsIScn(txtRemark.Value))
        {

            MessageBox("", "发布英文运价时，除了标题备注，不能出现中文");
            return;
        }

        if (hidsubmit.Value == "")
        {
            MessageBox("", "目的港不能为0个");
            return;
        }

        if (hidsubmit.Value.Replace("qwerhjkl", "").Replace("sdfgyuio", "").Replace("0", "").Replace("1", "") == "")
        {
            MessageBox("", "目的港不能为0个");
            return;
        }

        string[] strsubmitrow = Regex.Split(hidsubmit.Value, "sdfgyuio", new RegexOptions());

        for (int k = 0; k < strsubmitrow.Length - 1; k++)
        {
            if (strsubmitrow[k].Substring(0, 8) == "qwerhjkl" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl" )
            {
                MessageBox("", "第" + Convert.ToString(k + 1) + "行的目的港不能为空");
                return;
            }

        }

        if (txtTitle.Text == "")
        {
            MessageBox("", "标题不能为空");
        }
        else if (BasicDatePicker1_TextBox.Value == "")
        {
            MessageBox("", "有效日期不能为空");
        }
        else if (txtStart.Text == "")
        {
            MessageBox("", "启运港不能为空");
        }
        else if (DropDownList1.Text == "请选择")
        {
            MessageBox("", "请选择航线");
        }
        else
        {
            string strSql;
            string meno = check.CheckInput(txtRemark.Value);
            meno = meno.Replace("\n", "<br>");
            meno = meno.Replace(" ", "&nbsp");

            data_conn3 data_conn = new data_conn3();
            SqlConnection conn = new SqlConnection();
            conn = data_conn.mdb_conn();
            conn.Open();

            strSql = "update T_AIRINFO set entitle='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',title='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "',line='" + check.CheckInput(DropDownList1.SelectedValue.Replace("'", "''")) + "',enmemo='" + meno.Replace("'", "''") + "',memo='" + meno.Replace("'", "''") + "',PostDate='" + DateTime.Now.ToString().Replace("'", "''") + "',updateTimes=updateTimes+1 where id=" + check.CheckNumber(Request["id"]);
            SqlCommand myCommand = new SqlCommand(strSql, conn);

            myCommand.ExecuteNonQuery();



            myCommand.CommandText = "delete from T_AIRPRICE where AIRID=" + check.CheckNumber(Request["id"]);

            myCommand.ExecuteNonQuery();

            string strsubmit = hidsubmit.Value;
            string[] strarray = Regex.Split(strsubmit, "sdfgyuio", new RegexOptions());


            strSql = "";
            string value;
            string[] strrow = new string[strarray.Length];
            for (int i = 0; i < strarray.Length - 1; i++)
            {
                if (strarray[i] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
                {
                    strrow = Regex.Split(strarray[i], "qwerhjkl", new RegexOptions());
                    value = check.CheckNumber(Request["id"]) + ",'" + check.CheckInput(strrow[0]) + "','" + check.CheckInput(strrow[1]) + "','" + check.CheckInput(strrow[2]) + "','" + check.CheckInput(strrow[3]) + "','" + check.CheckInput(strrow[4]) + "','" + check.CheckInput(strrow[5]) + "','" + check.CheckInput(strrow[6]) + "','" + check.CheckInput(strrow[7]) + "','" + check.CheckInput(strrow[8]) + "','" + check.CheckInput(strrow[9]) + "','" + check.CheckInput(strrow[10]) + "','" + check.CheckInput(strrow[11]) + "','" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text) + "','" + DateTime.Now.ToString().Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "','" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(Request.Cookies["user_id"].Value.ToString()) + ",'" + check.CheckInput(txtTitle.Text) + "',1";

                    strSql += "insert into T_AIRPRICE (AIRID,DestPort,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,price20gpAppend,Distance,DepartureWkd,memo,Titlex,StartPortx,PostDatex,enddatex,linex,UserIDx,entitlex,ifEnx) values (" + value + ");";
                }
            }



            strSql += "update T_AIRINFO set DestPort1='" + check.CheckInput(strrow[0]) + "',PRICE_M1='" + check.CheckInput(strrow[1]) + "',PRICE_N1='" + check.CheckInput(strrow[2]) + "',PRICE_P451='" + check.CheckInput(strrow[3]) + "',PRICE_P1001='" + check.CheckInput(strrow[4]) + "',PRICE_P3001='" + check.CheckInput(strrow[5]) + "',PRICE_P5001='" + check.CheckInput(strrow[6]) + "',PRICE_P10001='" + check.CheckInput(strrow[7]) + "' where id=" + Request["id"].ToString() + ";";
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1";

            SqlCommand myCommand1 = new SqlCommand(strSql, conn);
            myCommand1.ExecuteNonQuery();
            conn.Close();



            topnew tp = new topnew();
            tp.SetTopNew(check.CheckNumber(Request["id"]), check.CheckInput(txtTitle.Text.Replace("'", "''")), DateTime.Now.ToString(), "10", check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(txtStart.Text.Replace("'", "''")), check.CheckNumber(Request.Cookies["user_id"].Value.ToString()));


            Response.Redirect("office_air_list.aspx");
        }
    }

    public bool WordsIScn(string words)
    {
        if (words == "")
        {
            return false;
        }
        string Tmmp;
        for (int i = 0; i < words.Length; i++)
        {
            Tmmp = words.Substring(i, 1);
            byte[] sarr = System.Text.Encoding.GetEncoding("gb2312").GetBytes(Tmmp);
            if (sarr.Length == 2)
            {
                return true;
            }
        }

        return false;
    }
}
