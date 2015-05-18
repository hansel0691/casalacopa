var directives = angular.module('main.directives', [])
    .directive('global', [
        '$rootScope', '$location',
        function($rootScope, $location) {
            return {
                link: function(scope, element, attrs) {
                    $rootScope.$on('$routeChangeStart', function() {
                    });
                    $rootScope.$on('$routeChangeSuccess', function() {
                        var url = $location.path().split('/');
                        var view = url[url.length - 1];

                        switch (view) {
                        case 'home':
                            scope.active = 0;
                            scope.title = 'The House';
                            break;
                        case 'location':
                            scope.active = 1;
                            scope.title = 'The Location';
                            break;
                        case 'rooms':
                            scope.active = 2;
                            scope.title = 'The Rooms';
                            break;
                        case 'terrace':
                            scope.active = 3;
                            scope.title = 'The Terrace';
                            break;
                        case 'about':
                            scope.active = 4;
                            scope.title = 'About';
                            break;
                        case 'todo':
                            scope.active = -1;
                            scope.title = 'The Things To Do';
                            break;
                        case 'gallery':
                            break;
                        default:
                            $scope.active = -1;
                            scope.title = view;
                        }
                    });
                }
            };
        }
    ])
    .directive('modalDialog', function() {
        return {
            restrict: 'E',
            scope: {
                show: '='
            },
            replace: true, // Replace with the template below
            transclude: true, // we want to insert custom content inside the directive
            link: function(scope, element, attrs) {
                scope.dialogStyle = {};
                if (attrs.width)
                    scope.dialogStyle.width = attrs.width;
                if (attrs.height)
                    scope.dialogStyle.height = attrs.height;
                scope.hideModal = function() {
                    scope.show = false;
                };
            },
            template: '...' // See below
        };
    });