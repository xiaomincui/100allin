<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lcl_detail.aspx.cs" Inherits="admin_userlist" MaintainScrollPositionOnPostback="true" %>

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
              <asp:TextBox ID="TextBox13" runat="server" Visible="False" Width="95px"></asp:TextBox></span></td>
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
                &nbsp;<asp:Label ID="lblyunjialeixing" runat="server" Text="整箱" Font-Size="10pt"></asp:Label></td>
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
            <td bgcolor="#f9f9f9" style="width: 80px; height: 26px;r">
                &nbsp; &nbsp;点击量：
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
            <td colspan="2"  style="vertical-align: middle;">
            <div id="Div1">
                <div id="head" runat="server">
                        
                        <table bgcolor="#D9D9D9" border="0" cellpadding="2" cellspacing="1" style="width: 760px;
                             border-collapse: collapse">
                            <tr>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 170px; height: 25px;
                                    text-align: center">
                                    目的港</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 68px; height: 25px; text-align: center">
                                    基本运价</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 68px; height: 25px;
                                    text-align: center">
                                    附加费</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 68px; height: 25px; text-align: center">
                                    航程</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 68px; height: 25px; text-align: center">
                                    出发日</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 68px; height: 25px; text-align: center">
                                    船公司</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 143px; height: 25px;
                                    text-align: center">
                                    备注</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle;  height: 25px; text-align: center">
                                    操作</td>
                            </tr>
                        </table>
                </div>
            

    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="SqlDataSource1" Width="761px" Height="1px" ShowHeader="False" OnDataBound="GridView1_DataBound1" OnRowDeleted="GridView1_RowDeleted1" OnRowUpdated="GridView1_RowUpdated1">
        <Columns>

            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" Visible="False" />
            <asp:TemplateField HeaderText="YunJiaID" SortExpression="YunJiaID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("YunJiaID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("YunJiaID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="hidden" />
                <HeaderStyle CssClass="hidden" />
                <FooterStyle CssClass="hidden" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目的港" SortExpression="DestPort">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DestPort") %>' Width="166px"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="不能为空！！！" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" CssClass="hidden"></asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <div style="word-break:break-all;"><asp:Label ID="Label2" runat="server" Text='<%# Bind("DestPort") %>'></asp:Label></div>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" Font-Size="12px" HorizontalAlign="Center" />
                <ItemStyle Width="172px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="基本运价" SortExpression="pricegp">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("pricegp") %>' Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("pricegp") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="附加费" SortExpression="price20gpAppend">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("price20gpAppend") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="航程" SortExpression="Distance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Distance") %>' Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Distance") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出发日" SortExpression="DepartureWkd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("DepartureWkd") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="船公司" SortExpression="DepartureWkd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("shipcompany") %>' Width="64px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("shipcompany") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" SortExpression="memo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("memo") %>' Width="137px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="143px" />
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="操作" >
                <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="price20gpMark" SortExpression="price20gpMark" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("price20gpMark") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("price20gpMark") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle  HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="25px" />
        <HeaderStyle BackColor="#F9F9F9" Height="25px" />
        <EditRowStyle Height="20px" />
    </asp:GridView>
    
    
    
    <table  cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;width:761px;border-collapse:collapse;">
    
        <tr>
            <td style="height: 26px; width:172px">
    
    
    
    
    
        <asp:TextBox ID="TextBox4" runat="server" Width="166px"></asp:TextBox></td>
            <td style="height: 26px;width:70px">
    <asp:TextBox ID="TextBox5" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;width:70px">
        <asp:TextBox ID="TextBox6" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;width:70px">
        <asp:TextBox ID="TextBox7" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;width:70px">
        <asp:TextBox ID="TextBox8" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;width:70px">
        <asp:TextBox ID="TextBox10" runat="server" Width="64px"></asp:TextBox></td>
            <td style="height: 26px;width:145px">
        <asp:TextBox ID="TextBox9" runat="server" Width="137px"></asp:TextBox></td>
            <td style="height: 26px;">
        <asp:Button ID="Button2" runat="server" Text="添加" Width="34px" OnClick="Button2_Click" /></td>
            
        </tr>
    
    
    
    </table>
    
    
    
    
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_DataBase_newConnectionString2 %>"
        DeleteCommand="DELETE FROM [TB_YunJiaInfo] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [TB_YunJiaInfo] ([YunJiaID], [DestPort], [DepartureWkd], [Distance], [memo], [price20gpAppend], [pricegp], [price20gpMark], [price40gp], [price40hq], [shipcompany]) VALUES (@YunJiaID, @DestPort, @DepartureWkd, @Distance, @memo, @price20gpAppend, @price20gp, @price20gpMark, @price40gp, @price40hq, @shipcompany, @shipcompany)"
        SelectCommand="SELECT [ID], [YunJiaID], [DestPort], [DepartureWkd], [Distance], [memo], [price20gpAppend], [pricegp],[price20gpMark],[shipcompany]   FROM [TB_YunJiaInfo] WHERE ([YunJiaID] = @YunJiaID)"
        UpdateCommand="UPDATE [TB_YunJiaInfo] SET [YunJiaID] = @YunJiaID, [DestPort] = @DestPort, [DepartureWkd] = @DepartureWkd, [Distance] = @Distance, [memo] = @memo, [price20gpAppend] = @price20gpAppend,[price20gpMark]=@price20gpMark, [pricegp] = @pricegp, [shipcompany] = @shipcompany WHERE [ID] = @ID" ProviderName="<%$ ConnectionStrings:DB_DataBase_newConnectionString2.ProviderName %>">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="YunJiaID" Type="Int32" />
            <asp:Parameter Name="DestPort" Type="String" />
            <asp:Parameter Name="DepartureWkd" Type="String" />
            <asp:Parameter Name="Distance" Type="String" />
            <asp:Parameter Name="memo" Type="String" />
            <asp:Parameter Name="price20gpAppend" Type="String" />
            <asp:Parameter Name="price20gpMark" />
            <asp:Parameter Name="pricegp" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="shipcompany" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="YunJiaID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="YunJiaID" Type="Int32" />
            <asp:Parameter Name="DestPort" Type="String" />
            <asp:Parameter Name="DepartureWkd" Type="String" />
            <asp:Parameter Name="Distance" Type="String" />
            <asp:Parameter Name="memo" Type="String" />
            <asp:Parameter Name="price20gpAppend" Type="String" />
            <asp:Parameter Name="price20gp" Type="String" />
            <asp:Parameter Name="price20gpMark" Type="String" />
            <asp:Parameter Name="price40gp" Type="String" />
            <asp:Parameter Name="price40hq" Type="String" />
            <asp:Parameter Name="shipcompany" Type="String" />
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
