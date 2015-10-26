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

public partial class poll_VoteReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double proportion;
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        ds = cn.mdb_ds("select * from TB_Poll", "voteReturn");
        int count = ds.Tables["voteReturn"].Rows.Count;


        //选择题1
        DataRow[] drchoice_0 = ds.Tables["voteReturn"].Select("choice_1=0");
        proportion = Convert.ToDouble(drchoice_0.Length) / Convert.ToDouble(count);
        choice_1_image0.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_1_0.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        DataRow[] drchoice_1 = ds.Tables["voteReturn"].Select("choice_1=1");
        proportion = Convert.ToDouble(drchoice_1.Length) / Convert.ToDouble(count);
        choice_1_image1.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_1_1.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        DataRow[] drchoice_2 = ds.Tables["voteReturn"].Select("choice_1=2");
        proportion = Convert.ToDouble(drchoice_2.Length) / Convert.ToDouble(count);
        choice_1_image2.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_1_2.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        DataRow[] drchoice_3 = ds.Tables["voteReturn"].Select("choice_1=3");
        proportion = Convert.ToDouble(drchoice_3.Length) / Convert.ToDouble(count);
        choice_1_image3.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_1_3.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";


        //选择题2
        drchoice_0 = ds.Tables["voteReturn"].Select("choice_2=0");
        proportion = Convert.ToDouble(drchoice_0.Length) / Convert.ToDouble(count);
        choice_2_image0.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_2_0.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_1 = ds.Tables["voteReturn"].Select("choice_2=1");
        proportion = Convert.ToDouble(drchoice_1.Length) / Convert.ToDouble(count);
        choice_2_image1.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_2_1.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_2 = ds.Tables["voteReturn"].Select("choice_2=2");
        proportion = Convert.ToDouble(drchoice_2.Length) / Convert.ToDouble(count);
        choice_2_image2.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_2_2.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_3 = ds.Tables["voteReturn"].Select("choice_2=3");
        proportion = Convert.ToDouble(drchoice_3.Length) / Convert.ToDouble(count);
        choice_2_image3.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_2_3.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";


        //选择题3
        drchoice_0 = ds.Tables["voteReturn"].Select("choice_3=0");
        proportion = Convert.ToDouble(drchoice_0.Length) / Convert.ToDouble(count);
        choice_3_image0.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_3_0.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_1 = ds.Tables["voteReturn"].Select("choice_3=1");
        proportion = Convert.ToDouble(drchoice_1.Length) / Convert.ToDouble(count);
        choice_3_image1.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_3_1.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_2 = ds.Tables["voteReturn"].Select("choice_3=2");
        proportion = Convert.ToDouble(drchoice_2.Length) / Convert.ToDouble(count);
        choice_3_image2.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_3_2.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_3 = ds.Tables["voteReturn"].Select("choice_3=3");
        proportion = Convert.ToDouble(drchoice_3.Length) / Convert.ToDouble(count);
        choice_3_image3.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_3_3.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";


        //选择题4
        drchoice_0 = ds.Tables["voteReturn"].Select("choice_4=0");
        proportion = Convert.ToDouble(drchoice_0.Length) / Convert.ToDouble(count);
        choice_4_image0.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_4_0.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_1 = ds.Tables["voteReturn"].Select("choice_4=1");
        proportion = Convert.ToDouble(drchoice_1.Length) / Convert.ToDouble(count);
        choice_4_image1.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_4_1.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_2 = ds.Tables["voteReturn"].Select("choice_4=2");
        proportion = Convert.ToDouble(drchoice_2.Length) / Convert.ToDouble(count);
        choice_4_image2.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_4_2.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_3 = ds.Tables["voteReturn"].Select("choice_4=3");
        proportion = Convert.ToDouble(drchoice_3.Length) / Convert.ToDouble(count);
        choice_4_image3.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_4_3.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";


        //选择题5
        drchoice_0 = ds.Tables["voteReturn"].Select("choice_5=0");
        proportion = Convert.ToDouble(drchoice_0.Length) / Convert.ToDouble(count);
        choice_5_image0.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_5_0.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_1 = ds.Tables["voteReturn"].Select("choice_5=1");
        proportion = Convert.ToDouble(drchoice_1.Length) / Convert.ToDouble(count);
        choice_5_image1.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_5_1.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_2 = ds.Tables["voteReturn"].Select("choice_5=2");
        proportion = Convert.ToDouble(drchoice_2.Length) / Convert.ToDouble(count);
        choice_5_image2.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_5_2.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        drchoice_3 = ds.Tables["voteReturn"].Select("choice_5=3");
        proportion = Convert.ToDouble(drchoice_3.Length) / Convert.ToDouble(count);
        choice_5_image3.Text = "<img src='images/tt.gif' width='" + Convert.ToString(proportion * 200) + "' height='10' />";
        choice_5_3.Text = Convert.ToString(String.Format("{0:F}", proportion * 100)) + "%";

        //MessageBox(Response.Cookies["vote"].Value, Response.Cookies["vote"].Value);
    }




    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }
}
