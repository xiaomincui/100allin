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

public partial class waysglobal_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        //string sql = "SELECT distinct yunjiaid,destport FROM TB_yunjiainfo WHERE yunjiaid = (select top 1 id from TB_Yunjia WHERE userid = 73066 order by id desc) ORDER BY destport ";
        //DataSet ds = cn.mdb_ds(sql, "waysyunjia");
        //Repeater1.DataSource = ds.Tables["waysyunjia"].DefaultView;
        //Repeater1.DataBind();

        string sql = "";
        DataSet ds = new DataSet(); 
        sql = "select * from TB_Yunjia WHERE userid = 73066 ORDER BY postdate desc,id desc ";

        ds = cn.mdb_ds(sql, "waysyunjia");
        Rptfcl.DataSource = ds.Tables["waysyunjia"].DefaultView;
        Rptfcl.DataBind();

        if (Page.IsPostBack != true)
        {
            PageRecord();
        }
    }

    protected void Rptfcl_ItemDataBound(object sender, EventArgs e)
    {
        check ck = new check();
        if (Rptfcl.Items.Count != 0)
        {
            DataSet ds;
            data_conn conn = new data_conn();
            Literal a;

            a = (Literal)Rptfcl.Items[0].FindControl("Literal1");
            string ids = a.Text;
            for (int i = 1; i < Rptfcl.Items.Count; i++)
            {
                a = (Literal)Rptfcl.Items[i].FindControl("Literal1");
                ids += "," + a.Text;
            }
            ds = conn.mdb_ds("select YunJiaID,DESTPORT,price20gp,price40gp,price40hq,price45hq,shipcompany from TB_YunJiaInfo where useridx = 73066 and YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table");

            //Response.Write("select YunJiaID,DESTPORT,price20gp,price40gp,price40hq,price45hq,shipcompany from TB_YunJiaInfo where userid = 73066 and YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT");
            string str = "";
            for (int i = 0; i < Rptfcl.Items.Count; i++)
            {
                string point = "";

                int count;
                a = (Literal)Rptfcl.Items[i].FindControl("Literal1");
                if (ds.Tables["table"].Select("YunJiaID=" + a.Text).Length > 10)
                {
                    count = 9;
                    point = "$$......######";
                }
                else
                {
                    count = ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1;
                }
                for (int j = 0; j < count + 1; j++)
                {

                    for (int k = 1; k < 7; k++)
                    {
                        str += ds.Tables["table"].Select("YunJiaID=" + a.Text)[j].ItemArray[k].ToString();
                        if (k != 6)
                        {
                            str += "##";
                        }
                    }
                    if (j != ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1)
                    {
                        str += "$$";
                    }
                }
                str += point;
                if (i != Rptfcl.Items.Count - 1)
                {
                    str += "**";
                }
            }
            Hidden1.Value = str;
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            a = (Literal)Rptfcl.Items[0].FindControl("Literal2");
            ids = a.Text;
            for (int i = 1; i < Rptfcl.Items.Count; i++)
            {
                a = (Literal)Rptfcl.Items[i].FindControl("Literal2");
                ids += "," + a.Text;
            }
            ds = conn.mdb_ds("select CompanyName,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,UserID from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table");
            str = "";
            for (int i = 0; i < Rptfcl.Items.Count; i++)
            {
                string point = "";
                int j;
                int count;
                a = (Literal)Rptfcl.Items[i].FindControl("Literal2");
                if (ds.Tables["table"].Select("UserID=" + a.Text).Length == 1)
                {
                    str += "公司名称" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[0].ToString();
                    str += "$$";
                    str += "电话号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[1].ToString();
                    str += "$$";
                    str += "传真号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[2].ToString();
                    str += "$$";
                    str += "手机号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[3].ToString();
                    str += "$$";
                    str += "MSN" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[4].ToString();
                    str += "$$";
                    str += "QQ" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[5].ToString();
                    str += "$$";
                    str += "电子邮箱" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[6].ToString();
                }

                if (i != Rptfcl.Items.Count - 1)
                {
                    str += "**";
                }
            }
            Hiddennn1.Value = str;
        }
    }

    void PageRecord()
    {
        check ck = new check();
        string request;
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            request = "";
        }
        else
        {
            request = Request.ServerVariables["HTTP_REFERER"].ToString();
            request = ck.CheckRecord(request);
        }

        string page = Request.Url.ToString();
        page = ck.CheckRecord(page);

        string pagefile = Request.Url.AbsolutePath.ToString();
        pagefile = ck.CheckRecord(pagefile);




        string pagesql = "select pagearea from TB_PageArea where pageaddress = '" + pagefile + "'";
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(pagesql, "TB_PageArea");


        string pagearea = "";

        if (ds.Tables["TB_PageArea"].Rows.Count > 0)
        {
            pagearea = ds.Tables["TB_PageArea"].Rows[0][0].ToString();
        }



        string address = Page.Request.UserHostAddress;
        string address1 = Page.Request.UserHostAddress;


        if (this.Request.Cookies["user_id"] == null)
        {
            string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
            cn.mdb_exe(sql);

        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
            else
            {
                string a = this.Request.Cookies["user_id"].Value;
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (" + this.Request.Cookies["user_id"].Value + ",'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
        }

        try
        {
            if (this.Request.Cookies["user_id"] == null)
            {
                string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);

            }
            else
            {
                if (this.Request.Cookies["user_id"].Value == "")
                {
                    string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                    cn.mdb_exe(sql);
                }
                else
                {
                    string a = this.Request.Cookies["user_id"].Value;
                    string sql = "insert into TB_BrowseRecord_New (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (" + this.Request.Cookies["user_id"].Value + ",'" + IPAddress + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                    cn.mdb_exe(sql);
                }
            }
        }
        catch
        {

        }
    }

    public static string IPAddress
    {
        get
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1) //没有"."肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("\"", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                            && temparyip[i].Substring(0, 3) != "10."
                            && temparyip[i].Substring(0, 7) != "192.168"
                            && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i]; //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null; //代理中的内容 非IP，取IP 
                }
            }
            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null &&

            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ?

            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables

            ["REMOTE_ADDR"];
            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }
    }

    public static bool IsIPAddress(string str1)
    {
        if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
        string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
        Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
        return regex.IsMatch(str1);
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

}
