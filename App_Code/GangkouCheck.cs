using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for GangkouCheck
/// </summary>
public class GangkouCheck
{
    public GangkouCheck()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static long? CheckMudiGang(string word)
    {
        SQLHelper.SQLHelper helper = new SQLHelper.SQLHelper();
        SqlDataReader reader;
        helper.RunSQL("select gangkou_id from V_GangkouSearch where mingcheng = @mingcheng", new SqlParameter[]
        {
            new SqlParameter("mingcheng",System.Data.SqlDbType.NVarChar, 250)
        }, out reader);

        long? gangkouId = null;
        if (reader.Read())
        {
            gangkouId = reader.GetInt64(0);
        }
        reader.Close();

        return gangkouId;
    }
}