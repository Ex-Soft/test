Ext.onReady(function() {
	var
		image = Ext.widget("image" /* equ "Ext.Img" */, {
			xtype: "image",
			width: 100,
			height: 100,
			src: Ext.BLANK_IMAGE_URL,
			x: 0,
			y: 0,
			renderTo: "divImage"
		}),
		imageEl,
		imageBox;

	if(image)
	{
		if(imageEl = image.getEl())
			imageBox = imageEl.getBox();
	}
});
