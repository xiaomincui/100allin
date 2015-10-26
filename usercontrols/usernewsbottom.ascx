<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usernewsbottom.ascx.cs" Inherits="usercontrols_usernewsbottom" %>
 <div class="news">
 	<div class="news_box">
		<ul style="border-right:1px solid #BAC6D2;">
			<li id="news_box_tit" style="border:none; height:32px; background:url(/images/fcl/ul_bg.jpg) repeat-x bottom;"><img src="/images/fcl/news.gif" />&nbsp;<a href="/bbs/forum-5-1.html">航运动态</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="font-weight:normal; text-decoration:underline;" href="/bbs/forum-5-1.html">更多..</a></li>
		    <asp:Repeater ID="RptaHangYunDongTai" runat="server">
              <ItemTemplate>
              <li style="width:306px;overflow:hidden; text-overflow:ellipsis; line-height:24px;"><a href="/bbs/thread-<%#Eval("id")%>-1.html" target="_blank" ><nobr>·(<%# Convert.ToDateTime(Eval("postdate")).ToString("MM-dd")%>)<%#Eval("title")%></nobr></a></li>
		      </ItemTemplate>
            </asp:Repeater>			
			
		</ul>
		<ul>
			 <li id="news_box_tit" style="border:none; height:32px; background:url(/images/fcl/ul_bg.jpg) repeat-x bottom;"><img src="/images/fcl/news.gif" />&nbsp;商务服务&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
			<li style="border:none; height:24px;">&nbsp;&nbsp;<img style="margin-top:8px;" src="/images/fcl/jt3.gif" width="8" height="8" />&nbsp;<a href="/bis/insurance.aspx" target="_blank" style="text-decoration:underline"><strong>保险</strong></a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;<img style="margin-top:8px;" src="/images/fcl/jt3.gif" width="8" height="8" />&nbsp;<a href="/message/BBSListExhibition.aspx" target="_blank" style="text-decoration:underline"><strong>展会</strong></a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;<img style="margin-top:8px;" src="/images/fcl/jt3.gif" width="8" height="8" />&nbsp;<a href="/bis/bank.aspx" target="_blank" style="text-decoration:underline"><strong>银行</strong></a>&nbsp;&nbsp;&nbsp;|</li>
			<li>·<a href="/bis/inspicc.aspx" target="_blank">中国人保财产保险</a></li>
			<li>·<a href="/bis/inspa.aspx" target="_blank">中国平安财产保险</a></li>
			<li>·<a href="/bis/inscpic.aspx" target="_blank">中国太平洋财产保险 </a></li>
			<li>·<a href="/bis/insdd.aspx" target="_blank">中国大地财产保险股份有限公司</a></li>
			<li>·<a href="/bis/insun.aspx" target="_blank">中华联合财产保险公司</a></li>
		</ul>
   </div>
 </div>