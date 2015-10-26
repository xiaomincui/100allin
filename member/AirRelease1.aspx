<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="AirRelease1.aspx.vb" Inherits="member_Release" title="Untitled Page" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link href="css/WebResource.css" type="text/css" rel="stylesheet" />	
	<script type="text/javascript" language="JavaScript">
	window.onbeforeunload = function()
    {  
      var n = window.event.screenX - window.screenLeft;  
      var b = n>document.documentElement.scrollWidth-20;  
      if(b && window.event.clientY < 0 || window.event.altKey)  
      {  
        
        window.open("a.aspx?flag=0&id="+document.getElementById("ctl00_ContentPlaceHolder1_hidSave").value,"_blank"); 
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
          newcell.innerHTML=   " <input  type='text'  style='width:81px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="87px"
         
          var   i=10;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML=   " <input  type='text'  style='width:44px;'onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.width="50px"
          }   
            var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='text'  style='width:64px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="70px"
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
    
    var table4 = document.getElementById("ctl00_ContentPlaceHolder1_GridView2");
    

    
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
    
    
    document.getElementById("ctl00_ContentPlaceHolder1_hidsubmit").value=str;
    
    document.getElementById("ctl00_ContentPlaceHolder1_Button1").click();
  }

    function insertTable(col,row)
    {
        if(event.ctrlKey&&event.keyCode==86)
        {
            
            var table4 = document.getElementById("ctl00_ContentPlaceHolder1_GridView2");
        
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
            
            var table4 = document.getElementById("ctl00_ContentPlaceHolder1_GridView2");    
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
	</script>
	<script type="text/javascript" language="javascript" src="../Web_Admin/include/calendar.js"></script>
<div>
    <table style="width: 773px; height: 144px">
        <tr>
            <td colspan="2">
                <div class="listTitle">
                    <table border="0" cellpadding="0" cellspacing="0" style="float: left">
                        <tr>
                            <td width="44">
                                <img height="27" src="images/edit_icon.gif" width="44" /></td>
                            <td width="130">
                                <span class="bigBoxTitle">我的空运运价</span></td>
                            <td style="width: 160px">
                                <%--<a href="AirRelease.aspx">不会使用新版运价发布功能？点击这里，回到老版本</a>--%></td>
                            <td width="413">
                                <div style="text-align: right">
                                    <a href="temp_upload3.aspx">
                                            <img border="0" height="30" src="images\btn_pl_hk.gif" width="130" /></a></div>
                            </td>
                        </tr>
                    </table>
                </div>
            
            </td>
        </tr>
        <tr>
            <td style="width: 436px; height: 301px;" valign="top">
                <div style="margin-top: 0px; margin-right: 0px; height: 1px">
                    <table bgcolor="#dbeef5" border="0" cellpadding="2" cellspacing="1" style="width: 460px;
                        height: 293px" >
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 12px">
                    &nbsp; &nbsp; 运价标题<b style=" color:#FF6600">*</b>：
                            </td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 12px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 发布时间：
                            </td>
                            <td bgcolor="#f2f8fb" style="width: 263px">
                                &nbsp;<asp:Label ID="labnow" runat="server" Font-Size="10pt" Text="Label"></asp:Label></td>
                        </tr>
                        <tr style="color: #226077">
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 有效时间<b style=" color:#FF6600">*</b>：</td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 26px">
                                <span style="color: #226077">
<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:150px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
   
                                        
                                     
                                     
                                     <SCRIPT src="js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"ctl00$ContentPlaceHolder1$BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
                                     
                                    </span></td>
                        </tr>
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 运价类型：</td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 26px">
                                &nbsp;<asp:Label ID="Label13" runat="server" Font-Size="10pt" Text="空运"></asp:Label></td>
                        </tr>
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 150px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 起运港<b style=" color:#FF6600">*</b>：</td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 26px">
                    <asp:TextBox ID="txtStart"
            runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 航线描述<b style=" color:#FF6600">*</b>：
                            </td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 26px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem>澳洲线</asp:ListItem>
            <asp:ListItem>非洲线</asp:ListItem>
            <asp:ListItem>北美线</asp:ListItem>
            <asp:ListItem>南美线</asp:ListItem>
            <asp:ListItem>欧洲线</asp:ListItem>
            <asp:ListItem>亚洲线</asp:ListItem>
            <asp:ListItem>国内航线</asp:ListItem>
        </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td bgcolor="#edf7fa" style="width: 80px; color: #29728d; height: 26px">
                    &nbsp; &nbsp; 备 注：</td>
                            <td bgcolor="#f2f8fb" style="width: 263px; height: 26px">
        <asp:TextBox ID="txtRemark" runat="server" Height="63px" Width="340px" TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </td>
            <td style="width: 258px; height: 301px;" valign="top">
                <div style="border-right: #dbeef5 1px solid; border-left: #dbeef5 1px solid; width: 281px;
                    border-bottom: #dbeef5 1px solid;  background-color: #f2f8fb; height: 288pxpx;">
                    <table border="0" cellspacing="0" style="border-top: #dbeef5 1px solid; border-left-width: 1px;
                        border-left-color: #dbeef5; border-bottom-width: 1px; border-bottom-color: #dbeef5;
                        width: 285px; height: 120px; background-color: #f2f8fb; border-right: #dbeef5 1px solid;">
                        <tr>
                            <td colspan="2" style="padding-left: 10px; font-weight: bold; vertical-align: bottom;
                                color: #29728d; height: 28px">
                                <div id="tt" runat="server">
                                您的名片
                                </div>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 10px; height: 41px">
                                
                                <asp:TextBox ID="txtname" runat="server" BackColor="#F2F8FB" BorderWidth="0px" Font-Bold="True"
                                    Font-Names="宋体" Font-Size="Medium" Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                公司名称：</td>
                            <td style="width: 260px; height: 25px">
                                
                                <asp:TextBox ID="txtCompanyName" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                电话号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtPhone" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                传真号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtFax" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                手机号码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtMovePhone" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                电子邮箱：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtUserEmail" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                公司地址：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtAddress" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 25px">
                                邮政编码：</td>
                            <td style="width: 260px">
                                
                                <asp:TextBox ID="txtPostNumber" runat="server" BackColor="#F2F8FB" BorderWidth="0px"
                                    Width="196px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; width: 389px; color: #29728d; height: 27px">
                                </td>
                            <td style="width: 260px; height: 27px">
                                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.100allin.com"
                                    Target="_blank" Visible="False">www.100allin.com</asp:HyperLink></td>
                        </tr>
                    </table>
                </div>
                <input id="Hidden1" runat="server" type="hidden" visible="false" /></td>
        </tr>
        <tr>
            <td colspan="2">
            <div  class="tipBox underline" style="width:746px; margin-bottom:8px;padding-left:13px;padding-top:5px;padding-bottom:5px;">
            <table width="682" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="20" style="height: 16px"><img src="images/light.gif" width="11" height="16" /></td>
                <td width="662" style="height: 16px">可从EXCEL中复制内容，粘粘在下列行中，快捷方便，赶紧试试！看清格式，别粘错了哦！</td>
              </tr>
            </table>
            </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: middle">
                <div id="Div1">
                
                   
                    
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Width="761px" Height="1px"  style="float: left">
                <Columns>
                    
                    <asp:TemplateField HeaderText="目的港">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="81px"></asp:TextBox><asp:CustomValidator
                                ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" CssClass="hidden"
                                ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"
                                ValidateEmptyText="True"></asp:CustomValidator>
                        </EditItemTemplate>
                        <ItemStyle Width="87px" Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestPort") %>' Width="81px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M" SortExpression="PRICE_M">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PRICE_M") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PRICE_M") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N" SortExpression="PRICE_N">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PRICE_N") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PRICE_N") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="45" SortExpression="PRICE_P45">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PRICE_P45") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PRICE_P45") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="100" SortExpression="PRICE_P100">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PRICE_P100") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate> 
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PRICE_P100") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="300" SortExpression="PRICE_P300">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PRICE_P300") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PRICE_P300") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="500" SortExpression="PRICE_P500">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("PRICE_P500") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("PRICE_P500") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="1000" SortExpression="PRICE_P1000">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("PRICE_P1000") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Font-Bold="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("PRICE_P1000") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="附加费">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("price20gpAppend") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="航程">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Distance") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Distance") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出发日">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="44px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="50px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DepartureWkd") %>' Width="44px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("memo") %>' Width="64px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="70px" Wrap="True" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("memo") %>' Width="64px" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        
                        <ItemStyle  />
                        <ItemTemplate>
                            <input type='button'  style='width:60px;' onClick='javascript:delRow(this.parentElement.parentElement)' value='删除此行'>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="False" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle Height="25px" Wrap="True" />
                <HeaderStyle BackColor="#F2F8FB" Font-Bold="False" Font-Names="宋体" Font-Size="12px"
                    ForeColor="#29728D" Height="25px" HorizontalAlign="Center" />
            </asp:GridView>
                    <table  cellspacing="0" rules="all" bordercolor="#FFFFFF" border="1" style="height:1px;border-collapse:collapse;">
                        <tr>
                            <td style="height: 25px; width: 64px;">
                                <input id="Button5" type="button" value="添加1行" language="javascript" onclick="addRow(document.getElementById('ctl00_ContentPlaceHolder1_GridView2'),1)" />
                                </td>
                                <td style="height: 25px; width: 64px;">
                                <input id="Button2" type="button" value="添加5行" language="javascript" onclick="addRow(document.getElementById('ctl00_ContentPlaceHolder1_GridView2'),5)" />
                                </td>
                                <td style="height: 25px; width: 64px;">
                                <input id="Button3" type="button" value="添加10行" language="javascript" onclick="addRow(document.getElementById('ctl00_ContentPlaceHolder1_GridView2'),10)" />
                                </td>
                                <td style="height: 25px; width: 64px;">
                                <input id="Button4" type="button" value="添加50行" language="javascript" onclick="addRow(document.getElementById('ctl00_ContentPlaceHolder1_GridView2'),50)" />
                                </td>
                            
                        </tr>
                    </table>
            

        </div>
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    <div style="width:761px; text-align: center;">
                        <input id="hidsubmit" type="hidden" runat="server" value="" />
                    <input id="bntsumbit" value="提交"  onclick="bntover()" type="button" />
                    <div style="display:none">
        <asp:Button ID="Button1" runat="server" Text="完成" Width="80px" />
        </div>
            </div>
        
        
        </td>
        </tr>
    </table>
        <input id="hidSave2" runat="server" type="hidden" />
        
        &nbsp;&nbsp;
        <input id="hidtable" type="hidden" />&nbsp;
    <asp:TextBox ID="hidSave" runat="server" CssClass="hidden"></asp:TextBox></div>

</asp:Content>

