<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usernewnewsbottom.ascx.cs" Inherits="usercontrols_usernewnewsbottom" %>
<div class="news_box">
    <ul >
	    <li class="news_box_tit" style="margin-bottom:12px; font:14px '宋体';padding-top:6px;"><img src="/images/fcl/news.gif" />&nbsp;<a href="/bbs/forum-5-1.html" target="_blank"><strong>航运动态</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="news_box_tit" style="margin-bottom:12px; font:14px '宋体';padding-top:6px;">&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="font-weight:normal; text-decoration:underline;" href="/bbs/forum-5-1.html">更多..</a></li>
        <asp:Repeater ID="RptaHangYunDongTai" runat="server">
          <ItemTemplate>
          <li><a href="/bbs/thread-<%#Eval("id")%>-1.html" target="_blank" >·(<%# Convert.ToDateTime(Eval("postdate")).ToString("MM-dd")%>)<%#Eval("title")%></a></li>
          </ItemTemplate>
        </asp:Repeater>		
    </ul>
    <ul>
      <li class="news_box_tit" style="margin-bottom:12px; font:12px '宋体';padding-top:6px;"><img src="/images/fcl/news.gif" />&nbsp;<strong>商务服务</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="news_box_tit" style="margin-bottom:12px; font:14px '宋体';padding-top:6px;">&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
      <li style="border:none; height:24px;">&nbsp;&nbsp;|&nbsp;&nbsp;<a href="/message/BBSListExhibition.aspx" target="_blank" style="text-decoration:underline"><strong>展会</strong></a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="/bis/insurance.aspx" target="_blank" style="text-decoration:underline"><strong>保险</strong></a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="/bis/bank.aspx" target="_blank" style="text-decoration:underline"><strong>银行</strong></a>&nbsp;&nbsp;&nbsp;|</li>
    <li>·<a href="/bis/inspicc.aspx" target="_blank">中国人保财产保险</a></li>
    <li>·<a href="/bis/inspa.aspx" target="_blank">中国平安财产保险</a></li>
    <li>·<a href="/bis/inscpic.aspx" target="_blank">中国太平洋财产保险 </a></li>
    <li>·<a href="/bis/insdd.aspx" target="_blank">中国大地财产保险股份有限公司</a></li>
    </ul>
</div>
 
    

