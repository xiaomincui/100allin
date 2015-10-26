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

public partial class member_useredit1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            LoadList1();
            LoadList2(0);
            GetUserInfo();
        }
        ddlcity1.Attributes.Add("onclick", "showTip('tipLocusNormal','tipLocusTrue','tipLocusFalse')");
        ddlcity2.Attributes.Add("onclick", "showTip('tipLocusNormal','tipLocusTrue','tipLocusFalse')");
        sex.Attributes.Add("onfocus", "txtonfocus(this)");
    }

    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (Request.Cookies[c] != null)
        {
            if (Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = Request.Cookies[c].Value.ToString();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    public void GetUserInfo()
    {

        check ck = new check();
        string id = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + id, "user");
        for (int i = 0; i < CompanyType.Items.Count; i++)
        {
            if (CompanyType.Items[i].Value == ds.Tables["user"].Rows[0]["CompanyType"].ToString())
            {
                CompanyType.Items[i].Selected = true;
            }
        }
        for (int i = 0; i <= ddlcity1.Items.Count - 1; i++)
        {
            if ((ddlcity1.Items[i].Text == ds.Tables["user"].Rows[0]["Login2_Locus1"].ToString()))
            {
                ddlcity1.Items[i].Selected = true;
                LoadList2(Convert.ToInt32(ddlcity1.Items[i].Value));
            }
        }
        for (int i = 0; i <= ddlcity2.Items.Count - 1; i++)
        {
            if ((ddlcity2.Items[i].Text == ds.Tables["user"].Rows[0]["Login2_Locus2"].ToString()))
            {
                ddlcity2.Items[i].Selected = true;
            }
        }
        Address.Value = ds.Tables["user"].Rows[0]["Address"].ToString();
        PostNumber.Value = ds.Tables["user"].Rows[0]["PostNumber"].ToString();

        sex.SelectedValue = ds.Tables["user"].Rows[0]["Sex"].ToString();

        Position.Value = ds.Tables["user"].Rows[0]["WPosition"].ToString();
        Fax.Value = ds.Tables["user"].Rows[0]["Fax"].ToString();
        MovePhone.Value = ds.Tables["user"].Rows[0]["MovePhone"].ToString();
        Msn.Value = ds.Tables["user"].Rows[0]["Usermsn"].ToString();
        QQ.Value = ds.Tables["user"].Rows[0]["Userqq"].ToString();
        sign.Value = ds.Tables["user"].Rows[0]["sign"].ToString();
        introduction.Value = ds.Tables["user"].Rows[0]["introduction"].ToString();

        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_fcl"].ToString() == "1")
        {
            checkfcl.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_lcl"].ToString() == "1")
        {
            checklcl.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_air"].ToString() == "1")
        {
            checkair.Checked = true;
        }

        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_cold"].ToString() == "1")
        {
            checkcold.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_dangerous"].ToString() == "1")
        {
            checkdangerous.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_tank"].ToString() == "1")
        {
            checktank.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_particular"].ToString() == "1")
        {
            checkparticular.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_BULK"].ToString() == "1")
        {
            checkBULK.Checked = true;
        }
        if (ds.Tables["user"].Rows[0]["Login2_Adventage_Type_input"].ToString() == "1")
        {
            checkinput.Checked = true;
        }



        ///////////////////////////////////////////
        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_Europe.Value) > -1))
        {
            chk_ship_Europe.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_SOUTH_AMERICA.Value) > -1))
        {
            chk_ship_SOUTH_AMERICA.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_air_Australia.Value) > -1))
        {
            chk_ship_Australia.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_Caribbean.Value) > -1))
        {
            chk_ship_Caribbean.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_offing.Value) > -1))
        {
            chk_ship_offing.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_Japan_Korea.Value) > -1))
        {
            chk_ship_Japan_Korea.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_CIMEX.Value) > -1))
        {
            chk_ship_CIMEX.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_Red_Sea.Value) > -1))
        {
            chk_ship_Red_Sea.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line"].ToString().IndexOf(chk_ship_Africa.Value) > -1))
        {
            chk_ship_Africa.Checked = true;
        }



        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_North_America.Value) > -1))
        {
            chk_air_North_America.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_Europe.Value) > -1))
        {
            chk_air_Europe.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_poncho.Value) > -1))
        {
            chk_air_poncho.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_Asia.Value) > -1))
        {
            chk_air_Asia.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_Africa.Value) > -1))
        {
            chk_air_Africa.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_Australia.Value) > -1))
        {
            chk_air_Australia.Checked = true;
        }

        if ((ds.Tables["user"].Rows[0]["Login2_Adventage_Line2"].ToString().IndexOf(chk_air_internal.Value) > -1))
        {
            chk_air_internal.Checked = true;
        }


        ListBox1.Items.Clear();
        selshiper.Items.Clear();

        string[] shipArray = new string[] { "马士基(MSK)", "长荣(EMC)", "中海(CSCL)", "达飞(CMA)", "韩进(HANJIN)", "万海(WANHAI)", "地中海(MSC)", "太平(PIL)", "东方海外(OOCL)", "中远(COSCO)", "以星(ZIM)", "阳明(YML)" };
        for (int i = 0; i < shipArray.Length; i++)
        {
            if (ds.Tables["user"].Rows[0]["Login2_Adventage_Shipper"].ToString().IndexOf(shipArray[i]) > -1)
            {
                selshiper.Items.Add(new ListItem(shipArray[i], shipArray[i]));
                Hidtypes.Value += shipArray[i] + "|";
            }
            else
            {
                ListBox1.Items.Add(new ListItem(shipArray[i], shipArray[i]));
            }
        }




        othershipper.Text = ds.Tables["user"].Rows[0]["Login2_Adventage_Shipper"].ToString().Split('|')[ds.Tables["user"].Rows[0]["Login2_Adventage_Shipper"].ToString().Split('|').Length - 1];
        
    }

    protected void LoadList1()
    {
        ddlcity1.Items.Clear();

        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("../xml/Provinces.xml"));
        //Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes 
        XmlNodeList node = doc.SelectNodes("Provinces")[0].ChildNodes;
        for (int i = 0; i <= node.Count - 1; i++)
        {
            ListItem pp = new ListItem(node[i].InnerText, node[i].Attributes["ID"].Value);
            ddlcity1.Items.Add(pp);

        }
    }


    protected string LoadList1search(int str)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("../xml/Provinces.xml"));
        XmlNodeList node = doc.SelectNodes("Provinces")[0].ChildNodes;
        for (int i = 0; i <= node.Count - 1; i++)
        {
            if ((node[i].InnerText == str.ToString()))
            {
                return node[i].Attributes["ID"].Value;
            }
        }
        return "";
    }

    protected void LoadList2(int ID)
    {
        ddlcity2.Items.Clear();


        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("../xml/Cities.xml"));


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

        if (ddlcity1.SelectedValue != "0" && ddlcity2.SelectedValue != "0")
        {
            tipLocusNormal.Style.Value = "display:none;";
            tipLocusTrue.Style.Value = "";
            tipLocusFalse.Style.Value = "display:none;";


        }
        else
        {
            tipLocusNormal.Style.Value = "display:none;";
            tipLocusTrue.Style.Value = "display:none;";
            tipLocusFalse.Style.Value = "";



        }
    }
    protected void ddlcity2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList3(Convert.ToInt32(ddlcity2.SelectedValue));

        if (ddlcity1.SelectedValue != "0" && ddlcity2.SelectedValue != "0")
        {
            tipLocusNormal.Style.Value = "display:none;";
            tipLocusTrue.Style.Value = "";
            tipLocusFalse.Style.Value = "display:none;";
            ddlcity1.CssClass = "";
            ddlcity2.CssClass = "";
        }
        else
        {
            tipLocusNormal.Style.Value = "display:none;";
            tipLocusTrue.Style.Value = "display:none;";
            tipLocusFalse.Style.Value = "";

        }
    }


    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        check ck = new check();



        //else if (Phone.Value == "")
        //{
        //    MessageBox("opfail", "电话为空");
        //}
        if (CompanyType.Value == "0")
        {
            MessageBox("opfail", "公司类型为空");
        }
        else if (ddlcity1.SelectedValue == "0" || ddlcity2.SelectedValue == "0")
        {
            MessageBox("opfail", "公司所在地为空");
        }
        else if (introduction.Value.Length >= 4000)
        {
            MessageBox("opfail", "公司简介过长");
        }
        else
        {
            string sql = "";
            sql = sql + "UPDATE ";
            sql = sql + "TB_User ";
            sql = sql + "SET ";
            sql = sql + "Sex = " + sex.SelectedValue + ",";
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

            //sql = sql + "CompanyName = '" + ck.CheckInput(Company.Value) + "',";
            sql = sql + "CompanyType = '" + ck.CheckInput(CompanyType.Value) + "',";
            sql = sql + "Login2_Locus1 = '" + ck.CheckInput(ddlcity1.SelectedItem.Text) + "', ";
            sql = sql + "Login2_Locus2 = '" + ck.CheckInput(ddlcity2.SelectedItem.Text) + "', ";
            sql = sql + "Address = '" + ck.CheckInput(Address.Value) + "',";
            sql = sql + "PostNumber = '" + ck.CheckInput(PostNumber.Value) + "',";
            sql = sql + "introduction = '" + ck.CheckInput(introduction.Value) + "',";


            
            
            //if (CoPortrait.FileName.ToString() != "")
            //{
            //    string filepath;
            //    filepath = Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + "(old).jpg";
            //    CoPortrait.SaveAs(filepath);
            //    ThumbnailImage thumbnailimage = new ThumbnailImage();
            //    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/companyhead/") + Request.Cookies["user_id"].Value.ToString() + ".jpg", 256, 256);
            //    sql = sql + "Login2_Head = 1,";
            //}
            sql = sql + "User_Level = 1 ";

            sql = sql + "WHERE UserID = " + Request.Cookies["user_id"].Value.ToString();

            data_conn cn = new data_conn();
            cn.mdb_exe(sql);
            
            string Login2_Adventage_Type_fcl, Login2_Adventage_Type_lcl, Login2_Adventage_Type_air, Login2_Adventage_Type_input, Login2_Adventage_Type_particular, Login2_Adventage_Type_cold, Login2_Adventage_Type_dangerous, Login2_Adventage_Type_tank, Login2_Adventage_Type_BULK, Login2_Adventage_type, Login2_Adventage_Line, Login2_Adventage_Line2, Login2_Adventage_Shipper, Login2_introduction;



            Login2_Adventage_Type_fcl = "0";
            Login2_Adventage_Type_lcl = "0";
            Login2_Adventage_Type_air = "0";
            Login2_Adventage_Type_input = "0";
            Login2_Adventage_Type_particular = "0";
            Login2_Adventage_Type_cold = "0";
            Login2_Adventage_Type_dangerous = "0";
            Login2_Adventage_Type_tank = "0";
            Login2_Adventage_Type_BULK = "0";
            if (checkall.Checked == true)
            {
                Login2_Adventage_Type_fcl = "1";
                Login2_Adventage_Type_lcl = "1";
                Login2_Adventage_Type_air = "1";
            }
            if (checkfcl.Checked == true)
            {
                Login2_Adventage_Type_fcl = "1";
            }
            if (checklcl.Checked == true)
            {
                Login2_Adventage_Type_lcl = "1";
            }
            if (checkair.Checked == true)
            {
                Login2_Adventage_Type_air = "1";
            }
            if (checkinput.Checked == true)
            {
                Login2_Adventage_Type_input = "1";
            }
            if (checkparticular.Checked == true)
            {
                Login2_Adventage_Type_particular = "1";
            }
            if (checkcold.Checked == true)
            {
                Login2_Adventage_Type_cold = "1";
            }
            if (checkdangerous.Checked == true)
            {
                Login2_Adventage_Type_dangerous = "1";
            }
            if (checktank.Checked == true)
            {
                Login2_Adventage_Type_tank = "1";
            }
            if (checkBULK.Checked == true)
            {
                Login2_Adventage_Type_BULK = "1";
            }



            Login2_Adventage_Line = "";
            Login2_Adventage_Line2 = "";



            if ((chk_ship_Europe.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Europe.Value + "|";
            }

            if ((chk_ship_SOUTH_AMERICA.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_SOUTH_AMERICA.Value + "|";
            }

            if ((chk_ship_Australia.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Australia.Value + "|";
            }

            if ((chk_ship_Caribbean.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Caribbean.Value + "|";
            }

            if ((chk_ship_offing.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_offing.Value + "|";
            }

            if ((chk_ship_Japan_Korea.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Japan_Korea.Value + "|";
            }

            if ((chk_ship_CIMEX.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_CIMEX.Value + "|";
            }

            if ((chk_ship_Red_Sea.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Red_Sea.Value + "|";
            }

            if ((chk_ship_Africa.Checked == true))
            {
                Login2_Adventage_Line += chk_ship_Africa.Value + "|";
            }





            if ((chk_air_North_America.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_North_America.Value + "|";
            }

            if ((chk_air_Europe.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_Europe.Value + "|";
            }

            if ((chk_air_poncho.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_poncho.Value + "|";
            }

            if ((chk_air_Asia.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_Asia.Value + "|";
            }

            if ((chk_air_Africa.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_Africa.Value + "|";
            }

            if ((chk_air_Australia.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_Australia.Value + "|";
            }

            if ((chk_air_internal.Checked == true))
            {
                Login2_Adventage_Line2 += chk_air_internal.Value + "|";
            }


            if ((string.IsNullOrEmpty(Login2_Adventage_Line)) && (string.IsNullOrEmpty(Login2_Adventage_Line2)))
            {
                //MessageBox("优势航线不能为空", "优势航线不能为空");
                //return;
            }
            else
            {
                if (Login2_Adventage_Line.Length != 0)
                {
                    Login2_Adventage_Line = Login2_Adventage_Line.Substring(0, Login2_Adventage_Line.Length - 1);
                }
            }






            Login2_Adventage_Shipper = Hidtypes.Value;

            if ((!string.IsNullOrEmpty(othershipper.Text)))
            {
                Login2_Adventage_Shipper += othershipper.Text;
            }





            sql = "update TB_User set Login2_Adventage_Type_fcl=" + Login2_Adventage_Type_fcl + ",Login2_Adventage_Type_lcl=" + Login2_Adventage_Type_lcl + ",Login2_Adventage_Type_air=" + Login2_Adventage_Type_air + ",Login2_Adventage_Type_input=" + Login2_Adventage_Type_input + ",Login2_Adventage_Type_particular=" + Login2_Adventage_Type_particular + ",Login2_Adventage_Type_dangerous=" + Login2_Adventage_Type_dangerous + ",Login2_Adventage_Type_cold=" + Login2_Adventage_Type_cold + ",Login2_Adventage_Type_tank=" + Login2_Adventage_Type_tank + ",Login2_Adventage_Type_BULK=" + Login2_Adventage_Type_BULK + ",Login2_Adventage_Line='" + ck.CheckInput(Login2_Adventage_Line) + "',Login2_Adventage_Line2='" + ck.CheckInput(Login2_Adventage_Line2) + "',Login2_Adventage_Shipper='" + ck.CheckInput(Login2_Adventage_Shipper) + "',User_Level=1 where UserID=" + this.Request.Cookies["user_id"].Value.ToString();


            cn.mdb_exe(sql);

            //GetUserInfo();
            MessageBox("", "修改成功");


        }
    }
}
