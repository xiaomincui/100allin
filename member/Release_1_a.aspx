<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Release_1_a.aspx.vb" Inherits="member_Release_1"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环球运费网 - 我的办公室 - 整箱运价</title>
    <link href="css/WebResource.css" type="text/css" rel="stylesheet" />	
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
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
#prot_warp
{
    font-size: 12px;
	font-family: arial, simsun;
	border:#7f9db9 1px solid;
	padding:4px;
	text-align: left;
	background-color: #ffffff;
	margin: 0px;
}
#prot_warp #prot_list a {
	color: #0055aa;
	text-decoration: none;
	line-height: 20px;
	display: block;
	curso: pointer;
	text-align: left;
	text-decoration:none;
	background-color:white;
	padding-left:5px;
	border:#fff 0px solid;
}
#prot_warp #prot_list a:hover{
	border-top: #7f9db9 1px solid;	
	background: #e7f1fd;	
	border-bottom: #7f9db9 1px solid;
}
#prot_warp #prot_list .hov{
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
.autodiv
{
    max-height:300px;
    -webkit-max-height:300px;
    height:expression(this.scrollHeight>299?"300px":"auto");
}

</style>
    <script type="text/javascript" language="javascript" src="http://ajax.googleapis.com/ajax/libs/prototype/1.6.1.0/prototype.js"></script>
    <script type="text/javascript" language="javascript" src="js/port2.js"></script>
    <script type="text/javascript" language="JavaScript">

//	window.onbeforeunload = function()
//    {  
//      var n = window.event.screenX - window.screenLeft;  
//      var b = n>document.documentElement.scrollWidth-20;  
//      if(b && window.event.clientY < 0 || window.event.altKey)  
//      {  
//        
//        window.open("a.aspx?flag=1&id="+document.getElementById("hidSave").value,"_blank"); 
//      }  
//    }  
	
	
	
    var curRow=null;   


 
  function   addRow(src,num,display)
  {   
      for(var k=0;k<num;k++)
      {
          var   newrow   =   src.insertRow();
          newrow.height=25; 
//          var   newcell   =   newrow.insertCell();
//          newcell.innerHTML=   " <input  type='text' class='ms_text'  style='width:104px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)'  onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
//          newcell.width="110px"
          var   i=9;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:60px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.width="66px"
          }   
            var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:60px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="66px"
          var newcell = newrow.insertCell();
          newcell.innerHTML=   " <table><tr><td><input  type='checkbox'  /></td></tr></table>"
         
          
          newcell.width="20px"
          if(display==1)
          {
            newcell.style.display="none";
          }
          
          
          var newcell = newrow.insertCell();
          newcell.align="center"
            newcell.innerHTML="<a href='javaScript:void(0)' onclick='delRow(this.parentElement.parentElement)'><img style='border:0px' src='../images/delete.jpg' /></a>";
       
       }


  }   
  

  
  
  
  function   delRow(src)
  {   
    src.parentElement.deleteRow(src.rowIndex);   
  }   
  
  
  function bntover()
  { 
    
    var table4 = document.getElementById("GridView2");
    

    
    var str = "";
    for(var i = 1;i < table4.rows.length;i++)
    {
        for(var j = 0;j < table4.rows[i].cells.length - 1;j++)
        {
            var value1 = table4.rows[i].cells[j];
            var aInput = value1.getElementsByTagName("input");
            if(aInput.length != 0)
            {
                if(j==table4.rows[i].cells.length - 2)
                {
                
                    if(aInput[0].checked)
                    {
                        
                        str += "1"+"qwerhjkl";
                    }
                    else
                    {
                        str += "0"+"qwerhjkl";
                    }
                }
                else
                {
                    str += aInput[0].value+"qwerhjkl";
                }
             }
             
        }
        str += "sdfgyuio";
    }
    
    
    document.getElementById("hidsubmit").value=str;
    
    document.getElementById("Button11").click();

  }
  
  function insertTable(col,row)
    {
        if(event.ctrlKey&&event.keyCode==86)
        {
            
            var table4 = document.getElementById("GridView2");
        
            var txtObj = window.clipboardData.getData("Text");
            
            if(txtObj.indexOf("\r\n") != -1)
            {
                event.keyCode=0;
                var sheetrows = txtObj.split("\r\n");
                for(var i=0;i<sheetrows.length-1;i++)
                {
                    
                    var sheetcols = sheetrows[i].split("\t");
                    for(var j=0;j < sheetcols.length;j++)
                    {
                        if(row + i <= table4.rows.length - 1 && col + j <= table4.rows[i].cells.length - 3)
                        {
                            var value1 = table4.rows[row + i].cells[col + j];
                            var aInput = value1.getElementsByTagName("input");
                            aInput[0].value = sheetcols[j];
                            //alert(sheetcols[j]);
                        }
                        else
                        {
                        
                        }
                    }
                }
            }
            else
            {
//                var value1 = table4.rows[row].cells[col];
//                var aInput = value1.getElementsByTagName("input");
//                aInput[0].value += window.clipboardData.getData("Text");
            }
        }
        else
        {
            
        }
    }
    
  function insertTableOnpaste(col,row)
    {
            
            var table4 = document.getElementById("GridView2");    
            var txtObj = window.clipboardData.getData("Text");
            if(txtObj.indexOf("\r\n") != -1)
            {
                event.keyCode=0;
                
                var sheetrows = txtObj.split("\r\n");
                for(var i=0;i<sheetrows.length-1;i++)
                {
                    
                    var sheetcols = sheetrows[i].split("\t");
                    for(var j=0;j < sheetcols.length;j++)
                    {
                        if(row + i <= table4.rows.length - 1 && col + j <= table4.rows[i].cells.length - 3)
                        {
                            var value1 = table4.rows[row + i].cells[col + j];
                            
                            var aInput = value1.getElementsByTagName("input");
                            aInput[0].value = sheetcols[j];
                            
                        }
                        else
                        {
                        
                        }
                    }
                }
                
                
              
              
            }
            else
            {
//                var value1 = table4.rows[row].cells[col];
//                var aInput = value1.getElementsByTagName("input");
//                aInput[0].value += window.clipboardData.getData("Text");
            }

    }	
    
    function CheckAll(form)//全选
  {
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.Name != "chkAll"&&e.disabled==false)
       e.checked = form.chkAll.checked;
    }
	
}
  
	</script>
    
<script type="text/javascript" language="javascript" src="../Web_Admin/include/calendar.js"></script>
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .displayrow{display:none}
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
		  
		  
		  
				<memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				
				
				
				<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
    <td width="44%"><strong>发布整箱运价</strong></td>
    <td width="50%" align="right"><%--<a href="/topic/order20091104/product_1.aspx" target="_blank"><img src="images/ttt_3.gif" width="152" height="27" border="0" /></a>--%></td>
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
                          <td align="left"><span id="ctl00_ContentPlaceHolder1_labnow"><asp:Label ID="labnow" runat="server" Text="Label" Font-Size="10pt"></asp:Label></span></td>
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
                          <td align="left"><span id="ctl00_ContentPlaceHolder1_Label3">整箱</span></td>
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
					
					<%--<div class="fcl_rg"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="8%" height="28">&nbsp;</td>
    <td width="22%">
    <div id="tt" runat="server">
    <span style="font:14px '宋体';"><strong>您的名片</strong></span>
    </div>
    </td>
    <td width="70%">&nbsp;</td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td colspan="2">
        <asp:TextBox ID="txtname" runat="server" BackColor="#E8F6FF" BorderWidth="0px"
                                    Font-Bold="True" Font-Names="宋体" Font-Size="Medium" Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>公司名称：</td>
    <td><asp:TextBox ID="txtCompanyName" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>电话号码：</td>
    <td><asp:TextBox ID="txtPhone" runat="server" BackColor="#F2F8FB" BorderWidth="0px" Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>传真：</td>
    <td><asp:TextBox ID="txtFax" runat="server" BackColor="#F2F8FB" BorderWidth="0px" Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>手机号码：</td>
    <td><asp:TextBox ID="txtMovePhone" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>电子邮箱：</td>
    <td><asp:TextBox ID="txtUserEmail" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>公司地址：</td>
    <td><asp:TextBox ID="txtAddress" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="28">&nbsp;</td>
    <td>邮政编码：</td>
    <td><asp:TextBox ID="txtPostNumber" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox>
                                    <input id="Hidden1" runat="server" type="hidden" visible="false" />
                                    </td>
  </tr>
</table>
</div>--%>
				</div>
				<div class="bill_box" style="line-height:18px; background:#FFFBCA; border:1px dashed #FFCC00;">
			    <p style="margin:0px 15px;background:url(images/light.gif) no-repeat left;">&nbsp;&nbsp;&nbsp;可从EXCEL中复制内容，粘粘在下列行中，快捷方便，赶紧试试！看清格式，别粘错了哦！</p>
		    </div>
			<div class="fcl">
			    
			
			
			 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Width="100%" Height="1px" border="0" cellspacing="3" cellpadding="0" >
                <Columns>
                    
                    <asp:TemplateField HeaderText="目的港">
                        <HeaderTemplate>
                        <span class="red">*</span>目的港
                        </HeaderTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# eval("DestPort") %>' Width="166px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# eval("DestPort") %>' Width="60px" CssClass="ms_text" onkeyup="autowords(this.id,event,2);" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="20GP">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# eval("price20gp") %>' Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox12" runat="server" Text='<%# eval("price20gp") %>' Width="60px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="40GP">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox22" runat="server" Text='<%# eval("price40gp") %>' Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox22" runat="server" Text='<%# eval("price40gp") %>' Width="60px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="40HQ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox32" runat="server" Text='<%# eval("price40hq") %>' Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox32" runat="server" Text='<%# eval("price40hq") %>' Width="60px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="45HQ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox33" runat="server" Text='<%# eval("price45hq") %>' Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox33" runat="server" Text='<%# eval("price45hq") %>' Width="60px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    
                    
                    <asp:TemplateField HeaderText="附加费">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# eval("price20gpAppend") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# eval("price20gpAppend") %>' CssClass="ms_text" Width="60px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="航程">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# eval("Distance") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# eval("Distance") %>' CssClass="ms_text" Width="60px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出发日">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# eval("DepartureWkd") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# eval("DepartureWkd") %>' CssClass="ms_text" Width="60px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="*船公司">
                        <HeaderTemplate>
                        <span class="red">*</span>船公司
                        </HeaderTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox18" runat="server" Text='<%# eval("shipcompany") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox18" runat="server" Text='<%# eval("shipcompany") %>' onkeyup="" CssClass="ms_text" Width="60px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# eval("memo") %>' CssClass="ms_text" Width="137px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="66px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# eval("memo") %>' CssClass="ms_text" Width="60px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="保证">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# eval("assurance") %>' CssClass="ms_text" Width="137px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="25px"  />
                        <ItemTemplate >
                       <%-- <asp:TextBox ID="TextBox119" runat="server" Text='<%# Bind("assurance") %>' CssClass="ms_text" Width="14px"></asp:TextBox>--%>
                        <table>
                        
                        <tr>
                        <td><asp:CheckBox ID="CheckBox1" Checked='<%#  IIF(eval("assurance").tostring = "1", "true", "false") %>' runat="server" /></td>
                        </tr>
                        </table>
                            
                            
                        </ItemTemplate>
                        <HeaderStyle />
                        <HeaderTemplate >
                        <table>
                        <tr>
                        <td><a href="/help/services_2.aspx" target="_blank"><img src="/images/fcl/cang.gif" alt="舱位保证，点击查看何为舱位保证" border=0 /></a></td>
                        </tr>
                        <tr>
                        <td><input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" /></td>
                        </tr>
                        </table>
                            
                            
                            
                        </HeaderTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        
                        
                        <ItemTemplate>
                            <a href="javaScript:void(0)" onclick="delRow(this.parentElement.parentElement)"><img style="border:0px" src="../images/delete.jpg" /></a>
                            <%--<input type='button' style='width:60px;'   onClick='javascript:delRow(this.parentElement.parentElement)' value='删除此行'>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                        <ItemStyle  HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle Height="25px" />
                <%--<HeaderStyle BackColor="#F2F8FB" Font-Bold="False" Font-Names="宋体" Font-Size="12px"
                    ForeColor="#29728D" Height="25px" HorizontalAlign="Center" />--%>
            </asp:GridView>
            
            
			<table  cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;border-collapse:collapse;">
                        <tr>
                            <td style="height: 25px; width: 64px;">
                                <asp:Literal ID="LitRow1" runat="server"><input id="Button5" type="button" value="添加1行" language="javascript" onclick="addRow(document.getElementById('GridView2'),1,0)" /></asp:Literal>
        </td>
        <td style="height: 25px; width: 64px;"><asp:Literal ID="LitRow5" runat="server"><input id="Button2" type="button" value="添加5行" language="javascript" onclick="addRow(document.getElementById('GridView2'),5,0)" /></asp:Literal>
        </td>
        <td style="height: 25px; width: 64px;"><asp:Literal ID="LitRow10" runat="server"><input id="Button3" type="button" value="添加10行" language="javascript" onclick="addRow(document.getElementById('GridView2'),10,0)" /></asp:Literal>
        </td>
        <%--<td style="height: 25px; width: 64px;"><asp:Literal ID="LitRow50" runat="server"><input id="Button4" type="button" value="添加50行" language="javascript" onclick="addRow(document.getElementById('GridView2'),50,0)" /></asp:Literal>
        </td>--%>
                            
                        </tr>
                    
                    </table>
			  <div style="width:731px; text-align: center;">
                        <input id="hidsubmit" type="text" runat="server" value="" class="hidden" />
                    <input id="bntsumbit" value="提交"  onclick="bntover()" type="button" />
                  <div style="display:none">
                    <asp:Button ID="Button11" runat="server" Text="完成" Width="80px" />
                        </div>
            </div>
            
            
            <asp:TextBox ID="hidSave" runat="server" CssClass="hidden"></asp:TextBox>
            
			</div>
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
	<span id="messages"></span>
    </form>
</body>
</html>
