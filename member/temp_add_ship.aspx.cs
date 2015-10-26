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

        SymmetricMethod ss = new SymmetricMethod();
        if (!IsPostBack)
        {

            //if (this.Request["id"] != null)
            //{
            //    if (this.Request["id"].ToString() != "")
            //    {

            //    }
            //    else
            //    {
            //        LoadValidate();
            //    }

            //}
            //else
            //{
            //    LoadValidate();
            //}


            load();
        }
    }

    //判断是否有参数validate
    public bool IsValidate()
    {
        if (this.Request["validate"] != null)
        {
            if (this.Request["validate"].ToString() != "")
            {
                return true;
            }
        }
        return false;
    }

    public void LoadValidate()
    {
        SymmetricMethod ss = new SymmetricMethod();
        if (IsValidate())
        {
            Session.Add("validate", ss.Decrypto(this.Request["validate"].ToString()));
        }
        else
        {
            Session.Add("validate", "");
        }

    }





    public void load()
    {
        data_conn cn = new data_conn();


        LitDate.Text = DateTime.Now.ToString("yy-MM-dd");


        if (this.Request["id"] != null)
        {
            if (this.Request["id"].ToString() != "")
            {

                DataSet ds = new DataSet();
                ds = cn.mdb_ds("SELECT * FROM TB_AIRGOODS WHERE ID = " + this.Request["id"].ToString() + "", "goods");

                if (ds.Tables["goods"].Rows[0]["USERID"].ToString() == this.Request.Cookies["user_id"].Value && ds.Tables["goods"].Rows[0]["typem"].ToString() == "海运货盘")
                {
                    txttitle.Value = ds.Tables["goods"].Rows[0]["title"].ToString();
                    BasicDatePicker1_TextBox.Value = Convert.ToDateTime(ds.Tables["goods"].Rows[0]["LAUNCHDATE"]).ToString("yy-MM-dd");
                    Lithits.Text = ds.Tables["goods"].Rows[0]["HITS"].ToString();
                    types.SelectedValue = ds.Tables["goods"].Rows[0]["types"].ToString();
                    type1.SelectedValue = ds.Tables["goods"].Rows[0]["type"].ToString();

                    nums.Value = ds.Tables["goods"].Rows[0]["AMOUNT"].ToString();
                    ddlPayType.SelectedValue = ds.Tables["goods"].Rows[0]["PAYMENT"].ToString();
                    tbGoodsName.Value = ds.Tables["goods"].Rows[0]["NAME"].ToString();
                    DropDownList1.SelectedValue = ds.Tables["goods"].Rows[0]["LINE"].ToString();
                    if (Convert.ToBoolean(ds.Tables["goods"].Rows[0]["ISDANGER"]))
                    {
                        rbldange_0.Checked = false;
                        rbldange_1.Checked = true;
                    }
                    else
                    {
                        rbldange_0.Checked = true;
                        rbldange_1.Checked = false;
                    }

                    price.Value = ds.Tables["goods"].Rows[0]["price"].ToString();
                    StartPort.Value = ds.Tables["goods"].Rows[0]["StartPort"].ToString();
                    CityName.Value = ds.Tables["goods"].Rows[0]["DestPort"].ToString();
                    tbremark.Value = ds.Tables["goods"].Rows[0]["DESCRIPTION"].ToString();


                    if (ds.Tables["goods"].Rows[0]["showtel"].ToString() != "0")
                    {
                        chkTel.Checked = true;
                    }
                    else
                    {
                        chkTel.Checked = false;
                    }

                    if (ds.Tables["goods"].Rows[0]["showmo"].ToString() != "0")
                    {
                        chkMobile.Checked = true;
                    }
                    else
                    {
                        chkMobile.Checked = false;
                    }

                    if (ds.Tables["goods"].Rows[0]["showadd"].ToString() != "0")
                    {
                        chkAddress.Checked = true;
                    }
                    else
                    {
                        chkAddress.Checked = false;
                    }

                    if (ds.Tables["goods"].Rows[0]["showemail"].ToString() != "0")
                    {
                        chkEmail.Checked = true;
                    }
                    else
                    {
                        chkEmail.Checked = false;
                    }

                    if (ds.Tables["goods"].Rows[0]["showcom"].ToString() != "0")
                    {
                        chkCompany.Checked = true;
                    }
                    else
                    {
                        chkCompany.Checked = false;
                    }
                }
                else
                {
                    Response.Redirect("../search/err.aspx");
                }

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
                insert();
            }

        }
        else
        {
            insert();
        }





    }



    public void insert()
    {

        //if (Session["cargo_a"] == "" | Session["cargo_a"] == null)
        //{
        //    Response.Redirect("../search/err.aspx");
        //}
        //else
        //{









        //}


        if (nums.Value != "" && BasicDatePicker1_TextBox.Value != "" && tbGoodsName.Value != "")
        {
            string typem = "", ISDANGER;
            DropDownList type = new DropDownList();



            if (rbldange_0.Checked)
            {
                ISDANGER = "0";
            }
            else
            {
                ISDANGER = "1";
            }


            check ck = new check();
            data_conn cn = new data_conn();

            string column = "userId,price,TITLE,POSTDATE,LAUNCHDATE,AMOUNT,PAYMENT,NAME,DESCRIPTION,LINE,STARTPORT,DESTPORT,TYPE,TYPES,TYPEM,ISDANGER,showtel,showmo,showadd,showemail,showcom";
            string value = this.Request.Cookies["user_id"].Value + ",'" + ck.CheckInput(price.Value) + "','" + ck.CheckInput(txttitle.Value) + "',getdate(),'" + ck.CheckInput(BasicDatePicker1_TextBox.Value) + "','" + ck.CheckInput(nums.Value) + "','" + ck.CheckInput(ddlPayType.SelectedValue) + "','" + ck.CheckInput(tbGoodsName.Value) + "','" + ck.CheckInput(tbremark.Value) + "','" + ck.CheckInput(DropDownList1.SelectedValue) + "','" + ck.CheckInput(StartPort.Value) + "','" + ck.CheckInput(CityName.Value) + "','" + ck.CheckInput(type1.SelectedValue) + "','" + ck.CheckInput(types.SelectedValue) + "','海运货盘'," + ISDANGER + "," + tureToInt(chkTel.Checked) + "," + tureToInt(chkMobile.Checked) + "," + tureToInt(chkAddress.Checked) + "," + tureToInt(chkEmail.Checked) + "," + tureToInt(chkCompany.Checked) + "";
            cn.mdb_exe("insert into TB_AIRGOODS (" + column + ") values (" + value + ")");
            Session["cargo_a"] = "";
            Response.Redirect("cargolist.aspx");
        }
        else
        {
            MessageBox("", "必填项不能为空");
        }


        //if (IsValidate())
        //{
        //    SymmetricMethod ss = new SymmetricMethod();

        //    if (ss.Encrypto(Session["validate"].ToString()) == this.Request["validate"].ToString())
        //    {

        //    }
        //    else
        //    {
        //        this.Response.Write("原来就是你这个SB啊");
        //    }
        //}
        //else
        //{
        //    this.Response.Write("原来就是你这个SB啊");
        //}




    }

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    public void update()
    {
        check ck = new check();
        string typem = "", ISDANGER;
        if (rbldange_0.Checked)
        {
            ISDANGER = "0";
        }
        else
        {
            ISDANGER = "1";
        }
        data_conn cn = new data_conn();
        //"++"
        string sql = "";
        sql += "update TB_AIRGOODS set ";
        sql += "price='" + ck.CheckInput(price.Value) + "',";
        sql += "TITLE='" + ck.CheckInput(txttitle.Value) + "',";
        sql += "POSTDATE=getdate(),";
        sql += "LAUNCHDATE='" + ck.CheckInput(BasicDatePicker1_TextBox.Value) + "',";
        sql += "AMOUNT='" + ck.CheckInput(nums.Value) + "',";
        sql += "PAYMENT='" + ck.CheckInput(ddlPayType.SelectedValue) + "',";
        sql += "NAME='" + ck.CheckInput(tbGoodsName.Value) + "',";
        sql += "DESCRIPTION='" + ck.CheckInput(tbremark.Value) + "',";
        sql += "LINE='" + ck.CheckInput(DropDownList1.SelectedValue) + "',";
        sql += "STARTPORT='" + ck.CheckInput(StartPort.Value) + "',";
        sql += "DESTPORT='" + ck.CheckInput(CityName.Value) + "',";
        sql += "TYPE='" + ck.CheckInput(type1.SelectedValue) + "',";
        sql += "TYPES='" + ck.CheckInput(types.SelectedValue) + "',";
        sql += "TYPEM='海运货盘',";
        sql += "ISDANGER=" + ISDANGER + ",";
        sql += "showtel=" + tureToInt(chkTel.Checked) + ",";
        sql += "showmo=" + tureToInt(chkMobile.Checked) + ",";
        sql += "showadd=" + tureToInt(chkAddress.Checked) + ",";
        sql += "showemail=" + tureToInt(chkEmail.Checked) + ",";
        sql += "showcom=" + tureToInt(chkCompany.Checked) + " where id=" + this.Request["id"].ToString();

        cn.mdb_exe(sql);

        Response.Redirect("cargolist.aspx");
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

}
