<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commodity.aspx.cs" Inherits="biz_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>商务服务-报关商检-环球运费网</title>
<link href="/css2/nav.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/MSClass.js"></script>
    <script language="javascript" type="text/javascript">
    function msg(id)
    {
        
        document.getElementById("mm").style.visibility="visible";
        
        
        var ss = document.getElementById("Hidden1").value.split("$");
        
        
        mm.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
        mm.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)-500+"px";

        
        mm.innerHTML = ss[id-1] + "</br>" + "<div style=\"width:100%;text-align:right;\"><a href='javascript:hidden();'>关闭</a></div>";
       
    }
    
    function hidden()
    {
        
        document.getElementById('mm').style.visibility='hidden';
    
    }
    </script>
</head>

<body>
<form id="form2" runat="server">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 报关商检</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="main_box_left">
			  <div class="bar_box" >
					  <h1>报关商检&nbsp;<span style="font-size:13px; font-weight:normal;">[commodity]</span></h1>
					  <div class="list_box">
							<div class="sh">筛选城市：<a href="commodity.aspx" style="color:#FF6600"><strong>全部</strong></a> 
							<a href="commodity.aspx?city=上海">上海</a> 
							 
							 
							<a href="commodity.aspx?city=天津">天津</a> 
							 
							<a href="commodity.aspx?city=宁波">宁波</a> 
							  ...&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="color:#000; text-decoration:underline;" href="application_commodity.aspx">申请展示我的公司</a></div>
							<div class="list_title" style="margin-bottom:8px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业务类型&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;服务城市&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业务规模&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;联系方式&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业务描述&nbsp;&nbsp;&nbsp;</div>
							<ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                <li><table width="100%" height="25" border="0" cellpadding="0" cellspacing="3">
                                  <tr>
                                    <td width="16%" align="center"><span style="font-size:14px;"><strong>
                                    <%#Eval("typeshipout").ToString()=="1"?"海运出口":""%>
                                    <%#Eval("typeshipin").ToString()=="1"?"海运进口":""%>
                                    <%#Eval("typeshipinout").ToString()=="1"?"海运进出口":""%>
                                    <%#Eval("typeair").ToString()=="1"?"空运报关":""%>
                                    </strong></span></td>
                                    <td width="16%" align="center"><span style="font-size:14px;"><strong><%#Eval("city") != DBNull.Value ? Eval("city") : ""%></strong></span></td>
                                    <td width="17%" align="center"><span class="red bold"><%#Eval("portfolio") != DBNull.Value ? Eval("portfolio") : ""%>票</span>/月<br />
                                      报关员：<span class="red bold"><%#Eval("declarer")!=DBNull.Value?Eval("declarer"):""%>人</span> <br />
                                      查验员：<span class="red bold"><%#Eval("checker") != DBNull.Value ? Eval("checker") : ""%>人</span></td>
                                    <td width="22%" align="center"><strong style="font-size:14px; color:#225781;"><%#Eval("linkmen") != DBNull.Value ? Eval("linkmen") : ""%></strong><br />
                                      电话：<%#Eval("phone") != DBNull.Value ? Eval("phone") : ""%><br /><%#Eval("company") != DBNull.Value ? Eval("company") : ""%></td>
                                    <td width="29%" class="gray"><%#Eval("description") != DBNull.Value ? (Eval("description").ToString().Length > 100 ? Eval("description").ToString().Substring(0, 100) + "<a href='javascript:;'><div onclick=\"msg(" + (Container.ItemIndex + 1) + ")\">更多</div></a>" : Eval("description").ToString()) : ""%></td>
                                  </tr>
                                </table>
                                </li>
                                </ItemTemplate>
                                </asp:Repeater>
							
							  
								
							  <li style=" padding:12px 0px; border:none;"><DIV class=manu><span class="disabled"
    style="padding-right: 0px; padding-left: 0px; float: left; padding-bottom: 0px;
    margin: 0px; color: #28385a; border-top-style: none; line-height: 27px; padding-top: 0px;
    border-right-style: none; border-left-style: none; height: 27px; border-bottom-style: none">
    共 <strong>
        <asp:Label ID="lblTotalPage" runat="server" Text="1"></asp:Label></strong> 页
    <strong>
        <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong> 条记录
    &nbsp;以上是第 <strong>
        <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>
    页 </span>
                                    <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                    <asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged"
                                        >
                                    </asp:DropDownList></DIV></li>
							</ul>
					  </div>
                    <input id="Hidden1" type="hidden" runat="server" />
                    </div>
			  </div><!--左边结束-->	
	</div>
  </div>
		  </div>
					<!--左边结束-->	
					<div class="main_right" style="float: left; margin:0px;"><!--右边开始-->
					  <div class="c_us_l">
					    <useranswerleft:useranswerleft ID="useranswerleft_1" runat="server" />
					  </div>
					</div>
					<!--右边结束-->			
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
    </form>
    
  

</body>
</html>
