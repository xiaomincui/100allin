<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useredit1.aspx.cs" Inherits="member_useredit1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改公司照片/头像/签名</title>
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


 
  function   addRow(src,num)
  {   
      for(var k=0;k<num;k++)
      {
          var   newrow   =   src.insertRow();
          newrow.height=25; 
          var   newcell   =   newrow.insertCell();
          newcell.innerHTML=   " <input  type='text' class='ms_text'  style='width:104px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)'  onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="110px"
          var   i=7;   
          while(i--)
          {   
            var   newcell   =   newrow.insertCell();
            newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:59px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
            newcell.width="65px"
          }   
            var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='text' class='ms_text' style='width:59px;' onpaste ='insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' onKeyDown='insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex)' />"
          newcell.width="65px"
          var newcell = newrow.insertCell();
          newcell.innerHTML=   " <input  type='checkbox'  />"
          newcell.width="20px"
          
          
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
  
	</script>
    

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
				
				<div class="main_box">
					<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
    <td width="44%"><strong>修改公司照片/头像/签名 </strong></td>
    <td width="50%" align="right"></td>
  </tr>
</table>
</div>
<div class="fcl" style="padding-left:10px;">
		<P><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td height="28" align="left"><strong>公司照片</strong>：</td>
    <td height="28" align="left">
        <asp:FileUpload ID="FileUpload1" runat="server"  onpropertychange="selectIMG(this)" /></td>
    <td height="28" align="left">
        </td>
    </tr>
    
    
    <tr>
    <td height="28" align="left"><strong>个人头像</strong>：</td>
    <td height="28" align="left">
        <asp:FileUpload ID="FileUpload2" runat="server"  onpropertychange="selectIMG(this)" /></td>
    <td height="28" align="left">
        </td>
    </tr>
    
    
    <tr>
    <td height="28" align="left"><strong>个性签名</strong>：</td>
    <td height="28" align="left">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    <td height="28" align="left">
        </td>
    </tr>
  
	<tr>
    <td height="28" align="left"></td>
    <td height="28" align="left">
        <asp:Button ID="Button8" runat="server" Text="提交修改信息" OnClick="Button8_Click"   />
        </td>
    <td height="28" align="left"></td>
	</tr>
</table>
</P>
</div>
</div>
				
				
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
