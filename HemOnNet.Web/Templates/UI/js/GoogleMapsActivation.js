/*

* Google maps activation

*/

var map;

function gMapLoad(containerElementID, latitude, longitude,text, zoomLevel, icon) {
    if (GBrowserIsCompatible()) {

        map = new GMap2($("#pnlMap")[0]);

        map.setCenter(new GLatLng(latitude, longitude), zoomLevel);

        map.setMapType(G_NORMAL_MAP);

        map.addControl(new GSmallZoomControl3D());

        var shIcon = new GIcon(G_DEFAULT_ICON);
        shIcon.image = icon;//"http://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png";
        shIcon.iconSize = new GSize(32, 32);
        shIcon.shadowSize = new GSize(56, 32);
        shIcon.iconAnchor = new GPoint(16, 32);
        shIcon.infoWindowAnchor = new GPoint(16, 0); 


        markerOptions = { icon: shIcon };

        var point = new GLatLng(latitude, longitude);

        map.addOverlay(createMarker(point,text, markerOptions));

    }

}

function gMapAddPoint(latitude, longitude, text, icon) {

    if (GBrowserIsCompatible()) {

        if (map) {
            var shIcon = new GIcon(G_DEFAULT_ICON);

            shIcon.image = icon;//"http://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png";

            // change the properties that are different.
            shIcon.iconSize = new GSize(32, 32);
            shIcon.shadowSize = new GSize(56, 32);
            shIcon.iconAnchor = new GPoint(16, 32);
            shIcon.infoWindowAnchor = new GPoint(16, 0); 
            
            markerOptions = { icon: shIcon };

            var point = new GLatLng(latitude, longitude);

            map.addOverlay(createMarker(point,text, markerOptions));
        
        }

        
        

    }

}

// Creates a marker at the given point
    // Clicking the marker will hide it
function createMarker(latlng, html,markerOptions) {
  var marker = new GMarker(latlng, markerOptions);
  marker.openInfoWindowHtml(html);
  GEvent.addListener(marker,"click", function() {
    map.openInfoWindowHtml(latlng, html);
  });
  return marker;
}
