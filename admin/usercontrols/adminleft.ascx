<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminleft.ascx.cs" Inherits="admin_usercontrols_adminleft" %>
<div id="left">
    <div class="leftbox">
	    <span class="tt14 bd txth30">��������Ϣ</span><br/>
	    <span class="bd">allinadmin</span>����ӭ����<br/>
	    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">�˳�</asp:LinkButton>
    </div>
<%--    <div class="leftbox">
	    <span class="tt14 bd txth30">���ͳ��</span><br/>
	    <a href="/admin/countuser.aspx">ע���û�ͳ��</a><br/>
	    <a href="/admin/countpriceline.aspx">�˼�/����ͳ��(�����߷���)</a><br/>
	    <a href="/admin/countpricepol.aspx">�˼�/����ͳ��(�����˸۷���)</a><br/>																			
	    <a href="/admin/countpricepolline.aspx">�˼�/����ͳ��(���˸�-����)</a><br/>	
    </div>--%>
    <div class="leftbox">
	    <span class="tt14 bd txth30">�˼�/���̹���</span><br/>
	    <a href="/admin/pricecount.aspx">�˼�����ͳ��</a><br/>
	    <a href="/admin/fcllist.aspx">�����˼�</a> <a href="/admin/lcllist.aspx">ƴ���˼�</a> <a href="/admin/airlist.aspx">�����˼�</a><br/>
<%--	    <a href="/admin/cargo.aspx">����</a> <br/>	--%>
<%--	    <a href="/admin/freightbillbord.aspx">�˼۷������а�</a><br/>	--%>									
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">�û�����</span><br/>
        <a href="/admin/usercount.aspx">�û�ͳ��</a><br/>
	    <a href="/admin/userlist.aspx">�û�����</a><br/>
	    <a href="/admin/importuserlistalizhike.aspx">Ali����ֱ�͹���</a><br/>
	    <a href="/admin/importuserlistalihuodai.aspx">Ali�����������</a><br/>
<%--	    <a href="/admin/importuserlistalie.aspx">E���򾡹���</a><br/>
	    <a href="/admin/userexport.aspx">�û�����ΪEXCEL���</a><br/>
	    <a href="/admin/sales/mycustomer.aspx">�ҵĿͻ�����</a><br/>
	    <a href="/admin/sales/myprecustomer.aspx">�����ڸ����Ŀͻ�</a><br/>--%>
    </div>
<%--    <div class="leftbox">
	    <span class="tt14 bd txth30">ҳ��ͳ��</span><br/>
	    <a href="/admin/pageareacount.aspx">��������ͳ��</a><br/>
	    <a href="/admin/pagecount.aspx">ҳ�������ͳ��</a><br/>																
	    <a href="/admin/infocount.aspx">ҳ������ͳ��</a><br/>		
    </div>--%>
<%--    <div class="leftbox">
	    <span class="tt14 bd txth30">�����ؼ��ֹ���</span><br/>
	    <a href="/admin/searchwordslist.aspx">�����ؼ��ֹ���</a><br/>
	    <a href="/admin/searchwordscount.aspx">�����ؼ���ͳ��</a><br/>																
    </div>--%>
    <div class="leftbox">
	    <span class="tt14 bd txth30">��Ϣ����</span><br/>
	    <a href="/admin/portlist.aspx">�ۿ����ݿ����</a><br/>	
<%--        <a href="/admin/message/BBSadminList.aspx">BBS����</a><br/>--%>
        <a href="/admin/message/NewList.aspx">������Ѷ����</a><br/>
<%--<a href="/admin/message/En_NewList.aspx">Ӣ��������Ѷ����</a><br/>	    --%>														
        <a href="/admin/message/Setrate.aspx">���ʹ���</a><br/>
<%--        <a href="/admin/link/LinkList.aspx">��������</a><br/>	
		<a href="/admin/titlelist.aspx">��ҳ��Ϣ����</a><br/>	
<a href="/admin/recycleBBSadminList.aspx">��̳����վ</a><br/>
<a href="/admin/bbsEditlist.aspx">��̳����</a><br/>
<a href="/admin/topic/reg0926.aspx">�1����</a><br/>
<a href="/admin/topic/supplier1125.aspx">�2����</a><br/>
<a href="/admin/hotport/list.aspx">���Ÿۿ�</a><br/>
<a href="/admin/productsapply/list.aspx">��Ʒ����</a><br/>
<a href="/admin/question/QuestionList.aspx">�ʴ����</a><br/>--%>
    </div>         
<%--    <div class="leftbox" style="display:none;">
	    <span class="tt14 bd txth30">����</span><br/>
	    <a href="/admin/baf/bafedit.aspx">BAF/CAF�ȸ��ӷѱ༭</a><br/>																		
    </div>--%>
</div>