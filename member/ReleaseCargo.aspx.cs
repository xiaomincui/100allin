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

public partial class member_temp_add_air : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
        }
    }

    public void load()
    {
        data_conn cn = new data_conn();





        if (this.Request["id"] != null)
        {
            if (this.Request["id"].ToString() != "")
            {



                





            }
        }

        //this.Response.Redirect("../search/err.aspx");

    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        if (this.Request["id"] != null)
        {
            if (this.Request["id"].ToString() != "")
            {
                update();
            }
            else
            {
                //this.Response.Write("insert");
                insert();
            }

        }
        else
        {
            insert();
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

    public void insert()
    {
        check ck = new check();
        

    }


    public void update()
    {
        
    }

    public int tureToInt(bool t)
    {
        if (t)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string title = ck.CheckInput(Text1.Value);
        string text = ck.CheckSqlWords(this.content.Value);
        text = text.Replace("'", "''");
        text = text.Replace("\r", "<br>");
        text = text.Replace("[img]", "<img src=\"");
        text = text.Replace("[/img]", "\" onerror=\"showerrimg(this);\"  />");
        text = text.Replace("[flash]", "<embed src=\"");
        text = text.Replace("[/flash]", "\"  type=\"application/x-shockwave-flash\" width=\"450\" height=\"390\"></embed>");
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
        //else if (text.Length > 4000)
        //{
        //    MessageBox("", "正文不能超过4000个字符");
        //    //Label2.Text = "正文不能超过4000个字符";
        //}
        else
        {

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



            int setinsert = 0;

            string[] k;
            k = new string[20];

            k[0] = "机票|查询";
            k[1] = "航空|电话";
            k[2] = "航空|官";
            k[3] = "航空|改签";
            k[4] = "訂票";
            k[5] = "航空|服务";
            k[6] = "机票";
            k[7] = "订票";
            k[8] = "機票";
            k[9] = "航空|電話";
            k[10] = "航|电话";



            for (int i = 0; i < k.Length - 1; i++)
            {                
                if (k[i] != null)
                {
                    setinsert = 0;
                    string[] m;
                    m = k[i].Split('|');
                    for (int j = 0; j < m.Length; j++)
                    {
                        Response.Write(m[j]);
                        if (title.ToLower().Contains(m[j]) == false)
                        {
                            setinsert = 1;
                            //Response.Write("不中");
                        }
                        else
                        {
                            
                            //Response.Write("中");
                        }
                    }
                    if (setinsert == 0)
                    {
                        //Response.Write("全中");
                        break;
                    }
                }
            }

            if (setinsert == 1)
            {
            	cn.mdb_exe("insert into TB_BBS (UserID,title,Data,PostDate,UpdateDate,types,ifvideo,ifimg) values (" + this.Request.Cookies["user_id"].Value + ",'" + title + "','" + text + "',getdate(),getdate(),6," + ifvideo + "," + ifimg + ")");
            }







            Session["post"] = "";
            this.Response.Redirect("cargolist.aspx");

        }
    }
}
