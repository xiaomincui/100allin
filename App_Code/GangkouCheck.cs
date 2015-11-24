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
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select gangkou_id from V_GangkouSearch where mingcheng = " + word.Replace("'", "''"), "gangkou");

        object gangkouId = ds.Tables["gangkou"].Rows[0]["gangkou_id"];
        if (gangkouId == null)
        {
            return -1;
        }
        return (long)gangkouId;
    }
}