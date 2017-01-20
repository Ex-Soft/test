Ext.require([
    'Ext.data.*',
    'Ext.tip.QuickTipManager'
]);

Ext.define('User', {
    extend: 'Ext.data.Model',
    fields: ['id', 'name', 'age'],
    proxy: {
        type: 'rest',
        url : 'data/users',
        reader: {
            type: 'json',
            root: 'users'
        }
    }
});

var
	userStore;

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("Ext.onReady");

	userStore = Ext.create('Ext.data.Store', {
		model: 'User',
		autoLoad: true
	});

	var
		User = Ext.ModelMgr.getModel('User');

	var
		ed = Ext.create('User', {
			name: 'Ed Spencer',
			age : 25
		});

	ed.save({
		success: function(ed) {
			if(window.console && console.log)
				console.log("Saved Ed! His ID is "+ ed.getId());
		}
	});
	
	User.load(1, {
		success: function(user) {
			if(window.console && console.log)
				console.log("Loaded user 1: " + user.get('name'));
		}
	});
});

