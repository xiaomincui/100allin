<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useremail.aspx.cs" Inherits="admin_useremail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>    
    <script language=javascript>
    
    function preview(){
        document.getElementById("preusername").innerHTML = document.getElementById("UserName").value;
        document.getElementById("prebody").innerHTML = replaceTextarea1(document.getElementById("txtmemo").value);
    }
    
    function replaceTextarea1(str){
    var reg=new RegExp("\r\n","g");
    var reg1=new RegExp(" ","g");
    
    str = str.replace(reg,"<br>");
    str = str.replace(reg1,"&nbsp;");
    
    return str;
}


function replaceTextarea2(str){
    var reg=new RegExp("<br>","g");
    var reg1=new RegExp("<p>","g");
    
    str = str.replace(reg,"\r\n");
    str = str.replace(reg1," ");
    
    return str;
}
    
    </script>    
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />    
</head>
<body onload="preview();">
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>	
				<div class="rightArea txth22">
                    <div style="margin-right:10px; margin-top:10px;">
                   
                          <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
                          <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;"> 给用户发邮件 </legend>
                            <table border="0" cellpadding="4" cellspacing="0">
                            <tr>
                              <td colspan="3" style="height:5px"></td>
                            </tr>
                            
                            
                            <tr>
                              <td width="80"><div align="right"><span >用户名</span></div></td>
                              <td width="15"><span class="regRequired"></span></td>
                              <td width="610"><div style="float:left;">
		                      <input name="UserName" id="UserName" type="text"  style="width:600px"  runat="server"  onkeyup="preview()"  /></div>
                              </td>
                            </tr>
                            
                            
                            <tr>
                              <td><div align="right"><span >用户邮件</span></div></td>
                              <td><span class="regRequired"></span></td>
                              <td><div style="float:left;">
                              <input name="UserEmail" id="UserEmail" type="text"  style="width:600px"  runat="server"  /></div>
                              </td>
                            </tr>

                            <tr>
                              <td><div align="right"><span >客服邮件</span></div></td>
                              <td><span class="regRequired"></span></td>
                              <td><div style="float:left;">
                                  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="606px">
                                      <asp:ListItem>service@100allin.cn</asp:ListItem>
                                      <%--<asp:ListItem>cus@100allin.com.cn</asp:ListItem>
                                      <asp:ListItem>nature@100allin.com.cn</asp:ListItem>
                                      <asp:ListItem>friday@100allin.com.cn</asp:ListItem>
                                      <asp:ListItem>eva@100allin.com.cn</asp:ListItem>--%>

                                  </asp:DropDownList></div>
                              </td>
                            </tr>
                            
                            <tr>
                              <td width="80"><div align="right"><span >主题</span></div></td>
                              <td width="15"><span class="regRequired"></span></td>
                              <td width="610"><div style="float:left;">
		                      <input name="Subject" id="Subject" type="text"  style="width:600px"  runat="server"   /></div>
                              </td>
                            </tr>
                            
                            <tr>
                              <td><div align="right">正文</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><textarea name="txtmemo" id="txtmemo" style="width:600px; height: 226px;"  runat="server" onkeyup="preview()" /></div></td>
                            </tr>
                            <tr>
                              <td colspan="3" style="height:5px"></td>
                            </tr>
                          </table>
                        </fieldset>
                          
	                      <div align="center"><br />
                              &nbsp;<input name="Submit2" type="button" class="InputBtn" value="发送邮件" style="width:80px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" onserverclick="Button2_ServerClick" />&nbsp;<br />
                              <br />
                              
 <div style="text-align:left;">
        <table border=0 cellspacing=3 cellpadding=0 width=540 bgcolor=#F0690F align=center>
          <tbody>
            <tr>
              <td bgcolor=#ffffff>
           <table width=90% height=80 border=0 align=center cellpadding=0 cellspacing=0>
                <tbody>
                  <tr>
                    <td>
            <a href=http://www.100allin.com target=_blank><img border=0 src=http://www.100allin.com/images/logo.gif width=149 height=47 /></a>
            <strong>
             <font size=3 color=#29728D>专业</font><font size=3 color=#FF6600>运价</font><font size=3 color=#29728D>搜索查询和发布</font>
            </strong>
           </td>
                  </tr>
                </tbody>
              </table>
                  <table border=0 cellspacing=0 cellpadding=13 width=90% bgcolor=#fffdcf align=center>
                    <tbody>
                      <tr>
                        <td><strong>尊敬的用户<span id="preusername"></span>，您好！</strong>
                            <br />
                            <br />
                            <table border=0 cellspacing=0 cellpadding=0 width=100% bgcolor=#fffdcf align=center>
                              <tbody>
                                <tr>
                                  <td width=51%><p><span id="prebody"></span> </p>
                                  <td width=49%></td>
                                </tr>
                              </tbody>
                          </table></td>
                      </tr>
                    </tbody>
                  </table>
                <br />
                  <table width=90% height=25 border=0 align=center cellpadding=0 cellspacing=0 bgcolor=#F0690F>
                    <tbody>
                      <tr>
                        <td width=13>&nbsp;</td>
                        <td width=468><font size=2>傲赢网为您提供多项优质免费服务：</font></td>
                      </tr>
                    </tbody>
                </table>
                  <table border=0 cellspacing=1 cellpadding=5 width=90% align=center>
                    <tbody>
                      <tr>
                        <td width=50 height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/up.gif width=48 height=48 /></td>
                        <td width=408 bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布海空运价信息</strong><br />
                        发布运价完全免费,批量上传功能让你更快更多的发布运价<br />
                        免费查看海空运运价,为您提供各航线超精品运价查询 </font></td>
                      </tr>
                      <tr>
                        <td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/search.gif width=48 height=48 /></td>
                        <td bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布货盘信息</strong><br />
        几千外贸客户资源,更多更好货盘等你来拿</font></td>
                      </tr>
                      <tr>
                        <td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/chat.gif width=48 height=48 /></td>
                        <td bgcolor=#e9e9e9><font size=2><strong>即时 与您的商友沟通</strong><br />
        聊天工具免下载免安装,随时随地与用户进行沟通</font></td>
                      </tr>
                    </tbody>
                  </table>
                  <br />
                <br />
                  <table border=0 cellspacing=0 cellpadding=0 width=90% align=center>
                    <tbody>
                      <tr>
                        <td><font size=2><p>您在使用过程中，如有任何问题或建议，请随时联系傲赢网客户服务人员，我们将热忱为您服务。 <br />
                        </p></font></td>
                      </tr>
                    </tbody>
                  </table>
            <br />
                <table border=0 cellspacing=0 cellpadding=0 width=90% align=center>
                    <tbody>
                      <tr>
                        <td align=center><font size=2>【温馨提示】<br />
                            <font size=2 color=#CC0000><strong>为保证您正常接收邮件，傲赢网建议您将此邮件地址加入到地址簿中。</strong></font><br />
                        </div></td>
                      </tr>
                    </tbody>
                </table></td>
            </tr>
            <tr>
              <td bgcolor=#FF6600 height=50 align=center><font size=2>傲赢网(<a href=http://www.100allin.com>http://www.100allin.com</a>)<br />
                "客服电话/传真：400-888-9256/021-63509508　邮箱：allin@100allin.com</font></td>
            </tr>
          </tbody> 
        </table> 
</div>        
                            
                      </div>
                    </div>               
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>