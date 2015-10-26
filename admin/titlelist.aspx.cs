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
            LoadRecord();
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

     //载入列表信息
    public void LoadRecord()
    {

        data_conn cn = new data_conn();

        string sql = "select * from TB_index";
        //this.Response.Write(sql);
        DataSet ds = cn.mdb_ds(sql, "yunjia");

        GridView1.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");

        LoadGridView2();
        //LoadGridView3();
        

    }

    public void LoadGridView2()
    {
        data_conn cn = new data_conn();
        string sql = "select * from TB_Attention";
        DataSet ds = cn.mdb_ds(sql, "yunjia");
        GridView2.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView2.DataKeyNames = new string[] { "id" };//主键
        GridView2.DataBind();
        GridView2.Attributes.Add("bordercolor ", "#D9D9D9");
    }

    //public void LoadGridView3()
    //{
    //    data_conn cn = new data_conn();
    //    string sql = "select top 8 * from TB_BBSImage";
    //    DataSet ds = cn.mdb_ds(sql, "yunjia");
    //    GridView3.DataSource = ds.Tables["yunjia"].DefaultView;
    //    GridView3.DataKeyNames = new string[] { "id" };//主键
    //    GridView3.DataBind();
    //    GridView3.Attributes.Add("bordercolor ", "#D9D9D9");
    //}


    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }





    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        LoadGridView2();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        LoadGridView2();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        



        data_conn cn = new data_conn();
        string sqlstr = "update TB_Attention set title='" + ((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].FindControl("TextBox1"))).Text + "',urllink='" + ((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].FindControl("TextBox2"))).Text + "' where id=" + GridView2.DataKeys[e.RowIndex].Value.ToString();

        cn.mdb_exe(sqlstr);
        GridView2.EditIndex = -1;
        LoadGridView2();
    }








    //protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView3.EditIndex = -1;
    //    LoadGridView3();
    //}

    //protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView3.EditIndex = e.NewEditIndex;
    //    LoadGridView3();
    //}
    //protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{


    //    data_conn cn = new data_conn();
    //    string sqlstr = "update TB_BBSImage set title='" + ((TextBox)(GridView3.Rows[e.RowIndex].Cells[3].FindControl("TextBox1"))).Text + "',urllink='" + ((TextBox)(GridView3.Rows[e.RowIndex].Cells[3].FindControl("TextBox2"))).Text + "' where id=" + GridView3.DataKeys[e.RowIndex].Value.ToString();
    //    cn.mdb_exe(sqlstr);


    //    FileUpload FileUpload1 = (FileUpload)(GridView3.Rows[e.RowIndex].Cells[3].FindControl("FileUpload1"));

    //    if (FileUpload1.FileName != "")
    //    {
    //        string filepath = Server.MapPath("../images/bbs/album/") + "/at_pic" + Convert.ToString(e.RowIndex + 1) + ".gif";
    //        FileUpload1.SaveAs(filepath);

    //    }
    //    GridView3.EditIndex = -1;
    //    LoadGridView3();
    //}

    
   
   

    
}
