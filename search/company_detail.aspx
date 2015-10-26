<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company_detail.aspx.vb" Inherits="search_company_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > <a href="/search/company.html" target="_blank">公司库</a> > <asp:Label
                    ID="lblWindowTitle" runat="server" Text="明细"></asp:Label></h1>
			<userservice:userservice ID="userservice1" runat="server" />
  </div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <div class="freight_List">
				  <div class="freight_List_title">
							<h2>公司库 - 私人企业</h2>
					  </div>
					  
					  <div class="list_box">
					  		<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CAE7F0">
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>机构名称</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>法人</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>职位</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>经营范围</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>经济行业</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>经济类型</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>行政区号</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>地址</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>邮编</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>电话</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>手机</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>注册资金</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>地区</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>销售产品</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>采购产品</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>Email</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>传真</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>网站</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>成立时间</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>进出口业务规模</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label20" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>企业规模</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td width="19%" height="35" align="right" bgcolor="#FFFFFF" class="blue"><strong>企业简介</strong>:</td>
    <td width="80%" align="left" bgcolor="#FFFFFF">&nbsp;<asp:Label ID="Label22" runat="server" Text="Label"></asp:Label></td>
  </tr>
</table>
					  </div>
				</div>

				 <usernewsbottom:usernewsbottom ID="usernewsbottom1" runat="server" />
			</div><!--左边结束-->	
			<div class="main_right"><!--右边开始-->
			  <div class="right_box" style="margin-top:0px;">
					<div class="right_box_title"><h2>您浏览过的运价有</h2>
					</div>
					<ul>
					<asp:Label ID="Label24" runat="server" Text=""></asp:Label>
					</ul>
				</div>
				<div class="right_box" >
					<div class="right_box_title"><h2>您搜索过的运价有</h2>
					</div>
					<ul>
                         <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                    </ul>
				</div>
				
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
