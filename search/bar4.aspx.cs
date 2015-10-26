using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class search_bar4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 定义"搜索"按钮改变颜色的事件
        ImageButton1.Attributes.Add("onmouseover", "this.src='../images/search3_s.gif'");
        ImageButton1.Attributes.Add("onmouseout", "this.src='../images/search3.gif'");
        ImageButton1.Attributes.Add("onfocus", "this.src='../images/search3_s.gif'");
        ImageButton1.Attributes.Add("onblur", "this.src='../images/search3.gif'");

        ImageButton12.Attributes.Add("onmouseover", "this.src='../images/search3_s.gif'");
        ImageButton12.Attributes.Add("onmouseout", "this.src='../images/search3.gif'");
        ImageButton12.Attributes.Add("onfocus", "this.src='../images/search3_s.gif'");
        ImageButton12.Attributes.Add("onblur", "this.src='../images/search3.gif'");

        ImageButton13.Attributes.Add("onmouseover", "this.src='../images/search3_s.gif'");
        ImageButton13.Attributes.Add("onmouseout", "this.src='../images/search3.gif'");
        ImageButton13.Attributes.Add("onfocus", "this.src='../images/search3_s.gif'");
        ImageButton13.Attributes.Add("onblur", "this.src='../images/search3.gif'");

        ImageButton1.Attributes.Add("onclick", "document.getElementById('form1').target = '_blank';");
        ImageButton12.Attributes.Add("onclick", "document.getElementById('form1').target = '_blank';");
        ImageButton13.Attributes.Add("onclick", "document.getElementById('form1').target = '_blank';");

        //定义所有输入框按回车跳到下一格

        txtLine.Attributes.Add("onkeydown", "KeyDown(event);");
        txtStartport.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport.Attributes.Add("onkeydown", "KeyDown(event);");
        txtLine2.Attributes.Add("onkeydown", "KeyDown(event);");
        txtStartport2.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport2.Attributes.Add("onkeydown", "KeyDown(event);");
        txtLine3.Attributes.Add("onkeydown", "KeyDown(event);");
        txtStartport3.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport3.Attributes.Add("onkeydown", "KeyDown(event);");
    }
}
