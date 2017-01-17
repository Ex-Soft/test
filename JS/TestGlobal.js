var
	o = {
		f: function() {
			WScript.Echo(this.parent ? "oB!" : "Tampax");
		}
	};

o.f();