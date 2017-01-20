/* http://tysonlloydcadenhead.com/blog/sencha-application-event-listening/ */

Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		application,
		myContainer = Ext.extend(Ext.Container, {
			text: 'Some text',
			initComponent: function() {
				var
					component = this;

				this.application.addListener('myCustomEvent', function(myVariable){
					alert(myVariable);
				});

				myContainer.superclass.initComponent.call(this);
			}
		}),
		myButton = Ext.extend(Ext.Button, {
			text: 'Click me',
			initComponent: function() {
				var
					application = this.application;

				this.handler = function(e){
					var
						myVariable = 'This is a variable';

					application.fireEvent('myCustomEvent', myVariable);
				}
				myButton.superclass.initComponent.call(this);
			}
		}),
		myApplication = Ext.extend(Ext.Panel, {
			height: 500,
			width: 700,
			initComponent: function() {
				this.addEvents ('myCustomEvent');
				this.items = [
					new myButton({ application: this }),
					new myContainer({ application: this })
				];
				myApplication.superclass.initComponent.call(this);
			}
		});

	application = new myApplication();
	application.render(document.body);
});
