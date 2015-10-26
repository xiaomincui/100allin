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
                if (Convert.ToInt32(ds2.Tables["table"].Rows[0]["User_Level"].ToString()) == 0)
                {
                    Response.Redirect("../accounts/regnormal.aspx");
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
            if (strsubmitrow[k].Substring(0, 8) == "qwerhjkl" && strsubmitrow[k] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
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
            //try
            //{
            string text = txtRemark.Value;
            text = text.Replace("\n", "<br>");
            text = text.Replace(" ", "&nbsp");
            SqlParameter[] paras = new SqlParameter[21];


            paras[0] = new SqlParameter("@PostDate", SqlDbType.SmallDateTime);
            paras[0].Value = DateTime.Now.ToString();
            paras[1] = new SqlParameter("@DestPort", SqlDbType.NVarChar);
            paras[1].Value = "";
            paras[2] = new SqlParameter("@StartPort", SqlDbType.NVarChar);
            paras[2].Value = check.CheckInput(txtStart.Text);
            paras[3] = new SqlParameter("@enddate", SqlDbType.NVarChar);
            paras[3].Value = check.CheckInput(BasicDatePicker1_TextBox.Value);
            paras[4] = new SqlParameter("@memo", SqlDbType.NText);
            paras[4].Value = text.Replace("'", "''");
            paras[5] = new SqlParameter("@COMPANY", SqlDbType.NVarChar);
            paras[5].Value = "";
            paras[6] = new SqlParameter("@AIRCOMPANY", SqlDbType.NVarChar);
            paras[6].Value = "";
            paras[7] = new SqlParameter("@UserID", SqlDbType.Int);
            paras[7].Value = check.CheckNumber(Request.Cookies["user_id"].Value.ToString());
            paras[8] = new SqlParameter("@title", SqlDbType.NVarChar, 50);
            paras[8].Value = check.CheckInput(txtTitle.Text);
            paras[9] = new SqlParameter("@attach", SqlDbType.NVarChar, 50);
            paras[9].Value = "";
            paras[10] = new SqlParameter("@hits", SqlDbType.Int);
            paras[10].Value = 0;
            paras[11] = new SqlParameter("@LINE", SqlDbType.NVarChar, 50);
            paras[11].Value = check.CheckInput(DropDownList1.Text);
            paras[12] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
            paras[12].Value = "";
            paras[13] = new SqlParameter("@CompanyAddr", SqlDbType.NVarChar);
            paras[13].Value = "";
            paras[14] = new SqlParameter("@CompanyPhone", SqlDbType.NVarChar);
            paras[14].Value = "";
            paras[15] = new SqlParameter("@CompanyFax", SqlDbType.NVarChar);
            paras[15].Value = "";
            paras[16] = new SqlParameter("@CommuPerson", SqlDbType.NVarChar);
            paras[16].Value = "";
            paras[17] = new SqlParameter("@email", SqlDbType.NVarChar);
            paras[17].Value = "";
            paras[18] = new SqlParameter("@mobile", SqlDbType.NVarChar);
            paras[18].Value = "";
            paras[19] = new SqlParameter("@UserID2", SqlDbType.Int);
            paras[19].Value = "0";
            paras[20] = new SqlParameter("@id", SqlDbType.Int);
            paras[20].Direction = ParameterDirection.Output;


            int id = Convert.ToInt32(ExecoutID("Air_UP_brand_add", paras));

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
                if (strarray[i] != "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl")
                {
                    strrow = Regex.Split(strarray[i], "qwerhjkl", RegexOptions.IgnoreCase);
                    if (strrow[3] == "" && strrow[4] == "" && strrow[5] == "" && strrow[6] == "" && strrow[7] == "")
                    {
                        strrow[5] = "cable";
                    }

                    value = check.CheckNumber(id.ToString()) + ",'" + check.CheckInput(strrow[0]) + "','" + check.CheckInput(strrow[1]) + "','" + check.CheckInput(strrow[2]) + "','" + check.CheckInput(strrow[3]) + "','" + check.CheckInput(strrow[4]) + "','" + check.CheckInput(strrow[5]) + "','" + check.CheckInput(strrow[6]) + "','" + check.CheckInput(strrow[7]) + "','" + check.CheckInput(strrow[8]) + "','" + check.CheckInput(strrow[9]) + "','" + check.CheckInput(strrow[10]) + "','" + check.CheckInput(strrow[11]) + "','" + check.CheckInput(txtTitle.Text) + "','" + check.CheckInput(txtStart.Text) + "','" + DateTime.Now + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "','" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Request.Cookies["user_id"].Value.ToString());

                    strSQL += "insert into T_AIRPRICE (AIRID,DestPort,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,price20gpAppend,Distance,DepartureWkd,memo,Titlex,StartPortx,PostDatex,enddatex,linex,UserIDx) values (" + value + ");";
                }
            }


            strSQL += "update T_AIRINFO set DestPort1='" + check.CheckInput(strrow[0]) + "',PRICE_M1='" + check.CheckInput(strrow[1]) + "',PRICE_N1='" + check.CheckInput(strrow[2]) + "',PRICE_P451='" + check.CheckInput(strrow[3]) + "',PRICE_P1001='" + check.CheckInput(strrow[4]) + "',PRICE_P3001='" + check.CheckInput(strrow[5]) + "',PRICE_P5001='" + check.CheckInput(strrow[6]) + "',PRICE_P10001='" + check.CheckInput(strrow[7]) + "' where id=" + id.ToString() + ";";
            strSQL += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1";
            SqlCommand myCommand1 = new SqlCommand(strSQL, conn);
            myCommand1.ExecuteNonQuery();
            conn.Close();
            topnew tp = new topnew();


            tp.SetTopNew(id.ToString(), check.CheckInput(txtTitle.Text), DateTime.Now.ToString(), "10", check.CheckInput(DropDownList1.Text), check.CheckInput(txtStart.Text.Replace("'", "''")), check.CheckNumber(Request.Cookies["user_id"].Value.ToString()));

            //Server.Transfer("ReleaseSucceed.aspx?id=" + id.ToString() + "&type=1");
            Server.Transfer("office_air_list.aspx");


        }
    }


}
