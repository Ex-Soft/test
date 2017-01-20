function onLoad()
{
	var
		map = new OpenLayers.Map("demoMap"),
		mapnik = new OpenLayers.Layer.OSM(),
		fromProjection = new OpenLayers.Projection("EPSG:4326"), // Transform from WGS 1984
		toProjection = new OpenLayers.Projection("EPSG:900913"), // to Spherical Mercator Projection
		lat = Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(5440.8833)),
		lon = Misc.GeographicToDegreeCoords(Misc.LORANToGeographicDegreeCoords(2028.7333)),
		position = new OpenLayers.LonLat(lon, lat).transform(fromProjection, toProjection),
		zoom = 18,
		markers = new OpenLayers.Layer.Markers("Markers");

	if(window.console && console.log)
		console.log("position: { lon: %d, lat: %d }", position.lon, position.lat);

	markers.id = "1";
	markers.events.register("mousedown", markers, function() {
		alert(this.id);
	});

	map.addLayer(mapnik);
	map.addLayer(markers);
	markers.addMarker(new OpenLayers.Marker(position));
	map.setCenter(position, zoom);
	//map.zoomToMaxExtent();
}
