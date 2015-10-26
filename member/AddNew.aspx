<%@ Page Language="C#" MasterPageFile="~/member/member.master" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="member_AddNew" Title="Untitled Page" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	
				  
                  <div style=" float :left">标题：<asp:TextBox ID="txtTitle" runat="server" Width="572px"></asp:TextBox></div>

    <CE:Editor ID="Editor1" runat="server">
    </CE:Editor>
                  
                  
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
                  发布时间<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>		
</asp:Content>

