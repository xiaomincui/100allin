<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="club_repaste_index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>转贴 - 环球运费网</TITLE>
<META http-equiv=content-type content="text/html; charset=utf-8">
<link href="css/style.css" rel="stylesheet" type="text/css">
</HEAD>
<BODY>

<clubheader:clubheader ID="clubheader1" runat="server" />
<DIV id=wrap>
<DIV id=main>
<clubleft:clubleft ID="clubleft1" runat="server" />
 
<DIV id=mainarea>
<div class="left_tit">
<div class="left_tit_text"><img src="images/icon28.gif"><strong>转帖</strong></div>
<div class="left_tit_more"><a href="javascript:history.back(-1);">返回上一页</a></div>
</div>
<DIV id="tabs2">
<DIV class="menu2box">
<UL id="menu2">
<LI class="hover"><a href="index.aspx">我的转帖</a></LI>
<LI><a href="friend.aspx">好友的转帖</a></LI>
<LI><a href="repaste.aspx">我要转帖</a></LI>
<LI><a href="random.aspx">今日热门</a></LI>
</UL>
</DIV>

<DIV class="main2box">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
								<ul>
								  <li>
								    <table width="790" border="0" cellspacing="0" cellpadding="0">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                      <tr>
                                        <td width="580" valign="top"><table width="580" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td width="30" height="32" align="center" background="images/zt_1.gif"><img src="images/sy_dt_rj1.gif" width="16" height="16"></td>
                                            <td width="518" background="images/zt_1.gif"><span class="gray"><%#Eval("ttime").ToString() %> 转帖</span></td>
                                            <td width="37" background="images/zt_1.gif"><a href="detail.aspx?rid=<%#Eval("rid").ToString() %>#comment">评论</a></td>
                                          </tr>
                                          <tr>
                                            <td colspan="3"><table width="500" border="0" cellspacing="0" cellpadding="0">
											<tr>
                                                <td height="10" colspan="2"></td>
                                              </tr>
                                              <tr>
                                                <td width="30" height="22">&nbsp;</td>
                                                <td><a style="font-size:14px;" href="detail.aspx?rid=<%#Eval("rid").ToString() %>"><strong><%#Eval("topic").ToString() %></strong></a></td>
                                              </tr>
                                              <%#(Eval("userid1").ToString() == Eval("userid2").ToString()) ? "" : "<tr><td height=22>&nbsp;</td><td class=gray> 转自：" + Eval("realname1").ToString() + " 的转帖</td></tr>"%>
                                              
                                              <tr>
                                                <td height="22">&nbsp;</td>
                                                <td> <%#GetFirstString(NoHTML(Eval("txt").ToString()),140)%></td>
                                              </tr>
                                            </table></td>
                                          </tr>
                                        </table></td>
                                        <td width="210">&nbsp;</td>
                                      </tr>
                                      <tr>
                                        <td height="20" colspan="3"></td>
                                      </tr>
                                      </ItemTemplate>
                                      </asp:Repeater>
                                      <tr>
                                        <td width="580" height="20"><div class="page2">
                                        <%= pagecontrol_string%>
                                        </div></td>
                                        <td width="210 height="20">&nbsp;</td>
                                      </tr>
                                      <tr>
                                        <td height="20" colspan="3"></td>
                                      </tr>
                                    </table>
								  </li>
								</ul>
		</DIV>
</DIV>
</DIV><!--/mainarea-->
<DIV id=bottom></DIV>
</DIV><!--/main-->
<clubfooter:clubfooter ID="clubfooter1" runat="server" />
</DIV>
</BODY></HTML>
