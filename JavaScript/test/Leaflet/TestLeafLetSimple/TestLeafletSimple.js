(function () {
	L.QuickHull = {

		/*
		 * @param {Object} cpt a point to be measured from the baseline
		 * @param {Array} bl the baseline, as represented by a two-element
		 *   array of latlng objects.
		 * @returns {Number} an approximate distance measure
		 */
		getDistant: function (cpt, bl) {
			var vY = bl[1].lat - bl[0].lat,
				vX = bl[0].lng - bl[1].lng;
			return (vX * (cpt.lat - bl[0].lat) + vY * (cpt.lng - bl[0].lng));
		},

		/*
		 * @param {Array} baseLine a two-element array of latlng objects
		 *   representing the baseline to project from
		 * @param {Array} latLngs an array of latlng objects
		 * @returns {Object} the maximum point and all new points to stay
		 *   in consideration for the hull.
		 */
		findMostDistantPointFromBaseLine: function (baseLine, latLngs) {
			var maxD = 0,
				maxPt = null,
				newPoints = [],
				i, pt, d;

			for (i = latLngs.length - 1; i >= 0; i--) {
				pt = latLngs[i];
				d = this.getDistant(pt, baseLine);

				if (d > 0) {
					newPoints.push(pt);
				} else {
					continue;
				}

				if (d > maxD) {
					maxD = d;
					maxPt = pt;
				}
			}

			return { maxPoint: maxPt, newPoints: newPoints };
		},


		/*
		 * Given a baseline, compute the convex hull of latLngs as an array
		 * of latLngs.
		 *
		 * @param {Array} latLngs
		 * @returns {Array}
		 */
		buildConvexHull: function (baseLine, latLngs) {
			var convexHullBaseLines = [],
				t = this.findMostDistantPointFromBaseLine(baseLine, latLngs);

			if (t.maxPoint) { // if there is still a point "outside" the base line
				convexHullBaseLines =
					convexHullBaseLines.concat(
						this.buildConvexHull([baseLine[0], t.maxPoint], t.newPoints)
					);
				convexHullBaseLines =
					convexHullBaseLines.concat(
						this.buildConvexHull([t.maxPoint, baseLine[1]], t.newPoints)
					);
				return convexHullBaseLines;
			} else {  // if there is no more point "outside" the base line, the current base line is part of the convex hull
				return [baseLine[0]];
			}
		},

		/*
		 * Given an array of latlngs, compute a convex hull as an array
		 * of latlngs
		 *
		 * @param {Array} latLngs
		 * @returns {Array}
		 */
		getConvexHull: function (latLngs) {
			// find first baseline
			var maxLat = false, minLat = false,
				maxPt = null, minPt = null,
				i;

			for (i = latLngs.length - 1; i >= 0; i--) {
				var pt = latLngs[i];
				if (maxLat === false || pt.lat > maxLat) {
					maxPt = pt;
					maxLat = pt.lat;
				}
				if (minLat === false || pt.lat < minLat) {
					minPt = pt;
					minLat = pt.lat;
				}
			}
			var ch = [].concat(this.buildConvexHull([minPt, maxPt], latLngs),
								this.buildConvexHull([maxPt, minPt], latLngs));
			return ch;
		}
	};
}());

(function setupOnLoad(global) {
	if(global)
	{
		if(global.addEventListener)
			global.addEventListener("load", onLoad, false);
		else if(global.attachEvent)
			global.attachEvent("onload", onLoad);
		else
			global.onload = onLoad;
	}
	
	function onLoad()
	{
		var
			//urlToMapService = "https://{s}.tiles.mapbox.com/v3/{id}/{z}/{x}/{y}.png",
			urlToMapService = "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
			LORANpoints = [
				{ lat: 5440.9333, lon: 2028.7190 },
				//{ lat: 5440.9273, lon: 2028.7680 },
				{ lat: 5440.8843, lon: 2028.7543 },
				{ lat: 5440.9273, lon: 2028.7680 },
				{ lat: 5440.8823, lon: 2028.7323 }
			],
			zoom = 18,
			points = LORAN2Point(LORANpoints),
			map = L.map("demoMap", {
				center: points[0],
				zoom: zoom
				//, crs: L.CRS.EPSG900913
				//, crs: L.CRS.EPSG4326
			});

		//map.setView(points[0], zoom);

		L.tileLayer(urlToMapService, {
			maxZoom: 18,
			attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
				'<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
				'Imagery © <a href="http://mapbox.com">Mapbox</a>',
			id: 'examples.map-i86knfo3'
		}).addTo(map);

		L.marker(points[0]).addTo(map)
			.bindPopup("<b>Hello world!</b><br />I am a popup.").openPopup();

		/*L.circle(points[0], 50, {
			color: 'red',
			fillColor: '#f03',
			fillOpacity: 0.5
		}).addTo(map).bindPopup("I am a circle.");*/

		L.polygon(L.QuickHull.getConvexHull(points)).addTo(map).bindPopup("I am a polygon.");

		var popup = L.popup();

		function onMapClick(e) {
			popup
				.setLatLng(e.latlng)
				.setContent("You clicked the map at " + e.latlng.toString())
				.openOn(map);
		}

		map.on('click', onMapClick);
	}

	function LORAN2Point(points)
	{
		var
			result = [];

		points.forEach(function(element, index, array) {
			result.push(L.latLng(Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(element.lat)), Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(element.lon))));
		});

		return result;
	}
})(this);

/*
L.whenReady(function() {
	var map = L.map('demoMap').setView([51.505, -0.09], 13);
});
*/
