function LoginForm()
{
	var	
		TextFieldLogin = new Ext.form.TextField({
			allowBlank: false
            ,fieldLabel: "Ћогин"
			,listeners: {
				specialkey: function(field, e){
					if(e.getKey() == e.ENTER){
						SubmitLogIn();
					}
				}
			}
		}),
		TextFieldPassword = new Ext.form.TextField({
			allowBlank: false
			,inputType: "password"
            ,fieldLabel: "ѕароль"
			,listeners: {
				specialkey: function(field, e){
					if(e.getKey() == e.ENTER){
						SubmitLogIn();
					}
				}
			}
		}),
		w = new Ext.Window({
			title: "¬ход..."
			,width: 320
			,height: 200
			,layout: "form"
			,bodyStyle: "padding:6px;"
            ,plain: true
            ,modal: true
            ,closable: false
            ,resizable: false
            ,labelWidth: 80
			,items: [
				TextFieldLogin,
				TextFieldPassword
			]
			,buttons: [{
				text: "OK"
				,handler: function(){
					SubmitLogIn();
				}
			}]
/*			,listeners: {
				show: function(w){
					TextFieldLogin.focus(false,500);
				}
			}*/
		}),
		SubmitLogIn=function(){
			Ext.Ajax.request({
				url: "LoginHandler.aspx",
				method: "POST",
				params: {
					login: TextFieldLogin.getValue(),
					passwd: TextFieldPassword.getValue(),
					loginrequest: true
				},
				success: function(result, request){
					w.close();
				}
			});
		};

//	w.show();
	w.show(
		null
		,function(){
			window.setTimeout(function(){
				TextFieldLogin.focus();
			}
			,500);
		}
	);
}
