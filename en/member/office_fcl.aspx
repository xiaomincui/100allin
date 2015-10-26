<%@ Page Language="C#" AutoEventWireup="true" CodeFile="office_fcl.aspx.cs" Inherits="en_office_sent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/office.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
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
          var   i=10;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML=   "<input type='text' class='ms_text' size='4' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.height="28"
            newcell.align="center"
          }   


          if(display==1)
          {
            newcell.style.display="none";
          }
          
          
          var newcell = newrow.insertCell();
          newcell.align="center"
            newcell.innerHTML="<input  type='button'  onclick='delRow(this.parentElement.parentElement)' value='del'  />";
       
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
    for(var i = 2;i < table4.rows.length;i++)
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
                        if(row + i <= table4.rows.length - 1 && col + j <= table4.rows[row+i].cells.length - 2)
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
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <enusertop:enusertop ID="enusertop1" runat="server" />
		
		<div class="main_page">
			<div class="dhang"><img src="../images/office/of_nav.gif" /></div>
			<enuserleft:enuserleft ID="enuserleft1" runat="server" />
			<div class="of_rg">
				
				<div class="of_rg_box">
					<h2>Send FCL information</h2>
					<h3><table width="612" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
		<td width="155" height="28" align="right">Subject&nbsp;:</td>
		<td width="457">
		<asp:TextBox ID="txtTitle" runat="server" Width="179px">
		</asp:TextBox>
            </td>
		</tr>
	  <tr>
	    <td height="28" align="right">Post date  may 1,2010.</td>
	    <td>
	    <asp:Label ID="labnow" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
	    </td>
	    </tr>
	  <tr>
	    <td height="28" align="right">Valid date&nbsp;:</td>
	    <td>
	    <span style="color: #226077">

<input name="BasicDatePicker1$TextBox" type="text" value="2010-1-19" readonly="readonly" id="BasicDatePicker1_TextBox"  runat="server" style="width: 179px"/>
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
	    <td height="28" align="right">Type  FCL</td>
	    <td>&nbsp;</td>
	    </tr>
	  <tr>
	    <td height="28" align="right">Pol&nbsp;:</td>
	    <td><asp:TextBox ID="txtStart" onkeyup="autowords(this.id,event,1);" runat="server" Width="179px" /></td>
	    </tr>
	  <tr>
	    <td height="28" align="right">line&nbsp;:</td>
	    <td>
	    <%--<asp:DropDownList ID="DropDownList1" runat="server">
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
        </asp:DropDownList>--%>
        <asp:DropDownList ID="DropDownList1" runat="server" Width=105 Font-Size="12px">
<asp:ListItem Value="">Please Choose</asp:ListItem>
<asp:ListItem Value="美加线">North America</asp:ListItem>
<asp:ListItem Value="欧地线">Euro/Med</asp:ListItem>
<asp:ListItem Value="中南美线">Middle/South America</asp:ListItem>
<asp:ListItem Value="日韩线">Japan and Korea</asp:ListItem>
<asp:ListItem Value="近洋线">Southeast Asia</asp:ListItem>
<asp:ListItem Value="非洲线">Africa</asp:ListItem>
<asp:ListItem Value="澳洲线">Australia</asp:ListItem>
<asp:ListItem Value="中东印巴线">Middle East</asp:ListItem>
<asp:ListItem Value="红海线">Red Sea</asp:ListItem>
</asp:DropDownList>
        <%--<input name="textfield22" type="text" size="25" />--%></td>
	    </tr>
			  <tr>
	    <td height="4" colspan="2"></td>
	    </tr>

	  <tr>
	    <td height="28" align="right" valign="top">Remark&nbsp;:</td>
	    <td><textarea name="textfield222" cols="35" rows="5" id="txtRemark" runat="server"></textarea></td>
	    </tr>
	  <tr>
	    <td height="28" align="right">&nbsp;</td>
	    <td>&nbsp;</td>
	    </tr>
	</table>
					</h3>
			        <div style=" width:652px; font-size:13px; padding:0px; margin:0px; float:left;">
                        <%--<asp:GridView ID="GridView1" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="3" Width="100%" BackColor="#E8F6FF">
                        <Columns>
                        <asp:TemplateField HeaderText="POD">
                        <HeaderTemplate>
                        POD
                        </HeaderTemplate>
                        <ItemStyle Height="28" VerticalAlign="Middle"  />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# eval("DestPort") %>' CssClass="ms_text" Width="38px" onkeyup="autowords(this.id,event,2);" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Height="28" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                        </Columns>
                        </asp:GridView>--%>
			        
			        
			        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#E8F6FF" id="GridView2">
                      <tr>
                        <td height="28" colspan="11" align="left" bgcolor="#BBDBEA">&nbsp;&nbsp;&nbsp;&nbsp;从EXCEL中复制内容，粘粘在下列行中，快捷方便，赶紧试试！看清格式，别粘错了哦！</td>
                      </tr>
					  <tr>
                        <td height="28" align="center">POD</td>
                        <td align="center">20GP</td>
                        <td align="center">40GP</td>
                        <td align="center">40HQ</td>
                        <td align="center">45HQ</td>
                        <td align="center">surcharge</td>
                        <td align="center">T/T</td>
                        <td align="center">ETD</td>
                        <td align="center">shipowner</td>
                        <td align="center">remark</td>
                        <td align="center">Del</td>
                      </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                        <td height="28" align="center"><input name="textfield435511" type="text" class="ms_text" size="4" value="<%# Eval("DestPort") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" /></td>
                        <td align="center"><input name="textfield4355" type="text" class="ms_text" size="4" value="<%# Eval("price20gp") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43552" type="text" class="ms_text" size="4" value="<%# Eval("price40gp") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43553" type="text" class="ms_text" size="4" value="<%# Eval("price40hq") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43554" type="text" class="ms_text" size="4" value="<%# Eval("price45hq") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43555" type="text" class="ms_text" size="4" value="<%# Eval("price20gpAppend") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43556" type="text" class="ms_text" size="4" value="<%# Eval("Distance") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43557" type="text" class="ms_text" size="4" value="<%# Eval("DepartureWkd") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43558" type="text" class="ms_text" size="4" value="<%# Eval("shipcompany") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="textfield43559" type="text" class="ms_text" size="4" value="<%# Eval("memo") %>" onpaste ="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)"  /></td>
                        <td align="center"><input name="button222" type="button" id="button22" onclick="delRow(this.parentElement.parentElement)" value="del"  /></td>
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                      
					  
					  

                      
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#E8F6FF" >
                    <tr>
                        <td height="28" colspan="11" align="left"><table cellspacing="0" cellpadding="0">
                          <tr>
                            <td><input name="button2" type="button" id="Button5" onclick="addRow(document.getElementById('GridView2'),1)" value="add 1 line"  />
                              &nbsp;&nbsp;</td>
                            <td><input name="button2" type="button" id="Button6" onclick="addRow(document.getElementById('GridView2'),5)" value="add 5 line"  />
                              &nbsp;&nbsp;</td>
                            <td><input name="button2" type="button" id="Button7" onclick="addRow(document.getElementById('GridView2'),10)" value="add 10 line" />
                              &nbsp;&nbsp;</td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="38" colspan="11" align="center"><input name="button22" type="button" id="button8" onclick="bntover()" value="Submit"  />
                        <div style="display:none" >
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                            <input id="hidsubmit" runat="server" type="text" />
                        </div>
                        
                        </td>
                      </tr>
                    </table>
			        </div>
			  </div>
			</div>
		    <div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
