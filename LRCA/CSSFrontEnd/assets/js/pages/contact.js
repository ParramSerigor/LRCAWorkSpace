var Contact = function () {

    return {
        
        //Map
        initMap: function () {
			var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#map',
				lat: 38.974823,
				lng: -77.162057
			  });
			   var marker = map.addMarker({
			       lat: 38.974823,
			       lng: -77.162057,
		            title: 'LRCA, LLC.'
		        });
			});
        }

    };
}();