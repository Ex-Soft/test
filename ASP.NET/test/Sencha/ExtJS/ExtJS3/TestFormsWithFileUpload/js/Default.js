Ext.BLANK_IMAGE_URL = "../ext/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		picBox = {
			columnWidth: 0.35,
			bodyStyle: "padding: 10px",
			items: [{
				xtype: "box",
				autoEl:	{
					tag: "div",
					html: '<img id="pic" src="' + Ext.BLANK_IMAGE_URL + '" class="img-contact" />'
				}
			}]
		},
		picFiles = {
			columnWidth: 0.65,
			layout: "form",
			labelAlign: "top",
			items: [{
				xtype: "textfield",
				fieldLabel: "Current",
				labelSeparator: "",
				name: "currPic",
				id: "currPic",
				readOnly: true,
				disabled: true,
				anchor: "100%"
			}, {
				xtype: "textfield",
				fieldLabel: "New (JPG or PNG or GIF only)",
				labelSeparator: "",
				name: "newPic",
				id: "newPic",
				style: "width: 300px",
				inputType: "file",
				allowBlank: false
			}]
		},
		pictUploadForm = new Ext.form.FormPanel({
			frame: true,
			title: "Change Picture",
			bodyStyle: "padding: 5px",
			width: 420,
			layout: "column",
			url: "contact-picture.aspx",
			method: "POST",
			fileUpload: true,
			items: [picBox, picFiles],
			buttons: [{
				text: "Upload Picture",
				handler: function() {
					var
						theForm = pictUploadForm.getForm();
						
					if (!theForm.isValid())
					{
						Ext.MessageBox.alert("Change Picture", "Please select a picture");
						return;
					}
					
					if (!validateFileExtension(Ext.getDom("newPic").value))
					{
						Ext.MessageBox.alert("Change Picture", "Only JPG or PNG or GIF, please.");
						return;
					}
					
					theForm.submit({
						params: { act: "setPicture", id: "contact1" },
						waitMsg: "Uploading picture"
					})
				}
			}, {
				text: "Cancel"
			}],
			listeners: {
				actioncomplete: function(form, action) {
					if (action.type == "load")
					{
						var
							pic = action.result.data;
							
						Ext.getDom("pic").src = pic.file;
						Ext.getCmp("currPic").setValue(pic.file);
					}
					
					if (action.type == "submit")
					{
						var
							pic = action.result.data;
							
						Ext.getDom("pic").src = pic.file;
						Ext.getCmp("currPic").setValue(pic.file);
						Ext.getDom("newPic").value = "";
						//Ext.getCmp("newPic").setValue("");
					}
				},
				actionfailed: function(form, action) {
					Ext.MessageBox.alert("actionfailed", "action.type == \""+action.type+"\"<br />action.failureType == \""+action.failureType+"\"");
				}
			}
		});

	pictUploadForm.render(document.body);
	pictUploadForm.getForm().load({ params: { act: "getPicture", id: "contact1" }, waitMsg: "Loading" });
});

function validateFileExtension(fileName)
{
	var
		exp = /^.*\.(jpg|JPG|png|PNG|gif|GIF)$/;
		
	return exp.test(fileName);
}
