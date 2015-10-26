<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="report.aspx.vb" Inherits="member_report" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding-top:15px; padding-bottom:10px;">
    <table>
        <tr>
            <td><img src="../images/reg/gif_45_026.gif" /></td>
            <td><div style="font-size:16px; font-weight:bold;">预测报告</div></td>
        </tr>
    </table>
</div>

<div style="line-height:20px; margin:0px 10px 10px 15px;  ">
    <div style=" font-size:14px; font-weight:bold; padding-top:10px;">请您在下面的框中填入您的Email地址，我们将把预测报告发送至您填写的Email地址处。</div>
    <div style=" font-size:12px; color:#666666;padding-bottom:5px; ">注：确保您的Email地址安全有效</div>
    <input type="text" style="width:650px;"></input>&nbsp&nbsp<input type="submit" name="Submit" value="提交" />&nbsp<input type="reset" name="Submit" value="清空" />
</div>
</asp:Content>

