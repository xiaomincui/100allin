var DWMsg={
//容器id 參數不正確(容器id設置錯誤！\n請檢查)
d1:"\u5bb9\u5668id\u8a2d\u7f6e\u932f\u8aa4\uff01\n\u8acb\u6aa2\u67e5"
}
function down_windows()
{
	this.winID = arguments[0];
	if(!this.winID){alert(DWMsg.d1); return;}
	
	var self = this;
	self.win = document.getElementById(self.winID);
	
	this.show=function(){
		self.win.style.position = "absolute";
	    self.win.style.zIndex = "40";
	    
	    if(d_win.Iscookie==true){
	    	if(Cookie.get("DWSum2")!==null){
	    		var cookie_sum =Cookie.get("DWSum2");
	    		if(cookie_sum<self.showsum){
	    			cookie_sum++;
					self.win.style.display="block";
	    			self.timer=setInterval(self._onScroll, 10);
					
	    		}
	    	}else{
				self.win.style.display="block";
		    	self.timer=setInterval(self._onScroll, 10);
	    	}
	    }else{
			self.win.style.display="block";
	    	self.timer=setInterval(self._onScroll, 10);
	    }
	}
	this.close=function(){
		if(d_win.Iscookie==true){	    
			var cookie_sum =0;	
	    	if(Cookie.get("DWSum2")!==null){
	    		cookie_sum=Cookie.get("DWSum2");
	    		cookie_sum++;
	    	}else{
		    	cookie_sum =1;
	    	}
	    	var cookie_days=30;//30天 cookie失效
	    	var cookietime = new Date((new Date()).getTime() + (cookie_days*60*60*1000));
	    	Cookie.set("DWSum2",cookie_sum,cookietime);
	    	clearInterval(self.timer);
			self.win.style.display="none";
			//document.getElementById("msg").innerHTML +="第 "+Cookie.get("DWSum2")+" 次被关闭！<br/>";
	    }else{
	    	clearInterval(self.timer);
			self.win.style.display="none";
	    }

		
	}
	this._onScroll=function(){
		var st = DW_croll().scrollTop;
	    var sl = DW_croll().scrollLeft;
	    var ch = document.documentElement.clientHeight;
	    var cw = document.documentElement.clientWidth;
	    var w = parseInt(self.win.offsetWidth, 10);
	    var h = parseInt(self.win.offsetHeight, 10);
	    var offsetLeft = sl + (cw - w);
	    var offsetTop = st + (ch - h);
	    self.win.style.left = offsetLeft + "px";
	    self.win.style.top = offsetTop + "px";
	}
}

function DW_croll() {
    if (document.body.scrollTop != 0) {
        return { scrollLeft: document.body.scrollLeft,
            scrollTop: document.body.scrollTop
        };
    }
    else {
        return { scrollLeft: document.documentElement.scrollLeft,
            scrollTop: document.documentElement.scrollTop
        };
    }
}

var Cookie = {
    set: function(name, value, expires, path, domain, secure) {
        document.cookie = name + "=" + escape(value) +
   ((expires) ? "; expires=" + expires.toGMTString() : "") +
   ((path) ? "; path=" + path : "") +
   ((domain) ? "; domain=" + domain : "") +
   ((secure) ? "; secure" : "");
    },
    get: function(name) {
        var dc = document.cookie;
        var prefix = name + "=";
        var begin = dc.indexOf("; " + prefix);
        if (begin == -1) {
            begin = dc.indexOf(prefix);
            if (begin != 0) return null;
        } else {
            begin += 2;
        }
        var end = document.cookie.indexOf(";", begin);
        if (end == -1) {
            end = dc.length;
        }
        return unescape(dc.substring(begin + prefix.length, end));
    },
    remove: function(name) {
        var expires = new Date();
        var names = name.split('|');
        for (var i = 0; i < names.length; i++) {
            this.set(names[i], "", expires);
        }
    },
    clear: function() {
        if (document.cookie == "") return;
        var arr = document.cookie.split("; ");
        if (arr.length) {
            var ar;
            for (var i = 0; i < arr.length; i++) {
                ar = arr[i].split("=");
                if (ar.length) {
                    this.remove(ar[0]);
                }
            }
        }
    }
}