<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login_2_edit.aspx.vb" Inherits="member_login_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
    function selectItem(Item)
    {
        if(Item != 0)
        {
            
            selectstr = document.getElementById("HidStrSelect").value.split("$$");
            document.getElementById("Select2").options.length = 0;
            var varItem = new Option("请选择",0 );      
            document.getElementById("Select2").options.add(varItem);
            selectsecondstr = selectstr[Item].split("|");
            for(i = 0;i < selectsecondstr.length - 1;i++)
            {
                var varItem = new Option(selectsecondstr[i],i+1 );      
                document.getElementById("Select2").options.add(varItem);
            }
            
            document.getElementById("Select2").value = 0;
            document.getElementById("hidindex").value = 0;
        }
        else
        {
            document.getElementById("Select2").options.length = 0;
            var varItem = new Option("请选择",0 );      
            document.getElementById("Select2").options.add(varItem);
            document.getElementById("Select2").value = 0;
        }
    }
    
    function tabhangxian(type)
    {
    
        if(type==1)
        {
            document.getElementById("tabship").style.display="";
            document.getElementById("tabair").style.display="none";
            document.getElementById("tabtypetr").style.display="";
        }
        else if(type==2)
        {
            document.getElementById("tabair").style.display="";
            document.getElementById("tabship").style.display="none";
            document.getElementById("tabtypetr").style.display="";
        }
    
    }
    
    function allcheck()
    {
    
        if(document.getElementById("checkall").checked==true)
        {
            document.getElementById("checkfcl").checked=true;
            document.getElementById("checklcl").checked=true;
            document.getElementById("checkair").checked=true;
            
        }
        else
        {
            document.getElementById("checkfcl").checked=false;
            document.getElementById("checklcl").checked=false;
            document.getElementById("checkair").checked=false;
            
        }
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->	
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
			您现在的位置:<a href="/" target="_blank">首页</a> > 注册</h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
			  <table width="90%" height="575" border="0" align="center" cellpadding="0" cellspacing="1">
			  	  <tr>
    <td height="10" colspan="3" align="center"></td>
    </tr>
				<tr>
    <td height="50" colspan="3" align="left" bgcolor="#556988"><table width="100%" border="0" cellspacing="6" cellpadding="0">
      <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/fcl/jt4.gif" width="8" height="8" /><span class="orange"><strong>恭喜您！Naturedeng</strong></span><span class="writ"> 您已经成功注册成为环球运费网会员！您选择的公司类型为“</span><span class="orange"><strong>货代</strong></span><span class="writ">”，我们为您提供了商铺服务来帮助您获得成交。现在您的商铺资料为空白状态，这可能将给您的意向客户造成虚假感受或无法对您产生信任，并将严重影响您的询价量，建议您马上补充！</span></td>
      </tr>
    </table></td>
    </tr>
	  <tr>
    <td height="10" colspan="3" align="center"></td>
    </tr>
  <tr>
    <td width="28%" height="32" align="left"><strong class="orange">&nbsp;&nbsp;注册第二步</strong></td>
    <td colspan="2">&nbsp;</td>
    </tr>
	  <tr>
    <td height="1" colspan="3" align="center" bgcolor="#999999"></td>
    </tr>
  <tr>
    <td height="10" colspan="3" align="center"></td>
    </tr>
  <tr>
    <td height="32" align="right" bgcolor="#F2F2F2"><strong>您的公司信息</strong></td>
    <td colspan="2" bgcolor="#F2F2F2">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" style="height: 38px"><span class="red">*</span>&nbsp;选择经营类型</td>
    <td style="height: 38px; width: 246px;">
      <asp:CheckBox ID="checkall" runat="server" />全部
      <asp:CheckBox ID="checkfcl" runat="server" />整箱
      <asp:CheckBox ID="checklcl" runat="server" />拼箱
      <asp:CheckBox ID="checkair" runat="server" />空运
       
    </td>
    <td style="height: 38px">&nbsp;</td>
  </tr>
  <tr>
    <td height="32" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;公司注册资金:</td>
    <td bgcolor="#FAFAFA" style="width: 246px"><asp:TextBox ID="TextBox1" runat="server" Width="209px"></asp:TextBox>
    </td>
    <td bgcolor="#FAFAFA">&nbsp;</td>
  </tr>
  <tr>
    <td height="32" align="right"><span class="red">*</span>&nbsp;公司成立时间</td>
    <td style="width: 246px">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="1990">1990以前</asp:ListItem>
            <asp:ListItem>1991</asp:ListItem>
            <asp:ListItem>1992</asp:ListItem>
            <asp:ListItem>1993</asp:ListItem>
            <asp:ListItem>1994</asp:ListItem>
            <asp:ListItem>1995</asp:ListItem>
            <asp:ListItem>1996</asp:ListItem>
            <asp:ListItem>1997</asp:ListItem>
            <asp:ListItem>1998</asp:ListItem>
            <asp:ListItem>1999</asp:ListItem>
            <asp:ListItem>2000</asp:ListItem>
            <asp:ListItem>2001</asp:ListItem>
            <asp:ListItem>2002</asp:ListItem>
            <asp:ListItem>2003</asp:ListItem>
            <asp:ListItem>2004</asp:ListItem>
            <asp:ListItem>2005</asp:ListItem>
            <asp:ListItem>2006</asp:ListItem>
            <asp:ListItem>2007</asp:ListItem>
            <asp:ListItem>2008</asp:ListItem>
            <asp:ListItem>2009</asp:ListItem>
        </asp:DropDownList></td>
    <td>&nbsp;</td>
  </tr>
                  <tr>
                      <td align="right" bgcolor="#fafafa" style="height: 32px" >
                      <span class="red">*</span>&nbsp;选择公司所在地
                      </td>
                      <td colspan="2" bgcolor="#fafafa" style="height: 44px; ">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity2" runat="server" AutoPostBack="True" Width="100px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity3" runat="server" AutoPostBack="True" Width="100px" Visible="False">
                        </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                      </td>
                      
                  </tr>
  <%--<tr>
    <td height="32" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;选择公司所在地</td>
    <td bgcolor="#FAFAFA">
    <select id="Select1" style="width: 105px; height: 150px" runat="server" onchange="selectItem(this.value)">
    <option value="0" selected="selected">请选择</option>
    </select>
    <select id="Select2" style="width: 105px; height: 150px" runat="server" onchange="document.getElementById('hidindex').value=this.value">
    <option value="0" selected="selected">请选择</option>
    </select>
        <input id="HidStrSelect" runat="server" style="width: 1px" type="hidden" />
        <input id="hidindex" runat="server" type="hidden" style="width: 1px" />
        </td>
    <td bgcolor="#FAFAFA">&nbsp;</td>
  </tr>--%>
  <tr id="tabtypetr" >
    <td height="32" align="right"><span class="red">*</span>&nbsp;选择优势航线</td>
    <td  colspan="2" >
       <table id="tabship" width="250" border="0" cellspacing="1" cellpadding="0" >
       <tr>
           <td width="50%">海运</td>
           <td width="50%">空运</td>
       </tr>
       <tr>
        <td><input id="chk_ship_Caribbean" type="checkbox" name="checkbox523" value="美加" runat="server" />美加</td>
        <td><input id="chk_air_North_America" type="checkbox" name="checkbox52" value="北美" runat="server" />北美</td>
      </tr>
      <tr>
        <td><input id="chk_ship_Europe" type="checkbox" name="checkbox52" value="欧地" runat="server" />欧地</td>
        <td><input id="chk_air_Europe" type="checkbox" name="checkbox53" value="欧洲" runat="server" />欧洲</td>
      </tr>
      <tr>
        <td><input id="chk_ship_SOUTH_AMERICA" type="checkbox" name="checkbox53" value="中南美" runat="server" />中南美</td>
        <td><input id="chk_air_poncho" type="checkbox" name="checkbox522" value="南美" runat="server" />南美</td>
      </tr>
      <tr>
        <td><input id="chk_ship_Japan_Korea" type="checkbox" name="checkbox525" value="日韩" runat="server" />日韩</td>
        <td><input id="chk_air_Asia" type="checkbox" name="checkbox523" value="亚洲" runat="server" />亚洲</td>
      </tr>
      <tr>
        <td><input id="chk_ship_offing" type="checkbox" name="checkbox524" value="近洋" runat="server" />近洋</td>
        <td><input id="chk_air_Africa" type="checkbox" name="checkbox524" value="非洲" runat="server" />非洲</td>
      </tr>
      <tr>
        <td><input id="chk_ship_Africa" type="checkbox" name="checkbox528" value="非洲" runat="server" />非洲</td>
        <td><input id="chk_air_Australia" type="checkbox" name="checkbox525" value="澳洲" runat="server" />澳洲</td>
      </tr>
      <tr>
        <td><input id="chk_ship_Australia" type="checkbox" name="checkbox522" value="澳洲" runat="server" />澳洲</td>
        <td><input id="chk_air_internal" type="checkbox" name="checkbox528" value="国内" runat="server" />国内</td>
      </tr>
      <tr>
        <td><input id="chk_ship_CIMEX" type="checkbox" name="checkbox526" value="中东印巴" runat="server" />中东印巴</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td><input id="chk_ship_Red_Sea" type="checkbox" name="checkbox527" value="红海" runat="server" />红海</td>
        <td>&nbsp;</td>
      </tr>
       

    </table>
    

    
    </td>
    </tr>
  <tr>
    <td height="32" align="right" valign="top">优势船公司</td>
    <td colspan="2">
    <table id="Table1" width="250" border="0" cellspacing="1" cellpadding="0" >
      <tr>
        <td width="50%"><input id="chkMSK" type="checkbox" name="chkMSK" value="马士基(MSK)" runat="server" />
          马士基(MSK)</td>
        <td width="50%"><input id="chkMSC" type="checkbox" name="checkbox53" value="地中海(MSC)" runat="server" />
          地中海(MSC)</td>
      </tr>
      <tr>
        <td><input id="chkEMC" type="checkbox" name="checkbox522" value="长荣(EMC)" runat="server" />
          长荣(EMC)</td>
        <td><input id="chkPIL" type="checkbox" name="checkbox523" value="太平(PIL)" runat="server" />
          太平(PIL)</td>
      </tr>
      <tr>
        <td><input id="chkCSCL" type="checkbox" name="checkbox524" value="中海(CSCL)" runat="server" />
          中海(CSCL)</td>
        <td><input id="chkOOCL" type="checkbox" name="checkbox525" value="东方海外(OOCL)" runat="server" />
          东方海外(OOCL)</td>
      </tr>
      <tr>
        <td><input id="chkCMA" type="checkbox" name="checkbox526" value="达飞(CMA)" runat="server" />          
          达飞(CMA)</td>
        <td><input id="chkCOSCO" type="checkbox" name="checkbox527" value="中远(COSCO)" runat="server" />
          中远(COSCO)</td>
      </tr>
      <tr>
        <td><input id="chkHANJIN" type="checkbox" name="checkbox528" value="韩进(HANJIN)" runat="server" />          
          韩进(HANJIN)</td>
        <td><input id="chkZIM" type="checkbox" name="checkbox528" value="以星(ZIM)" runat="server" />          
          以星(ZIM)</td>
      </tr>
      <tr>
        <td><input id="chkWANHAI" type="checkbox" name="checkbox528" value="万海(WANHAI)" runat="server" />          
          万海(WANHAI)</td>
        <td><input id="chkYML" type="checkbox" name="checkbox528" value="阳明(YML)" runat="server" />          
          阳明(YML)</td>
      </tr>
      <tr>
        <td colspan="2">其他：<asp:TextBox ID="othershipper" runat="server"></asp:TextBox></td>
        
      </tr>

    </table>
    
    </td>
    </tr>
  <tr>
    <td height="32" align="right" bgcolor="#FAFAFA">特色服务</td>
    <td colspan="2" bgcolor="#FAFAFA"><input name="Username9" type="text" id="Username9" size="30" runat="server" />
      <img src="images/login/wh.gif" width="14" height="14" />&nbsp;怎么填写查看标准格式</td>
    </tr>
  <tr>
    <td height="32" align="right" valign="top">荣誉资质</td>
    <td colspan="2"><table width="100%" border="0" cellspacing="1" cellpadding="0">
      <tr>
        <td width="49%"><textarea name="textarea2" cols="40" rows="5" id="TEXTAREA1" runat="server"></textarea></td>
        <td width="51%" valign="top">&nbsp;<img src="images/login/wh.gif" width="14" height="14" />&nbsp;怎么填写查看标准格式</td>
      </tr>
    </table></td>
    </tr>
  <tr>
    <td height="32" align="right" bgcolor="#FAFAFA">服务承诺</td>
    <td colspan="2" bgcolor="#FAFAFA"><input name="Username11" type="text" id="Username11" size="30" runat="server" />
      <img src="images/login/wh.gif" width="14" height="14" />&nbsp;怎么填写查看标准格式</td>
    </tr>
                  <tr>
                      <td align="right" bgcolor="#fafafa" height="32">
                          图片</td>
                      <td bgcolor="#fafafa" colspan="2">
                          <asp:FileUpload ID="FileUpload1" runat="server" />（上传代表您公司图片，大小256×256为宜）</td>
                  </tr>
  <tr>
    <td height="10" colspan="3" align="right">
<img src="/images/shops/gs.gif" onerror="this.style.display = 'none'"  alt="展示公司图片" id="imgcompanyhead" runat="server" width="256" height="256" />    
    </td>
    </tr>
  <tr>
    <td height="32" align="right">&nbsp;</td>
    <td colspan="2">    
        <asp:Button ID="Button2" runat="server" Text="提交" />&nbsp;&nbsp;
        <input onclick="checkAll();return false; __doPostBack('Button1','')" name="Button12" id="Button12" value="取消" type="button" /></td>
    </tr>
  <tr>
    <td height="10" colspan="3" align="right"></td>
    </tr>
</table>
</div>
		</div>
	  <div class="foot"><strong>友情链接</strong>：<a href="#" target="_blank">中国航贸网</a> 递四方速递 青岛物流网 中国物流招聘网 中国物流联合网 进口交流论坛 便易精品服饰网 中国软启动网 重型物流行业网 物流网 08中国商机网 
          <br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;物流招聘网 快递查询网 猎头学院 城市通 现代物流专线网 泛珠三角物流网 上海租车 MAX56物流网 中国物流人才招聘网 制造资源网 中国货架网 网络114	  </div>
	   <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
