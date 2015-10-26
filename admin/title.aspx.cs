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
using System.Web.Security;

public partial class admin_userlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadUser();
        if (Page.IsPostBack == false)
        {
            IMG1.Src = "/images/index/showpic" + this.Request["id"].ToString() + ".jpg";




            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_index where id=" + this.Request["id"].ToString(), "index");
            txttitle.Value = ds.Tables["index"].Rows[0]["title"].ToString();
            txtimagelink.Value = ds.Tables["index"].Rows[0]["image_link"].ToString();
            txtcolor.Value = ds.Tables["index"].Rows[0]["title_color"].ToString();
            txtrow1.Value = ds.Tables["index"].Rows[0]["row1"].ToString();
            txtlink1.Value = ds.Tables["index"].Rows[0]["row1_link"].ToString();
            txtrow2.Value = ds.Tables["index"].Rows[0]["row2"].ToString();
            txtrow3_1.Value = ds.Tables["index"].Rows[0]["row3_1"].ToString();
            txtrow3_2.Value = ds.Tables["index"].Rows[0]["row3_2"].ToString();
            txtlink3.Value = ds.Tables["index"].Rows[0]["row3_link"].ToString();
            txtrow4_1.Value = ds.Tables["index"].Rows[0]["row4_1"].ToString();
            txtrow4_2.Value = ds.Tables["index"].Rows[0]["row4_2"].ToString();
            txtlink4.Value = ds.Tables["index"].Rows[0]["row4_link"].ToString();
            
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
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


    protected void Button2_Click(object sender, EventArgs e)
    {




        string id = this.Request["id"].ToString();

        check ck = new check();
        string sql = "update TB_index set title='" + txttitle.Value + "',title_color='" + txtcolor.Value + "',row1='" + txtrow1.Value + "',row1_link='" + txtlink1.Value + "',row2='" + txtrow2.Value + "',row3_1='" + txtrow3_1.Value + "',row3_2='" + txtrow3_2.Value + "',row3_link='" + txtlink3.Value + "',row4_1='" + txtrow4_1.Value + "',row4_2='" + txtrow4_2.Value + "',row4_link='" + txtlink4.Value + "',image_link='" + txtimagelink.Value + "' where id=" + this.Request["id"].ToString();




        data_conn cn = new data_conn();
        cn.mdb_exe(sql);

        //string sql = "insert into TB_Storage (StorageName,City,TypeName,Storage_area,Field_area,Address,intro,inbuiltValue,Company,linkmen,Phone,Postdate) values ";
        //sql += "('" + ck.CheckInput(txtStorage.Value) + "','" + ck.CheckInput(txtCity.Value) + "','" + ck.CheckInput(DropDownList1.SelectedItem.Text) + "'," + ck.CheckInput(txtStoragearea.Value) + "," + ck.CheckInput(txtFieldarea.Value) + ",'" + ck.CheckInput(txtAddress.Value) + "','" + ck.CheckInput(txtIntro.Value) + "','" + ck.CheckInput(value) + "','" + ck.CheckInput(txtCompany.Value) + "','" + ck.CheckInput(txtlinkmen.Value) + "','" + ck.CheckInput(txtPhone.Value) + "',getdate())";
        //string id = mdb_exe_return(sql);





        if (FileUpload1.FileName != "")
        {
            string filepath = Server.MapPath("../images/index/") + "/showpic" + id + ".jpg";
            FileUpload1.SaveAs(filepath);

        }

        this.Response.Redirect("titlelist.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.history.go(-2);</script>");
    }

}
