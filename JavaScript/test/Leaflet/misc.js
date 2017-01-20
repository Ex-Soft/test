(function(win) {
	if(!win.Misc)
		win.Misc = {
			roundTo: function(aValue, aDigit) {
				var
					LFactor = arguments.length>=2 ? Math.pow(10,-aDigit) : 1,
					tmpInt;

				aValue*=LFactor;
				tmpInt = aValue<0 ? aValue-0.5 : aValue+0.5;
				tmpInt=Math.floor(tmpInt);

				return(tmpInt/LFactor);
			},

			LORANToGeographicDegreeCoords: function (coord) {
				var
					deg = { NegativeSign: coord < 0 },
					intcoord = parseInt((coord / 100).toString()),
					fcoord,
					m,
					sec;

				deg.H = Math.abs(intcoord);

				fcoord = coord - intcoord * 100;
				m = parseInt(fcoord.toString());
				deg.M = Math.abs(m > 59 ? 59 : m);

				sec = parseInt(((coord - parseInt(coord.toString())) * 60).toString());
				deg.S = Math.abs(sec = sec > 59 ? 59 : sec);
				deg.SS = Math.abs(parseInt(((Misc.roundTo((coord - parseInt(coord.toString())) * 60, -5) - sec) * 100)).toString());

				return deg;
			},

			GeographicToDegreeCoords: function(deg) {
				var coord = deg.H + deg.M / 60.0 + deg.S / 3600.0 + deg.SS / 360000.0;

				if (deg.NegativeSign)
					coord *= -1;

				return coord;
			}
		}
})(window);
