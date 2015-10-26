<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userservice.ascx.cs" Inherits="usercontrols_userservice" %>
<script type="text/javascript" language="javascript">

function kf()
{
    
    if (document.getElementById("kfk").style.visibility=="hidden")
    {
        document.getElementById("kfk").style.visibility="visible";
        kfk.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop+10)+"px";
        kfk.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft-400)+"px";
    }
    else
    {
        hiddenkfk()
    }
　　

}
function hiddenkfk()
{
        
    document.getElementById('kfk').style.visibility='hidden';
    
}
</script>

	<span class="right_tn"><img src="/images/fcl/lian.GIF" />&nbsp;<a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a></span>

		    <div class="online_box" style="position:absolute; background:#FFFFFF; border:1px solid #999999; visibility:hidden;" id="kfk">
			    <fieldset style="border-top: 1px solid #ccc; padding-bottom:0px; border-bottom:none;border-left:none;border-right:none;"><legend style="color:#FF6600; font-weight: bold; font-size: 14px; "><img style="vertical-align:middle;" src="/images/index/kf.jpg"/>&nbsp;在线客服</legend>
			    </fieldset>
		      <div class="online_box_title">您好！这里是环球运费网服务中心！请问有什么能帮到您。<br />
		        <table>
		            <tr>
		                <td>
		                您的姓名：
		                </td>
		                <td>
		                 <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
		                </td>    
		                <td>
		                您的公司：
		                </td>
		                <td>
		                 <asp:TextBox ID="TextBox3" runat="server" Width="90px"></asp:TextBox>
		                </td>      		                            
		            </tr>
		            <tr>
		                <td>
		                您的电话：
		                </td>
		                <td>
		                 <asp:TextBox ID="TextBox4" runat="server" Width="80px"></asp:TextBox>
		                </td>		
		                <td>
		                您的Email：
		                </td>
		                <td>
		                 <asp:TextBox ID="TextBox2" runat="server" Width="90px"></asp:TextBox>
		                </td>			                                
		            </tr>		            
		        </table>
		            您想对客服说什么？
                  <textarea name="textarea" cols="38" style="height:85px" id="TEXTAREA1" runat="server"></textarea>
			      <br />
                      <div style="padding:15px 0px 0px 100px;"> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/login/botton2.jpg" OnClick="ImageButton1_Click" /></div></div>
			    <div class="online_box_bot">
			    <img src="/images/login/tel.gif" />&nbsp;客服电话：400-888-9256&nbsp;<img src="/images/login/email.gif" width="16" height="16" />&nbsp;e-mail：<a href="#">allin@100allin.com</a> </div>
		    </div>

