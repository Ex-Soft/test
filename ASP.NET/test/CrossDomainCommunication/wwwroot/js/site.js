(function (global) {
	if (typeof (MainForm) === "undefined")
		global.MainForm = new (function () {
			var me = this;

			this.main = undefined;
			this.lastData = undefined;
			this.frameNo = 0;

			this.addEventListener = function (element, eventName, handler) {
				if (element.addEventListener)
					element.addEventListener(eventName, handler, false);
				else if (element.attachEvent)
					element.attachEvent("on" + eventName, handler);
				else
					element.onload = handler;
			};

			this.onLoad = function (e) {
				var btn;

				if (btn = document.getElementById("btnAddIFrame"))
					me.addEventListener(btn, "click", me.onBtnAddIFrameClick);
				if (btn = document.getElementById("btnAddWidget"))
					me.addEventListener(btn, "click", me.onBtnAddWidgetClick);

				me.addEventListener(window, "message", me.onMessage);
			};

			this.onBtnAddIFrameClick = function (e) {
				var frm;

				if (!(me.main = document.querySelector("main")) || !(frm = document.createElement("iframe")))
					return;

				frm.scrolling = "no";
				frm.style.width = me.getRandomInt(100, 200) + "px";
				if (me.lastData && me.lastData.height > 150)
					frm.style.height = me.lastData.height + "px";
				me.addEventListener(frm, "load", me.onFrameLoad);
				frm.src = `/iframe?frameNo=${++me.frameNo}`;
				me.main.appendChild(frm);
			};

			this.onBtnAddWidgetClick = function (e) {
				var frm;

				if (!(me.main = document.querySelector("main")) || !(frm = document.createElement("iframe")))
					return;

				frm.scrolling = "no";
				frm.style.width = me.getRandomInt(100, 200) + "px";
				if (me.lastData && me.lastData.height > 150)
					frm.style.height = me.lastData.height + "px";
				me.addEventListener(frm, "load", me.onFrameLoad);
				frm.src = "/widget.html";
				me.main.appendChild(frm);
			};

			this.onFrameLoad = function (e) {
				if (me.lastData)
					e.target.contentWindow.postMessage({ data: me.lastData.data }, "*");
			};

			this.onMessage = function (e) {
				console.log("MainForm.onMessage(%o)", e);

				for (var i = frames.length - 1; i >= 0; --i) {
					if (frames[i].postMessage)
						frames[i].postMessage(me.lastData = e.data, "*");
				}

				me.autoGrow(e.data.height);
			};

			this.autoGrow = function (height) {
				var iframes = document.body.getElementsByTagName("iframe");
				for (var i = iframes.length - 1; i >= 0; --i) {
					if (iframes[i].offsetHeight < height)
						iframes[i].style.height = height + "px";
				}
			};

			this.getRandomInt = function (min, max) {
				min = Math.ceil(min);
				max = Math.floor(max);
				return Math.floor(Math.random() * (max - min)) + min;
			}
		})();

	global.MainForm.addEventListener(global, "load", global.MainForm.onLoad);
})(this);
