using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// AllinFreight 的摘要说明
/// </summary>
public class AllinFreight
{
	public AllinFreight()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string[] GetFreightDetail(string ftype,string yid,string ydid)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        AllinOrder AllinOrder1 = new AllinOrder();

        yid = ck.CheckNumber(yid);
        ydid = ck.CheckNumber(ydid);

        string sql = "";

        sql = "SELECT * FROM V_POP_FCL WHERE yunjiaid = " + yid + " ";

        if (ftype == "8")
        {
            sql = "SELECT TOP 1 * FROM V_POP_FCL WHERE yunjiaid = " + yid + " ORDER BY id desc";
            if (ydid != "0")
            {
                sql = "SELECT TOP 1 * FROM V_POP_FCL WHERE id = " + ydid;
            }
        }

        if (ftype == "9")
        {
            sql = "SELECT * FROM V_POP_LCL WHERE yunjiaid = " + yid + " ORDER BY id desc";
            if (ydid != "0")
            {
                sql = "SELECT TOP 1 * FROM V_POP_LCL WHERE id = " + ydid;
            }
        }

        if (ftype == "10")
        {
            sql = "SELECT * FROM V_POP_AIR WHERE yunjiaid = " + yid + " ORDER BY id desc";
            if (ydid != "0")
            {
                sql = "SELECT TOP 1 * FROM V_POP_AIR WHERE id = " + ydid;
            }
        }

        ds = cn.mdb_ds(sql, "yunjia");

        //HttpContext.Current.Response.Write(sql);

        string[] k;
        k = new string[100];
        if (ds.Tables["yunjia"].Rows.Count > 0)
        {
            k[0] = ds.Tables["yunjia"].Rows[0]["yunjiaid"].ToString(); //运价编号
            k[1] = ds.Tables["yunjia"].Rows[0]["id"].ToString(); //运价详情编号
            k[2] = ds.Tables["yunjia"].Rows[0]["hangxianmiaoshu"].ToString(); //航线描述
            k[3] = ds.Tables["yunjia"].Rows[0]["startport"].ToString(); //启运港
            k[4] = ds.Tables["yunjia"].Rows[0]["destport"].ToString(); //目的港
            k[5] = ds.Tables["yunjia"].Rows[0]["postdate"].ToString(); //发布日期
            k[6] = ds.Tables["yunjia"].Rows[0]["enddate"].ToString(); //结束日期
            k[7] = ds.Tables["yunjia"].Rows[0]["title"].ToString(); //运价标题
            k[8] = ds.Tables["yunjia"].Rows[0]["companyname"].ToString(); //公司名称
            k[9] = ds.Tables["yunjia"].Rows[0]["realname"].ToString(); //真实姓名
            k[10] = ds.Tables["yunjia"].Rows[0]["userid"].ToString(); //真实姓名
            k[11] = ds.Tables["yunjia"].Rows[0]["star_allin"].ToString(); //安运通级别
            k[12] = ds.Tables["yunjia"].Rows[0]["star_user"].ToString(); //保障级别
            k[13] = ds.Tables["yunjia"].Rows[0]["assurance"].ToString(); //舱位保证数据
            k[14] = AllinOrder1.GetAllinStar(ds.Tables["yunjia"].Rows[0]["star_allin"].ToString()); //安运通级别标记
            k[15] = AllinOrder1.GetUserStar(ds.Tables["yunjia"].Rows[0]["star_user"].ToString()); //保障级别标记
            k[16] = AllinOrder1.GetAssuranceSpace(ds.Tables["yunjia"].Rows[0]["assurance"].ToString()); //舱位保证标记
            k[17] = AllinOrder1.GetAssurancePrice(ds.Tables["yunjia"].Rows[0]["star_allin"].ToString()); //价格保证标记
            k[18] = "<a href=\"/company/" + SetKey(ds.Tables["yunjia"].Rows[0]["userid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["yunjia"].Rows[0]["companyname"].ToString() + "</a>"; //公司链接
            k[19] = "<a href=\"/company/" + SetKey(ds.Tables["yunjia"].Rows[0]["userid"].ToString()) + "/\" target=\"_blank\">" + AllinOrder1.GetAllinStar(ds.Tables["yunjia"].Rows[0]["star_allin"].ToString()) + "</a>"; //安运通级别标记（带链接）
            k[20] = "<a href=\"/company/" + SetKey(ds.Tables["yunjia"].Rows[0]["userid"].ToString()) + "/\" target=\"_blank\">" + AllinOrder1.GetUserStar(ds.Tables["yunjia"].Rows[0]["star_user"].ToString()) + "</a>"; //保障级别标记（带链接）


            k[30] = ds.Tables["yunjia"].Rows[0]["price20gp"].ToString(); //20尺柜价格
            k[31] = ds.Tables["yunjia"].Rows[0]["price40gp"].ToString(); //40尺柜价格
            k[32] = ds.Tables["yunjia"].Rows[0]["price40hq"].ToString(); //40尺高柜价格
            k[33] = ds.Tables["yunjia"].Rows[0]["price45hq"].ToString(); //45尺高柜价格
            k[34] = ds.Tables["yunjia"].Rows[0]["shipcompany"].ToString(); //船公司
            k[35] = "<a href=\"/fcl/" + SetKey(ds.Tables["yunjia"].Rows[0]["yunjiaid"].ToString()) + "_" + ds.Tables["yunjia"].Rows[0]["id"].ToString() + ".html\" target=\"_blank\">" + ds.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>"; //运价链接
            k[36] = ds.Tables["yunjia"].Rows[0]["price20gpappend"].ToString();//附加费价格

            k[40] = ds.Tables["yunjia"].Rows[0]["pricegp"].ToString(); //20尺柜价格
            k[41] = ds.Tables["yunjia"].Rows[0]["pricegpv"].ToString(); //40尺柜价格
            k[42] = "<a href=\"/lcl/" + SetKey(ds.Tables["yunjia"].Rows[0]["yunjiaid"].ToString()) + "_" + ds.Tables["yunjia"].Rows[0]["id"].ToString() + ".html\" target=\"_blank\">" + ds.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>"; //运价链接

            k[50] = ds.Tables["yunjia"].Rows[0]["PRICE_M"].ToString(); //20尺柜价格
            k[51] = ds.Tables["yunjia"].Rows[0]["PRICE_N"].ToString(); //40尺柜价格
            k[52] = ds.Tables["yunjia"].Rows[0]["PRICE_P45"].ToString(); //40尺柜价格
            k[53] = ds.Tables["yunjia"].Rows[0]["PRICE_P100"].ToString(); //40尺柜价格
            k[54] = ds.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString(); //40尺柜价格
            k[55] = ds.Tables["yunjia"].Rows[0]["PRICE_P500"].ToString(); //40尺柜价格
            k[56] = ds.Tables["yunjia"].Rows[0]["PRICE_P1000"].ToString(); //40尺柜价格
            k[57] = "<a href=\"/air/" + SetKey(ds.Tables["yunjia"].Rows[0]["yunjiaid"].ToString()) + "_" + ds.Tables["yunjia"].Rows[0]["id"].ToString() + ".html\" target=\"_blank\">" + ds.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>"; //运价链接
        
        }
        return k;
    }//取得运价详细信息


    public void SetFreightViewrecord(string type,string yid,string ydid)
    {
        try
        {
            GetRequest GetRequest1 = new GetRequest();
            check ck = new check();
            data_conn cn = new data_conn();
            string userid = GetRequest1.GetRequestCookies("user_id", "0");

            if (userid != "0")
            {
                string address = HttpContext.Current.Request.UserHostAddress;
                string sql = "";
                sql += "INSERT INTO TB_FREIGHT_VIEWRECORD (userid,userip,freight_type,freight_code,freight_code1) VALUES (" + userid + ",'" + address + "'," + type + "," + yid + ", '" + ydid + "')";

                string agent = "";
                agent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

                string[] k;
                k = new string[10];

                int ifbot = 0;

                k[0] = "spider";
                k[1] = "bot";
                k[2] = "slurp";
                k[3] = "pirst";
                k[4] = "wget";
                k[5] = "oray";
                k[6] = "nutch";

                for (int i = 0; i < k.Length - 1; i++)
                {
                    if (k[i] != null)
                    {
                        if (agent.ToLower().Contains(k[i]))
                        {
                            ifbot = 1;
                        }
                    }
                }

                if (ifbot == 0)
                {
                    cn.mdb_exe(sql);
                }
            }


        }
        catch
        { 
        
        }
    }

    public void SetFreightViewrecord2(string type, string yid, string ydid,string yuserid)
    {
        try
        {
            GetRequest GetRequest1 = new GetRequest();
            check ck = new check();
            data_conn cn = new data_conn();
            string userid = GetRequest1.GetRequestCookies("user_id", "0");

            string address = HttpContext.Current.Request.UserHostAddress;
            string sql = "";

            if (userid != "0")
            {
                sql += "INSERT INTO TB_FREIGHT_VIEWRECORD (userid,userip,freight_type,freight_code,freight_code1,yuserid) VALUES (" + userid + ",'" + address + "'," + type + "," + yid + ", '" + ydid + "'," + yuserid + ")";
            }
            else
            {
                sql += "INSERT INTO TB_FREIGHT_VIEWRECORD (userid,userip,freight_type,freight_code,freight_code1,yuserid) VALUES (0,'" + address + "'," + type + "," + yid + ", '" + ydid + "'," + yuserid + ")";
            }


            string agent = "";
            agent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

            string[] k;
            k = new string[10];

            int ifbot = 0;

            k[0] = "spider";
            k[1] = "bot";
            k[2] = "slurp";
            k[3] = "pirst";
            k[4] = "wget";
            k[5] = "oray";
            k[6] = "nutch";

            for (int i = 0; i < k.Length - 1; i++)
            {
                if (k[i] != null)
                {
                    if (agent.ToLower().Contains(k[i]))
                    {
                        ifbot = 1;
                    }
                }
            }

            if (ifbot == 0)
            {
                cn.mdb_exe(sql);
            }

            
        }
        catch
        {

        }
    }

    public string SetKey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }//获得密钥
}
