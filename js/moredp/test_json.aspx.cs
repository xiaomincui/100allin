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
using System.Data.SqlClient;

public partial class test_json : System.Web.UI.Page
{
    public string prot_str, prot_sum;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * 取真实港口数据
         * 
        string strSQL = "";
        SqlDataReader sdr = null;
        strSQL = "SELECT CityName, CityNameCH, firstletter, firstletterCH,Line FROM dbo.TB_City ORDER BY fcount DESC";
        sdr = GetData.GetReaders(strSQL);
        prot_str += "[";
        int i = 0;
        while (sdr.Read())
        {
            i++;
            prot_str += "{\"id\":\"" + i + "\",";
            prot_str += "\"CN\":\"" + sdr["CityName"].ToString() + "\",\"CNCH\":\"" + sdr["CityNameCH"].ToString() + "\",\"ENFL\":\"" + sdr["firstletter"].ToString() + "\",\"CHFL\":\"" + sdr["firstletterCH"].ToString() + "\",\"Line\":\"" + sdr["Line"].ToString() + "\"},";
        }
        prot_str += "{}]";
        prot_sum = i.ToString();
        sdr.Dispose();
         */


        //随机生成港口数据，方便做测试用。
        Random_string();
    }
    private void Random_string()
    {
        /*样本容量 str_l */
        int i, str_l = 2000;
        prot_sum = str_l.ToString();
        prot_str += "[";
        for (i = 1; i <= str_l; i++)
        {
            prot_str += "{\"id\":\"" + i + "\",";
            prot_str += "\"CN\":\"" + CreateVerifyCode(5) + "\",\"CNCH\":\"" + CreateVerifyCode(5) + "\",\"ENFL\":\"" + CreateVerifyCode(1) + "\",\"CHFL\":\"" + CreateVerifyCode(1) + "\",\"Line\":\"" + CreateVerifyCode(4) + "\"},";
        }
        prot_str += "{}]";
    }

    private string CreateVerifyCode(int code_s)
    {
        string CodeSerial = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        string[] arr = CodeSerial.Split(',');

        string code = "";

        int randValue = -1;

        Random rand = new Random(Guid.NewGuid().GetHashCode());

        for (int i = 0; i < code_s; i++)
        {
            randValue = rand.Next(0, arr.Length - 1);

            code += arr[randValue];
        }

        return code;
    }
}
