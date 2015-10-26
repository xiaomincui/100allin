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
                DataSet ds2;
                data_conn conn = new data_conn();
                string sql;
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Request.Cookies["user_id"].Value);
                ds2 = conn.mdb_ds(sql, "table");
                if (Convert.ToInt32(ds2.Tables["table"].Rows[0]["ifEn"].ToString()) == 0)
                {
                    Response.Redirect("../../member/useredit2.aspx");
                }
                DateTime dtime = DateTime.Now;
                DateTime startMonth = dtime.AddDays(1 - dtime.Day);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
                if (DateTime.Now.Day >= 15)
                {
                    BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(' ')[0];
                }
                else
                {
                    BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15";
                }

                if (Request["startport"] != null)
                {
                    if (Request["startport"].ToString() != "")
                    {
                        txtStart.Text = Request["startport"].ToString();
                    }
                }

                if (Request["hx"] != null)
                {
                    if (Request["hx"].ToString() != "")
                    {
                        DropDownList1.SelectedValue = Request["hx"].ToString();
                    }
                }

            }
            labnow.Text = DateTime.Now.ToString().Split(' ')[0];
            RepeaterDataBind();


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
        dt.Columns.Add("pricegpv");
        dt.Columns.Add("pricegp");
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
                row["pricegpv"] = "";
                row["pricegp"] = "";
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
                row["pricegpv"] = strrow[1];
                row["pricegp"] = strrow[2];
                row["price20gpAppend"] = strrow[3];
                row["Distance"] = strrow[4];
                row["DepartureWkd"] = strrow[5];
                row["shipcompany"] = strrow[6];
                row["memo"] = strrow[7];



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
            if (strsubmitrow[k].Substring(0, 8) == "qwerhjkl" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
            {
                MessageBox("", "第" + Convert.ToString(k + 1) + "行的目的港不能为空");
                return;
            }

            string[] strrow = Regex.Split(strsubmitrow[k], "qwerhjkl", new RegexOptions());
            if (strrow[6] == "" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
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
            //try
            //{
            string text = txtRemark.Value;
            text = text.Replace("\n", "<br>");
            text = text.Replace(" ", "&nbsp");
            SqlParameter[] paras = new SqlParameter[29];
            paras[0] = new SqlParameter("@UserID", SqlDbType.Int);
            paras[0].Value = check.CheckNumber(Request.Cookies["user_id"].Value.ToString());
            paras[1] = new SqlParameter("@title", SqlDbType.NVarChar, 50);
            paras[1].Value = check.CheckInput(txtTitle.Text);
            paras[2] = new SqlParameter("@PostDate", SqlDbType.SmallDateTime);
            paras[2].Value = DateTime.Now.ToString();
            paras[3] = new SqlParameter("@enddate", SqlDbType.SmallDateTime);
            paras[3].Value = check.CheckInput(BasicDatePicker1_TextBox.Value);
            paras[4] = new SqlParameter("@yunjialeixing", SqlDbType.Int);
            paras[4].Value = 9;
            paras[5] = new SqlParameter("@hangxianmiaoshu", SqlDbType.NVarChar, 255);
            paras[5].Value = check.CheckInput(DropDownList1.SelectedValue);
            paras[6] = new SqlParameter("@StartPort", SqlDbType.NVarChar, 50);
            paras[6].Value = check.CheckInput(txtStart.Text.Replace("'", "''"));
            paras[7] = new SqlParameter("@DestPort", SqlDbType.NVarChar);
            paras[7].Value = "";
            paras[8] = new SqlParameter("@zhuangxiangchangdi", SqlDbType.NVarChar);
            paras[8].Value = "";
            paras[9] = new SqlParameter("@baozhuangyaoqiu", SqlDbType.NVarChar);
            paras[9].Value = "";
            paras[10] = new SqlParameter("@PriceDesc", SqlDbType.NText);
            paras[10].Value = "";
            paras[11] = new SqlParameter("@memo", SqlDbType.NText);
            paras[11].Value = text.Replace("'", "''");
            paras[12] = new SqlParameter("@fujiandizhi", SqlDbType.NVarChar);
            paras[12].Value = "";
            paras[13] = new SqlParameter("@ifpass", SqlDbType.Int);
            paras[13].Value = 0;
            paras[14] = new SqlParameter("@hits", SqlDbType.Int);
            paras[14].Value = 0;
            paras[15] = new SqlParameter("@OnTop", SqlDbType.Int);
            paras[15].Value = 0;
            paras[16] = new SqlParameter("@supportspecial", SqlDbType.Bit);
            paras[16].Value = false;
            paras[17] = new SqlParameter("@specialdesc", SqlDbType.NVarChar);
            paras[17].Value = "";
            paras[18] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
            paras[18].Value = "";
            paras[19] = new SqlParameter("@CompanyAddr", SqlDbType.NVarChar);
            paras[19].Value = "";
            paras[20] = new SqlParameter("@CompanyPhone", SqlDbType.NVarChar);
            paras[20].Value = "";
            paras[21] = new SqlParameter("@CompanyFax", SqlDbType.NVarChar);
            paras[21].Value = "";
            paras[22] = new SqlParameter("@CommuPerson", SqlDbType.NVarChar);
            paras[22].Value = "";
            paras[23] = new SqlParameter("@email", SqlDbType.NVarChar);
            paras[23].Value = "";
            paras[24] = new SqlParameter("@mobile", SqlDbType.NVarChar);
            paras[24].Value = "";
            paras[25] = new SqlParameter("@entitle", SqlDbType.NVarChar, 200);
            paras[25].Value = check.CheckInput(txtTitle.Text);
            paras[26] = new SqlParameter("@enmemo", SqlDbType.NText);
            paras[26].Value = check.CheckInput(txtRemark.Value);
            paras[27] = new SqlParameter("@ifen", SqlDbType.Int);
            paras[27].Value = 1;
            paras[28] = new SqlParameter("@id", SqlDbType.Int);
            paras[28].Direction = ParameterDirection.Output;


            int id = Convert.ToInt32(ExecoutID("UP_brand_add", paras));

            string strsubmit = hidsubmit.Value;
            string[] strarray = Regex.Split(strsubmit, "sdfgyuio", new RegexOptions());

            int i;
            data_conn3 data_conn = new data_conn3();
            SqlConnection conn = new SqlConnection();
            conn = data_conn.mdb_conn();
            conn.Open();
            string value;
            string strSQL = "";
            string[] strrow = new string[strarray.Length];
            for (i = 0; i < strarray.Length - 1; i++)
            {
                if (strarray[i] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
                {
                    strrow = Regex.Split(strarray[i], "qwerhjkl", RegexOptions.IgnoreCase);
                    value = check.CheckNumber(id.ToString()) + ",'" + check.CheckInput(strrow[0]) + "','" + check.CheckInput(strrow[1]) + "','" + check.CheckInput(strrow[2]) + "','" + check.CheckInput(strrow[3]) + "','" + check.CheckInput(strrow[4]) + "','" + check.CheckInput(strrow[5]) + "','" + check.CheckInput(strrow[6]) + "','" + check.CheckInput(strrow[7]) + "','" + check.CheckInput(txtTitle.Text) + "','" + check.CheckInput(txtStart.Text) + "','" + DateTime.Now + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "',8,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Request.Cookies["user_id"].Value.ToString()) + ",'" + check.CheckInput(txtTitle.Text) + "',1";

                    strSQL += "insert into TB_YunJiaInfo (YunJiaID,DestPort,pricegpv,pricegp,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,entitlex,ifEnx) values (" + value + ");";
                }
            }


            strSQL += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow[0]) + "',pricegpv1='" + check.CheckInput(strrow[1]) + "',pricegp1='" + check.CheckInput(strrow[2]) + "',shipcompany1='" + check.CheckInput(strrow[6]) + "' where id=" + id.ToString() + ";";
            strSQL += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.lclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (tb_yunjia.yunjialeixing = 9) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where (TB_PRICECOUNT.cid = 1);";

            SqlCommand myCommand1 = new SqlCommand(strSQL, conn);
            myCommand1.ExecuteNonQuery();
            conn.Close();
            topnew tp = new topnew();

            tp.SetTopNew(id.ToString(), check.CheckInput(txtTitle.Text), DateTime.Now.ToString(), "9", check.CheckInput(DropDownList1.Text), check.CheckInput(txtStart.Text.Replace("'", "''")), check.CheckNumber(Request.Cookies["user_id"].Value.ToString()));


            //Response.Redirect("office_lcl_list.aspx");


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
