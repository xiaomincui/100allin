<%@ Control Language="C#" AutoEventWireup="true" CodeFile="headmid120150520.ascx.cs" Inherits="usercontrols_headmid120150520" %>
<div class="header-mid">
			<div class="header-mid-left"><a href="/"><img src="/images2015/logo.gif" alt="环球运费网"></a></div>
			<div class="header-mid-right">
					<div id="tab">
						<ul class="tab-menu">
							<li <%=((Request.Url.ToString().ToLower().IndexOf("lcl") != -1) || (Request.Url.ToString().ToLower().IndexOf("air") != -1) || (Request.Url.ToString().ToLower().IndexOf("company") != -1))?"":" class=\"selected\""%>>整箱海运价</li>
							<li <%=(Request.Url.ToString().ToLower().IndexOf("lcl") != -1)?" class=\"selected\"":""%>>拼箱海运价</li>
							<li <%=(Request.Url.ToString().ToLower().IndexOf("air") != -1)?" class=\"selected\"":""%>>空运运价</li>
							<li <%=(Request.Url.ToString().ToLower().IndexOf("company") != -1)?" class=\"selected\"":""%>>公司库</li>																		
						</ul>
						<div class="tab-box">
                            <div <%=((Request.Url.ToString().ToLower().IndexOf("lcl") != -1) || (Request.Url.ToString().ToLower().IndexOf("air") != -1) || (Request.Url.ToString().ToLower().IndexOf("company") != -1))?" class=\"hide\"":""%>>
                                    <div class="tab-box-input">
                                        <label><span>请输入起运港</span><input type="text" id="txtStartport" sou_type="start_port" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                        <span>至</span>
                                        <label><span>请输入目的港</span><input type="text" id="txtDestport" sou_type="end_port" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                        <span>由</span>
                                        <label><span>请输入船公司</span><input type="text" id="txtCarrier" sou_type="ship_com" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                        <span>承运</span>
                                    </div>
                                    <div class="tab-box-submit">
                                        <input type="button" value="" class="search-btn" id="fcl-submit"/>
                                    </div>				
                            </div>
                            <div <%=((Request.Url.ToString().ToLower().IndexOf("lcl") != -1))?"":" class=\"hide\""%>>
                                    <div class="tab-box-input">
                                        <label><span>请输入起运港</span><input type="text" id="txtStartport2" sou_type="start_port" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                        <span>至</span>
                                        <label><span>请输入目的港</span><input type="text" id="txtDestport2" sou_type="end_port" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                    </div>
                                    <div class="tab-box-submit">
                                        <input type="button" value="" class="search-btn"  id="lcl-submit"/>
                                    </div>                  
                            </div>
                            <div <%=((Request.Url.ToString().ToLower().IndexOf("air") != -1))?"":" class=\"hide\""%>>
                                    <div class="tab-box-input">
                                        <label><span>请输入起运地</span><input type="text" id="txtStartport3" sou_type="air_start" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                        <span>至</span>
                                        <label><span>请输入目的地</span><input type="text" id="txtDestport3" sou_type="air_port" onfocus="auto_init(event,this);" class="input-txt"/></label>
                                    </div>
                                    <div class="tab-box-submit">
                                        <input type="button" value="" class="search-btn"  id="air-submit"/>
                                    </div>
                            </div>
                            <div <%=((Request.Url.ToString().ToLower().IndexOf("company") != -1))?"":" class=\"hide\""%>>
                                    <div class="tab-box-input">
                                        <label><span>请输入公司名称</span><input type="text" id="txtCompanyName"  class="input-txt"/></label>
                                    </div>
                                    <div class="tab-box-submit">
                                        <input type="button" value="" class="search-btn"  id="company-submit"/>
                                    </div>                            
                            </div>
						</div>
					</div>
			</div>
		</div>