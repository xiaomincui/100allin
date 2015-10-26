using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using SQLHelper;
using System.Data.SqlClient;


/// <summary>
/// GetData 的摘要说明
/// </summary>
public class GetData
{
    public GetData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static SqlDataReader GetReaders(string sql)
    {
        ///定义类SQLHelper
        SQLHelper.SQLHelper sqlHelper = new SQLHelper.SQLHelper();

        ///定义保存从数据库获取的结果的DataReader
        SqlDataReader dr = null;

        try
        {
            sqlHelper.RunSQL(sql, out dr);
        }
        catch (Exception ex)
        {
            SystemError.CreateErrorLog(ex.Message);
            throw new Exception(ex.Message, ex);
        }
        return (dr);
    }

}
