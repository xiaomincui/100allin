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
            IMG1.Src = "../../bis/images/Storage/upload/" + this.Request["id"].ToString() + "_1.jpg";
            IMG2.Src = "../../bis/images/Storage/upload/" + this.Request["id"].ToString() + "_2.jpg";
            IMG3.Src = "../../bis/images/Storage/upload/" + this.Request["id"].ToString() + "_3.jpg";
            IMG4.Src = "../../bis/images/Storage/upload/" + this.Request["id"].ToString() + "_4.jpg";
            IMG5.Src = "../../bis/images/Storage/upload/" + this.Request["id"].ToString() + "_5.jpg";



            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_Storage where id=" + this.Request["id"].ToString(), "Storage");
            txtStorage.Value = ds.Tables["Storage"].Rows[0]["StorageName"].ToString();
            txtCity.Value = ds.Tables["Storage"].Rows[0]["City"].ToString();
            DropDownList1.SelectedValue = ds.Tables["Storage"].Rows[0]["TypeName"].ToString();
            txtStoragearea.Value = ds.Tables["Storage"].Rows[0]["Storage_area"].ToString();
            txtFieldarea.Value = ds.Tables["Storage"].Rows[0]["Field_area"].ToString();
            txtValue.Value = ds.Tables["Storage"].Rows[0]["inbuiltValue"].ToString();
            txtAddress.Value = ds.Tables["Storage"].Rows[0]["Address"].ToString();
            txtIntro.Value = ds.Tables["Storage"].Rows[0]["intro"].ToString();
            txtCompany.Value = ds.Tables["Storage"].Rows[0]["Company"].ToString();
            txtlinkmen.Value = ds.Tables["Storage"].Rows[0]["linkmen"].ToString();
            txtPhone.Value = ds.Tables["Storage"].Rows[0]["Phone"].ToString();


            if (ds.Tables["Storage"].Rows[0]["state"].ToString() == "0")
            {
                CheckBox1.Checked = false;
            }
            else
            {
                CheckBox1.Checked = true;
            }
            
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
        if (txtStorage.Value != "" && txtCity.Value != "" && txtStoragearea.Value != "" && txtFieldarea.Value != "" && txtAddress.Value != "" && txtIntro.Value != "" && txtValue.Value != "")
        {
            string check;
            if (CheckBox1.Checked)
            {
                check = "1";
            }
            else
            {
                check = "0";
            }



            string id = this.Request["id"].ToString();
            
            check ck = new check();
            string sql = "update TB_Storage set StorageName='" + txtStorage.Value + "',City='" + txtCity.Value + "',TypeName='" + DropDownList1.SelectedItem.Text + "',Storage_area=" + txtStoragearea.Value + ",Field_area=" + txtFieldarea.Value + ",Address='" + txtAddress.Value + "',intro='" + txtIntro.Value + "',inbuiltValue='" + txtValue.Value + "',Company='" + txtCompany.Value + "',linkmen='" + txtlinkmen.Value + "',Phone='" + txtPhone.Value + "',state=" + check + " where id=" + this.Request["id"].ToString();

            
            data_conn cn = new data_conn();
            cn.mdb_exe(sql);

            //string sql = "insert into TB_Storage (StorageName,City,TypeName,Storage_area,Field_area,Address,intro,inbuiltValue,Company,linkmen,Phone,Postdate) values ";
            //sql += "('" + ck.CheckInput(txtStorage.Value) + "','" + ck.CheckInput(txtCity.Value) + "','" + ck.CheckInput(DropDownList1.SelectedItem.Text) + "'," + ck.CheckInput(txtStoragearea.Value) + "," + ck.CheckInput(txtFieldarea.Value) + ",'" + ck.CheckInput(txtAddress.Value) + "','" + ck.CheckInput(txtIntro.Value) + "','" + ck.CheckInput(value) + "','" + ck.CheckInput(txtCompany.Value) + "','" + ck.CheckInput(txtlinkmen.Value) + "','" + ck.CheckInput(txtPhone.Value) + "',getdate())";
            //string id = mdb_exe_return(sql);


            


            if (FileUpload1.FileName != "")
            {
                string filepath = Server.MapPath("../../bis/images/") + "/Storage/upload/old/" + id + "_1.jpg";
                FileUpload1.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_1.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_big_1.jpg", 210, 150);
            }
            if (FileUpload2.FileName != "")
            {
                string filepath = Server.MapPath("../../bis/images/") + "/Storage/upload/old/" + id + "_2.jpg";
                FileUpload2.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_2.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_big_2.jpg", 210, 150);
            }
            if (FileUpload3.FileName != "")
            {
                string filepath = Server.MapPath("../../bis/images/") + "/Storage/upload/old/" + id + "_3.jpg";
                FileUpload3.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_3.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_big_3.jpg", 210, 150);
            }
            if (FileUpload4.FileName != "")
            {
                string filepath = Server.MapPath("../../bis/images/") + "/Storage/upload/old/" + id + "_4.jpg";
                FileUpload4.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_4.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_big_4.jpg", 210, 150);
            }
            if (FileUpload5.FileName != "")
            {
                string filepath = Server.MapPath("../../bis/images/") + "/Storage/upload/old/" + id + "_5.jpg";
                FileUpload5.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_5.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("../../bis/images/") + "/Storage/upload/" + id + "_big_5.jpg", 210, 150);
            }


            this.Response.Redirect("Storagelist.aspx");
        }
        else
        {
            MessageBox("", "*必填");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.history.go(-2);</script>");
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}
