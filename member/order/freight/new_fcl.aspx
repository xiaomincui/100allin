<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_fcl.aspx.vb" Inherits="pro_freight_new_fcl" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<title>整箱运价发布</title>
<link href="../order/css/master.css" rel="stylesheet" type="text/css" />
<link href="../order/css/userlist.css" rel="stylesheet" type="text/css" />
<link href="/pro/css/WebResource.css" rel="stylesheet" type="text/css" />
<script src="/pro/js/WebResource.js" type="text/javascript"></script>
<script src="/pro/js/coolite.js" type="text/javascript"></script>
<script src="/pro/js/basicdatepicker.js" type="text/javascript"></script>
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



function   addRow(src,num)
{   
  for(var k=0;k<num;k++)
  {
      var   newrow   =   src.insertRow();
      newrow.height=25; 
      var   newcell   =   newrow.insertCell();
      newcell.innerHTML=   " <input  type='text'  style='width:114px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)'  onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
      newcell.width="120px"
      var   i=7;   
      while(i--)
      {   
        var   newcell   =   newrow.insertCell();
        newcell.innerHTML=   " <input  type='text'  style='width:59px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
        newcell.width="65px"
      }   
        var newcell = newrow.insertCell();
      newcell.innerHTML=   " <input  type='text'  style='width:79px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
      newcell.width="85px"
      var newcell = newrow.insertCell();
      newcell.innerHTML=   " <input   type='button' onClick='javascript:delRow(this.parentElement.parentElement)' style='width:60px;'  value='删除此行'>"
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
            str += aInput[0].value+"qwerhjkl";
         }
    }
    str += "sdfgyuio";
}


document.getElementById("hidsubmit").value=str;

document.getElementById("Button1").click();
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

        }

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

        }
        
    }
    else
    {
        
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
    <table style="width: 773px;">

        <tr>
            <td style="width: 436px; height: 301px;" valign="top">
                <div style="margin-top: 0px; margin-right: 0px; height: 1px">
                    <table bgcolor="#eeeeee" border="0" cellpadding="2" cellspacing="1" style="width: 460px;
                        height: 293px">
                        <tr>
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 12px">
                                &nbsp; &nbsp;
                    运价标题<b style=" color:#FF6600">*</b>：
                            </td>
                            <td bgcolor="#F9F9F9" style="width: 263px; height: 12px">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px">
                                &nbsp; &nbsp;
                    发布时间：
                            </td>
                            <td bgcolor="#F9F9F9" style="width: 263px">
                                <asp:Label ID="labnow" runat="server" Text="Label" Font-Size="10pt"></asp:Label></td>
                        </tr>
                        <tr style="color: #226077">
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px">
                                &nbsp; &nbsp;
                    有效时间<b style=" color:#FF6600">*</b>：</td>
                            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                                <span style="color: #226077">
                                    <input id="txtenddate" runat="server" name="date1" type="text" readonly="readOnly" style="width: 148px" />
            <IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="/pro/images/WebResource.gif" border=10 />        
<SCRIPT type=text/javascript>
//<![CDATA[
var d = new Date();
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:d.getYear()+"/"+(d.getMonth()+1)+"/"+d.getDate(),nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"txtenddate",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>                                        
                                    </span></td>
                        </tr>
                        <tr>
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px">
                                &nbsp; &nbsp;
                    运价类型：</td>
                            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                                <asp:Label ID="Label10" runat="server" Text="整箱"></asp:Label></td>
                        </tr>
                        <tr>
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px">
                                &nbsp; &nbsp;
                    起运港<b style=" color:#FF6600">*</b>：</td>
                            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                    <asp:TextBox ID="txtStart"
            runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333; height: 26px">
                                &nbsp; &nbsp;
                    航线描述<b style=" color:#FF6600">*</b>：
                            </td>
                            <td bgcolor="#F9F9F9" style="width: 263px; height: 26px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
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
                            <td bgcolor="#F9F9F9" style="width: 80px; color: #333333;height: 26px"">
                                &nbsp; &nbsp;
                    备 注：</td>
                            <td bgcolor="#F9F9F9" style="width: 263px;height: 26px"">
        <asp:TextBox ID="txtRemark" runat="server" Height="63px" Width="316px" TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </td>
            <td style="width: 258px; height: 301px;" valign="top">
                <div style="border-right: #eeeeee 1px solid; border-left: #eeeeee 1px solid; width: 281px;
                    border-bottom: #eeeeee 1px solid;  background-color: #F9F9F9; height: 288px;">
                    <table border="0" cellspacing="0" style="border-top: #eeeeee 1px solid; border-left-width: 1px;
                        border-left-color: #eeeeee; border-bottom-width: 1px; border-bottom-color: #eeeeee;
                        width: 285px; height: 120px; background-color: #F9F9F9; border-right: #eeeeee 1px solid;">
                        <tr>
                            <td colspan="2" style="padding-left: 10px; font-weight: bold; vertical-align: bottom;
                                color: #333333; height: 28px">
                                <div id="tt" runat="server">
                                您的名片</div></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 10px; height: 41px">
                                <asp:TextBox ID="txtname" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Font-Bold="True" Font-Names="宋体" Font-Size="Medium" Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                公司名称：</td>
                            <td style="width: 260px; height: 25px">
                                <asp:TextBox ID="txtCompanyName" runat="server" BorderWidth="0px" BackColor="#F9F9F9" Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                电话号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtPhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                传真号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtFax" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                手机号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtMovePhone" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                电子邮箱：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtUserEmail" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                公司地址：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtAddress" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 25px">
                                邮政编码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtPostNumber" runat="server" BackColor="#F9F9F9" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #333333; height: 27px">
                                </td>
                            <td style="width: 260px; height: 27px">
                                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.100allin.com" Target="_blank" Visible="False">www.100allin.com</asp:HyperLink></td>
                        </tr>
                    </table>
                    <input id="Hidden1" runat="server" type="hidden" visible="false" /></div>
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
            <td colspan="2" style="vertical-align: middle">
                <div id="Div1">
                    <%--<div id="head" runat="server">
                        <table bgcolor="#eeeeee" border="0" cellpadding="2" cellspacing="1" style="color: #333333;
                            border-collapse: collapse; width: 761px;">
                            <tr>
                                <td bgcolor="#F9F9F9" nowrap=true style="vertical-align: middle; width: 118px; height: 25px;
                                    text-align: center; ">
                                    目的港</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    20GP</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    40GP</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    40HQ</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px;
                                    text-align: center">
                                    附加费</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    航程</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    出发日</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 63px; height: 25px; text-align: center">
                                    船公司</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle; width: 85px; height: 25px;
                                    text-align: center">
                                    备注</td>
                                <td bgcolor="#F9F9F9" style="vertical-align: middle;  height: 25px; text-align: center">
                                    操作</td>
                            </tr>
                        </table>
                    </div>--%>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Width="761px"   >
                <Columns>
                    <%--<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                        <ItemStyle CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <FooterStyle CssClass="hidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TempID" >
                        <ItemStyle CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <FooterStyle CssClass="hidden" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="目的港">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="114px"></asp:TextBox><asp:CustomValidator
                                ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" CssClass="hidden"
                                ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"
                                ValidateEmptyText="True"></asp:CustomValidator>
                        </EditItemTemplate>
                        <ItemStyle Width="120px" Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="114px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            
                            
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="20GP">
                        <EditItemTemplate>f
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("price20gp") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("price20gp") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label2" runat="server" Text='<%# Bind("price20gp") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="40GP">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("price40gp") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("price40gp") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label3" runat="server" Text='<%# Bind("price40gp") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="40HQ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("price40hq") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("price40hq") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label4" runat="server" Text='<%# Bind("price40hq") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="45HQ" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <%--<asp:Label ID="Label5" runat="server"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="附加费">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("price20gpAppend") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="航程">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Distance") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Distance") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label7" runat="server" Text='<%# Bind("Distance") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出发日">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label8" runat="server" Text='<%# Bind("DepartureWkd") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="船公司">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("shipcompany") %>' Width="59px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="65px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("shipcompany") %>' Width="59px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label10" runat="server" Text='<%# Bind("shipcompany") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="65px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("memo") %>' Width="79px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="85px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("memo") %>' Width="79px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                            <%--<asp:Label ID="Label9" runat="server" Text='<%# Bind("memo") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Width="85px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemStyle  />
                        <ItemTemplate>
                        <input type='button'  style='width:60px;' onClick='javascript:delRow(this.parentElement.parentElement)' value='删除此行'>
                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="删除"></asp:LinkButton>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle Height="25px" />
                <HeaderStyle BackColor="#F9F9F9" Font-Bold="False" Font-Names="宋体" Font-Size="12px"
                    ForeColor="#333333" Height="25px" HorizontalAlign="Center" />
            </asp:GridView>
                    
                    
                    <%--<table id="table1" cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;border-collapse:collapse;" runat="server">
                    
                        <tr style="height:25px;">
                            <td style="width:120px; height: 25px;">
        <asp:TextBox ID="txt1" runat="server" Width="114px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt2" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt3" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt4" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt5" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt6" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txt7" runat="server" Width="59px"></asp:TextBox></td>
                            <td style="width:65px; height: 25px;">
        <asp:TextBox ID="txtshipcompany" runat="server" Width="59px"></asp:TextBox></td>
        
        
        
        
                            <td style="width:85px; height: 25px;">
        <asp:TextBox ID="txt8" runat="server" Width="79px"></asp:TextBox></td>
                            <td style=" height: 25px; width: 64px;">
        <asp:Button ID="Button4" runat="server" Text="添加" Width="34px" /></td>
                        </tr>
                        
                        
                        
                        
                        
                        
     
                    
                    
                    </table>--%>
                    
                    <table id="tabletemp" cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;border-collapse:collapse;">
                    
                        <tr style="height:25px;">
                            <td style=" height: 25px; width: 64px;">
        <input id="Button2" type="button" value="添加1行" language="javascript" onclick="addRow(document.getElementById('GridView2'),1)" />
        
        
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button5" type="button" value="添加5行" language="javascript" onclick="addRow(document.getElementById('GridView2'),5)" />
        
        
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button3" type="button" value="添加10行" language="javascript" onclick="addRow(document.getElementById('GridView2'),10)" />
        
        
                            </td>
                            <td style=" height: 25px; width: 64px;">
        <input id="Button4" type="button" value="添加50行" language="javascript" onclick="addRow(document.getElementById('GridView2'),50)" />
        
        
                            </td>
                        </tr>
                        
     
                    
                    
                    </table>
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    <div style="width:761px; text-align: center;">
                        <input id="hidsubmit" type="hidden" runat="server" value="" />
                    <input id="bntsumbit" value="提交"  onclick="bntover()" type="button" />
                    <div style="display:none">
        <asp:Button ID="Button1" runat="server" Text="完成" Width="80px" />
        </div>
            </div>

        </div>
            </td>
        </tr>
    </table>
        <input id="hidSave2" runat="server" type="hidden" />
        <input id="hidtable" type="hidden" />
    <asp:TextBox ID="hidSave" runat="server" CssClass="hidden"></asp:TextBox></div>
			

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
