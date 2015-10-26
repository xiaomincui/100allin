<%@ Page Language="C#" AutoEventWireup="true" CodeFile="titlelist.aspx.cs" Inherits="admin_userlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>
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
				<div class="tt18 bd rightTitle">
					<div class="icon"><img src="images/home_title.gif" /></div>
					<div class="text">首页管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">首页标题</div>
				</div>
				
				<div class="rightArea txth22">
	                
                    
                    <div class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>                                   
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="0px" />
                                </asp:TemplateField> 
                                                          
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("id") %>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField> 
                                
                                
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        大标题
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2"><nobr><%# Eval("title") %></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="75px" />
                                </asp:TemplateField> 
                                 
                                
                               
                                  
                                
                                  
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        修改时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("Eidttime")).ToString("yyyy-MM-dd")%><BR/>
                                        <%# Convert.ToDateTime(Eval("Eidttime")).ToString("HH:mm:ss")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>   
                                                                                                                                                                                                                  
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="title.aspx?id=<%# Eval("id") %>"><img src="/admin/images/edit.gif" border=0 /></a> 
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>    
                                                               
                            </Columns>                        
                            <HeaderStyle BackColor="#F0F0F0" />
                        </asp:GridView>
                        <br />
                        <a href="titleIMG1.aspx">航运动态图片</a><br />
                        <a href="titleIMG2.aspx">论坛最新关注图片1 </a>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; <a href="titleIMG3.aspx">论坛最新关注图片2</a><br />
                        <br /><div class="tt14 bd rightSubTitle">
                            <div class="text">
                                论坛首页</div>
                        </div>
                    </div>
                    
                    
                    
                                    
			    </div>
			      <a href="message/title6.aspx">论坛聚焦1</a>&nbsp;&nbsp;&nbsp;&nbsp;
			      <a href="message/title7.aspx">论坛聚焦2</a>&nbsp;&nbsp;&nbsp;&nbsp;
			      <a href="message/title1.aspx">焦点1</a>&nbsp;&nbsp;&nbsp;&nbsp;
                  <a href="message/title2.aspx">焦点2</a>&nbsp;&nbsp;&nbsp;&nbsp;
                  <a href="message/title3.aspx">关注1</a>&nbsp;&nbsp;&nbsp;&nbsp;
                  <%--<a href="message/title4.aspx">关注2</a>&nbsp;&nbsp;&nbsp;&nbsp;--%>
<a href="message/title5.aspx">航运焦点1</a>&nbsp;&nbsp;&nbsp;&nbsp;
<a href="message/title8.aspx">航运焦点2</a>
                  <br />
                  <br />
                  <asp:GridView ID="GridView2" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" 
                  OnRowCancelingEdit="GridView2_RowCancelingEdit" 
                  OnRowEditing="GridView2_RowEditing" 
                  OnRowUpdating="GridView2_RowUpdating">
                      <Columns>
                          <asp:TemplateField>
                              <HeaderTemplate>
                              </HeaderTemplate>
                              <ItemTemplate>
                              </ItemTemplate>
                              <ItemStyle Width="0px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  编号
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <%# Eval("id") %>
                              </ItemTemplate>
                              <ItemStyle Width="35px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  标题
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <div style="width:200px;	overflow: hidden; text-overflow:ellipsis;">
                                      <nobr><%# Eval("title") %></nobr>
                                  </div>
                              </ItemTemplate>
                              <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("title") %>' Width="190px"></asp:TextBox>
                              </EditItemTemplate>         
                              <ItemStyle Width="200px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  链接
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <div style="width:200px;	overflow: hidden; text-overflow:ellipsis;"><%# Eval("urllink")%></div>
                                  
                              </ItemTemplate>
                              <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("urllink") %>' Width="190px"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemStyle Width="200px" />
                          </asp:TemplateField>
                          <asp:CommandField ShowEditButton="True" HeaderText="操作" >
                                    <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:CommandField>
                          <%--<asp:TemplateField>
                              <HeaderTemplate>
                                  编辑
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <a href="title.aspx?id=<%# Eval("id") %>">
                                      <img src="/admin/images/edit.gif" border=0 /></a>
                              </ItemTemplate>
                              <ItemStyle Width="30px" HorizontalAlign="Center" />
                          </asp:TemplateField>--%>
                      </Columns>
                      <HeaderStyle BackColor="#F0F0F0" />
                  </asp:GridView>
                  <br />
                  <br />
                  <%--<div class="tt14 bd rightSubTitle">
                      <div class="text">
                          酷图专区</div>
                  </div>
                  <br />
                  <asp:GridView ID="GridView3" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" 
                  OnRowCancelingEdit="GridView3_RowCancelingEdit" 
                  OnRowEditing="GridView3_RowEditing" 
                  OnRowUpdating="GridView3_RowUpdating">
                      <Columns>
                          <asp:TemplateField>
                              <HeaderTemplate>
                              </HeaderTemplate>
                              <ItemTemplate>
                              </ItemTemplate>
                              <ItemStyle Width="0px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  编号
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <%# Eval("id") %>
                              </ItemTemplate>
                              <ItemStyle Width="35px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  标题
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <div style="width:70px;	overflow: hidden; text-overflow:ellipsis;">
                                      <nobr><%# Eval("title") %></nobr>
                                  </div>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("title") %>' Width="44px" MaxLength="10"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemStyle Width="70px" />
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  链接
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <div style="width:200px;	overflow: hidden; text-overflow:ellipsis;">
                                      <%# Eval("urllink")%>
                                  </div>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("urllink") %>' Width="190px"　MaxLength="200"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemStyle Width="200px" />
                          </asp:TemplateField>
                          
                          
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  图片
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <div style="width:130px;	overflow: hidden; text-overflow:ellipsis;">
                                  <img  src="/images/bbs/album/at_pic<%# Eval("id") %>.gif"  width="130" height="90" />
                                  </div>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </EditItemTemplate>
                              <ItemStyle Width="80px" />
                          </asp:TemplateField>
                          
                          
                          
                          <asp:CommandField ShowEditButton="True" HeaderText="操作" >
                              <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                          </asp:CommandField>
                          
                      </Columns>
                      <HeaderStyle BackColor="#F0F0F0" />
                  </asp:GridView>--%>
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
