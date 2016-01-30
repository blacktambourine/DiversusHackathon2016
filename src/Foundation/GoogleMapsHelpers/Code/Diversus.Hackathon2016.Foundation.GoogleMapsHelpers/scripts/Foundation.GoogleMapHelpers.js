window.jsGoogleMapHelpers = window.jsGoogleMapHelpers || {};

(function (jsGoogleMapHelpers) {
    var map;
    var markers = [];
    var transitLayer;

    //initialise the map with default location
    jsGoogleMapHelpers.initMap = function (latitude, longitude, zoomLevel) {
        map = new google.maps.Map(document.getElementById('map'),
        {
            center: { lat: latitude, lng: longitude },
            zoom: zoomLevel,
        });

        transitLayer = new google.maps.TransitLayer();
    }

    //create a marker for a single point type
    jsGoogleMapHelpers.CreateSinglePointMarker = function (location) {
        var markerPosition = { lat: location.latitude, lng: location.longitude };
        var marker = new google.maps.Marker(
		{
		    position: markerPosition,
		    map: map
		});

        var infowindow = new google.maps.InfoWindow({ content: location.title });

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

        markers.push(marker);
    }

    //Toggle built transit layer in Google Maps
    jsGoogleMapHelpers.ToggleTransitLayer = function (isEnabled) {
        if (isEnabled == true) {
            transitLayer.setMap(map);
        }
        else {
            transitLayer.setMap(null);
        }
    }

})(window.jsGoogleMapHelpers);