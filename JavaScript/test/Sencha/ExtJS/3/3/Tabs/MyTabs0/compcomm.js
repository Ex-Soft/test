// vim: sw=4:ts=4:nu:nospell:fdc=4
/*global Ext, Example */
/**
 * Components Communication Example Application
 *
 * @author    Ing. Jozef Sakáloš
 * @copyright (c) 2008, by Ing. Jozef Sakáloš
 * @date      10. April 2008
 * @version   $Id: compcomm.js 138 2009-03-20 21:22:35Z jozo $
 *
 * @license compcomm.js is licensed under the terms of the Open Source
 * LGPL 3.0 license. Commercial use is permitted to the extent that the 
 * code/component(s) do NOT become part of another Open Source or Commercially
 * licensed development library or toolkit without explicit permission.
 * 
 * License details: http://www.gnu.org/licenses/lgpl.html
 */
 
Ext.ns('Example');

// {{{
Example.LinksPanel = Ext.extend(Ext.Panel, {
 
    // configurables
     border:false
	,cls:'link-panel'
	,links:[{
		 text:'Link 1'
		,href:'#'
	},{
		 text:'Link 2'
		,href:'#'
	},{
		 text:'Link 3'
		,href:'#'
	}]
	,layout:'fit'
	,tpl:new Ext.XTemplate('<tpl for="links"><a class="examplelink" href="{href}">{text}</a></tpl>')

    // {{{
    ,afterRender:function() {
 
        // call parent
        Example.LinksPanel.superclass.afterRender.apply(this, arguments);
 
		// create links
		this.tpl.overwrite(this.body, {links:this.links});
 
    } // e/o function afterRender
    // }}}
 
}); // e/o extend
 
// register xtype
Ext.reg('linkspanel', Example.LinksPanel);
// }}}
// {{{
Example.Window = Ext.extend(Ext.Window, {
 
    // configurables
    // anything what is here can be configured from outside
    layout:'border'
 
    // {{{
    ,initComponent:function() {
        
		// hard coded config - cannot be changed from outside
		var config = {
			items:[{
				 xtype:'linkspanel'
				,region:'west'
				,width:200
				,collapsible:true
				,collapseMode:'mini'
				,split:true
			},{
				 xtype:'tabpanel'
				,region:'center'
				,border:false
				,activeItem:0
				,tabPosition: 'bottom'
				,items:[{
					title:'A tab'
				}]
			}]
		};

		// apply config
        Ext.apply(this, Ext.apply(this.initialConfig, config));

        // call parent
        Example.Window.superclass.initComponent.apply(this, arguments);
 
		this.linksPanel = this.items.itemAt(0);
		this.tabPanel = this.items.itemAt(1);

		this.linksPanel.on({
			 scope:this
			,render:function() {
				this.linksPanel.body.on({
					 scope:this
					,click:this.onLinkClick
					,delegate:'a.examplelink'
					,stopEvent:true
				});
			}
		});
    } // e/o function initComponent
    // }}}
	 // {{{
	,onLinkClick:function(e, t) {
		var title = t.innerHTML;
		var tab = this.tabPanel.items.find(function(i){return i.title === title;});
		if(!tab) {
			tab = this.tabPanel.add({
				 title:title
				,layout:'fit'
			});
		}
		this.tabPanel.setActiveTab(tab);

	} // eo function onLinkClick
	// }}}

}); // e/o extend
 
// register xtype
Ext.reg('examplewindow', Example.Window);
// }}}
 
Ext.BLANK_IMAGE_URL = './ext/resources/images/default/s.gif';
 
// application main entry point
Ext.onReady(function() {
 
    Ext.QuickTips.init();
 
    // create and show window
	var win = new Example.Window({
		 width:600
		,height:400
		,closable:false
		,title:Ext.fly('page-title').dom.innerHTML
	});
	win.show();
 
}); // eo function onReady
 
// eof
