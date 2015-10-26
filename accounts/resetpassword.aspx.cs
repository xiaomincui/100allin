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

public partial class accounts_resetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["u"] == null)
        {
            throw new Exception();
        }
        else
        {
            if (this.Request["u"].ToString() == "")
            {
                throw new Exception();
            }
            else
            {

                if (this.Request["p"] == null)
                {
                    throw new Exception();
                }
                else
                {
                    if (this.Request["p"].ToString() == "")
                    {
                        throw new Exception();
                    }
                    else
                    {
                        data_conn cn = new data_conn();
                        check ck = new check();
                        DataSet ds = cn.mdb_ds("select * from TB_User where username='" + ck.CheckInput(Request["u"].ToString()) + "'", "user");
                        if (MD5(MD5(ds.Tables["user"].Rows[0]["UserPassword"].ToString() + DateTime.Today.ToString())) == Request["p"].ToString())
                        //if (ds.Tables["user"].Rows[0]["UserPassword"].ToString() + DateTime.Today.ToString() == Request["p"].ToString())
                        {

                        }
                        else
                        {
                            //Response.Write(MD5(MD5(ds.Tables["user"].Rows[0]["UserPassword"].ToString() + DateTime.Today.ToString())));
                            throw new Exception();
                        }
                    }
                }
            }
        }
    }


    public string MD5(string str)
    {
        Byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = "";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Text1.Value.Length >= 6 && Text1.Value.Length <= 15)
        {
            if (Text1.Value == Text2.Value)
            {
                check ck = new check();
                data_conn cn = new data_conn();
                cn.mdb_exe("update TB_User set UserPassword='" + ck.CheckInput(Text1.Value) + "' where userid = (select userid from TB_User where username='" + Request["u"].ToString() + "')");
                Response.Redirect("resetpasswordsuccess.aspx");
            }
            else
            {
                MessageBox("", "密码长度在6～15个字符之间");
            }
        }
        else
        {
            MessageBox("", "密码长度在6～15个字符之间");
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
}
