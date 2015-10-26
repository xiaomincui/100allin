function initEcAd(layerName1) { 
	eval("document.all."+layerName1+".style.posTop = -200"); 
	eval("document.all."+layerName1+".style.visibility = 'hidden'"); 
	MoveRightLayer(layerName1); 
}
function checkclient(layerName1){ 	
	if (document.body.clientWidth>100){	
		eval("document.all."+layerName1+".style.visibility='visible'"); 
	} 
} 
 
function MoveRightLayer(layerName) { 
	var x = 5; var y = 100; 
	var top = eval("document.all."+layerName+".style.posTop"); 
	var diff = (document.documentElement.scrollTop + y - top)*.40; 
	var y = document.documentElement.scrollTop + y - diff; 
	eval("document.all." + layerName + ".style.posTop = y"); 
	eval("document.all." + layerName + ".style.posRight = x"); 
	setTimeout("MoveRightLayer('"+layerName+"');", 10); 
} 

initEcAd('index_couplet_right');
checkclient('index_couplet_right');