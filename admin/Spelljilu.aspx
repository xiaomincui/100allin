<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Spelljilu.aspx.vb" Inherits="admin_Spelljilu" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
    <link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
body{
	margin:0px;
	padding:0px;
	font-size:12px;
}
div {
	padding-right: 0px;
	padding-left: 0px;
	padding-bottom: 0px;
	margin: 0px;
	padding-top: 0px;
}

.autodiv
{
    max-height:300px;
    -webkit-max-height:300px;
    height:expression(this.scrollHeight>299?"300px":"auto");
}

/*
	程序需要用到的css

*/
.dtable {
	border-collapse: collapse;
}
.dtable thead th {
	text-align: center;
	background-color: rgb(228,234,242);
	margin: 0px;
	padding:0px;
}
.dtable tbody td {
	border: 1px rgb(208,215,229) solid;
	margin: 0px;
	padding:0px;
}
.redfont {
	color: red;
}
/*浮動表頭*/
.TitleTable {
	border-collapse: collapse;
	margin: 0px;
	padding:0px;
}
.TitleTable tbody th {
	text-align: center;
	border: 1px rgb(234,236,245) solid;
	margin: 0px;
	padding:0px;
}
.TitleTable thead{
	margin: 0px;
	padding:0px;
}
.mdiv {
	position: relative;
	height: 25px;
	margin-left: 0px;
}
.absdiv {
	position: absolute;
	z-index: 10;
	left: 0px;
	top: 0px;
	height: 25px;
}
/*table body*/
.del_row {
	cursor: pointer;
	text-decoration: underline;
}
/*文本框高*/
.t_h {
	height: 14px;
}
.txt {
	font-size: 12px;
	border: 1px rgb(255,255,255) solid;
	overflow: hidden;
}
/*文本框编辑时*/
.txt_edit {
	border: 1px rgb(242,149,54) solid;
}
.eth {
	cursor: pointer;
}
/*弹出层*/
#prot_warp {
	font-size: 12px;
	font-family: arial, simsun;
	border: #7f9db9 1px solid;
	padding: 4px;
	text-align: left;
	background-color: #ffffff;
	margin: 0px;
}
#prot_warp #prot_list a {
	color: #0055aa;
	text-decoration: none;
	line-height: 20px;
	display: block;
	cursor: pointer;
	text-align: left;
	text-decoration: none;
	background-color: white;
	padding-left: 5px;
	border: #fff 0px solid;
}
#prot_warp #prot_list a:hover {
	border-top: #7f9db9 1px solid;
	background: #e7f1fd;
	border-bottom: #7f9db9 1px solid;
}
#prot_warp #prot_list .hov {
	border-top: #7f9db9 1px solid;
	background: #e7f1fd;
	border-bottom: #7f9db9 1px solid;
}
#prot_warp #prot_list span {
	padding-right: 0px;
	padding-left: 0px;
	float: right;
	padding-bottom: 0px;
	margin: 0px;
	padding-top: 0px;
	text-align: left;
}
#prot_warp #prot_message {
	padding-right: 0px;
	display: block;
	padding-left: 5px;
	padding-bottom: 0px;
	color: #666;
	word-break: break-all;
	line-height: 20px;
	padding-top: 0px;
	border-bottom: #aaa 1px dashed;
	font-family: "simyou";
	word-wrap: break-word;
}
.autodiv {
	max-height: 300px;
	-webkit-max-height: 300px;
	height: expression(this.scrollHeight>299?"300px":"auto");
}
#vb {
	height: 230px;
}
.dayclose {
	width: 58px;
	display: block;
	text-align: right;
	color: blue;
	text-decoration: underline;
	cursor: pointer;
}
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
		  	
		  	
	        
				
				
				
				<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"></td>
    <td width="44%"><strong>我的拼箱运价</strong></td>
    <td width="50%" align="right"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
</div>
				<div class="fcl">
					
					  <table width="100%" border="0" cellspacing="1" cellpadding="0" style="font-size:14px">
                        <tr>
                          <td width="3%" height="28">&nbsp;</td>
                          <td width="15%"><span class="red">*</span> 运价标题：</td>
                          <td align="left"><asp:TextBox ID="txtTitle" CssClass="ms_text" runat="server" Width="240px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td>&nbsp;&nbsp;发布时间：</td>
                          <td align="left"><span id="ctl00_ContentPlaceHolder1_labnow"><asp:Label ID="labpost" runat="server" Text="Label" Font-Size="10pt"></asp:Label></span></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td><span class="red">*</span> 有效时间：</td>
                          <td align="left">
                         <span style="color: #226077">
<link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
<input name="BasicDatePicker1$TextBox" type="text" value="2010-1-19" readonly="readonly" id="BasicDatePicker1_TextBox"  runat="server"/>
<img id="BasicDatePicker1_Image" class="bdpButton" alt="" border="10" src="/js/date/images/button.gif" style="height:22px;width:28px;border-width:0px;" />
<script type="text/javascript" src="/js/date/js/w.js"></script>
<script type="text/javascript" src="/js/date/js/w1.js"></script>
<script type="text/javascript" src="/js/date/js/w2.js"></script>

<script type="text/javascript">
//<![CDATA[
var d = new Date();
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",minimumDate:d.getFullYear()+"/"+(d.getMonth()+1)+"/"+d.getDate(),todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("无法载入日期控件，请联系网站客服！");
//]]>
</script>
                                        
                                        
                                     
                                    </span>
                          
                          </td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td>&nbsp;&nbsp;运价类型：</td>
                          <td align="left"><span id="ctl00_ContentPlaceHolder1_Label3">拼箱</span></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td>&nbsp;&nbsp;<span class="red">*</span> 起运港：</td>
                          <td align="left"><asp:TextBox ID="txtStart" CssClass="ms_text"  onkeyup="autowords(this.id,event,1);"  runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td><span class="red">*</span> 航线描述： </td>
                          <td align="left"><asp:DropDownList ID="DropDownList1" runat="server">
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
        </asp:DropDownList>                          </td>
                        </tr>
                        <tr>
                          <td height="65">&nbsp;</td>
                          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备 注：</td>
                          <td align="left"><asp:TextBox ID="txtRemark" CssClass="ms_text" runat="server" Height="63px" Width="500px" TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                      </table>
					
					
				</div>
				<div class="bill_box" style="line-height:18px; background:#FFFBCA; border:1px dashed #FFCC00;">
			    <p style="margin:0px 15px;background:url(images/light.gif) no-repeat left;">&nbsp;&nbsp;&nbsp;可从EXCEL中复制内容，粘粘在下列行中，快捷方便，赶紧试试！看清格式，别粘错了哦！</p>
		    </div>
		    
		    
		    
		    <div id="t1" style="float:left">
			
			</div>
			
			<div>
			    
			
			
			
			  <input id="txthidden" type="hidden" value="" runat="server" />
            <input id="addtr1" type="button" value="添加1行"  />
            <input id="addtr5" type="button" value="添加5行"  />
            <input id="addtr10" type="button" value="添加10行"  />
		<%--<input id="trsum" style="width: 30px" type="text" value="5" /><input id="addtr" type="button" value="addTR" />--%>
		
		<input id="dc" type="button" value="删除选中行" />
		<input id="clearall" type="button" value="清空所有" />
		<br />
		删除<input id="trdsum" style="width: 30px" type="text" value="5" />行 <input id="deltr" type="button" value="确定" />
		
		<div style="width:700px; text-align:center">
		
		<a href="javascript:document.getElementById('sub').click()"><img src="/member/images/tijiao.gif" border="0" /></a>
            <div style="display:none">
                  <input id="sub" type="button" value="提交" style="width:80px;height:50px" />
                    <asp:Button ID="Button11" runat="server" Text="完成" Width="80px" />
                        </div>
		
		
		</div>
		
		<span id="t_message"></span>
		<script type="text/javascript">
            /*
	            動態加載JS文件。
	            加載完成後，才執行 初始化表格動作。
            */
            
            var _js = document.createElement('script');
            _js.setAttribute('type', 'text/javascript');
            _js.setAttribute('src', '/js/js_table.js');
            document.getElementsByTagName('head')[0].appendChild(_js);
            if (document.all) { //如果是IE
	            _js.onreadystatechange = function () {
	                if (_js.readyState == 'loaded' || _js.readyState == 'complete') {
	    	            Load_Table();
	                }
	                else
	                {   
	                    
	                }
	            }
            }
            else {
	            _js.onload = function () {
		            Load_Table(); 
	            }
            }
            </script>
            
            
            
			</div>
			<textarea sou_type="end_port" class="t_h txt" style="width: 58px; background-color: rgb(255, 255, 255); border-color: rgb(255, 255, 255);" id="t1_2_1"></textarea>
	

            <asp:TextBox ID="hidSave" runat="server" CssClass="hidden"></asp:TextBox>
			
			
			
			
			
		  </div>
            
	
			
		  	
		  	
		  		
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
    </form>
</body>
</html>
