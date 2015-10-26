<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_fcl.aspx.vb" Inherits="pro_freight_edit_fcl" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<title>整箱运价修改</title>
<link href="../order/css/master.css" rel="stylesheet" type="text/css" />
<link href="../order/css/userlist.css" rel="stylesheet" type="text/css" />
<link href="/pro/css/WebResource.css" rel="stylesheet" type="text/css" />
<script src="/pro/js/WebResource.js" type="text/javascript"></script>
<script src="/pro/js/coolite.js" type="text/javascript"></script>
<script src="/pro/js/basicdatepicker.js" type="text/javascript"></script>
<script type="text/javascript" language="JavaScript">
  var curRow=null;   
 
  function   addRow(src,num)
  {   
      for(var k=0;k<num;k++)
      {
          var   newrow   =   src.insertRow();
          newrow.height=25; 
          var   newcell   =   newrow.insertCell();
          newcell.innerHTML=   " <input  type='text'  style='width:114px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="120px"
          var   i=7;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML= " <input  type='text'  style='width:59px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.width="65px"
          }
            var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='text'  style='width:79px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="85px"
          var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='button' onClick='javascript:delRow(this.parentElement.parentElement)' style='width:60px;'  value='删除此行'>"
       }


  }   
  function   delRow(src)
  {   
    src.parentElement.deleteRow(src.rowIndex);   
  }   
  function bntover()
  { 
    
    var table4 = document.getElementById("GridView1");
    

    
    var str = "";
    for(var i = 1;i < table4.rows.length;i++)
    {
        for(var j = 0;j < table4.rows[i].cells.length - 1;j++)
        {
            var value1 = table4.rows[i].cells[j];
            var aInput = value1.getElementsByTagName("input");
            if(aInput.length != 0)
            {
                str += aInput[0].value+"qwerhjkl";
             }
        }
        str += "sdfgyuio";
    }
    
    
    document.getElementById("hidsubmit").value=str;
    
    document.getElementById("Button1").click();
  }

	function insertTable(col,row)
    {
        if(event.ctrlKey&&event.keyCode==86)
        {
            
            var table4 = document.getElementById("GridView1");
        
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
                return false; 
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
            
            var table4 = document.getElementById("GridView1");    
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
	</script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />										
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">

<div>


    <table style="width: 773px; height: 144px">

        <tr>
            <td valign="top" style="width: 436px; height: 311px;">
    <div style=" margin-top:0px; margin-right:0px; height: 1px;" >
    <table border="0" cellpadding="2" cellspacing="1" bgcolor="#eeeeee" style="width: 460px; height: 300px; ">
        <tr>
            <td bgcolor="#F9F9F9" style=" width:80px; height: 12px; color: #333333;">
                &nbsp; &nbsp;
            运价标题<b style=" color:#FF6600">*</b>：            </td>
         <td bgcolor="#F9F9F9" style="width: 263px; height: 12px">
        <asp:TextBox ID="TextBox1" runat="server" Width="339px"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px;">
                &nbsp; &nbsp;
            发布时间：            </td>
         <td bgcolor="#F9F9F9" style="width: 263px">
             &nbsp;<asp:Label ID="lblPostDate" runat="server" Width="187px" Font-Size="10pt"></asp:Label></td>
        </tr>
        
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; color: #333333;">
                &nbsp; &nbsp; 有效时间<b style=" color:#FF6600">*</b>：</td>
         <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
             <input id="txtenddate" runat="server" name="date1" type="text" style="width: 149px" readonly="readOnly" />
            <IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="/pro/images/WebResource.gif" border=10 />        
<SCRIPT type=text/javascript>
//<![CDATA[
var d = new Date();
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:d.getYear()+"/"+(d.getMonth()+1)+"/"+d.getDate(),nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"txtenddate",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
             </td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; color: #333333;">
                &nbsp; &nbsp; 运价类型：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                &nbsp;<asp:Label ID="lblyunjialeixing" runat="server" Text="整箱" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; color: #333333;">
                &nbsp; &nbsp; 起运港<b style=" color:#FF6600">*</b>：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:TextBox ID="txtStartPost" runat="server">
      
    </asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; color: #333333;">
                &nbsp; &nbsp; 航线描述<b style=" color:#FF6600">*</b>：            </td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:DropDownList ID="ddlhangxianmiaoshu" runat="server">
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
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="#F9F9F9" style="height: 26px; width: 80px; color: #333333;">
                &nbsp; &nbsp;
                备 注：</td>
            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
    <asp:TextBox ID="txtmemo" runat="server" Height="70px" Width="339px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
  </table>
  
  
  </div>
          </td>
            <td valign="top" style="width: 259px; height: 311px;">
            <%--<div style=" height: 300px; background-color:#F9F9F9 ; border-bottom: #eeeeee 1px solid; border-right: #eeeeee 1px solid; border-left: #eeeeee 1px solid;">--%>
            <table border="0" cellspacing="0"  style="width: 285px; height: 138px;background-color:#F9F9F9; border-top: #eeeeee 1px solid; border-right: #eeeeee 1px solid; border-left: #eeeeee 1px solid; border-bottom: #eeeeee 1px solid;">
            
            
            <tr>
                <td colspan="2" style="height: 28px; padding-left:10px; font-weight: bold; color: #333333; vertical-align: bottom;">
                    <div id="tt" runat="server">
                    您的名片
                    </div>
                    </td>
            </tr>
            
            <tr>
                <td colspan="2" style="padding-left:10px; height: 34px;">
                    &nbsp;<asp:TextBox ID="txtname" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Font-Bold="True" Font-Names="宋体" Font-Size="Medium"  Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style=" padding-left:10px; width: 389px; color: #333333; height: 27px;">
                    公司名称：</td>
                <td style="width: 260px; height: 25px;">
                    &nbsp;
                    <asp:TextBox ID="txtCompanyName" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                    电话号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtPhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px" Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                    传真号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtFax" runat="server" BackColor="#F9F9F9" BorderWidth="0px" Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                    手机号码：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtMovePhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                    电子邮箱：</td>
                <td style="width: 260px">
                    &nbsp;
                    <asp:TextBox ID="txtUserEmail" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                        Width="196px"></asp:TextBox></td>
            </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                        公司地址：</td>
                    <td style="width: 260px">
                        &nbsp;
                        <asp:TextBox ID="txtAddress" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                            Width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                        邮政编码：</td>
                  <td style="width: 260px">&nbsp;
                      <asp:TextBox ID="txtPostNumber" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                          Width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="padding-left:10px; width: 389px; color: #333333; height: 27px;">
                        </td>
                    <td style="width: 260px; height: 27px;">
                        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.100allin.com"
                            Target="_blank" Visible="False">www.100allin.com</asp:HyperLink>
                <input id="Hidden1" runat="server" type="hidden" visible="false" value="0" /></td>
                </tr>
            
            
            
 
            
            
            
            
            </table>
                <%--</div>--%>
            
            
            
            
            
            
            
            
            
            
          </td>
        </tr>
        
        <tr>
            <td colspan="2">
            <div  class="tipBox underline" style="width:746px; margin-bottom:8px;padding-left:13px;padding-top:5px;padding-bottom:5px;">
            <table width="682" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="682" style="height: 16px">可从EXCEL中复制内容，粘粘在下列行中，快捷方便，赶紧试试！看清格式，别粘错了哦！</td>
              </tr>
            </table>
            </div>
            </td>
        </tr>
        <tr>
            <td colspan="2"  style="vertical-align: middle">
            <div id="Div1">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="761px" Height="1px" >
        <Columns>

           
            <asp:TemplateField HeaderText="目的港" SortExpression="DestPort">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DestPort") %>' Width="114px"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="不能为空！！！" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" CssClass="hidden"></asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="114px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" Font-Size="12px" HorizontalAlign="Center" />
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="20GP" SortExpression="price20gp">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("price20gp") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                      <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("price20gp") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="40GP" SortExpression="price40gp">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("price40gp") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("price40gp") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="40HQ" SortExpression="price40hq">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("price40hq") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("price40hq") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="附加费" SortExpression="price20gpAppend">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="航程" SortExpression="Distance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Distance") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Distance") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出发日" SortExpression="DepartureWkd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="船公司" SortExpression="DepartureWkd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("shipcompany") %>' Width="59px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("shipcompany") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            
            
            
            
            <asp:TemplateField HeaderText="备注" SortExpression="memo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("memo") %>' Width="79px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("memo") %>' Width="79px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                <ItemStyle Width="85px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        
                        
                        <ItemTemplate>
                        <input type='button'  style='width:60px;' onClick='javascript:delRow(this.parentElement.parentElement)' value='删除此行'>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#333333" Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="price20gpMark" SortExpression="price20gpMark" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("price20gpMark") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("price20gpMark") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle ForeColor="#333333" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="25px" />
        <HeaderStyle BackColor="#F9F9F9" Height="25px" />
        <EditRowStyle Height="20px" />
    </asp:GridView>
               <table id="tabletemp" cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;border-collapse:collapse;">
                    
                        <tr style="height:25px;">
                            <td style=" height: 25px; width: 64px;">
        <input id="Button2"     type="button" value="添加1行" language="javascript" onclick="addRow(document.getElementById('GridView1'),1)" />
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button5"     type="button" value="添加5行" language="javascript" onclick="addRow(document.getElementById('GridView1'),5)" />
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button3"     type="button" value="添加10行" language="javascript" onclick="addRow(document.getElementById('GridView1'),10)" />
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button4"     type="button" value="添加50行" language="javascript" onclick="addRow(document.getElementById('GridView1'),50)" />
                            </td>
                        </tr>
        </table>
        </div>
    
        
        
       
        <div style="width:761px; text-align: center;">
        <input id="hidsubmit" type="hidden" runat="server" value="" />
        <input id="bntsumbit" value="提交"  onclick="bntover()" type="button" />
        <div style="display:none">
         <asp:Button ID="Button1" runat="server" Text="更新" Width="80px" />
        
        </div>
        </div>
        </td>
        </tr>
    
    
    
    </table>

        <br />
    <div style="z-index: 101; left: 100px; width: 100px; position: absolute; top: 100px;
        height: 100px">
    </div>
    <br />
    &nbsp;&nbsp;
</div>
			

</div>
</div>
</div>
</div>			
</div>
<probottom:probottom ID="probottom1" runat="server" />
</div>
</div>


</form>
</body>
</html>
