<%@ Page Language="C#" MasterPageFile="~/member/member.master" AutoEventWireup="true" CodeFile="NewList.aspx.cs" Inherits="member_news_NewList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

				<div class="listTitle">
                  <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="44" style="height: 27px"><img src="images/edit_icon.gif" width="44" height="27" /></td>
                      <td width="318" style="height: 27px"><span class="bigBoxTitle">我的整箱运价</span></td>
                      <td width="413" style="height: 27px"><div style="text-align:right"> <a href="temp_upload1.aspx"></a>&nbsp;</div></td>
                    </tr>
                  </table>
                </div>
				
	                <div class="tipBox" style="width:755px;margin-left:5px;margin-top:10px;padding-left:13px;padding-top:8px;padding-bottom:6px;color:#315E8E;">
	                <table border="0" cellspacing="0" cellpadding="0">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">编号</td>
                        <td style="width: 49px"><asp:TextBox ID="txtYunjiaid" runat="server" CssClass="t1" Width="125px"></asp:TextBox></td>
	                    <td style="width: 34px">
                            标题
                        </td>
	                    <td style="width: 92px">  
                            <asp:TextBox ID="txtLine" runat="server" CssClass="t2" Width="114px"></asp:TextBox>
                        </td>
	                    <td style="width: 40px">
                            发布人</td>
	                    <td style="width: 91px"><asp:TextBox ID="txtStartport" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 39px">
                            </td>
	                    <td style="width: 100px"><div style=" display:none"><asp:TextBox ID="txtDestport" runat="server" CssClass="t3" Width="90px"></asp:TextBox></div></td>

	                    <td width="20"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" /></td>
	                  </tr>
	                </table>
	                </div>
                    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
                      <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="200px" >&nbsp;&nbsp;&nbsp;&nbsp;搜索结果：&nbsp;</td>
                          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;<strong><asp:Label ID="hidTxtYunjiaid" runat="server">
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtLine" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtStartport" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtDestport" runat="server" >
                          </asp:Label></strong>&nbsp;，傲赢网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有用户" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
                        </tr>
                      </table>
                    </asp:Panel>
                    <div  class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" Width="770px">
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
                                        <input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input id="id" type="checkbox" value="<%# Eval("id") %>" onclick="checkToList(this.form)" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        置顶
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbtop" runat="server" Checked='<%# (Convert.ToInt32(Eval("istop").ToString()) == 0) ? false:true%>' AutoPostBack="True" OnCheckedChanged="ckbtop_CheckedChanged" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>                                

                            <asp:TemplateField >
                                <ItemTemplate>
                                <div class="c1" style=" padding-left:5px">
                                <nobr>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %>'></asp:Label></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="50px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:5px">编号</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>

                                <asp:TemplateField >
                                <ItemTemplate>
                                <div class="c6" style=" width:300px;	overflow: hidden; 	text-overflow:ellipsis;padding-left:20px">
                                <nobr><a href='/message/BBSMessage.aspx?id=<%# Eval("id")%>&page=1' target="_blank">
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("title") %>'></asp:Label></a></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="300px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:20px">标题</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="板块">
                                <ItemTemplate>
                                
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                  
                                  <asp:ListItem  Value="5">新闻</asp:ListItem>
                                  <asp:ListItem  Value="6">展会信息</asp:ListItem>
                                  <asp:ListItem  Value="7">保险相关</asp:ListItem>
                                  <asp:ListItem  Value="8">银行相关</asp:ListItem>
                                  <asp:ListItem  Value="9">最新汇率</asp:ListItem>
                                  <asp:ListItem  Value="9">运费快报</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="发帖人">
                                <ItemTemplate>
                                
                                    <div class="c7"><nobr><asp:Label ID="Label3" runat="server" Text='<%# Eval("releasename") %>'></asp:Label></nobr></div>
                                    <div class="c7"><nobr><asp:Label ID="Label5" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="回帖数">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("message") %>'></asp:Label>/
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("hits") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="回复人">
                                <ItemTemplate>
                                    <div class="c7"><nobr><asp:Label ID="Label25" runat="server" Text='<%# (Eval("restorename").ToString() != "" ) ? Eval("restorename"):"无" %>'></asp:Label></nobr></div>
                                    <div class="c7"><nobr><asp:Label ID="Label4" runat="server" Text='<%# (Eval("restorename").ToString() != "" ) ? Eval("UpdateDate"):"" %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>--%>






                                                                                                                                                                                       
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="News.aspx?id=<%# Eval("id") %>"><img src="/admin/images/edit.gif" border=0 /></a> 
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        删除
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="javascript:delConfirm('<%# Eval("id") %>')"><img src="/admin/images/del.gif" border=0 /></a>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>                                  
                            </Columns>
                            <HeaderStyle BackColor="#F2F8FB" Height="30px" />
                        </asp:GridView>
                    </div>
                    <div class="page"><div class="pageCount">共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>&nbsp;页&nbsp;<strong><asp:Label
                            ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
                            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页</div><div class="pageControl">
                                <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                </div>
                        <div class="pageText">直接翻页：</div>
                        <div class="pageSelect">
                        <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                        </asp:DropDownList>
                      </div>
                    </div>
                    <div class="buttons">
                        <input id="Button1" type="button" value="删除选定用户" onclick="delAll()" style="width:100px; height:30px" />
                        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
                        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
                        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidSearch_Click"/>
                        <asp:Button ID="Button3" runat="server" Text="发布"　style="width:100px; height:30px" OnClick="Button3_Click" /></div>                  
			    		
				
</asp:Content>

