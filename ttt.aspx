<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ttt.aspx.cs" Inherits="ttt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body style="font-size:12px; font-family:Arial;">
    <form id="form1" runat="server">
    <div>
        美加线 整箱<BR/>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        美加线 拼箱<BR/>
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        欧地线 整箱<BR/>
        <asp:Repeater ID="Repeater3" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        欧地线 拼箱<BR/>
        <asp:Repeater ID="Repeater4" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        中南美线 整箱<BR/>
        <asp:Repeater ID="Repeater5" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        中南美线 拼箱<BR/>
        <asp:Repeater ID="Repeater6" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        日韩线 整箱<BR/>
        <asp:Repeater ID="Repeater7" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        日韩线 拼箱<BR/>
        <asp:Repeater ID="Repeater8" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        
        近洋线 整箱<BR/>
        <asp:Repeater ID="Repeater9" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        近洋线 拼箱<BR/>
        <asp:Repeater ID="Repeater10" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        非洲线 整箱<BR/>
        <asp:Repeater ID="Repeater11" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        非洲线 拼箱<BR/>
        <asp:Repeater ID="Repeater12" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        澳洲线 整箱<BR/>
        <asp:Repeater ID="Repeater13" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        澳洲线 拼箱<BR/>
        <asp:Repeater ID="Repeater14" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        中东印巴线 整箱<BR/>
        <asp:Repeater ID="Repeater15" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        中东印巴线 拼箱<BR/>
        <asp:Repeater ID="Repeater16" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
        红海线 整箱<BR/>
        <asp:Repeater ID="Repeater17" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater>
        <BR/>
        
        红海线 拼箱<BR/>
        <asp:Repeater ID="Repeater18" runat="server">
        <ItemTemplate>
        <%#Server.HtmlEncode(Eval("PortLink").ToString()) %>
        </ItemTemplate>
        </asp:Repeater> 
        <BR/>
        
    </div>
    </form>
</body>
</html>
