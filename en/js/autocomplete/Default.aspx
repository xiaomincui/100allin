<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>主页搜索框 Ajax交互</title>
    <!--
/**
 * @function 主页港口搜索框的自动完成功能（AJAX交互）
 * @encode utf-8
 * @copyright (C) 徐奕峰
 * @file Default.aspx
 * @author 徐奕峰
 * @version 1.0
 * @date 2010-03-09
 * @description 1,JS库选用prototype
 *              2,已测浏览器 IE6,Firefox,Opera,Chrome
 *              3,传输字符串格式选用 json
 *              4,记录用户查询词频
 * @remark 1,暂不考虑 回传页面的缓存问题
 *         2,暂不考虑 提示纠错功能
 */
-->
    <style type="text/css">
body{
	margin:0px;
	padding:0px;
	font-size:12px;
}
div {
	padding-right: 0px;
	padding-left: 0px;
	padding-bottom: 0px;
	margin: 0px;
	padding-top: 0px;
}
#prot_warp
{
    font-size: 12px;
	font-family: arial, simsun;
	border:#7f9db9 1px solid;
	padding:4px;
	text-align: left;
	background-color: #ffffff;
	margin: 0px;
}
#prot_warp #prot_list a {
	color: #0055aa;
	text-decoration: none;
	line-height: 20px;
	display: block;
	curso: pointer;
	text-align: left;
	text-decoration:none;
	background-color:white;
	padding-left:5px;
	border:#fff 0px solid;
}
#prot_warp #prot_list a:hover{
	border-top: #7f9db9 1px solid;	
	background: #e7f1fd;	
	border-bottom: #7f9db9 1px solid;
}
#prot_warp #prot_list .hov{
	border-top: #7f9db9 1px solid;	
	background: #e7f1fd;	
	border-bottom: #7f9db9 1px solid;
}
#prot_warp #prot_list span {
	padding-right: 0px;
	padding-left: 0px;
	float: right;
	padding-bottom: 0px;
	margin: 0px;
	padding-top: 0px;
	text-align: left;
}

#prot_warp #prot_message {
	padding-right: 0px;
	display: block;
	padding-left: 5px;
	padding-bottom: 0px;
	color: #666;
	word-break: break-all;
	line-height: 20px;
	padding-top: 0px;
	border-bottom: #aaa 1px dashed;
	font-family: "simyou";
	word-wrap: break-word;
}
.autodiv
{
    max-height:300px;
    -webkit-max-height:300px;
    height:expression(this.scrollHeight>299?"300px":"auto");
}

</style>

    <script type="text/javascript" language="javascript" src="http://ajax.googleapis.com/ajax/libs/prototype/1.6.1.0/prototype.js"></script>
    
    <script type="text/javascript" language="javascript" src="port.js"></script>
</head>
<body>
    <div style="margin: 0 auto; width: 950px; text-align: center;">
        <br />
        <br />
        <input type="text" id="txtStartport" name="loading_prot_txt" style="border: 1px solid #000000;
            width: 200px"  onkeyup="autowords(this.id,event);"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <input type="text" id="txtDestport" name="destination_prot_txt" style="border: 1px solid #000000;
            width: 200px" onkeyup="autowords(this.id,event);"/>
        <br />
        <span id="messages"></span>
    </div>
</body>
</html>
