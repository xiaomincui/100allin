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
using System.Xml;

public partial class accounts_refill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadMessage();
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {
                Literal1.Text = "";
                ImageButton1.Visible = true;
            }
            else
            {
                Literal1.Text = "<a href=\"javascript:showDiv()\"><img src=\"images/4_button.gif\" border=\"0\" /></a>";
                ImageButton1.Visible = false;
            }
        }
        else
        {
            Literal1.Text = "<a href=\"javascript:showDiv()\"><img src=\"images/4_button.gif\" border=\"0\" /></a>";
            ImageButton1.Visible = false;
        }


        if (!Page.IsPostBack)
        {




            LoadList1();
            LoadList2(0);
        }
    }
    protected void LoadList1()
    {
        ddlcity1.Items.Clear();

        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("/xml/Provinces.xml"));
        //Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes 
        XmlNodeList node = doc.SelectNodes("Provinces")[0].ChildNodes;
        for (int i = 0; i <= node.Count - 1; i++)
        {
            ListItem pp = new ListItem(node[i].InnerText, node[i].Attributes["ID"].Value);
            ddlcity1.Items.Add(pp);

        }
    }


    protected void LoadList2(int ID)
    {
        ddlcity2.Items.Clear();


        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("/xml/Cities.xml"));


        XmlNodeList node = doc.SelectNodes("Cities")[0].ChildNodes;


        string flag = null;
        for (int i = 0; i <= node.Count - 1; i++)
        {
            if (node[i].Attributes["PID"].Value == ID.ToString() | node[i].Attributes["PID"].Value == "0")
            {
                if (ddlcity2.Items.Count == 0)
                {
                    flag = node[i].Attributes["ID"].Value;
                }
                ListItem pp = new ListItem(node[i].InnerText, node[i].Attributes["ID"].Value);
                ddlcity2.Items.Add(pp);
            }

            //LoadList3(flag) 
        }
    }

    protected void LoadList3(int ID)
    {
        ddlcity3.Items.Clear();


        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("../xml/Districts.xml"));


        XmlNodeList node = doc.SelectNodes("Districts")[0].ChildNodes;



        for (int i = 0; i <= node.Count - 1; i++)
        {
            if ((node[i].Attributes["CID"].Value == ID.ToString() | node[i].Attributes["CID"].Value == "0"))
            {
                ListItem pp = new ListItem(node[i].InnerText, node[i].Attributes["ID"].Value);
                ddlcity3.Items.Add(pp);
            }
        }
        if (ddlcity3.Items.Count == 1 && ddlcity2.SelectedItem.Text != "请选择")
        {
            ddlcity3.Items.Add(ddlcity2.SelectedItem.Text);

        }
    }


    protected void ddlcity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList2(Convert.ToInt32(ddlcity1.SelectedValue));
        ddlcity1.Focus();
    }
    protected void ddlcity2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList3(Convert.ToInt32(ddlcity2.SelectedValue));
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //LoadMessage();
    }



    public void LoadMessage()
    {
        Response.Write("<div id=\"popDiv\" class=\"mydiv\" style=\"display:block;\"><font color='#FF0000'>asdfasdf：</font><b>asdfasdfasdf</b><br/>asdfasdfa<br/><br/><br/><br/>");
        Response.Write("<a href=\"javascript:closeDiv()\">[关闭窗口]</a> aasdfasdf</div>");
        Response.Write("<div id=\"bg\" class=\"bg\" style=\"display:block;\">");
        Response.Write("<iframe  style=\"position:absolute; visibility:inherit; top:0px; left:0px; width:100%; height:100%; z-index:-1; filter='progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)';\"></iframe>");
        Response.Write("</div>");



    }




    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        check ck = new check();
        string username1 = ck.CheckInput(username.Value);
        string password1 = ck.CheckInput(password.Value);
        string autologin = "1";

        if (chkAutoLogin.Checked == true)
        {
            autologin = "1";
        }
        else
        {
            autologin = "0";
        }

        if (username1 == "" && password1 == "")
        {
            MessageBox("opfail", "未填写用户名和密码");
        }
        else
        {
            if (username1 == "")
            {
                MessageBox("opfail", "未填写用户名");
            }
            if (password1 == "")
            {
                MessageBox("opfail", "未填写密码");
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "UserID,username,ifvip,ifmanage,realname,companyname,phone,useremail ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "username = '" + username1 + "' ";
        sql = sql + "AND Userpassword = '" + password1 + "' ";

        ds = cn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            string userid = ds.Tables["user"].Rows[0][0].ToString();
            string usernm = ds.Tables["user"].Rows[0][1].ToString();
            string ifvip = ds.Tables["user"].Rows[0]["ifvip"].ToString();
            string ifmanage = ds.Tables["user"].Rows[0]["ifmanage"].ToString();

            Response.Cookies["user_id"].Value = userid;
            Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);
            Response.Cookies["user_password1"].Value = password1;
            Response.Cookies["ifvip"].Value = ifvip;
            Response.Cookies["ifmanage"].Value = ifmanage;

            string realname = ds.Tables["user"].Rows[0]["realname"].ToString();
            string companyname = ds.Tables["user"].Rows[0]["companyname"].ToString();
            string phone = ds.Tables["user"].Rows[0]["phone"].ToString();
            string useremail = ds.Tables["user"].Rows[0]["useremail"].ToString();

            Response.Cookies["realname"].Value = Server.UrlEncode(realname);
            Response.Cookies["companyname"].Value = Server.UrlEncode(companyname);
            Response.Cookies["phone"].Value = Server.UrlEncode(phone);
            Response.Cookies["useremail"].Value = Server.UrlEncode(useremail);

            if (autologin == "1")
            {
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_name"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_password1"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifvip"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifmanage"].Expires = DateTime.Now.AddDays(365);

                Response.Cookies["realname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["companyname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["phone"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["useremail"].Expires = DateTime.Now.AddDays(365);
            }

            if (Request.Cookies["user_id"] != null)
            {
                if (Request.Cookies["user_id"].Value.ToString() != "")
                {
                    Literal1.Text = "";
                    ImageButton1.Visible = true;
                }
                else
                {
                    Literal1.Text = "<a href=\"javascript:showDiv()\"><img src=\"images/4_button.gif\" border=\"0\" /></a>";
                    ImageButton1.Visible = false;
                }
            }
            else
            {
                Literal1.Text = "<a href=\"javascript:showDiv()\"><img src=\"images/4_button.gif\" border=\"0\" /></a>";
                ImageButton1.Visible = false;
            }


            //Response.Redirect(Server.UrlDecode(Request.QueryString["redirect_url"]));
        }
        else
        {
            MessageBox("opfail", "用户名或密码填写错误");
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


    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        check ck = new check();
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {



                if (CompanyType.Value == "0")
                {
                    MessageBox("opfail", "公司类型为空");
                }
                else if (ddlcity1.SelectedValue == "0" || ddlcity2.SelectedValue == "0")
                {
                    MessageBox("opfail", "公司所在地为空");
                }
                else if (introduction.Value == "")
                {
                    MessageBox("opfail", "公司介绍为空");
                }
                else if (Address.Value.Length > 50)
                {
                    MessageBox("opfail", "联系地址不能大于50个字符");
                }
                else if (PostNumber.Value.Length > 50)
                {
                    MessageBox("opfail", "邮政编码不能大于50个字符");
                }
                else if (Position.Value.Length > 20)
                {
                    MessageBox("opfail", "职位不能大于20个字符");
                }
                else if (Fax.Value.Length > 50)
                {
                    MessageBox("opfail", "传真不能大于50个字符");
                }
                else if (MovePhone.Value.Length > 50)
                {
                    MessageBox("opfail", "手机不能大于50个字符");
                }
                else if (Msn.Value.Length > 50)
                {
                    MessageBox("opfail", "MSN不能大于50个字符");
                }
                else if (QQ.Value.Length > 50)
                {
                    MessageBox("opfail", "QQ不能大于50个字符");
                }
                else if (sign.Value.Length > 200)
                {
                    MessageBox("opfail", "个性签名不能大于200个字符");
                }
                else if (introduction.Value.Length > 800)
                {
                    MessageBox("opfail", "公司介绍不能大于800个字符");
                }
                else
                {
                    string sql = "";
                    sql = sql + "UPDATE ";
                    sql = sql + "TB_User ";
                    sql = sql + "SET ";

                    sql = sql + "Sex = " + RadioButtonList1.SelectedValue + ",";

                    sql = sql + "WPosition = '" + ck.CheckInput(Position.Value) + "',";

                    //sql = sql + "Phone = '" + ck.CheckInput(Phone.Value) + "',";
                    //sql = sql + "Phone2 = '" + ck.CheckInput(Phone2.Value) + "',"; 
                    sql = sql + "Fax = '" + ck.CheckInput(Fax.Value) + "',";
                    sql = sql + "MovePhone = '" + ck.CheckInput(MovePhone.Value) + "',";
                    sql = sql + "Usermsn = '" + ck.CheckInput(Msn.Value) + "',";
                    sql = sql + "Userqq = '" + ck.CheckInput(QQ.Value) + "',";
                    sql = sql + "sign = '" + ck.CheckInput(sign.Value) + "',";

                    if (Portrait.FileName.ToString() != "")
                    {
                        string filepath;
                        filepath = Server.MapPath("/member/Head/") + Request.Cookies["user_id"].Value.ToString() + "(old).jpg";
                        Portrait.SaveAs(filepath);
                        ThumbnailImage thumbnailimage = new ThumbnailImage();
                        thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/Head/") + Request.Cookies["user_id"].Value.ToString() + ".jpg", 70, 70);
                        sql = sql + "HeadURL = 1,";
                    }

                    sql = sql + "CompanyType = '" + ck.CheckInput(CompanyType.Value) + "',";
                    sql = sql + "Login2_Locus1 = '" + ck.CheckInput(ddlcity1.SelectedItem.Text) + "', ";
                    sql = sql + "Login2_Locus2 = '" + ck.CheckInput(ddlcity2.SelectedItem.Text) + "', ";
                    sql = sql + "Address = '" + ck.CheckInput(Address.Value) + "',";
                    sql = sql + "PostNumber = '" + ck.CheckInput(PostNumber.Value) + "',";
                    sql = sql + "introduction = '" + ck.CheckInput(introduction.Value) + "',";
                    sql = sql + "User_Level = 1 ";
                    sql = sql + "WHERE UserID = " + Request.Cookies["user_id"].Value.ToString();

                    data_conn cn = new data_conn();
                    cn.mdb_exe(sql);


                    if (CompanyType.Value == "1")
                    {
                        Response.Redirect("/accounts/login4.aspx");
                    }
                    else if (CompanyType.Value == "2")
                    {
                        Response.Redirect("/accounts/login3.aspx");
                    }
                    else
                    {
                        Response.Redirect("/accounts/regsuccess.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("/accounts/refill.aspx");
            }
        }
        else
        {
            Response.Redirect("/accounts/refill.aspx");
        }


    }
}
