//TabStrip切换
function dytabstrip(c1,c2){
	var dh = this;
	//定义TabStrip标签内容对象
	this.tabobj = [];
	//定义当前标签索引；
	this.nowindex = null;
	//定义自动展示变量
	this.autoid = null;
	this.startindex = 0;
	this.timeset = 3000;
	//添加标签及内容
	this.addtab = function(tab,content){
		this.tabobj[this.tabobj.length] = {"tab":tab,"content":content};
	}
	//展示指定索引的标签内容
	this.showtab = function(index){
		if(isNaN(index) || index<=0 || index>=this.tabobj.length){
			index = 0;
		}
		if(this.tabobj.length>0){
			this.tabobj[index].tab.className = c1;
			this.tabobj[index].content.style.display = "block";
			if(this.nowindex != null && index != this.nowindex){
				this.tabobj[this.nowindex].tab.className = c2;
				this.tabobj[this.nowindex].content.style.display = "none"; 
			}
			this.nowindex = index;
			this.startindex = index;
		}
	}
	//自动展示
	this.autoshow = function(){
		if(this.startindex>=this.tabobj.length){
			this.startindex = 0;
		}
		this.showtab(this.startindex);
		this.startindex += 1;
		this.autoid = window.setTimeout(function(){dh.autoshow()},this.timeset)
	}
	//清除自动展示
	this.clearautoshow = function(){
		window.clearTimeout(this.autoid);
	}
}

var dyts3 = new dytabstrip("current","notcurrent");
dyts3.addtab(document.getElementById("csbsp01"),document.getElementById("csb01"));
dyts3.addtab(document.getElementById("csbsp02"),document.getElementById("csb02"));
dyts3.addtab(document.getElementById("csbsp03"),document.getElementById("csb03"));
dyts3.autoshow();