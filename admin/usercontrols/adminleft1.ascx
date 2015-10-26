<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminleft.ascx.cs" Inherits="admin_usercontrols_adminleft" %>
<div id="left">
    <div class="leftbox">
	    <span class="tt14 bd txth30">管理者信息</span><br/>
	    <span class="bd">allinadmin</span>，欢迎您！<br/>
	    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出</asp:LinkButton>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">相关统计</span><br/>
	    <a href="/admin/countuser.aspx">注册用户统计</a><br/>
	    <a href="/admin/countpriceline.aspx">运价/货盘统计(按航线分类)</a><br/>
	    <a href="/admin/countpricepol.aspx">运价/货盘统计(按启运港分类)</a><br/>																			
	    <a href="/admin/countpricepolline.aspx">运价/货盘统计(启运港-航线)</a><br/>	
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">运价/货盘管理</span><br/>
	    <a href="/admin/pricecount.aspx">运价数量统计</a><br/>
	    <a href="/admin/fcllist.aspx">整箱运价</a> <a href="/admin/lcllist.aspx">拼箱运价</a> <a href="/admin/airlist.aspx">空运运价</a><br/>
	    <a href="#">海运货盘</a> <a href="#">空运货盘</a><br/>											
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">用户管理</span><br/>
        <a href="/admin/usercount.aspx">用户统计</a><br/>
	    <a href="/admin/userlist.aspx">用户管理</a><br/>
	    <a href="/admin/importuserlistalizhike.aspx">Ali导入直客管理</a><br/>
	    <a href="/admin/importuserlistalihuodai.aspx">Ali导入货代管理</a><br/>
	    <a href="/admin/importuserlistalie.aspx">E网打尽管理</a><br/>
	    <a href="/admin/userexport.aspx">用户导出为EXCEL表格</a><br/>
            <a href="/admin/message/BBSadminList.aspx">BBS管理</a><br/>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">页面统计</span><br/>
	    <a href="/admin/pageareacount.aspx">板块访问量统计</a><br/>
	    <a href="/admin/pagecount.aspx">页面访问量统计</a><br/>																
	    <a href="/admin/infocount.aspx">页面数量统计</a><br/>		
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">搜索关键字管理</span><br/>
	    <a href="/admin/searchwordslist.aspx">搜索关键字管理</a><br/>
	    <a href="/admin/searchwordscount.aspx">搜索关键字统计</a><br/>																
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">信息管理</span><br/>
	    <a href="/admin/portlist.aspx">港口数据库管理</a><br/>															
    </div>         
    <div class="leftbox" style="display:none;">
	    <span class="tt14 bd txth30">其它</span><br/>
	    <a href="/admin/baf/bafedit.aspx">BAF/CAF等附加费编辑</a><br/>																		
    </div>
</div>