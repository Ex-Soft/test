function onLoad()
{
	var
		LORANpoints = [
			{ lat: 5440.9333, lon: 2028.7190 },
			//{ lat: 5440.9273, lon: 2028.7680 },
			{ lat: 5440.8843, lon: 2028.7543 },
			{ lat: 5440.9273, lon: 2028.7680 },
			{ lat: 5440.8823, lon: 2028.7323 }
		],
		points = LORAN2Point(LORANpoints),
		map = new OpenLayers.Map("demoMap"),
		mapnik = new OpenLayers.Layer.OSM()
		position = new OpenLayers.LonLat(points[0].x, points[0].y),
		zoom = 18
		//markers = new OpenLayers.Layer.Markers("Markers"),
		ring = new OpenLayers.Geometry.LinearRing(points),
		polygon = new OpenLayers.Geometry.Polygon([ring]),
		attributes = {name: "my name", bar: "foo"},
		feature = new OpenLayers.Feature.Vector(polygon, attributes),
		layer = new OpenLayers.Layer.Vector("Test");

	map.addLayer(mapnik);

	layer.addFeatures([feature]);

	map.addLayers([layer]);

	/*
	map.addLayer(markers);
	points.forEach(function(element, index) {
		var marker = new OpenLayers.Marker(new OpenLayers.LonLat(element.y, element.x));

		marker.id = index.toString();
		marker.events.register("mousedown", marker, function() {
			alert(this.id);
		});

		markers.addMarker(marker);
	});
	*/

	map.setCenter(position, zoom);
}

function LORAN2Point(points)
{
	var
		result = [],
		fromProjection = new OpenLayers.Projection("EPSG:4326"),
		toProjection = new OpenLayers.Projection("EPSG:900913");

	points.forEach(function(element, index, array) {
		var position = new OpenLayers.LonLat(Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(element.lon)), Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(element.lat))).transform(fromProjection, toProjection);

		result.push(new OpenLayers.Geometry.Point(position.lon, position.lat));
	});

	return result;
}
