using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class topic_year20091229_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["2009_9users"] == null)
        {
            Response.Cookies["2009_9users"].Value = "0";
            Response.Cookies["2009_9users"].Expires = DateTime.Now.AddDays(365);
        }

        if (Request.Cookies["2009_vote"] == null)
        {
            Response.Cookies["2009_vote"].Value = "0";
            Response.Cookies["2009_vote"].Expires = DateTime.Now.AddDays(365);
        }

        if (Request.Cookies["2009_wish"] == null)
        {
            Response.Cookies["2009_wish"].Value = "0";
            Response.Cookies["2009_wish"].Expires = DateTime.Now.AddDays(365);
        }
        
        Load9Users();

        LoadVote();

        LoadWish();

    }

    protected void Load9Users()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "";
        sql += "SELECT * FROM TB_2009_9USERS ORDER BY uno";

        ds = cn.mdb_ds(sql, "users");

        Literal1.Text = ds.Tables["users"].Rows[0]["flower"].ToString();
        Literal2.Text = ds.Tables["users"].Rows[0]["brick"].ToString();

        Literal3.Text = ds.Tables["users"].Rows[1]["flower"].ToString();
        Literal4.Text = ds.Tables["users"].Rows[1]["brick"].ToString();

        Literal5.Text = ds.Tables["users"].Rows[2]["flower"].ToString();
        Literal6.Text = ds.Tables["users"].Rows[2]["brick"].ToString();

        Literal7.Text = ds.Tables["users"].Rows[3]["flower"].ToString();
        Literal8.Text = ds.Tables["users"].Rows[3]["brick"].ToString();

        Literal9.Text = ds.Tables["users"].Rows[4]["flower"].ToString();
        Literal10.Text = ds.Tables["users"].Rows[4]["brick"].ToString();

        Literal11.Text = ds.Tables["users"].Rows[5]["flower"].ToString();
        Literal12.Text = ds.Tables["users"].Rows[5]["brick"].ToString();

        Literal13.Text = ds.Tables["users"].Rows[6]["flower"].ToString();
        Literal14.Text = ds.Tables["users"].Rows[6]["brick"].ToString();

        Literal15.Text = ds.Tables["users"].Rows[7]["flower"].ToString();
        Literal16.Text = ds.Tables["users"].Rows[7]["brick"].ToString();

        Literal17.Text = ds.Tables["users"].Rows[8]["flower"].ToString();
        Literal18.Text = ds.Tables["users"].Rows[8]["brick"].ToString();
    }


    protected void LoadVote()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        string sql = "";
        sql = "";
        sql += "SELECT * FROM TB_2009_VOTE ORDER BY vno";

        ds = cn.mdb_ds(sql, "users");

        sql = "";
        sql += "SELECT * FROM TB_2009_VOTECOUNT";

        ds1 = cn.mdb_ds(sql, "count");

        double count = Convert.ToDouble(ds1.Tables["count"].Rows[0]["vcount"].ToString());

        if (count == 0)
        {
            count = 1;
        }

        IMG1.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[0]["vote"].ToString()) / count * 300));
        Literal19.Text = ds.Tables["users"].Rows[0]["vote"].ToString();
        Literal20.Text = (Convert.ToDouble(ds.Tables["users"].Rows[0]["vote"].ToString()) / count * 100).ToString("N");

        IMG2.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[1]["vote"].ToString()) / count * 300));
        Literal21.Text = ds.Tables["users"].Rows[1]["vote"].ToString();
        Literal22.Text = (Convert.ToDouble(ds.Tables["users"].Rows[1]["vote"].ToString()) / count * 100).ToString("N");

        IMG3.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[2]["vote"].ToString()) / count * 300));
        Literal23.Text = ds.Tables["users"].Rows[2]["vote"].ToString();
        Literal24.Text = (Convert.ToDouble(ds.Tables["users"].Rows[2]["vote"].ToString()) / count * 100).ToString("N");

        IMG4.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[3]["vote"].ToString()) / count * 300));
        Literal25.Text = ds.Tables["users"].Rows[3]["vote"].ToString();
        Literal26.Text = (Convert.ToDouble(ds.Tables["users"].Rows[3]["vote"].ToString()) / count * 100).ToString("N");

        IMG5.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[4]["vote"].ToString()) / count * 300));
        Literal27.Text = ds.Tables["users"].Rows[4]["vote"].ToString();
        Literal28.Text = (Convert.ToDouble(ds.Tables["users"].Rows[4]["vote"].ToString()) / count * 100).ToString("N");

        IMG6.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[5]["vote"].ToString()) / count * 300));
        Literal29.Text = ds.Tables["users"].Rows[5]["vote"].ToString();
        Literal30.Text = (Convert.ToDouble(ds.Tables["users"].Rows[5]["vote"].ToString()) / count * 100).ToString("N");

        IMG7.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[6]["vote"].ToString()) / count * 300));
        Literal31.Text = ds.Tables["users"].Rows[6]["vote"].ToString();
        Literal32.Text = (Convert.ToDouble(ds.Tables["users"].Rows[6]["vote"].ToString()) / count * 100).ToString("N");

        IMG8.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[7]["vote"].ToString()) / count * 300));
        Literal33.Text = ds.Tables["users"].Rows[7]["vote"].ToString();
        Literal34.Text = (Convert.ToDouble(ds.Tables["users"].Rows[7]["vote"].ToString()) / count * 100).ToString("N");

        IMG9.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[8]["vote"].ToString()) / count * 300));
        Literal35.Text = ds.Tables["users"].Rows[8]["vote"].ToString();
        Literal36.Text = (Convert.ToDouble(ds.Tables["users"].Rows[8]["vote"].ToString()) / count * 100).ToString("N");

        IMG10.Width = Convert.ToInt32((Convert.ToDouble(ds.Tables["users"].Rows[9]["vote"].ToString()) / count * 300));
        Literal37.Text = ds.Tables["users"].Rows[9]["vote"].ToString();
        Literal38.Text = (Convert.ToDouble(ds.Tables["users"].Rows[9]["vote"].ToString()) / count * 100).ToString("N");


    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

            string vote1 = "0";
            if (CheckBox1.Checked == true)
            {
                vote1 = "1";
            }

            string vote2 = "0";
            if (CheckBox2.Checked == true)
            {
                vote2 = "1";
            }

            string vote3 = "0";
            if (CheckBox3.Checked == true)
            {
                vote3 = "1";
            }

            string vote4 = "0";
            if (CheckBox4.Checked == true)
            {
                vote4 = "1";
            }

            string vote5 = "0";
            if (CheckBox5.Checked == true)
            {
                vote5 = "1";
            }

            string vote6 = "0";
            if (CheckBox6.Checked == true)
            {
                vote6 = "1";
            }

            string vote7 = "0";
            if (CheckBox7.Checked == true)
            {
                vote7 = "1";
            }

            string vote8 = "0";
            if (CheckBox8.Checked == true)
            {
                vote8 = "1";
            }

            string vote9 = "0";
            if (CheckBox9.Checked == true)
            {
                vote9 = "1";
            }

            string vote10 = "0";
            if (CheckBox10.Checked == true)
            {
                vote10 = "1";
            }



            data_conn cn = new data_conn();
            string sql = "";
            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote1 + " WHERE vno = 1";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote2 + " WHERE vno = 2";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote3 + " WHERE vno = 3";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote4 + " WHERE vno = 4";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote5 + " WHERE vno = 5";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote6 + " WHERE vno = 6";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote7 + " WHERE vno = 7";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote8 + " WHERE vno = 8";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote9 + " WHERE vno = 9";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTE SET vote = vote + " + vote10 + " WHERE vno = 10";

            cn.mdb_exe(sql);

            sql = "";
            sql += "UPDATE TB_2009_VOTECOUNT SET vcount = vcount + 1";

            cn.mdb_exe(sql);


            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('感谢您的投票！');", true);
            LoadVote();

            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            CheckBox9.Checked = false;
            CheckBox10.Checked = false;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Cookies["2009_wish"].Value == "1")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您已经许过愿了哦！');", true);
        }
        else
        {
            check ck = new check();
            data_conn cn = new data_conn();

            string name = ck.CheckInput(Text1.Value);

            string wish = ck.CheckInput(TextArea1.Value);

            string sql = "";
            sql = "";
            sql += "INSERT TB_2009_WISH (name,txt) VALUES ('" + name + "','" + wish + "')";

            cn.mdb_exe(sql);

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('听到你的愿望了，愿它早日成真哦！');", true);
            Response.Cookies["2009_wish"].Value = "1";
            LoadWish();
        }

    }


    protected void LoadWish()
    {

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "";
        sql += "SELECT TOP 6 * FROM TB_2009_WISH ORDER BY id DESC";

        ds = cn.mdb_ds(sql,"wish");

        Repeater1.DataSource = ds.Tables["wish"].DefaultView;
        Repeater1.DataBind();
    }

    protected void Flower9Users(string uno)
    {
        data_conn cn = new data_conn();
        string sql = "";
        sql = "";
        sql += "UPDATE TB_2009_9USERS SET flower = flower + 1 WHERE uno = " + uno;

        cn.mdb_exe(sql);


        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('谢谢CCTV，谢谢MTV，谢谢大家！');", true);
        Load9Users();
 
    }

    protected void Brick9Users(string uno)
    {
        data_conn cn = new data_conn();
        string sql = "";
        sql = "";
        sql += "UPDATE TB_2009_9USERS SET brick = brick + 1 WHERE uno = " + uno;

        cn.mdb_exe(sql);


        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('各位大哥大姐，请手下留情啊！');", true);
        Response.Cookies["2009_9users"].Value = "1";
        Load9Users();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Flower9Users("1");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Brick9Users("1");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Flower9Users("2");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Brick9Users("2");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Flower9Users("3");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Brick9Users("3");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Flower9Users("4");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Brick9Users("4");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Flower9Users("5");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Brick9Users("5");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        Flower9Users("6");
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        Brick9Users("6");
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        Flower9Users("7");
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        Brick9Users("7");
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        Flower9Users("8");
    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        Brick9Users("8");
    }
    protected void LinkButton17_Click(object sender, EventArgs e)
    {
        Flower9Users("9");
    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        Brick9Users("9");
    }


}
