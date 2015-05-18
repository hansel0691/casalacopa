angular.module('main.controllers.location', [])
    .controller('locationCtr', ['$scope',
        function($scope) {
            var map = null;

            //, 
            function initialize() {
                var myLatlng = { lat: 23.118386, lng: -82.430482 };
                var mapOptions = {
                    center: myLatlng,
                    zoom: 15
                };
                map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: 'Casa la Copa',
                });

                setTimeout(google.maps.event.addListenerOnce(map, 'idle', function () { google.maps.event.trigger(map, 'resize'); }), 100);
            }

            $(document).ready(function () { initialize(); });

        }])