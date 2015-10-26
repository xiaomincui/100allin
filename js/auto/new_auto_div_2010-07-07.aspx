<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_auto_div_2010-07-07.aspx.cs" Inherits="new_auto_div_2010_07_07" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>自动完成功能——优化版2010-07-07</title>
    <!--
/**
 * @function 自动完成功能——优化版
 * @encode utf-8
 * @copyright (C) 徐奕峰
 * @file new_auto_div_2010-07-07.aspx
 * @author 徐奕峰
 * @version 1.0
 * @date 2010-07-07
 * @description 1,修正前一个版本的已发现bug
 *              2,已测浏览器 IE6,Firefox,Chrome
 *              3,数据源种类命名规则：启运港：start_port
 *                                    目的港：end_port
 *                                    船公司：ship_com
 *                                    出发日：day_begin
 *                                    空港_目的港：air_port
 *                                    空港_起運港：air_start
 * @remark 1,textbox里添加autocomplete="off" 屏蔽浏览器的自动完成功能。
 *         2,更改触发事件，动态添加textbox的动作监听事件。
 *         3,本机测试：兼容ie6,firefox3.66,chrome4.0,opera10.6,safari4.05
 */
-->
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
        }
        div
        {
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
            border: #7f9db9 1px solid;
            padding: 4px;
            text-align: left;
            background-color: #ffffff;
            margin: 0px;
        }
        #prot_warp #prot_list a
        {
            color: #0055aa;
            text-decoration: none;
            line-height: 20px;
            display: block;
            cursor: pointer;
            text-align: left;
            text-decoration: none;
            background-color: white;
            padding-left: 5px;
            border: #fff 0px solid;
        }
        #prot_warp #prot_list a:hover
        {
            border-top: #7f9db9 1px solid;
            background: #e7f1fd;
            border-bottom: #7f9db9 1px solid;
        }
        #prot_warp #prot_list .hov
        {
            border-top: #7f9db9 1px solid;
            background: #e7f1fd;
            border-bottom: #7f9db9 1px solid;
        }
        #prot_warp #prot_list span
        {
            padding-right: 0px;
            padding-left: 0px;
            float: right;
            padding-bottom: 0px;
            margin: 0px;
            padding-top: 0px;
            text-align: left;
        }
        #prot_warp #prot_message
        {
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
            max-height: 300px;
            -webkit-max-height: 300px;
            height: expression(this.scrollHeight>299?"300px":"auto");
        }
        #vb
        {
            height: 230px;
        }
    </style>

    <script type="text/javascript" language="javascript" src="airprot_ch.js"></script>

    <script type="text/javascript" language="javascript" src="ac.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="messages">
        启运港：<asp:TextBox ID="TextBox1" runat="server" sou_type="start_port" onfocus="auto_init(event,this);" autocomplete="off">起运港</asp:TextBox><br />
        &nbsp;&nbsp;
        目的港：<asp:TextBox ID="TextBox2" runat="server" sou_type="end_port" onfocus="auto_init(event,this);" autocomplete="off">目的港</asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        船公司：<asp:TextBox ID="TextBox3" runat="server" sou_type="ship_com" onfocus="auto_init(event,this);" autocomplete="off">船公司</asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        船公司：<asp:TextBox ID="TextBox4" runat="server" sou_type="ship_com" onfocus="auto_init(event,this);" autocomplete="off">船公司</asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        目的港：<asp:TextBox ID="TextBox5" runat="server" sou_type="end_port" onfocus="auto_init(event,this);" autocomplete="off">目的港</asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        启运港：<asp:TextBox ID="TextBox6" runat="server" sou_type="start_port" onfocus="auto_init(event,this);" autocomplete="off"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        空港_目的港：<asp:TextBox ID="TextBox8" runat="server"
            sou_type="air_port" onfocus="auto_init(event,this);" autocomplete="off">目的地</asp:TextBox><br />
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
        空港_起運港：<asp:TextBox ID="TextBox9" runat="server"
            sou_type="air_start" onfocus="auto_init(event,this);" autocomplete="off">起运地</asp:TextBox><br />
        <hr />
        
    
    <input type="button"  value="aaaa" onclick="document.forms[0].submit();"/>
    </form>
    </div>
</body>
</html>
