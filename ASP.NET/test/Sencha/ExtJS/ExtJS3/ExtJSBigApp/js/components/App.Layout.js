Ext.ns("App.Components");
Ext.ns("App.Layout");

App.Components.AppName = Ext.extend(Ext.Component, {
    constructor: function(c) {
        var d = {
            autoEl: {
                tag: "div"
            },
            cls: "app-name",
            html: App.Config.AppName,
            setName: function(name) {
                this.getEl().dom.innerText = name;
            }
        }
        App.Components.AppName.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.AppLogo = Ext.extend(Ext.Component, {
    constructor: function(c) {
        var d = {
            autoEl: {
                tag: "img",
                src: App.Config.AppLogoPath
            },
            cls: "app-logo",
            setLogo: function(src) {
                this.getEl().dom.src = src;
            }
        }
        App.Components.AppLogo.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.AppHeader = Ext.extend(Ext.Container, {
    constructor: function(c) {
        var appName = new App.Components.AppName();
        var appLogo = new App.Components.AppLogo();
        var d = {
            tag: "div",
            cls: "app-header",
            AppName: appName,
            AppLogo: appLogo,
            items: [appName, appLogo]
        }
        App.Components.AppHeader.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.NorthPanel = Ext.extend(Ext.Panel, {
    constructor: function(c) {
        var appHeader = new App.Components.AppHeader();
        var d = {
            region: "north",
            height: 36,
            items: [appHeader],
            border: false,
            margins: "0 0 5 0",
            setAppName: function(name) {
                appHeader.AppName.setName(name);
            },
            setAppLogo: function(src) {
                appHeader.AppLogo.setLogo(src);
            }
        }
        App.Components.NorthPanel.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.CenterPanel = Ext.extend(Ext.Panel, {
    constructor: function(c) {
        var grid = new App.Components.StaffGrid();
        var d = {
            title: "Staff:",
            region: "center",
            layout: "fit",
            margins: "0 5 0 5",
            Grid: grid,
            items: [grid]
        }
        App.Components.CenterPanel.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.Layout = Ext.extend(Ext.Viewport, {
    constructor: function(c) {
        var header = new App.Components.NorthPanel();
        var center = new App.Components.CenterPanel();
        
        var d = {
            layout: "border",
            Header: header,
            Center: center,
            items: [header, center]
        }
        App.Components.Layout.superclass.constructor.call(this, Ext.apply(d, c));
    }
});