<%@ Page Language="C#" AutoEventWireup="true" CodeFile="air_detail.aspx.cs" Inherits="admin_userlist" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>    
    <script type="text/javascript" language="javascript" src="../Web_Admin/include/calendar.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
</head>
<body>
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				
				
				
				
				
				<div>


    <table style="width: 773px; height: 144px">
        <tr>
            <td valign="top" style="width: 436px; height: 311px;">
    <div style=" margin-top:0px; margin-right:0px; height: 1px;" >
    <table border="0" cellpadding="2" cellspacing="1" bgcolor="#D9D9D9" style="width: 460px; height: 300px; ">
        <tr>
            <td bgcolor="#F9F9F9" style=" width:80px; height: 12px; ">
                &nbsp; &nbsp;
            运价标题：            </td>
         <td bgcolor="#F9F9F9" style="width: 263px; height: 12px">
        <asp:TextBox ID="TextBox1" runat="server" Width="339px"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td bgcolor="#F9F9F9" style="width: 80px; height: 26px;">
                &nbsp; &nbsp;
            发布时间：            </td>
         <td bgcolor="#F9F9F9" style="width: 263px">
             <span style="color: #226077">
             <input id="txtpostdate" runat="server" name="date1" type="text" style="width: 149px" />
                 <A onclick=event.cancelBubble=true; href="javascript:showCalendar('IMG1',true,'txtpostdate',null);">                   <IMG id=IMG1 height=21 src="../web_Admin/images/button.gif" width=34 align=absMiddle border=0>
                 </A>
                 <asp:TextBox ID="TextBox16" runat="server" Visible="False" Width="95px"></asp:TextBox></span></td>
        </tr>
        
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px;  ">
                &nbsp; &nbsp; 有效时间：</td>
         <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
            <span style="color: #226077">
             <input id="txtenddate" runat="server" name="date1" type="text" style="width: 149px" />
                 <A onclick=event.cancelBubble=true; href="javascript:showCalendar('imageCalendar1',true,'txtenddate',null);">                   <IMG id=imageCalendar1 height=21 src="../web_Admin/images/button.gif" width=34 align=absMiddle border=0>
                 </A>
            </span>
                 
             </td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; ">
                &nbsp; &nbsp; 运价类型：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                &nbsp;<asp:Label ID="lblyunjialeixing" runat="server" Text="空运" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px;">
                &nbsp; &nbsp; 起运港：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:TextBox ID="txtStartPost" runat="server">
      
    </asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; ">
                &nbsp; &nbsp; 航线描述：            </td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:DropDownList ID="ddlhangxianmiaoshu" runat="server">
        <asp:ListItem>请选择</asp:ListItem>
        <asp:ListItem>美加线</asp:ListItem>
        <asp:ListItem>欧地线</asp:ListItem>
        <asp:ListItem>中南美线</asp:ListItem>
        <asp:ListItem>日韩线</asp:ListItem>
        <asp:ListItem>近洋线</asp:ListItem>
        <asp:ListItem>非洲线</asp:ListItem>
        <asp:ListItem>澳洲线</asp:ListItem>
        <asp:ListItem>中东印巴线</asp:ListItem>
        <asp:ListItem>红海线</asp:ListItem>
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="#f9f9f9" style="width: 80px; height: 26px">
                &nbsp; &nbsp; 点击量：
            </td>
            <td bgcolor="#f9f9f9" style="width: 263px; height: 26px">
                <asp:TextBox ID="txthit" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; ">
                &nbsp; &nbsp;
                备 注：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:TextBox ID="txtmemo" runat="server" Height="70px" Width="339px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
  </table>
  
  
  </div>
          </td>
            <td valign="top" style="width: 259px; height: 311px;">
            <%--<div style=" height: 300px; background-color:#F2F8FB ; border-bottom: #dbeef5 1px solid; border-right: #dbeef5 1px solid; border-left: #dbeef5 1px solid;">--%>
            <table border="0" cellspacing="0"  style="width: 285px; height: 138px;background-color:#F9F9F9; border-top: #D9D9D9 1px solid; border-right: #D9D9D9 1px solid; border-left: #D9D9D9 1px solid; border-bottom: #D9D9D9 1px solid;">
            
            
            <tr>
                <td colspan="2" style="height: 28px; padding-left:10px; font-weight: bold;  vertical-align: bottom;">
                    <div id="tt" runat="server">
                    您的名片
                    </div>
                    </td>
            </tr>
            
            <tr>
                <td colspan="2" style="padding-left:10px; height: 34px;">
                    &nbsp;<asp:TextBox ID="txtname" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Font-Bold="True" Font-Names="宋体" Font-Size="Medium"  Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style=" padding-left:10px; width: 389px;  height: 27px;">
                    公司名称：</td>
                <td style="width: 260px; height: 25px;">
                    &nbsp;
                    <asp:TextBox ID="txtCompanyName" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; height: 27px;">
                    电话号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtPhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px" Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; height: 27px;">
                    传真号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtFax" runat="server" BackColor="#F9F9F9" BorderWidth="0px" Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px;  height: 27px;">
                    手机号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtMovePhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; height: 27px;">
                    电子邮箱：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtUserEmail" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px; height: 27px;">
                        公司地址：</td>
                    <td style="width: 260px">
                        &nbsp;
                        <asp:TextBox ID="txtAddress" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                            Width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px;  height: 27px;">
                        邮政编码：</td>
                  <td style="width: 260px">&nbsp;
                      <asp:TextBox ID="txtPostNumber" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                          Width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px;  height: 27px;">
                        </td>
                    <td style="width: 260px; height: 27px;">
                        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.100allin.com"
                            Target="_blank" Visible="False">www.100allin.com</asp:HyperLink>
                <input id="Hidden1" runat="server" type="hidden" visible="false" /></td>
                </tr>
            
            
            
 
            
            
            
            
            </table>
                <%--</div>--%>
            
            
            
            
            
            
            
            
            
            
          </td>
        </tr>
        <tr>
            <td colspan="2"  style="vertical-align: middle">
            <div id="Div1">
            
            
            
            
                <div id="head" runat="server">
                    <table  bgcolor="#D9D9D9" border="0" cellpadding="2" cellspacing="1" style="border-collapse: collapse; width: 761px;">
                            <tr>
                                <td bgcolor="#F9F9F9" style="width: 85px; height: 25px; vertical-align: middle; text-align: center;">
                                    目的港</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    M</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    N</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    45</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    100</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    300</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    500</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    1000</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px; vertical-align: middle; text-align: center;">
                                    附加费</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px;vertical-align: middle; text-align: center;">
                                    航程</td>
                                <td bgcolor="#F9F9F9" style="width: 48px; height: 25px;vertical-align: middle; text-align: center;">
                                    出发日</td>
                                <td bgcolor="#F9F9F9" style="width: 68px; height: 25px;vertical-align: middle; text-align: center;">
                                    备注</td>
                                <td bgcolor="#F9F9F9" style=" height: 25px;vertical-align: middle; text-align: center;">
                                    操作</td>
                            </tr>
                        
                        
                        
                        </table>
                </div>
            
            
            
          
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="SqlDataSource1" Width="761px" Height="1px" ShowHeader="False" OnDataBound="GridView1_DataBound" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" Visible="False">
            </asp:BoundField>
            <asp:TemplateField HeaderText="AIRID" SortExpression="AIRID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AIRID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle CssClass="hidden" />
                <HeaderStyle CssClass="hidden" />
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AIRID") %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle CssClass="hidden" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目的港" SortExpression="DESTPORT">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DESTPORT") %>' Width="81px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2"
                        CssClass="hidden" ErrorMessage="不能为空！！！" OnServerValidate="CustomValidator1_ServerValidate"
                        ValidateEmptyText="True"></asp:CustomValidator>
                </EditItemTemplate>
                <ItemStyle Width="87px" Font-Bold="False" />
                <ItemTemplate>
                    <div style="word-break:break-all;"><asp:Label ID="Label2" runat="server" Text='<%# Bind("DESTPORT") %>'></asp:Label></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" Font-Names="宋体"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="M" SortExpression="PRICE_M">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PRICE_M") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PRICE_M") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" Font-Names="宋体"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N" SortExpression="PRICE_N">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PRICE_N") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PRICE_N") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="+45" SortExpression="PRICE_P45">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PRICE_P45") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("PRICE_P45") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="+100" SortExpression="PRICE_P100">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PRICE_P100") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("PRICE_P100") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="+300" SortExpression="PRICE_P300">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("PRICE_P300") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("PRICE_P300") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="+500" SortExpression="PRICE_P500">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("PRICE_P500") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("PRICE_P500") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="+1000" SortExpression="PRICE_P1000">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("PRICE_P1000") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("PRICE_P1000") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="附加费" SortExpression="price20gpAppend">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("price20gpAppend") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="航程" SortExpression="Distance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Distance") %>'  Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("Distance") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="离港" SortExpression="departurewkd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("departurewkd") %>' Width="44px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("departurewkd") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" Font-Names="宋体"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" SortExpression="memo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("memo") %>'  Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="70px" />
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False"  HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="操作" >
                <HeaderStyle Font-Bold="False" Font-Names="宋体"  HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Columns>
        <RowStyle Height="25px" />
        <HeaderStyle BackColor="#F9F9F9" Height="25px" />
        <EditRowStyle Height="20px" />
    </asp:GridView>
    
    
    
    
    
    
    
    
    
    <table cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;width:761px;border-collapse:collapse;">
    
        <tr>
            <td style="height: 26px; width:87px">
    
    
    
    
    
        <asp:TextBox ID="TextBox4" runat="server" Width="81px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
    <asp:TextBox ID="TextBox5" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox6" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox7" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox8" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox9" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox10" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
        <asp:TextBox ID="TextBox11" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
                <asp:TextBox ID="TextBox12" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
                <asp:TextBox ID="TextBox13" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:50px">
                <asp:TextBox ID="TextBox14" runat="server" Width="44px"></asp:TextBox></td>
            <td style="height: 26px; width:70px">
                <asp:TextBox ID="TextBox15" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;">
        <asp:Button ID="Button2" runat="server" Text="添加" Width="34px" OnClick="Button2_Click" /></td>
            
        </tr>
    
    
    
    </table>
    
    
    
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_DataBase_newConnectionString2 %>"
        DeleteCommand="DELETE FROM [T_AIRPRICE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [T_AIRPRICE] ([AIRID], [DESTPORT], [PRICE_M], [PRICE_N], [PRICE_P45], [PRICE_P100], [PRICE_P300], [PRICE_P500], [PRICE_P1000], [departurewkd], [memo], [price20gpAppend], [Distance]) VALUES (@AIRID, @DESTPORT, @PRICE_M, @PRICE_N, @PRICE_P45, @PRICE_P100, @PRICE_P300, @PRICE_P500, @PRICE_P1000, @departurewkd, @memo, @price20gpAppend, @Distance)"
        SelectCommand="SELECT [ID], [AIRID], [DESTPORT], [PRICE_M], [PRICE_N], [PRICE_P45], [PRICE_P100], [PRICE_P300], [PRICE_P500], [PRICE_P1000], [departurewkd], [memo], [price20gpAppend], [Distance] FROM [T_AIRPRICE] WHERE ([AIRID] = @AIRID)"
        UpdateCommand="UPDATE [T_AIRPRICE] SET [AIRID] = @AIRID, [DESTPORT] = @DESTPORT, [PRICE_M] = @PRICE_M, [PRICE_N] = @PRICE_N, [PRICE_P45] = @PRICE_P45, [PRICE_P100] = @PRICE_P100, [PRICE_P300] = @PRICE_P300, [PRICE_P500] = @PRICE_P500, [PRICE_P1000] = @PRICE_P1000, [departurewkd] = @departurewkd, [memo] = @memo, [price20gpAppend] = @price20gpAppend, [Distance] = @Distance WHERE [ID] = @ID" ProviderName="<%$ ConnectionStrings:DB_DataBase_newConnectionString2.ProviderName %>">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="AIRID" Type="Int32" />
            <asp:Parameter Name="DESTPORT" Type="String" />
            <asp:Parameter Name="PRICE_M" Type="String" />
            <asp:Parameter Name="PRICE_N" Type="String" />
            <asp:Parameter Name="PRICE_P45" Type="String" />
            <asp:Parameter Name="PRICE_P100" Type="String" />
            <asp:Parameter Name="PRICE_P300" Type="String" />
            <asp:Parameter Name="PRICE_P500" Type="String" />
            <asp:Parameter Name="PRICE_P1000" Type="String" />
            <asp:Parameter Name="departurewkd" Type="String" />
            <asp:Parameter Name="memo" Type="String" />
            <asp:Parameter Name="price20gpAppend" Type="String" />
            <asp:Parameter Name="Distance" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="AIRID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="AIRID" Type="Int32" />
            <asp:Parameter Name="DESTPORT" Type="String" />
            <asp:Parameter Name="PRICE_M" Type="String" />
            <asp:Parameter Name="PRICE_N" Type="String" />
            <asp:Parameter Name="PRICE_P45" Type="String" />
            <asp:Parameter Name="PRICE_P100" Type="String" />
            <asp:Parameter Name="PRICE_P300" Type="String" />
            <asp:Parameter Name="PRICE_P500" Type="String" />
            <asp:Parameter Name="PRICE_P1000" Type="String" />
            <asp:Parameter Name="departurewkd" Type="String" />
            <asp:Parameter Name="memo" Type="String" />
            <asp:Parameter Name="price20gpAppend" Type="String" />
            <asp:Parameter Name="Distance" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
        
        
       
        <div style="width:761px; text-align: center;">
         <asp:Button ID="Button1" runat="server" Text="更新" Width="80px" OnClick="Button1_Click1" />
        
        
        </div>
        </td>
        </tr>
    
    
    
    </table>

        <br />
    <div style="z-index: 101; left: 100px; width: 100px; position: absolute; top: 100px;
        height: 100px">
    </div>
    <br />
    &nbsp;&nbsp;
</div>

					
					
					
					
							
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
