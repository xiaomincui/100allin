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
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public partial class bbs_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        check ck = new check();

        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select TB_Message.*,UserName,UserPassword from TB_Message,TB_User where TB_Message.Userid=TB_User.Userid and TB_Message.id=" + ck.CheckNumber(this.Request["id"]), "table");

            DataSet dstype = cn.mdb_ds("select TB_BBSList.id,TB_BBSList.name from TB_BBS,TB_BBSList where TB_BBS.types=TB_BBSList.id and TB_BBS.id=" + ds.Tables["table"].Rows[0]["BBSID"].ToString(), "type");

            

            //if (ds.Tables["table"].Rows[0]["UserID"].ToString() == Request.Cookies["user_id"].Value.ToString())
            //{
            string text = ds.Tables["table"].Rows[0]["Data"].ToString().Replace("<br>", "\r");
            text = text.Replace("<img src=\"", "[img]");
            text = text.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
            text = text.Replace("<embed src=\"", "[flash]");
            text = text.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
            content.Value = text;
            //}
            //else
            //{

            //    Button1.Visible = false;
            //    Response.Write("<script>window.setTimeout('parent.history.go(-2)',5000);</script>");
            //}
        }


        LoadRecord();


        
    }

    public void LoadRecord()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        //string sql = "select TB_BBSEdit.id,TB_BBSEdit.title,TB_BBSEdit.Data, TB_User.username,TB_BBSEdit.EditTime from TB_BBSAdminIncident,TB_BBSEdit,TB_User where TB_BBSAdminIncident.id=TB_BBSEdit.IncidentID and TB_User.UserID=TB_BBSAdminIncident.AdminID and TB_BBSAdminIncident.BBSID=" + ck.CheckNumber(this.Request["id"]) + " order by TB_BBSEdit.EditTime desc";

        string sql = "select TB_MessageEdit.id,TB_MessageEdit.Data, TB_User.username,TB_MessageEdit.EditTime ";
        sql += "from TB_BBSAdminIncident,TB_MessageEdit,TB_User where TB_BBSAdminIncident.id=TB_MessageEdit.IncidentID ";
        sql += "and TB_User.UserID=TB_BBSAdminIncident.AdminID ";
        sql += "and TB_BBSAdminIncident.BBSID=" + ck.CheckNumber(this.Request["id"]) + " and types=6 order by TB_MessageEdit.EditTime desc";


        DataSet ds = cn.mdb_ds(sql, "Record");

        GridView1.DataSource = ds.Tables["Record"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
        }
    }

    
            
                
            


    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string text = ck.CheckSqlWords(this.content.Value);

        if (text == "")
        {
            MessageBox("", "正文不能为空");
            //Label2.Text = "正文不能为空";
        }

        else
        {


            string text1 = ck.CheckSqlWords(content.Value);
	    text = text.Replace("'", "''");
            text1 = text1.Replace("\r", "<br>");
            text1 = text1.Replace("[img]", "<img src=\"");
            text1 = text1.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text1 = text1.Replace("[flash]", "<embed src=\"");
            text1 = text1.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");


            
            data_conn cn = new data_conn();


            DataSet ds = cn.mdb_ds("select * from TB_Message where id=" + ck.CheckNumber(this.Request["id"]), "BBS");
            string Data = ds.Tables["BBS"].Rows[0]["Data"].ToString();
            

            cn.mdb_exe("update TB_Message set Data='" + text + "',EditDate=getdate() where id=" + ck.CheckNumber(this.Request["id"]));

            string IncidentID = mdb_exe_return("insert into TB_BBSAdminIncident (BBSID,AdminID,Meno,EditTime,Types) values (" + ck.CheckNumber(this.Request["id"]) + "," + Request.Cookies["bbsadmin_id"].Value + ",'" + this.txtMeno.Text + "',getDate(),6)");



            cn.mdb_exe("insert into TB_MessageEdit (IncidentID,Data,EditTime) values (" + IncidentID + ",'" + text + "',getDate())");
		//Response.Write("insert into TB_MessageEdit (IncidentID,Data,EditTime) values (" + IncidentID + ",'" + Data + "',getDate())");

            DataSet ds1 = cn.mdb_ds("select count(*) as count,MAX(BBSID) as BBSID from TB_Message where id<=" + ck.CheckNumber(this.Request["id"]) + " and BBSid in (select BBSID from TB_Message where id=" + ck.CheckNumber(this.Request["id"]) + ")", "table");
            //string url = "thread-" + ds.Tables["table"].Rows[0]["BBSID"] + "-" + Convert.ToString((Convert.ToInt32(ds.Tables["table"].Rows[0]["count"]) / 10) + 1) + ".html" + "#" + ck.CheckNumber(this.Request["id"]);


            this.Response.Redirect("BBSadminMessage.aspx?id=" + ds1.Tables["table"].Rows[0]["BBSID"]);



            

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

    public string mdb_exe_return(string sql)
    {
        data_conn cn = new data_conn();
        OleDbConnection connection1 = cn.mdb_conn();
        OleDbCommand command1;
        connection1.Open();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        command1 = new OleDbCommand(sql, connection1);
        command1.ExecuteNonQuery();
        command1 = new OleDbCommand("select @@identity", connection1);
        da.SelectCommand = command1;
        da.Fill(ds, "aa");
        connection1.Close();
        return ds.Tables["aa"].Rows[0][0].ToString();
    }

   

    public static string GetFirstString(string stringToSub, int length)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
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

            if (nLength > length)
            {
                isCut = true;
                break;
            }
        }
        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
    }

    public static bool IsOdd(int n)
    {
        return Convert.ToBoolean(n % 2);
    }
}
