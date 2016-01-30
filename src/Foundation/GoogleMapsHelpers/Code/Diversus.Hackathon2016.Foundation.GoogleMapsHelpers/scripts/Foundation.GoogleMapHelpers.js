window.jsGoogleMapHelpers = window.jsGoogleMapHelpers || {};

(function (jsGoogleMapHelpers) {
    var map;
    var facetList = [];

    var markers = [];
    var transitLayer;
    var transitLayerVisible = false;
    var heatmap;

    //initialise the map with default location
    jsGoogleMapHelpers.initMap = function (mapLatitude, mapLongitude, zoomLevel, facets) {
        map = new google.maps.Map(document.getElementById('map'),
        {
            center: { lat: mapLatitude, lng: mapLongitude },
            zoom: zoomLevel,
        });

        facetList = facets;
        transitLayer = new google.maps.TransitLayer();

        //for each facet create the relevant type	
        for (var i = 0; i < facetList.length; i++) {
            switch (facetList[i].FacetType) {
                case 'Markers':
                    jsGoogleMapHelpers.CreateSinglePointFacet(facetList[i]);
                    break;
                case 'Polygon':
                    jsGoogleMapHelpers.CreatePolygonFacet(facetList[i]);
                    break;
                case 'Heatmap':
                    jsGoogleMapHelpers.CreateHeatmapFacet(facetList[i]);
                    break;
            }
        }
    }

    //on off toggle for facets
    jsGoogleMapHelpers.toggleFacet = function (facetId, facetType) {
        switch (facetType) {
            case 'Markers':
                jsGoogleMapHelpers.ToggleMarkerFacet(facetId);
                break;
            case 'Polygon':
                //jsGoogleMapHelpers.CreatePolygonFacet(facetList[i]);
                break;
            case 'Heatmap':
                jsGoogleMapHelpers.toggleHeatmap(facetId);
                break;
            case 'Transit':
                jsGoogleMapHelpers.ToggleTransitLayer(transitLayerVisible);
                break;
        }
    }

    //#region Markers
    jsGoogleMapHelpers.CreateSinglePointFacet = function (singlePointFacet) {
        for (var i = 0; i < singlePointFacet.Locations.length; i++) {
            jsGoogleMapHelpers.CreateSinglePointMarker(singlePointFacet.FacetId, singlePointFacet.Locations[i], singlePointFacet.Colour)
        }
    }

    jsGoogleMapHelpers.CreateSinglePointMarker = function (facetId, location, iconUrl) {
        var markerPosition = { lat: location.lat, lng: location.lng };
        var marker = new google.maps.Marker(
		{
		    position: markerPosition,
		    map: map,
		    id: facetId,
		    icon: iconUrl
		});

        var infowindow = new google.maps.InfoWindow({ content: location.title });

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

        markers.push(marker);
    }

    jsGoogleMapHelpers.ToggleMarkerFacet = function (facetId) {
        var isEnabled = false;
        var haveHitFirstMarker = false;

        for (var i = 0; i < markers.length; i++) {
            var marker = markers[i];
            if (marker.id == facetId) {
                if (haveHitFirstMarker == false) {
                    isEnabled = marker.getVisible();
                }
                haveHitFirstMarker = true;
                marker.setVisible(!isEnabled)
            }
        }
    }

    //#endregion


    //#region transit layer in Google Maps
    jsGoogleMapHelpers.ToggleTransitLayer = function (isEnabled) {
        if (isEnabled == false) {
            transitLayer.setMap(map);
            transitLayerVisible = true;
        }
        else {
            transitLayer.setMap(null);
            transitLayerVisible = false;
        }
    }
    //#endregion

    //#region Polygon area
    jsGoogleMapHelpers.CreatePolygonFacet = function (polygonFacet) {
        var polygonRegion = new google.maps.Polygon({
            id: polygonFacet.FacetId,
            paths: polygonFacet.Locations,
            strokeColor: polygonFacet.Colour,
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: polygonFacet.Colour,
            fillOpacity: 0.35
        });

        polygonRegion.setMap(map);
    }

    //todo: 

    //#endregion

    //#region heatmap
    jsGoogleMapHelpers.CreateHeatmapFacet = function (heatmapFacet) {
        var heatPoints = [];
        for (var i = 0; i < heatmapFacet.Locations.length; i++) {
            var heatPoint = new google.maps.LatLng(heatmapFacet.Locations[i].lat, heatmapFacet.Locations[i].lng);
            heatPoints.push(heatPoint);
        }

        heatmap = new google.maps.visualization.HeatmapLayer(
		{
		    id: heatmapFacet.FacetId,
		    data: heatPoints,
		    map: map
		});

        setHeatMapGradient(heatmapFacet.Colour, heatmap)
    }

    jsGoogleMapHelpers.toggleHeatmap = function (facetId) {
        heatmap.setMap(heatmap.getMap() ? null : map);
    }

    function setHeatMapGradient(primeColour, heatMapInstance) {
        var gradient = [
		'rgba(0, 255, 255, 0)',
		'rgba(0, 255, 255, 1)',
		'rgba(0, 191, 255, 1)',
		'rgba(0, 127, 255, 1)',
		'rgba(0, 63, 255, 1)',
		'rgba(0, 0, 255, 1)',
		'rgba(0, 0, 223, 1)',
		'rgba(0, 0, 191, 1)',
		'rgba(0, 0, 159, 1)',
		'rgba(0, 0, 127, 1)',
		'rgba(63, 0, 91, 1)',
		'rgba(127, 0, 63, 1)',
		'rgba(191, 0, 31, 1)',
		'rgba(255, 0, 0, 1)',
		primeColour
        ]
        heatMapInstance.set('gradient', heatMapInstance.get('gradient') ? null : gradient);
    }
    //#endregion

})(window.jsGoogleMapHelpers);