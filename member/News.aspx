<%@ Page Language="C#" MasterPageFile="~/member/member.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="member_News" Title="Untitled Page" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

				
				  
                  <div style=" float :left">标题：<asp:TextBox ID="txtTitle" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left; margin-left:10px; width: 129px; margin-bottom:15px">
                      类型：<asp:DropDownList ID="DropDownList1" runat="server" Width="86px">
                      <asp:ListItem Value="5">新闻</asp:ListItem>
                      <asp:ListItem Value="6">商务服务</asp:ListItem>
                  </asp:DropDownList></div>
                  
                 <%-- <CE:Editor ID="Editor1" runat="server">
                  </CE:Editor>--%>
    <CE:Editor ID="Editor1" runat="server">
    </CE:Editor>
                 
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
                  发布时间<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>	
</asp:Content>

