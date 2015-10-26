using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// AllinUser 的摘要说明
/// </summary>
public class AllinUser
{
	public AllinUser()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    ///   <summary>   
    ///   获得某个用户的信息   
    ///   </summary> 
    ///   <param name="u">表示用户的userid</param>
    /// <returns>返回值：用户信息数组</returns>
    public string[] GetUserDetail(string u)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        u = ck.CheckNumber(u);

        string sql = "";

        sql = "SELECT * FROM TB_USER,TB_ORDER_ACCOUNT WHERE TB_USER.userid = TB_ORDER_ACCOUNT.userid AND TB_USER.userid = " + u + " ";

        ds = cn.mdb_ds(sql, "user");

        //HttpContext.Current.Response.Write(sql);

        string[] k;
        k = new string[100];
        k[0] = ds.Tables["user"].Rows[0]["UserID"].ToString(); //用户编号
        k[1] = ds.Tables["user"].Rows[0]["UserName"].ToString(); //用户名
        k[2] = ds.Tables["user"].Rows[0]["UserPassword"].ToString(); //密码
        k[3] = ds.Tables["user"].Rows[0]["RealName"].ToString(); //真实姓名
        k[4] = ds.Tables["user"].Rows[0]["CompanyName"].ToString(); //公司名
        k[5] = ds.Tables["user"].Rows[0]["UserEmail"].ToString(); //邮箱
        k[6] = ds.Tables["user"].Rows[0]["MovePhone"].ToString(); //手机
        k[7] = ds.Tables["user"].Rows[0]["Phone"].ToString(); //电话
        k[8] = ds.Tables["user"].Rows[0]["Fax"].ToString(); //传真
        k[9] = ds.Tables["user"].Rows[0]["ali_account"].ToString(); //阿里账户
        k[10] = ds.Tables["user"].Rows[0]["UCenterHomeUid"].ToString(); //uid
        k[11] = ds.Tables["user"].Rows[0]["star_allin"].ToString();
        k[12] = ds.Tables["user"].Rows[0]["star_user"].ToString();

        k[50] = ds.Tables["user"].Rows[0]["bank"].ToString(); //传真
        k[51] = ds.Tables["user"].Rows[0]["bankname"].ToString(); //传真
        k[52] = ds.Tables["user"].Rows[0]["bankaccount"].ToString(); //传真
        k[53] = ds.Tables["user"].Rows[0]["otheraccount"].ToString(); //传真
        k[54] = ds.Tables["user"].Rows[0]["credit"].ToString(); //传真
        k[55] = ds.Tables["user"].Rows[0]["overage"].ToString(); //传真

        k[61] = ds.Tables["user"].Rows[0]["Login2_Locus1"].ToString(); //区
        k[62] = ds.Tables["user"].Rows[0]["Login2_Locus2"].ToString(); //市
        return k;
    }//取得运价详细信息
}
