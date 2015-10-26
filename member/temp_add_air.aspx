<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp_add_air.aspx.cs" Inherits="member_temp_add_air" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <title>海运货盘</title>
    <link href="css/WebResource.css" type="text/css" rel="stylesheet" />	
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    
    

    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
		  <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
		  <div class="friend_title"><strong>航空货盘发布管理</strong></div>	   
		  <div id="cities" name="cities" style="visibility:hidden"></div>

<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#E8E8E8" class="bgTbTop">
	<tr align="left" bgcolor="#F6F6F6" class="news_font" >
       	<td width="184" height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">货盘信息标题&nbsp;&nbsp;</span></div></td>
   	  <td width="914" bgcolor="#FFFFFF">
   	  <%--<input name="title" type="text"  id="txttitle" runat="server" size="30" maxlength="50" style="width:200px" />	--%>
   	<input  runat="server" name="nums" type="text" class="InputTxt" id="txttitle"  size="30" maxlength="60" msg="请填写货量" style="width:200px">
   		</td>
    </tr>
	<tr bgcolor="#F6F6F6" class="news_font">
	  <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2">点击量&nbsp;&nbsp;</span></div></td>
	  <td bgcolor="#FFFFFF" class="bgTdMain"><asp:Literal ID="Lithits" runat="server"></asp:Literal></td>
    </tr>
	<tr bgcolor="#F6F6F6" class="news_font">
      <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2"><strong>出运日期</strong><span class="STYLE5">*</span>&nbsp;&nbsp; </span></div></td>
	  <td bgcolor="#FFFFFF" class="bgTdMain">
	  
	  
<%--	  
	  <input name="endtime" type="text" runat="server" class="InputTxt"   id="endtime" dataType="Date" msg="出运日期格式不正确" style="width:100px" readonly="readonly"   >
	    &nbsp; <A onclick=event.cancelBubble=true; href="javascript:showCalendar('imageCalendar1',false,'endtime',null);"> <IMG id=imageCalendar1 height=21 src="../web_Admin/images/button.gif" width=34 align=absMiddle border=0></A> --%>
	 
	 <link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
<input name="BasicDatePicker1$TextBox" type="text" value="" readonly="readonly" id="BasicDatePicker1_TextBox"  runat="server"/>
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
	 
	 <%--<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:150px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
   
                                        
                                     
                                     
                                     <SCRIPT src="js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var d = new Date();
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:d.getYear()+"/"+(d.getMonth()+1)+"/"+d.getDate(),nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>--%>
	 
	 
	 
	 
	    <span class="STYLE3">时间格式为“年-月-日 时:分:秒”，如： 
            <asp:Literal ID="LitDate" runat="server"></asp:Literal></span> </td>
    </tr>
	<tr align="left" bgcolor="#F6F6F6" class="news_font">
      <td height="30" bgcolor="#FFFFFF"><div align="right" class="STYLE2">货源&nbsp;&nbsp;</div></td>
	  <td bgcolor="#FFFFFF">
          <asp:DropDownList ID="types" runat="server">
          <asp:ListItem Value="直客">直客</asp:ListItem>
          <asp:ListItem Value="同行">同行</asp:ListItem>
          </asp:DropDownList>


		<%--<%if request.QueryString("type") = "1" then%>
		  <input type="hidden" name="typem" value="海运货盘">
		<%else%>
		  <input type="hidden" name="typem" value="空运货盘">
	    <%end if%>--%></td>
    </tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right" class="STYLE2">类型&nbsp;&nbsp;</div></td>
		<td bgcolor="#FFFFFF">
		<asp:DropDownList ID="type1" runat="server">
          <asp:ListItem Value="暂无">暂无</asp:ListItem>
          <asp:ListItem Value="平货">平货</asp:ListItem>
          <asp:ListItem Value="泡货">泡货</asp:ListItem>
          </asp:DropDownList>

		
		

		  &nbsp;</td>
	</tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2"><strong>货量</strong><span class="STYLE5">*</span>&nbsp;&nbsp;</span></div></td>
		<td bgcolor="#FFFFFF"><input  runat="server" name="nums" type="text" class="InputTxt" id="nums"  size="30" maxlength="60" msg="请填写货量" style="width:200px">
			&nbsp;</td>
	</tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">运费支付方式&nbsp;&nbsp;</span></div></td>
		<td bgcolor="#FFFFFF" >
		<asp:DropDownList ID="ddlPayType" runat="server">
          <asp:ListItem Value="预付">预付</asp:ListItem>
          <asp:ListItem Value="到付">到付</asp:ListItem>
          <asp:ListItem Value="其它">其它</asp:ListItem>
          </asp:DropDownList>
		

	</tr>

	<tr align="left" bgcolor="#F6F6F6" class="news_font" >
        <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2"><strong>货物名称</strong><span class="STYLE5">*</span>&nbsp;&nbsp;</span></div></td>
        <td bgcolor="#FFFFFF">
        <input name="tbGoodsName" type="text" class="InputTxt" id="tbGoodsName"  size="30" maxlength="50"  dataType="Require" msg="请填写货盘名称" style="width:100px"  runat="server" ></td>
    </tr>
                <tr bgcolor="#F6F6F6" class="news_font"> 
                  <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right" class="STYLE2">出货航线&nbsp;&nbsp;</div></td>
                  <td bgcolor="#FFFFFF" class="bgTdMain">
                  <asp:DropDownList ID="DropDownList1" runat="server">
          <asp:ListItem Value="CHINA-WEST AMERICA">中国-美西</asp:ListItem>
          <asp:ListItem Value="CHINA-EAST AMERICA">中国-美东</asp:ListItem>
          <asp:ListItem Value="CHINA-MIDDLE SOUTH AMERICA">中国-中南美</asp:ListItem>
          <asp:ListItem Value="CHINA-EURO/MED">中国-欧地</asp:ListItem>
          <asp:ListItem Value="CHINA-AFRICA">中国-非洲</asp:ListItem>
          <asp:ListItem Value="CHINA-JAPAN">中国-日本</asp:ListItem>
          <asp:ListItem Value="CHINA-KOREA">中国-韩国</asp:ListItem>
          <asp:ListItem Value="CHINA-RUSSIA/FAR EAST">中国-俄罗斯远东</asp:ListItem>
          <asp:ListItem Value="CHINA-SOUTHEASTASIA">中国-东南亚</asp:ListItem>
          <asp:ListItem Value="CHINA-MIDDLE EAST/PERSIAN GULF">中国-中东/波斯湾</asp:ListItem>
          <asp:ListItem Value="CHINA-AUSTRALIA">中国-澳洲</asp:ListItem>
          <asp:ListItem Value="CHINA-香港">中国-中国香港</asp:ListItem>
          <asp:ListItem Value="CHINA-MACAO">中国-中国澳门</asp:ListItem>
          <asp:ListItem Value="CHINA-TAIWANG">中国-中国台湾</asp:ListItem>
          <asp:ListItem Value="THE WHOLE WORLD">环球航线</asp:ListItem>
          <asp:ListItem Value="其它">其它航线</asp:ListItem>
          </asp:DropDownList>
          
          
          
          
          
          
          
               </td>
            </tr>
				<tr align="left"  bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">属危险品&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF">
                      
                      
                      
                      <asp:RadioButton ID="rbldange_0" GroupName="dange" runat="server" Checked="true" />
                  <%--<input runat="server" name="rbldange" type="radio" id="rbldange_0" value="0" checked="checked" />--%>
				  <label for="rbldange_0">否</label>
				  <asp:RadioButton ID="rbldange_1" GroupName="dange" runat="server" />
				  <%--<input runat="server" id="rbldange_1" type="radio" name="rbldange" value="1"  />--%>
				  <label for="rbldange_1">是</label>                  
				  
				 
				  </td>
            </tr>
                <tr align="left"  bgcolor="#F6F6F6" class="news_font" style="display:none">
                  <td height="30" bgcolor="#FFFFFF"><div align="right">目标价格&nbsp;&nbsp;</div></td>
                  <td bgcolor="#FFFFFF"><input runat="server" name="price" type="text" class="InputTxt" id="price" size="10" maxlength="10" > 
                    <span class="STYLE3">单位为美元</span> </td>
            </tr>
				
                <tr align="left" bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">启运港&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF"><input runat="server" id="StartPort"  name="StartPort" type="text" /></td>
            </tr>
                <tr align="left"  bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">目的港&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF"><span class="bgTdMain">
                    <input type="text" runat="server" name="CityName"  id="CityName"  style="width:144px" />
                  </span> </td>
            </tr>
				
						     <tr bgcolor="#F6F6F6" class="news_font">
                  <td height="85" valign="middle" bgcolor="#FFFFFF"  class="bgTdMain"><div align="right"><span class="STYLE2">货盘描述&nbsp;&nbsp; </span></div></td>
                  <td bgcolor="#FFFFFF" class="bgTdMain"><textarea runat="server" name="tbremark" id="tbremark" style="height:80px;width:320px;" class="InputTxt" ></textarea>
                    <span class="black12 STYLE3"> </span>                  </td>
			</tr>
                             <tr valign="middle" bgcolor="#F6F6F6" class="news_font" style="display:none">
                               <td align="center" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2">联系方式设定&nbsp;&nbsp; </span></div></td>
                               <td bgcolor="#FFFFFF" class="bgTdMain">在货盘中显示以下联系方式 (以下选项可复选，可不选)：<br>
                               
                               
                                   <input runat="server" name="chkTel" type="checkbox" id="chkTel" value="1" checked="CHECKED" >
                                 电话 
                                 
                                 <br>
                                 <input runat="server" name="chkMobile" type="checkbox" id="chkMobile" value="1" checked="CHECKED" >
                                 手机 
                                 <br>
                                 <input runat="server" name="chkAddress" type="checkbox" id="chkAddress" value="1" checked="CHECKED" >
                                 地址 
                                 <br>
                                 <input runat="server" name="chkEmail" type="checkbox" id="chkEmail" value="1" checked="CHECKED" >
                                 电子邮箱 
                                 <br>
                                 <input runat="server" name="chkCompany" type="checkbox" id="chkCompany" value="1" checked="CHECKED" >
                                 公司名称 
                                 </td>
                             </tr>
                <tr valign="middle" bgcolor="#F6F6F6" class="news_font"> 
                  <td height="50" colspan="2" align="center" bgcolor="#FFFFFF" class="bgTdMain"><span class="tablebody1">
                  </span>                                      
				    
                    
					
					<input type="submit" value="完成"  id="Submit1" onserverclick="Submit1_ServerClick" runat="server">
					&nbsp;&nbsp;
			      <input name="Submit2" type="button" class="InputBtn" value="返回" onclick=history.back() id="Button1" runat="server" ></td>
    </tr>
  </table>
<table width="98%"  border="0" cellspacing="0" cellpadding="0">
  <TR>
    <TD height="30" align="center" class="news_font STYLE5"> 以上信息由企业自行提供，该企业负责信息内容的真实性、准确性和合法性。我们对此不承担任何保证责任</TD>
  </TR>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
<br>
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
