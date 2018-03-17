app.controller('SubtitleController', ['$scope', 'SubtitleService', function ($scope, SubtitleService) {

    $scope.getSubtitles = function () {
        getSubtitles();
    };

     function getSubtitles() {
        var servCall = SubtitleService.getSubs($scope.inputText);
         servCall.then(function (d) {
             $scope.subtitles = d.data;

         }, function (error) {
             $log.error('Oops! Something went wrong while fetching the data.');
         });
  
}
}]);   