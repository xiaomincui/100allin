using System;
using System.Collections.Generic;
using System.Data;
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

    public static long CheckMudiGang(string word)
    {
        data_conn3 cn = new data_conn3();
        SqlConnection conn = cn.mdb_conn();

        conn.Open();
        SqlCommand cmd = new SqlCommand("select gangkou_id from V_GangkouSearch where mingcheng = @mingcheng", conn);
        cmd.Parameters.AddWithValue("mingcheng", word);
        object gangkouId = cmd.ExecuteScalar();
        conn.Close();

        if (gangkouId == null)
        {
            return -1;
        }
        return (long)gangkouId;
    }
}