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

public partial class bis_application_storage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null)
        {

            Response.Cookies["url"].Value = Request.Url.ToString();
            this.Response.Redirect("../member/reg.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                Response.Cookies["url"].Value = Request.Url.ToString();
                this.Response.Redirect("../member/reg.aspx");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (txtStorage.Value != "" && txtCity.Value != "" && txtStoragearea.Value != "" && txtFieldarea.Value != "" && txtAddress.Value != "" && txtIntro.Value != "" && txtValue.Value != "")
        {

            string value;
            if (txtValue.Value == "请填写20'40'40H'的内装价格")
            {
                value = "";
            }
            else
            {
                value = txtValue.Value;
            }
            check ck = new check();
            string sql = "insert into TB_Storage (StorageName,City,TypeName,Storage_area,Field_area,Address,intro,inbuiltValue,Company,linkmen,Phone,Postdate,UserID) values ";
            sql += "('" + ck.CheckInput(txtStorage.Value) + "','" + ck.CheckInput(txtCity.Value) + "','" + ck.CheckInput(DropDownList1.SelectedItem.Text) + "'," + ck.CheckInput(txtStoragearea.Value) + "," + ck.CheckInput(txtFieldarea.Value) + ",'" + ck.CheckInput(txtAddress.Value) + "','" + ck.CheckInput(txtIntro.Value) + "','" + ck.CheckInput(value) + "','" + ck.CheckInput(txtCompany.Value) + "','" + ck.CheckInput(txtlinkmen.Value) + "','" + ck.CheckInput(txtPhone.Value) + "',getdate()," + this.Request.Cookies["user_id"].Value.ToString() + ")";
            string id = mdb_exe_return(sql);


            if (FileUpload1.FileName != "")
            {
                string filepath = Server.MapPath("images/") + "/Storage/upload/old/" + id + "_1.jpg";
                FileUpload1.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_1.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_big_1.jpg", 210, 150);
            }
            if (FileUpload2.FileName != "")
            {
                string filepath = Server.MapPath("images/") + "/Storage/upload/old/" + id + "_2.jpg";
                FileUpload2.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_2.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_big_2.jpg", 210, 150);
            }
            if (FileUpload3.FileName != "")
            {
                string filepath = Server.MapPath("images/") + "/Storage/upload/old/" + id + "_3.jpg";
                FileUpload3.SaveAs(filepath);
                ThumbnailImage thumbnailimage = new ThumbnailImage();
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_3.jpg", 48, 48);
                thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_big_3.jpg", 210, 150);
            }
            //if (FileUpload4.FileName != "")
            //{
            //    string filepath = Server.MapPath("images/") + "/Storage/upload/old/" + id + "_4.jpg";
            //    FileUpload4.SaveAs(filepath);
            //    ThumbnailImage thumbnailimage = new ThumbnailImage();
            //    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_4.jpg", 48, 48);
            //    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_big_4.jpg", 210, 150);
            //}
            //if (FileUpload5.FileName != "")
            //{
            //    string filepath = Server.MapPath("images/") + "/Storage/upload/old/" + id + "_5.jpg";
            //    FileUpload5.SaveAs(filepath);
            //    ThumbnailImage thumbnailimage = new ThumbnailImage();
            //    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_5.jpg", 48, 48);
            //    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("images/") + "/Storage/upload/" + id + "_big_5.jpg", 210, 150);
            //}


            this.Response.Redirect("Storage.aspx");
        }
        else
        {
            MessageBox("", "*必填");
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

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }
}
