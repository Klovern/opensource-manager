var ProjectController = function ($scope) {
    $scope.cards = [];

    $scope.init = function (json) {
        json.data.ResultList.forEach(function (item) {
            $scope.cards.push(
                {
                    BoardId: item.BoardId,
                    ColumnId: item.ColumnId,
                    Title: item.Title            
                }
            );
        });
    };  
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
ProjectController.$inject = ['$scope'];