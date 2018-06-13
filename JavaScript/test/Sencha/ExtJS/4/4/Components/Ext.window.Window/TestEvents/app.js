Ext.onReady(function() {
	Ext.create("Ext.window.Window", {
		x: 100,
		y: 100,
		height: 100,
		width: 100,
		html: "<div><img id=\"TestImg\"></div>",
		maximizable: true,
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "get",
				handler: function(btn, e) {
					var
						w = btn.up("window");

					if(window.console && console.log)
						console.log("getPosition(false)=%o, getPosition(true)=%o, height=%i, width=%i", w.getPosition(false), w.getPosition(true), w.height, w.width);
				}
			}]
		}],
		listeners: {
			beforerender: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.beforerender()");
			},
			render: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.render()");
			},
			afterrender: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.afterrender()");

				this.getImg().addListener("load", function(e, img, eOpts) {
					if(window.console && console.log)
						console.log("img.load(%o)", arguments);
				});
			},
			beforeclose: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.beforeclose() getPosition(false)=%o, getPosition(true)=%o, height=%i, width=%i, x=%i, y=%i", win.getPosition(false), win.getPosition(true), win.height, win.width, win.x, win.y);
			},
			beforedestroy: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.beforedestroy() getPosition(false)=%o, getPosition(true)=%o, height=%i, width=%i, x=%i, y=%i", win.getPosition(false), win.getPosition(true), win.height, win.width, win.x, win.y);
			},
			close: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.close()");
			},
			destroy: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.destroy()");
			},
			move: function(win, x, y, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.onmove() x=%i, y=%i", x, y);
			},
			resize: function(win, width, height, eOpts ) {
				if(window.console && console.log)
					console.log("Ext.window.Window.onresize() width=%i, height=%i", width, height);

				var
					imgs = ["http://www.sql.ru/forum/images/cry.gif", "http://www.sql.ru/forum/images/bigeyes.gif", "http://www.sql.ru/forum/images/smoke.gif", "http://www.sql.ru/forum/images/biggrin.gif"];
					//imgs = ["http://javascript.ru/forum/images/smilies/cray.gif", "http://javascript.ru/forum/images/smilies/help.gif", "http://javascript.ru/forum/images/smilies/stop.gif", "http://javascript.ru/forum/images/smilies/smile.gif"];

				this.getImg().set({ src: imgs[(width+height)%4] });
			},
			show: function(win, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.show()");
			}
		},
		getImg: function() {
			if(!this.img)
				this.img = Ext.get("TestImg");

			return this.img;
		}
	}).show();
});
