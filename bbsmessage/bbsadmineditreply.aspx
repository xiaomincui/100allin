<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bbsadmineditreply.aspx.cs" Inherits="bbs_post" validateRequest=false %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">





<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    
    <link href="../admin/css/master.css" rel="stylesheet" type="text/css" />
    <link href="../admin/css/userlist.css" rel="stylesheet" type="text/css" />
      
    
    <link href="../css/bbs.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../bbs/editor/comm.css" />
    <script language="javascript" src="../bbs/editor/all.js"></script>
    <script language="javascript" src="../bbs/editor/editor.js"></script>
    <script language="javascript" src="../bbs/editor/editor_toolbar.js"></script>
    <script type="text/javascript">
    function fill(id)
    {

        document.getElementById("content").value=document.getElementById("Data"+id).outerText;
        fPutContent(document.getElementById("content").value);
    }
    
    
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
</head>
<body>
<form id="form2" runat="server">
    <div id="page">
		<div id="center">
			<bbsadmintop:bbsadmintop id="bbsadmintop1" runat="server" />
			<bbsadminmenu:bbsadminmenu id="bbsadminmenu1" runat="server" />
		  <div id="main">
			<bbsadminleft:bbsadminleft id="bbsadminleft1" runat="server" />			
			
			
			
			
			
			
				<div class="main_top_left" style="width:750px;">
				  
			  		<div class="mainbox formbox" style="width:750px;">
						<h1><a href="#">发新话题</a></h1>
						<table width="100%" cellspacing="0" cellpadding="0">
 <%-- <tr>
    <td width="22%" height="24" bgcolor="#E8F3FD" class="gray">用户名</td>
    <td width="78%" bgcolor="#E8F3FD"><span class="gray">
        <asp:Literal ID="Litusername" runat="server"></asp:Literal></span> <span class="blue"><a href="#">[退出登录]</a></span></td>
    </tr>--%>

  <tr>
    <td height="28">内容</td>
    <td>
    <br />
    <textarea id="content" name="content" style=" display:none"  runat="server"></textarea>
    <script language="javascript">
		gContentId = "content";//要载入内容的content ID
		OutputEditorLoading();
		</script>
    <iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:90%;height:500px;overflow:visible;" hideFocus></iframe>
    </td>
  </tr>

  <tr>
    <td height="28">&nbsp;</td>
    <td><span class="btns">
    <input type="button" value="发表帖子" onclick="DoProcess();document.getElementById('Button1').click()" />
        <div style=" display:none"><asp:Button ID="Button1" runat="server" Text="发表帖子" Width="81px" OnClick="Button1_Click" /></div></span></td>
  </tr>
                            <tr>
                                <td height="28">
                                    编辑备注</td>
                                <td>
                                    <asp:TextBox ID="txtMeno" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                        BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound"
                                        Width="740px">
                                        <Columns>
                                            
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="c6" style="width: 370px; overflow: hidden; text-overflow: ellipsis; padding-left: 20px">
                                                        <span id='Data<%# Eval("id") %>'>
                                                            <%# Eval("Data") %>
                                                        </span>
                                                        <%--<asp:Label ID='Data<%# Eval("id") %>' runat="server" Text='<%# Eval("Data") %>'></asp:Label>--%>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="170px" />
                                                <HeaderTemplate>
                                                    <div style="padding-left: 20px">
                                                        内容</div>
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="编辑人">
                                                <ItemTemplate>
                                                    <div class="c7">
                                                        <nobr><asp:Label ID="Label3" runat="server" Text='<%# Eval("username") %>'></asp:Label></nobr>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="编辑时间">
                                                <ItemTemplate>
                                                    <div class="c7">
                                                        <nobr><asp:Label ID="Label25" runat="server" Text='<%# Convert.ToDateTime(Eval("EditTime")).ToString("yy-MM-dd") %>'></asp:Label></nobr>
                                                    </div>
                                                    <div class="c7">
                                                        <nobr><asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("EditTime")).ToString("t") %>'></asp:Label></nobr>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    恢复
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript:fill('<%# Eval("id") %>')">
                                                        <img border="0" src="/admin/images/del.gif" /></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#F0F0F0" />
                                    </asp:GridView>
                                </td>
                            </tr>
</table>

				  </div>
	  		  </div>
				
		  
		  
		  
		
		
		
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>