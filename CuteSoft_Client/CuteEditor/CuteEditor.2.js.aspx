<%@ Page Language="C#" ContentType="text/javascript" Inherits="CuteEditor.EditorUtilityPageWithCache" %>
//<script>


var OxOc59f=["[[_setting_]]","[[_CuteEditorResource_]]","\x26[[DNN_Arg]]","document"]; function CuteEditor_IE_Initialize(editorid,hiddenid,frameid){var element=document.getElementById(editorid); CuteEditor_IE_Initialize2(element,element) ;}  ; function CuteEditor_IE_Initialize2(element,editor){var htcmode=false;var _setting_=OxOc59f[0x0];var _CuteEditorResource_=OxOc59f[0x1];var colorpickerurl='<%=ProcessWebPath("ColorPicker.Aspx")%>?culture=[[_culture_]]'+OxOc59f[0x2];
<!-- #include file="CuteEditor.htc.aspx.txt" -->

;
<!-- #include file="_shared.js" -->

;
<!-- #include file="_sharedie.js" -->

;
<!-- #include file="CuteEditor.htc.initialize.htm" -->

;
<!-- #include file="CuteEditor.htc.utility.htm" -->

;
<!-- #include file="CuteEditor.htc.properties.htm" -->

;
<!-- #include file="CuteEditor.htc.editordot.htm" -->

;
<!-- #include file="CuteEditor.htc.editordotcmd.htm" -->

;
<!-- #include file="CuteEditor.htc.commands.htm" -->

;
<!-- #include file="CuteEditor.htc.docevents.htm" -->

;
<!-- #include file="CuteEditor.htc.menulib.htm" -->

;
<!-- #include file="CuteEditor.htc.ctxmenu.htm" -->

; TestFrameReady() ; function TestFrameReady(){if(editor[OxOc59f[0x3]].getElementById(editor._FrameID)){ StartInitialize() ;} else { setTimeout(TestFrameReady,0xa) ;} ;}  ;}  ;