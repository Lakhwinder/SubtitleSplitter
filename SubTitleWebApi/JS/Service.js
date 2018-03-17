app.service("SubtitleService", function ($http) {
    this.getSubs = function (input) {
        return $http.get("../api/Subtitle?input=" + input);
    };
}); 