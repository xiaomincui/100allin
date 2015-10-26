<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="getdicker.aspx.vb" Inherits="member_getdicker" title="我的讨价还价" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript" src="js/function.js"></script>
    <div class="listTitle">
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="44"><img src="images/edit_icon.gif" width="44" height="27" /></td>
          <td width="318"><span class="bigBoxTitle">我的讨价还价</span></td>
          <td width="413"><div style="text-align:right; font-size:12px;">
          <a href="getdicker.aspx?filter=new" <%=IIf(Request.QueryString("filter") = "new", "style=""font-weight:bold;font-size:14px;""","") %>>未读讨价还价</a> | 
          <a href="getdicker.aspx" <%=IIf(Request.QueryString("filter") = "", "style=""font-weight:bold;font-size:14px;""","") %>>所有收到的讨价还价</a> | 
          <a href="getdicker.aspx?filter=my" <%=IIf(Request.QueryString("filter") = "my", "style=""font-weight:bold;font-size:14px;""","") %>>我发送的讨价还价</a>
          </div></td>
        </tr>
      </table>
    </div>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
<DIV class="listTable">
    <asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="id" type="checkbox" value="<%# eval("did") %>" onclick="checkToList(this.form)" />
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="读否">
                <ItemTemplate>
                    <div class="edit"><%#IIf(Eval("readed") = "0", "<b style=""color:red"">" & IIf(Request.QueryString("filter") = "my","对方","") & "未读</b>", "<span style=""color:green"">" & IIf(Request.QueryString("filter") = "my","对方","") & "已读</span>")%></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="70px" />
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </asp:TemplateField>                  
            <asp:TemplateField HeaderText="发件人">
                <ItemTemplate>
                    <div class="startPortText"><nobr>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# eval("realname") %>'></asp:Label></nobr></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="110px" />
                <ItemStyle HorizontalAlign="Left" Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="货物情况">
                <ItemTemplate>
                    <div class="titleText2"><nobr>&nbsp;&nbsp;<a href="getdicker_detail.aspx?pid=<%# eval("did")%>&cid=<%#IIf(Request.QueryString("filter") = "my", eval("listener"),eval("chater")) %>#<%# eval("did")%>"><asp:Label ID="Label3" runat="server" Text='<%# eval("cargo") %>'></a></asp:Label></nobr></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="355px" />
                <ItemStyle HorizontalAlign="Left" Width="355px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布日期">
                <ItemTemplate>
                    <div class="titleText3">&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text='<%# eval("chattime")  %>'></asp:Label></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="135px" />
                <ItemStyle HorizontalAlign="Left" Width="135px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <div class="edit"><a href="javascript:delConfirm('<%# eval("did") %>')">删除</a></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>                                                     
        </Columns>
        <HeaderStyle BackColor="#F2F8FB" Height="30px" />
        <RowStyle Height="30px"  />
    </asp:GridView>
    
    <asp:GridView id="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="Checkbox1" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="Checkbox2" type="checkbox" value="<%# eval("did") %>" onclick="checkToList(this.form)" />
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="读否">
                <ItemTemplate>
                    <div class="edit"><%#IIf(Eval("readed") = "0", "<b style=""color:red"">" & IIf(Request.QueryString("filter") = "my","对方","") & "未读</b>", "<span style=""color:green"">" & IIf(Request.QueryString("filter") = "my","对方","") & "已读</span>")%></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="70px" />
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </asp:TemplateField>                  
            <asp:TemplateField HeaderText="收件人">
                <ItemTemplate>
                    <div class="startPortText"><nobr>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# eval("listener_realname") %>'></asp:Label></nobr></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="110px" />
                <ItemStyle HorizontalAlign="Left" Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="货物情况">
                <ItemTemplate>
                    <div class="titleText2"><nobr>&nbsp;&nbsp;<a href="pm_detail.aspx?pid=<%# eval("did")%>&cid=<%#IIf(Request.QueryString("filter") = "my", eval("listener"),eval("chater")) %>#<%# eval("did")%>"><asp:Label ID="Label3" runat="server" Text='<%# eval("cargo") %>'></a></asp:Label></nobr></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="355px" />
                <ItemStyle HorizontalAlign="Left" Width="355px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布日期">
                <ItemTemplate>
                    <div class="titleText3">&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text='<%# eval("chattime")  %>'></asp:Label></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="135px" />
                <ItemStyle HorizontalAlign="Left" Width="135px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <div class="edit"><a href="javascript:delConfirm('<%# eval("did") %>')">删除</a></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#29728D" HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>                                                     
        </Columns>
        <HeaderStyle BackColor="#F2F8FB" Height="30px" />
        <RowStyle Height="30px"  />
    </asp:GridView> </DIV><DIV class="page"><DIV class="pageCount">共&nbsp;<STRONG><asp:Label id="lblTotalPage" runat="server" Text="1"></asp:Label></STRONG>&nbsp;页&nbsp;<STRONG><asp:Label id="lblTotalItem" runat="server" Text="0"></asp:Label></STRONG>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<STRONG><asp:Label id="lblCurrentPage" runat="server" Text="1"></asp:Label></STRONG>&nbsp;页</DIV><DIV class="pageControl"><asp:LinkButton id="lnkFirstPage" runat="server">第一页</asp:LinkButton> <asp:LinkButton id="lnkPrePage" runat="server">上一页</asp:LinkButton> <asp:LinkButton id="lnkNextPage" runat="server">下一页</asp:LinkButton> <asp:LinkButton id="lnkLastPage" runat="server">最后页</asp:LinkButton> </DIV><DIV class="pageText">直接翻页：</DIV><DIV class="pageSelect"><asp:DropDownList id="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown">
        </asp:DropDownList> </DIV></DIV><DIV class="listTable"><INPUT style="WIDTH: 100px; HEIGHT: 30px" id="Button1" onclick="delAll()" type=button value="删除选定运价" /> <asp:Button id="btnHidDel" runat="server" Text="Button" CssClass="hidden"></asp:Button> <asp:TextBox id="delList" runat="server" CssClass="hidden"></asp:TextBox> <asp:Button id="btnHidSearch" runat="server" Text="Button" CssClass="hidden"></asp:Button> <asp:Timer id="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer></DIV>
</ContentTemplate>
    </asp:UpdatePanel>	
</asp:Content>

