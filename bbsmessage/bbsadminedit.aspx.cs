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
            DataSet ds = cn.mdb_ds("select TB_BBS.*,UserName,UserPassword,TB_BBSList.id as typeID,TB_BBSList.name from TB_BBS,TB_User,TB_BBSList where TB_BBS.Userid=TB_User.Userid and TB_BBSList.id=TB_BBS.types and TB_BBS.id=" + ck.CheckNumber(this.Request["id"]), "table");



            
            
            //if (ds.Tables["table"].Rows[0]["UserID"].ToString() == Request.Cookies["user_id"].Value.ToString())
            //{
                string text1 = ds.Tables["table"].Rows[0]["Data"].ToString().Replace("<br>", "\r");
                text1 = text1.Replace("<img src=\"", "[img]");
                text1 = text1.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text1 = text1.Replace("<embed src=\"", "[flash]");
                text1 = text1.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                content.Value = text1;
                string text2 = ds.Tables["table"].Rows[0]["title"].ToString().Replace("<br>", "\r");
                text2 = text2.Replace("&nbsp", " ");
                text2 = text2.Replace("<img src=\"", "[img]");
                text2 = text2.Replace("\" onerror=\"showerrimg(this);\"  />", "[/img]");
                text2 = text2.Replace("<embed src=\"", "[flash]");
                text2 = text2.Replace("\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>", "[/flash]");
                Text1.Value = text2;
            //}
            //else
            //{
            //    Button1.Visible = false;
            //    //TextBox1.Text = "对不起，您只能修改自己发表的贴子";
            //    Response.Write("<script>window.setTimeout('parent.history.go(-1)',5000);</script>");

            //}
        }

        LoadRecord();
    }

    public void LoadRecord()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "select TB_BBSEdit.id,TB_BBSEdit.title,TB_BBSEdit.Data, TB_User.username,TB_BBSEdit.EditTime from TB_BBSAdminIncident,TB_BBSEdit,TB_User where TB_BBSAdminIncident.id=TB_BBSEdit.IncidentID and TB_User.UserID=TB_BBSAdminIncident.AdminID and TB_BBSAdminIncident.BBSID=" + ck.CheckNumber(this.Request["id"]) + " and Types=5 order by TB_BBSEdit.EditTime desc";
        
        DataSet ds = cn.mdb_ds(sql, "Record");

        GridView1.DataSource = ds.Tables["Record"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");
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
            


    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string text = ck.CheckSqlWords(this.content.Value);

        if (text == "")
        {
            MessageBox("", "正文不能为空");
            //Label2.Text = "正文不能为空";
        }
        else if (Text1.Value == "")
        {
            MessageBox("", "标题不能为空");
            //Label2.Text = "标题不能为空";
        }
        else if (Text1.Value.Length > 50)
        {
            MessageBox("", "标题不能超过50个字符");
            //Label2.Text = "标题不能超过50个字符";
        }

        else
        {


            string text1 = ck.CheckSqlWords(content.Value);
            text = text.Replace("'", "''");

text1 = text1.Replace("Times New Roman", " ");
text1 = text1.Replace("'", "''");
            text1 = text1.Replace("\r", "<br>");
            text1 = text1.Replace("[img]", "<img src=\"");
            text1 = text1.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text1 = text1.Replace("[flash]", "<embed src=\"");
            text1 = text1.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");


            string text2 = ck.CheckInput(Text1.Value);

            text2 = text2.Replace("\r", "<br>");
            text2 = text2.Replace(" ", "&nbsp");
            text2 = text2.Replace("[img]", "<img src=\"");
            text2 = text2.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
            text2 = text2.Replace("[flash]", "<embed src=\"");
            text2 = text2.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
            data_conn cn = new data_conn();

            string ifvideo = "0";
            string ifimg = "0";


            if (text.IndexOf("<embed") != -1 || text.IndexOf("<EMBED") != -1)
            {
                ifvideo = "1";
            }

            if (text.IndexOf("<img") != -1 || text.IndexOf("<IMG") != -1)
            {
                ifimg = "1";
            }

            DataSet ds = cn.mdb_ds("select * from TB_BBS where id=" + ck.CheckNumber(this.Request["id"]), "BBS");
            string Data = ds.Tables["BBS"].Rows[0]["Data"].ToString();
		Data = Data.Replace("'", "''");
            string title = ds.Tables["BBS"].Rows[0]["title"].ToString();


            cn.mdb_exe("update TB_BBS set Data='" + text1 + "',title='" + text2 + "',EditDate=getdate(),ifvideo=" + ifvideo + ",ifimg=" + ifimg + " where id=" + ck.CheckNumber(this.Request["id"]));
		



            string IncidentID = mdb_exe_return("insert into TB_BBSAdminIncident (BBSID,AdminID,Meno,EditTime,Types) values (" + ck.CheckNumber(this.Request["id"]) + "," + Request.Cookies["bbsadmin_id"].Value + ",'" + this.txtMeno.Text + "',getDate(),5)");

		//Response.Write("insert into TB_BBSEdit (IncidentID,title,Data,EditTime) values (" + IncidentID + ",'" + title + "','" + Data + "',getDate())");

            cn.mdb_exe("insert into TB_BBSEdit (IncidentID,title,Data,EditTime) values (" + IncidentID + ",'" + title + "','" + Data + "',getDate())");

            
            this.Response.Redirect("BBSadminMessage.aspx?id=" + ck.CheckNumber(this.Request["id"]));



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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
        }
    }
}


