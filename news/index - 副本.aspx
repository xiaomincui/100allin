<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="news_index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>航运动态-环球运费网</title>
<meta name="keywords" content="航运动态-环球运费网" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新航运动态" />
<link href="/css/doc20110107.css" rel="stylesheet" type="text/css" />
</head>
<body>


<div class="h_box">
    <usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
    <usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
    <usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
    <div class="menu">
        <h1>您的位置：<a href="/">首页</a> >  新闻资讯 &gt; <asp:Label ID="Label4" runat="server" Text=""></asp:Label></h1>
    </div>
    <div class="main_left" style="width:620px;line-height:25px;border:1px solid #F2C8C6; padding:10px 30px;"><!--左边开始-->
        <div class="news_list">
        <div style="width:612px;height:150px;display:none;">
            <div style="width:200px;height:150px;float:left;"><asp:Literal ID="Literal3" runat="server"></asp:Literal></div>
            <div style="width:390px;height:30px;float:left;font-size:16px; font-weight:bold; margin-left:15px;"><asp:Literal ID="Literal4" runat="server"></asp:Literal>今日要闻：<asp:Literal ID="Literal1" runat="server"></asp:Literal></a></div>
            <div style="width:390px;height:100px;float:left;margin-left:15px;"><asp:Literal ID="Literal2" runat="server"></asp:Literal>...</div>
            <div style="width:390px;height:20px;float:left;text-align:right; margin-left:15px;"><asp:Literal ID="Literal5" runat="server"></asp:Literal>更多>></a></div>
        </div>

						<h2>新闻资讯</h2>
						  <ul style="font-size:14px; line-height:25px; margin-top:10px;">
                        <asp:Repeater ID="Repeater4" runat="server">
                            <ItemTemplate>						  
							<li>·<a href="/news/1/2/<%#Eval("id") %>.html" target="_blank" title="<%#Eval("title") %>"><%#Eval("title") %></a> <span class="gray">(<%#Convert.ToDateTime(Eval("postdate").ToString()).ToString("M月d日") %>)</span></li>
                            </ItemTemplate>
                        </asp:Repeater>							
						  </ul>
						  <div class="manu"><a href="/news/1/2/list_1.html" style="font-size:14px;">更多资讯 >></a> </div>
						  <br/>
				    </div>
    </div>
    <!--左边结束-->	
    <div class="main_right" style="width:220px;float:left;line-height:25px;margin-left:20px;">
        <div class="right_box" style="padding:10px;border:1px solid #F2C8C6;margin-bottom:20px;display:none;">
            <div class="right_box_title" style="overflow:hidden;"><span style="float:right;"><a href="/news/1/11/list_1.html">更多>></a></span><h2 style="float:left;">船公司公告</h2>
            </div>
            <ul>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>						  
							<li style="padding:5px 0px; line-height:18px;"><a href="/news/1/2/<%#Eval("id") %>.html" target="_blank" title="<%#Eval("title") %>"><%#Eval("title") %></a> <span class="gray">(<%#Convert.ToDateTime(Eval("postdate").ToString()).ToString("M-d") %>)</span></li>
                            </ItemTemplate>
                        </asp:Repeater>	
            </ul>
        </div>
        <div class="right_box" style="padding:10px;border:1px solid #F2C8C6;margin-bottom:20px;display:none;">
            <div class="right_box_title"><h2>最新附加费</h2>
            </div>
            <ul>
	            <li><a href="/intro/orc.aspx"><%=DateTime.Now.Month %>月最新ORC</a> </li>
	            <li><a href="/intro/thc.aspx"><%=DateTime.Now.Month %>月各大船公司最新THC</a> </li>
	            <li><a href="/intro/baf.aspx"><%=DateTime.Now.Month %>月各大船公司最新BAF/CAF</a> </li>
            </ul>
        </div>
        <div class="right_box" style="padding:10px;border:1px solid #F2C8C6;margin-bottom:20px;">
            <div class="right_box_title"><h2>常用工具</h2>
            </div>
            <ul>
	            <li><a href="/carrier/">船公司查询</a> </li>
	            <li><a href="/ports/">世界港口库</a> </li>
	            <li><a href="/tools/hs.aspx">HS编码</a> </li>
	            <li><a href="/tools/tax.aspx">海关税率</a> </li>
            </ul>
        </div>          
    </div>
    <!--右边结束-->
    <userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
<script src="http://s16.cnzz.com/stat.php?id=2376862&web_id=2376862&show=pic1" language="JavaScript"></script>
</body>
</html>