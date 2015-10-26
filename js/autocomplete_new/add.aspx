<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员页面港口，船公司文本框的自动完成功能</title>
    <!--
/**
 * @function 管理员页面港口，船公司文本框的自动完成功能
 * @encode utf-8
 * @copyright (C) 徐奕峰
 * @file add.aspx
 * @author 徐奕峰
 * @version 1.0
 * @date 2010-03-09
 * @description 1,数据信息库为 port_add.js
 *              2,已测浏览器 IE6,Firefox,Chrome
 *              3,数据源种类命名规则：启运港：start_port
 *                                    目的港：end_port
 *                                    船公司：ship_com
 *                                    出发日：day_begin
 *                                    空港_目的港：air_port
 *                                    空港_起運港：air_start
 * @remark 1,
 *         2,
 *         3,
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
            curso: pointer;
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
    </style>

    <script type="text/javascript" language="javascript" src="airprot_ch.js"></script>

    <script type="text/javascript" language="javascript" src="port_add.js"></script>

    <%--<script type="text/javascript" language="javascript" src="port_en.js"></script>--%>

</head>
<body>
    <div id="aaa" style="position: absolute; width: 169px; height: 274px; z-index: 1;
        left: 659px; top: 9px">
    </div>
    <form id="form1" runat="server">
    <div id="messages">
        启运港：<asp:TextBox ID="TextBox1" runat="server" sou_type="start_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp;&nbsp;
        目的港：<asp:TextBox ID="TextBox2" runat="server" sou_type="end_port" onkeyup="autowords(this,event);"
            onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        船公司：<asp:TextBox ID="TextBox3" runat="server" sou_type="ship_com" onkeyup="autowords(this,event);"
            onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        船公司：<asp:TextBox ID="TextBox4" runat="server" sou_type="ship_com" onkeyup="autowords(this,event);"
            onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        目的港：<asp:TextBox ID="TextBox5" runat="server" sou_type="end_port" onkeyup="autowords(this,event);"
            onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        启运港：<asp:TextBox ID="TextBox6" runat="server" sou_type="start_port" onkeyup="autowords(this,event);"
            onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;空港_目的港：<asp:TextBox ID="TextBox8" runat="server"
            sou_type="air_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 空港_起運港：<asp:TextBox ID="TextBox9" runat="server"
            sou_type="air_start" onkeyup="autowords(this,event);" onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox><br />
        <hr />
        出发日：<asp:TextBox ID="TextBox7" runat="server" sou_type="day_begin" onclick="autowords(this,event);event.cancelBubble=true;"></asp:TextBox>
    </div>
    </form>
    <textarea id="vb"></textarea>
    <input type="button" value="vv" onclick="vba();" />

    <script>
        function vba() {
            res = bote_str || "[]";
            eval("txt = " + res);
            txt_l = txt.length;
            var aa = [];
            aa.push("[");
            for (var i = 0; i < txt_l - 1; i++) {
                //aa.push("{\"c\":\"" + txt[i].CN + "\",\"d\":\""+txt[i].Country+"\"},")
                aa.push("{\"c\":\"" + txt[i].CN + "\"},");
            }
            aa.push("{}]");
            document.getElementById("vb").value = aa.join("");
        }
    </script>

</body>
</html>
