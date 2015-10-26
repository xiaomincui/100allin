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
        string strSQL = "select * from TB_YunJia where id=" + id;
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

            txtTitle.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables[0].Rows[0]["entitle"].ToString());
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
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["hangxianmiaoshu"].ToString();

            string memo = ds.Tables[0].Rows[0]["enmemo"].ToString();
            memo = memo.Replace("<br>", "\n");
            memo = memo.Replace("&nbsp", " ");
            txtRemark.Value = HttpContext.Current.Server.HtmlDecode(memo);

            data_conn conn = new data_conn();
            DataSet dsyunjia = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a, "yunjia");
            DataRow row = dsyunjia.Tables["yunjia"].NewRow();

            row["DestPort"] = "";
            row["price20gp"] = "";
            row["price40gp"] = "";
            row["price40hq"] = "";
            row["price45hq"] = "";
            row["price20gpAppend"] = "";
            row["Distance"] = "";
            row["DepartureWkd"] = "";
            row["shipcompany"] = "";
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
        dt.Columns.Add("price20gp");
        dt.Columns.Add("price40gp");
        dt.Columns.Add("price40hq");
        dt.Columns.Add("price45hq");
        dt.Columns.Add("price20gpAppend");
        dt.Columns.Add("Distance");
        dt.Columns.Add("DepartureWkd");
        dt.Columns.Add("shipcompany");
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
                row["price20gp"] = "";
                row["price40gp"] = "";
                row["price40hq"] = "";
                row["price45hq"] = "";
                row["price20gpAppend"] = "";
                row["Distance"] = "";
                row["DepartureWkd"] = "";
                if (Request["shipcompany"] != null && Request["shipcompany"].ToString() != "" && i == 0)
                {
                    row["shipcompany"] = Request["shipcompany"].ToString();
                }
                else
                {
                    row["shipcompany"] = "";
                }
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
                row["price20gp"] = strrow[1];
                row["price40gp"] = strrow[2];
                row["price40hq"] = strrow[3];
                row["price45hq"] = strrow[4];
                row["price20gpAppend"] = strrow[5];
                row["Distance"] = strrow[6];
                row["DepartureWkd"] = strrow[7];
                row["shipcompany"] = strrow[8];
                row["memo"] = strrow[9];


                dt.Rows.Add(row);
            }
            


        }

        Repeater1.DataSource = dt.DefaultView;
        Repeater1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (hidsubmit.Value == "")
        {
            MessageBox("", "目的港不能为0个");
            return;
        }

        if (WordsIScn(hidsubmit.Value) || WordsIScn(txtTitle.Text) || WordsIScn(txtStart.Text) || WordsIScn(txtRemark.Value))
        {

            MessageBox("", "发布英文运价时，除了标题备注，不能出现中文");
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
            if (strsubmitrow[k].Substring(0, 8) == "qwerhjkl" && (strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl"))
            {
                MessageBox("", "第" + Convert.ToString(k + 1) + "行的目的港不能为空");
                return;
            }

            string[] strrow = Regex.Split(strsubmitrow[k], "qwerhjkl", new RegexOptions());
            if (strrow[8] == "" && (strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl"))
            {
                MessageBox("", "第" + Convert.ToString(k + 1) + "行的船公司不能为空");
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

            strSql = "update TB_YunJia set entitle='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',title='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "',hangxianmiaoshu='" + check.CheckInput(DropDownList1.SelectedValue.Replace("'", "''")) + "',enmemo='" + meno.Replace("'", "''") + "',memo='" + meno.Replace("'", "''") + "',PostDate='" + DateTime.Now.ToString().Replace("'", "''") + "',updateTimes=updateTimes+1 where id=" + check.CheckNumber(Request["id"]);
            SqlCommand myCommand = new SqlCommand(strSql, conn);

            myCommand.ExecuteNonQuery();
            


            myCommand.CommandText = "delete from TB_YunJiaInfo where YunJiaID=" + check.CheckNumber(Request["id"]);

            myCommand.ExecuteNonQuery();

            string strsubmit = hidsubmit.Value;
            string[] strarray = Regex.Split(strsubmit, "sdfgyuio", new RegexOptions());



            strSql = "";
            string value;
            string[] strrow = new string[strarray.Length];
            for (int i = 0; i < strarray.Length - 1; i++)
            {
                if (strarray[i] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
                {
                    strrow = Regex.Split(strarray[i], "qwerhjkl", new RegexOptions());
                    value = check.CheckNumber(Request["id"]) + ",'" + check.CheckInput(strrow[0]) + "','" + check.CheckInput(strrow[1]) + "','" + check.CheckInput(strrow[2]) + "','" + check.CheckInput(strrow[3]) + "','" + check.CheckInput(strrow[4]) + "','" + check.CheckInput(strrow[5]) + "','" + check.CheckInput(strrow[6]) + "','" + check.CheckInput(strrow[7]) + "','" + check.CheckInput(strrow[8]) + "','" + check.CheckInput(strrow[9]) + "','" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "','" + DateTime.Now.ToString().Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',8,'" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(Request.Cookies["user_id"].Value.ToString()) + ",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',1";

                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price45hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,entitlex,ifEnx) values (" + value + ");";
                }
            }



            strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow[0]) + "',price20gp1='" + check.CheckInput(strrow[1]) + "',price40gp1='" + check.CheckInput(strrow[2]) + "',price40hq1='" + check.CheckInput(strrow[3]) + "',price45hq1='" + check.CheckInput(strrow[4]) + "',shipcompany1='" + check.CheckInput(strrow[8]) + "' where id=" + Request["id"].ToString() + ";";
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (tb_yunjia.yunjialeixing = 8) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1;";

            SqlCommand myCommand1 = new SqlCommand(strSql, conn);
            myCommand1.ExecuteNonQuery();
            conn.Close();



            topnew tp = new topnew();
            tp.SetTopNew(check.CheckNumber(Request["id"]), check.CheckInput(txtTitle.Text.Replace("'", "''")), DateTime.Now.ToString(), "8", check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(txtStart.Text.Replace("'", "''")), check.CheckNumber(Request.Cookies["user_id"].Value.ToString()));


            Response.Redirect("office_fcl_list.aspx");
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
