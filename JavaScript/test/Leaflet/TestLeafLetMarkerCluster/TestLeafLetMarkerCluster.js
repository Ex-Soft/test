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
			tiles = L.tileLayer(urlToMapService, {
				maxZoom: 18,
				attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
					'<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
					'Imagery © <a href="http://mapbox.com">Mapbox</a>',
				id: 'examples.map-i86knfo3'
			}),
			map = new L.map("demoMap", {
				center: points[0],
				zoom: zoom,
				layers: [tiles]
			}),
			markers = new L.MarkerClusterGroup({ maxClusterRadius: 300 }),
			markerList = [];

			points.forEach(function(element, index, array) {
				var
					title = "Point No" + index,
					marker = new L.Marker(element, { title: title });
				marker.bindPopup(title);
				markerList.push(marker);
				if(window.console && console.log)
					console.log("%d, %d", element.lat, element.lng);
			});

			markers.addLayers(markerList);
			map.addLayer(markers);
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
