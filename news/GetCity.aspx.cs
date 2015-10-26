using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news_GetCity : System.Web.UI.Page
{
    private string resultType = "json";
    protected void Page_Load(object sender, EventArgs e)
    {
        //获取请求的参数  
        if (!String.IsNullOrEmpty(Request.QueryString["resultType"]))
        {

            resultType = Request.QueryString["resultType"].ToLower() == "html" ? "html" : "json";
        }
        string html = GetResult(resultType);

        //清空缓冲区  
        Response.Clear();
        //将字符串写入响应输出流  
        Response.Write(html);
        //将当前所有缓冲的输出发送的客户端，并停止该页执行  
        Response.End();
    }

    private string GetResult(string resultType)
    {
        string result = "";
        if (resultType == "html")
        {

            //返回的html  
            result = @"<ul><li id=""1"">北京</li><li id=""2"">天津</li></ul>";
        }
        else if (resultType == "json")
        {
            //返回的json数据  
            result = @"  
[{""pkid"":""0001"",""ProvinceId"":""BJ"",""CityName"":""北京"",""CityNameEn"":""Beijing"",""PostCode"":""010"",""isHotCity"":false},  
 {""pkid"":""0002"",""ProvinceId"":""TJ"",""CityName"":""天津"",""CityNameEn"":""Tianjin"",""PostCode"":""022"",""isHotCity"":false}]";

        }
        return result;
    }  
}