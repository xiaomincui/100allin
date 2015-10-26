<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BBSMessage.aspx.cs" Inherits="message_Default" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 运价搜索 - 整箱运价</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
#pp td{nowrap=true;}
-->
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>

</head>
<body onload="AutoTips('officetips')">
<form id="form2" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
			<div id="main">
				<adminleft:adminleft id="adminleft1" runat="server" />	
				<div id="right" language="javascript" onclick="return right_onclick()">
                        <div>
                            <br />
                            
                            
                            <table  width="963" height="161">
                                <tr> 
                                    <td width="148">
                                    <div  align="center">
                                    
                                        <asp:Image ID="Image1" runat="server" />
                                    </div>
                                        
                                    <div  align="center">
                                        <asp:Label ID="laltitlename" runat="server" Text="Label"></asp:Label></div>
                                    
                                    </td>
                                    
                                    
                                    <td width="550">
                                    <table  width="550" height="144">
                                        <tr>
                                            <td  height="21">
                                                <div  style="float:left">
                                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div align="right">
                                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></div>
                                            </td>
                                        </tr>
                                        <tr><td  height="96">
                            
                            
                            
                            
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td></tr>
                                        <tr><td  height="21">
                                            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%></td></tr>
                                    
                                    </table>
                                    
                                    </td>
                                </tr>
                            </table>
                            
                            
                            
                            
                            <br />
                            <asp:Repeater ID="Repeater1" runat="server" DataMember="DefaultView">
                            <ItemTemplate>
                           
                            
                            <table  width="963" height="161">
                                <tr> 
                                    <td width="148">
                                    <div  align="center">
                                    
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# (Convert.ToBoolean(Eval("HeadURL"))==true)? ("../member/Head/"+Eval("UserID")+".jpg"):("../member/Head/default.jpg") %>' />
                                    </div>
                                        
                                    <div  align="center"><%#Eval("UserName")%></div>
                                    
                                    </td>
                                    
                                    
                                    <td width="550">
                                    <table  width="550" height="144">
                                        <tr>
                                            <td  height="21">
                                                <div  style="float:left">
                                                    发表于：<%#Eval("PostDate")%>
                                                </div>
                                                <div align="right">
                                                    第<%# (Container.ItemIndex + 1) + (Convert.ToInt32(lblCurrentPage.Text)-1)*10%>楼
                                                </div>
                                            </td>
                                        </tr>
                                        <tr><td  height="96"><%#Eval("Data")%></td></tr>
                                        <tr><td  height="21">
                                            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%></td></tr>
                                    
                                    </table>
                                    
                                    </td>
                                </tr>
                            </table>
                            </br>
                            </ItemTemplate>
                            </asp:Repeater>
                            &nbsp;&nbsp;
                            <br />
                        <div class="page">
                            <div class="pageCount">
                                共 <strong>
                                    <asp:Label ID="lblTotalPage" runat="server" Text="1"></asp:Label></strong> 页
                                <strong>
                                    <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong> 条记录
                                &nbsp;以上是第 <strong>
                                    <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>
                                页</div>
                            <div class="pageControl">
                                <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                            </div>
                            <div class="pageText" style="width: 143px">
                                直接翻页：<asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown"
                                    OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                            <ce:editor id="TextBox1" runat="server"></ce:editor>
                            
                            
                            <br />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" /><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="删除回复" />
                        </div>
                    
                    
                    



				
				
				
				
				</div>
			</div>
		</div>
    </div>
	<div><img src="../images/blank.gif" width="100%" height="10" /></div>
	<div id="bottom">
		<div class="line"><img src="../images/line_blue.gif" width="100%" height="1" /></div>
		<div class="copyright"><a href="/intro/about.aspx">关于傲赢</a>|<a href="/intro/service.aspx">服务条款</a>|<a href="/intro/law.aspx">法律声明</a>|<a href="/intro/contact.aspx">联系我们</a><br />Copyright 2007 100Allin.com All Rights Reserved<br />沪ICP备07510944号<input id="Hidden1" runat="server" style="width: 1px" type="hidden" /></div>
	</div>
</form>		
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1">
function right_onclick() {

}

</script>	
</body>
</html>