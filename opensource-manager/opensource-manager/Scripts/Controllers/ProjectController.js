var ProjectController = function ($scope) {
    $scope.cards = [];

    $scope.init = function (json) {
        // console.log(JSON.stringify(json.data.ResultList));

        json.data.ResultList.forEach(function (item) {
            console.log("hit");
            $scope.cards.push(
                {
                    BoardId: item.BoardId,
                    Title: item.Title
                }
            );
        });

    };
    console.log($scope.cards);    
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
ProjectController.$inject = ['$scope'];