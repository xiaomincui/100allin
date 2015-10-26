<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="shop_bloom_index" EnableViewState="false" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>杭州世航船务有限公司—环球运费网</title>
<meta name="description" content="" />
<meta name="keywords" content="" />

<link href="web.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div class="main">

    <div class="big_pic">
        <img src="images/home.jpg" alt="专注于非洲航线"/>
    </div>
	<div class="index">
	航&nbsp;&nbsp;&nbsp;线：<asp:Literal ID="Literal1" runat="server"></asp:Literal>
  </div>
	<div class="select">
	上海起运-<asp:Literal ID="Literal3" runat="server"></asp:Literal>-<asp:Literal ID="Literal4"
        runat="server"></asp:Literal>
    </div>
	<div class="table">
	  <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#666666">
          <tr>
            <td bgcolor="#96B9D5"><span class="table_title">目的港</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">20GP</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">40GP</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">40HQ</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">45HQ</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">船公司</span></td>
            <td bgcolor="#96B9D5" width="80"><span class="table_title">查看详细</span></td>
          </tr>
          <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
          <tr>
            <td bgcolor="#FFFFFF"><%#Eval("destport").ToString() %></td>
            <td bgcolor="#FFFFFF"><%#Eval("price20gp").ToString() %></td>
            <td bgcolor="#FFFFFF"><%#Eval("price40gp").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price40hq").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price45hq").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("shipcompany").ToString() %></td>
            <td bgcolor="#FFFFFF"><a href="/fcl/<%#setkey(Eval("sid").ToString())%>_<%#Eval("did").ToString() %>.html" target="_blank">查看详细</a></td>
          </tr>
          </ItemTemplate>
          </asp:Repeater>

        </table>
    </div>
    <div class="manu"><%= pagecontrol_string%> </div>
    <div class="foot">Copyright &copy; 2007-2011 www.100allin.com All Rights Reserved 沪ICP备07510944号 </div> 
</div>
<userblankbottom:userblankbottom ID="userblankbottom1" runat="server" />
</body>
</html>
