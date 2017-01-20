Ext.onReady(function() {
	var
		store = Ext.create("Ext.data.TreeStore", {
			root: {
				text: "root",
				id: "root",
				expanded: true,
				children: [{
					text: "Child 1",
					data: "Child 1 additional data",
					children: [{
						text: "Child 1 Subchild 1",
						data: "Some additional data of Child 1 Subchild 1",
						leaf: true
					},{
						text: "Child 1 Subchild 2",
						data: "Some additional data of Child 1 Subchild 2",
						leaf: true
					}]
				},{
					text: "Child 2",
					leaf:true,
					data: "Last but not least. Data of Child 2"
				}]
			}
		}),
		tree = Ext.create("Ext.tree.Panel", {
			region: "west",
			title: "Tree",
			layout: "fit",
			width: 300,
			store: store,
			split: true,
			collapsible: true,
			autoScroll: true,
			border: false,
			viewConfig: {
				plugins: {
					ptype: "treeviewdragdrop",
					//allowContainerDrop: false,
					//allowParentInsert: false,
					enableDrop: false,
					dragGroup: "tree2div",
					listeners: {
						beforedrop: function(node, data, overModel, dropPosition, dropFunction, eOpts) {
							if(window.console && console.log)
								console.log("Ext.tree.plugin.TreeViewDragDrop.beforedrop(%o)", arguments);
						},
						drop: function(node, data, overModel, dropPosition, eOpts) {
							if(window.console && console.log)
								console.log("Ext.tree.plugin.TreeViewDragDrop.drop(%o)", arguments);						}
					}
				}
			},
			listeners: {
				itemclick: function(view, record, item, index, e, eOpts) {
					if(window.console && console.log)
						console.log("Ext.tree.Panel.itemclick(%o)", arguments);
				}
			}
		}),
		panel = Ext.create("Ext.panel.Panel", {
			region: "center",
			title: "Drop Target",
			html: "<div class=\"drop-target\" "
				+ "style=\"border: 1px silver solid; margin: 20px; padding: 8px; height: 140px\">"
				+ "<div>Drop a node here. I\'m the DropTarget.</div></div>",
			border: false,
			listeners: {
				afterrender: function() {
					var
						dropTarget = this.body.child("div.drop-target");

					if(dropTarget)
					{

						var
							alreadyExists = function(target, data) {
								var
									//text = dd.dragData.records[0].get("text"),
									text = data.records[0].get("text"),
									el = Ext.fly(target),
									exists = el.select(".appended");

								return Ext.Array.some(exists.elements, function(item, index, allItems) {
											return item.innerHTML == text;
									});

							},
							dropZone = Ext.create("Ext.dd.DropZone", dropTarget, {
								ddGroup: "tree2div",

								getTargetFromEvent: function(e) {
									if(window.console && console.log)
										console.log("getTargetFromEvent()");

									return e.getTarget("div.drop-target");
								},

								notifyEnter: function(ddSource, e, data) {
									if(window.console && console.log)
										console.log("notifyEnter(%o)", arguments);

									var
										target = this.getTargetFromEvent(e);

									return !alreadyExists(target, data) ? Ext.dd.DropZone.prototype.dropAllowed : Ext.dd.DropZone.prototype.dropNotAllowed;
								},
								
								onNodeEnter: function(target, source, e, data) {
									if(window.console && console.log)
										console.log("onNodeEnter(%o)", arguments);

									source.proxy.setStatus(!alreadyExists(target, data) ? Ext.dd.DropZone.prototype.dropAllowed : Ext.dd.DropZone.prototype.dropNotAllowed);
								},
								
								/*notifyOver: function(ddSource, e, data) {
									if(window.console && console.log)
										console.log("notifyOver(%o)", arguments);

									var
										target = this.getTargetFromEvent(e);

									return !alreadyExists(target, data) ? Ext.dd.DropZone.prototype.dropAllowed : Ext.dd.DropZone.prototype.dropNotAllowed;
								},*/

								onNodeOver: function(target, source, e, data) {
									if(window.console && console.log)
										console.log("onNodeOver(%o)", arguments);

									return !alreadyExists(target, data) ? Ext.dd.DropZone.prototype.dropAllowed : Ext.dd.DropZone.prototype.dropNotAllowed;
								},

								notifyDrop: function(ddSource, e, data) {
									if(window.console && console.log)
										console.log("notifyDrop(%o)", arguments);

									var
										target = this.getTargetFromEvent(e);

									if(alreadyExists(target, data))
										return false;

									var
										//text = ddSource.dragData.records[0].get("text"),
										text = data.records[0].get("text");

									Ext.DomHelper.append(target, { tag: "div", html: text, cls: "appended" }) ;

									return true;
								}
								/*
								onNodeDrop: function(target, dd, e, data) {
									if(window.console && console.log)
										console.log("onNodeDrop(%o)", arguments);

									if(alreadyExists(target, data))
										return false;

									var
										//text = dd.dragData.records[0].get("text"),
										text = data.records[0].get("text"),
										el = Ext.fly(target);

									Ext.DomHelper.append(el, { tag: "div", html: text, cls: "appended" }) ;
									
									return true;
								}*/
							});
					}
				}
			}
		});

	Ext.create("Ext.container.Viewport", {
		layout: "border",
		items: [
			tree,
			panel
		]
	});
});
