<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_json.aspx.cs" Inherits="test_json" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Javascript操作json在大数据量下的速度测试</title>
        <!--
/**
 * @function Javascript操作json在大数据量下的速度测试
 * @encode utf-8
 * @copyright (C) 徐奕峰
 * @file test_json.aspx
 * @author 徐奕峰
 * @version 1.0
 * @date 2010-03-15
 * @description 1,目标测试样本数据量 2000+
 *              2,
 * @remark 1,暂不考虑 回传页面的缓存问题
 *
 *
 *测试结果：（单位：毫秒）
 *-----------------------------------------------------------
 *         |  IE6   |  firefox  |  chrome   |   opera
 *-----------------------------------------------------------
 *  500条  |   80   |     7     |     9     |     15
 *-----------------------------------------------------------
 * 1000条  |  400   |    18     |    14     |     47
 *-----------------------------------------------------------
 * 1500条  |  900   |    20     |    20     |     78
 *-----------------------------------------------------------
 * 2000条  |  1700  |    42     |    30     |     140
 *-----------------------------------------------------------
 * 2500条  |  2700  |    40     |    33     |     204
 *-----------------------------------------------------------
 *注：以上数据均为平均数值
 */
-->

<script type="text/javascript">
/**
 * 重新排序
 * @param pr 按照pr列排序
 *          ENFL  英文首字母
 *          CHFL  拼音首字母
*/
function sort_prot(pr)
{
    var a = new Date();/*时间检测*/
    var arr = [];
    var txt = [];
    var res = prot_str || "[]";
    eval("txt = " + res);
    var i= 0;
    for (i = 0; i < txt.length-1; i++)
    {
            arr[i] =[];
            arr[i][0]=txt[i].id;
            if(pr=="ENFL")
            arr[i][1]=txt[i].ENFL;
            if(pr=="CHFL")
            arr[i][1]=txt[i].CHFL;
    }
    arr.sort(function(a,b){return a[1].localeCompare(b[1])});/*排序*/
    
    /*重新拼装json字符串*/
    var aa = "[";
    for(var t=0;t<arr.length-1;t++)
    {
        i = parseInt(arr[t][0],10) - 1;
        aa += "{\"id\":\""+arr[t][0]+"\",";
        aa += "\"CN\":\"" + txt[i].CN + "\",\"CNCH\":\"" + txt[i].CNCH + "\",\"ENFL\":\"" + txt[i].ENFL + "\",\"CHFL\":\"" + txt[i].CHFL +"\",\"Line\":\"" + txt[i].Line + "\"},";
    }
    aa +="{}]";
    //document.getElementById("show_port").innerHTML = "<br/>"+aa;
    prot_str = aa;
    /*时间检测*/
    var t1 = new Date().getTime()-a.getTime();
    var b = new Date();
    show_port();/*重绘页面数据*/
    var t2 = new Date().getTime()-b.getTime();
    alert("重新排序花费 "+t1+" 毫秒\n"+"页面显示花费 "+t2+" 毫秒\n"+"共花：" + (new Date().getTime()-a.getTime()) + "毫秒");
    prot_str = res;/*将json字符串还原*/
}
 
function show_port()
{
    var aa ="";
    aa +="<table style=\"border-collapse:collapse\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\">";
    aa += "<tr>";
    aa += "<td>ID</td>";
    aa += "<td>CN</td>";
    aa += "<td>CNCH</td>";
    aa += "<td>英文首字母</td>";
    aa += "<td>拼音首字母</td>";
    aa += "<td>Line</td>";
    aa += "</tr>";
    
    var txt = [];
    var res = prot_str || "[]";
    eval("txt = " + res);
    for (var i = 0; i < txt.length-1; i++)
    {
        aa += "<tr>";
        aa += "<td>"+txt[i].id+"</td>";
        aa += "<td>"+txt[i].CN+"</td>";
        aa += "<td>"+txt[i].CNCH+"</td>";
        aa += "<td>"+txt[i].ENFL+"</td>";
        aa += "<td>"+txt[i].CHFL+"</td>";
        aa += "<td>"+txt[i].Line+"</td>";
        aa += "</tr>";
    }
    aa += "</table>";
    document.getElementById("show_port").innerHTML = aa;
}
</script>
</head>
<body>
    <div id="info_sum">
    <script type="text/javascript">
    var info_sum ="<%= prot_sum %>";
    document.write( "共 <span style=\"color:red;\">"+info_sum+"</span> 条数据");
    </script>
    </div>
    <script type="text/javascript">
    var prot_str='<%= prot_str %>';
    </script>
    
    <div id="port_stor">
    <script type="text/javascript">
    //document.write(SortDemo());
    </script>
    </div>
    <div style="border-bottom-style: dashed; border-bottom-width: 1px; border-bottom-color: #000000">
</div>
    <input type="button" value="显示原始数据" onclick="show_port()" />
    <input type="button" value="英文首字母排序" onclick="sort_prot('ENFL')" />
    <input type="button" value="中文拼音首字母排序" onclick="sort_prot('CHFL')" />
    <div id="show_port"></div>
</body>
</html>
