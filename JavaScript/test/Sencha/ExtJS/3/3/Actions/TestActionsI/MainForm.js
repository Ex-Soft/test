Ext.onReady(function() {
	var
		action = new Ext.Action({
			iconCls: 'icon-data',
			text: 'Import',
			handler: function() {
				Ext.Msg.alert('Action executed', 'This is the Import action executing...');
			}
		}),
		panel = new Ext.Panel({
			title: 'What you can do with Actions',
			width: 450,
			height: 200,
			bodyStyle: 'padding:10px;',
			tbar: [
				action, {
					text: 'Action Menu',
					menu: [action]
				}
			],
			items: [
				new Ext.Button(action)
			],
			renderTo: Ext.getBody()
		}),
		tb = panel.getTopToolbar();

	tb.add('-', {
		text: 'Disable action',
		handler: function() {
			action.setDisabled(!action.isDisabled());
			this.setText(action.isDisabled() ? 'Enable action' : 'Disable action');
		}
	}, {
		text: 'Change action text',
		handler: function() {
			Ext.Msg.prompt('Enter Text', 'Enter new text for the action:', function(btn, text) {
				if (btn == 'ok' && text) {
					action.setText(text);
					action.setHandler(function() {
						Ext.Msg.alert('Click', 'This is the "' + text + '" action executing...');
					});
				}
			});
		}
	}, {
		text: 'Switch action icon',
		handler: function() {
			action.setIconClass(action.getIconClass()=='icon-data' ? 'icon-filter' : 'icon-data');
		}
	});
	
	tb.doLayout();
});
