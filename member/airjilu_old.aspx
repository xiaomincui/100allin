﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="airjilu_old.aspx.vb" Inherits="member_Airjilu"  validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环球运费网 - 我的办公室 - 空运运价</title>
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript">

	window.onbeforeunload = function()
    {  
      var n = window.event.screenX - window.screenLeft;  
      var b = n>document.documentElement.scrollWidth-20;  
      if(b && window.event.clientY < 0 || window.event.altKey)  
      {  
        
        window.open("a.aspx?flag=1&id="+document.getElementById("hidSave").value,"_blank"); 
      }  
    }  
	
	
	
    var curRow=null;   


 
  function   addRow(src,num,display)
  {   
      for(var k=0;k<num;k++)
      {
          var   newrow   =   src.insertRow();
          newrow.height=25; 
          var   newcell   =   newrow.insertCell();
          newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:72px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="78px"
         
          var   i=10;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:47px;'onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.width="53px"
          }   
            var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:47px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="53px"
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
                        if(row + i <= table4.rows.length - 1 && col + j <= table4.rows[i].cells.length - 2)
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
                        if(row + i <= table4.rows.length - 1 && col + j <= table4.rows[i].cells.length - 2)
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
    <td width="44%"><strong>我的空运运价</strong></td>
    <td width="50%" align="right"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
</div>
				<div class="fcl">
					
					  <table width="100%" border="0" cellspacing="1" cellpadding="0"  style="font-size:14px">
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
                          <td align="left"><span id="ctl00_ContentPlaceHolder1_Label3">空运</span></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td>&nbsp;&nbsp;<span class="red">*</span> 起运港：</td>
                          <td align="left"><asp:TextBox ID="txtStart" CssClass="ms_text"    runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td><span class="red">*</span> 航线描述： </td>
                          <td align="left"><asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem>澳洲线</asp:ListItem>
            <asp:ListItem>非洲线</asp:ListItem>
            <asp:ListItem>北美线</asp:ListItem>
            <asp:ListItem>南美线</asp:ListItem>
            <asp:ListItem>欧洲线</asp:ListItem>
            <asp:ListItem>亚洲线</asp:ListItem>
            <asp:ListItem>国内航线</asp:ListItem>
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
			<div class="fcl">
			    
			
			
			 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Width="100%" Height="1px" border="0" cellspacing="3" cellpadding="0" >
                <Columns>
                    
                    <asp:TemplateField HeaderText="目的港">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="166px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="78px" Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("DestPort")) %>' Width="72px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="M" SortExpression="PRICE_M">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PRICE_M") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox2" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_M").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="N" SortExpression="PRICE_N">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PRICE_N") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox3" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_N").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="45" SortExpression="PRICE_P45">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PRICE_P45") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox4" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_P45").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="100" SortExpression="PRICE_P100">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PRICE_P100") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox5" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_P100").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="300" SortExpression="PRICE_P300">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PRICE_P300") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox6" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_P300").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="500" SortExpression="PRICE_P500">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("PRICE_P500") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox7" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_P500").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="1000" SortExpression="PRICE_P1000">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("PRICE_P1000") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                             <asp:TextBox ID="TextBox8" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("PRICE_P1000").ToString) %>' Width="47px" CssClass="ms_text" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    

                    
                    
                    
                    
                    <asp:TemplateField HeaderText="附加费">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("price20gpAppend") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("price20gpAppend").ToString) %>' CssClass="ms_text" Width="47px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="航程">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Distance") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("Distance").ToString) %>' CssClass="ms_text" Width="47px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出发日">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("DepartureWkd") %>' CssClass="ms_text" Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("DepartureWkd").ToString) %>' CssClass="ms_text" Width="47px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("memo") %>' CssClass="ms_text" Width="137px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="53px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# HttpContext.Current.Server.HtmlDecode(Eval("memo").ToString) %>' CssClass="ms_text" Width="47px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="保证">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# eval("assurance") %>' CssClass="ms_text" Width="137px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="25px" />
                        <HeaderTemplate>
                            <table>
                        <tr>
                        <td><a href="/help/services_2.aspx" target="_blank"><img src="/images/fcl/cang.gif" alt="舱位保证，点击查看何为舱位保证" border=0 /></a></td>
                        </tr>
                        <tr>
                        <td><input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" /></td>
                        </tr>
                        </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                       <%-- <asp:TextBox ID="TextBox119" runat="server" Text='<%# Bind("assurance") %>' CssClass="ms_text" Width="14px"></asp:TextBox>--%>
                        <table>
                        
                        <tr>
                        <td><asp:CheckBox ID="CheckBox1" Checked='<%#  IIF(eval("assurance").tostring = "1", "true", "false") %>' runat="server" /></td>
                        </tr>
                        </table>
                            
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        
                        
                        <ItemTemplate>
                            <a href="javaScript:void(0)" onclick="delRow(this.parentElement.parentElement)"><img style="border:0px" src="../images/delete.jpg" /></a>
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
        <td style="height: 25px; width: 64px;"><asp:Literal ID="LitRow50" runat="server"><input id="Button4" type="button" value="添加50行" language="javascript" onclick="addRow(document.getElementById('GridView2'),50,0)" /></asp:Literal>
        </td>
                            
                        </tr>
                    
                    </table>
			  <div style="width:731px; text-align: center;">
                        <input id="hidsubmit" type="hidden" runat="server" value="" />
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
    </form>
</body>
</html>