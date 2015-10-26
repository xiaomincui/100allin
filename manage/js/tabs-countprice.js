/*
 * Ext JS Library 2.1
 * Copyright(c) 2006-2008, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */

Ext.onReady(function(){
    // basic tabs 1, built from existing content
    var tabs = new Ext.TabPanel({
        renderTo: 'tabs1',
        width:780,
        activeTab: 0,
        frame:true,
		plain:true,
        defaults:{autoHeight: true},
        items:[
            {contentEl:'markup', title: '所有运价/货盘'},
            {contentEl:'now', title: '有效运价/货盘'},
            {contentEl:'script', title: '今日运价/货盘'},
            {contentEl:'yest', title: '昨日运价/货盘'}
        ]
    });

});