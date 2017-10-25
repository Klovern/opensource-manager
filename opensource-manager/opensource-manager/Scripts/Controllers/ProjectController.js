var ProjectController = function ($scope) {
    $scope.cards = [];

    $scope.init = function (json) {
        // console.log(JSON.stringify(json.data.ResultList));

        json.data.ResultList.forEach(function (item) {
            console.log("hit");
            $scope.cards.push(
                {
                    helloAngular: "I do not work!",
                    BoardId: item.BoardId,
                    Title: item.Title
                }
            );
        });

    };

    console.log($scope.cards);
    setTimeout(function () {
        console.log("update");
        $scope.cards = [
            {
                helloAngular: "I do not work!",
                BoardId: "1",
                Title: "Todo"
            },
            {
                helloAngular: "Iluul!",
                BoardId: "32",
                Title: "Test"
            },
            {
                helloAngular: "I do not work!",
                BoardId: "s",
                Title: "Done"
            },
            {
                helloAngular: "I do not work!",
                BoardId: "s",
                Title: "Extra"
            }
        ];
        $scope.$digest();
    }, 3000);

    $scope.updateData = function () {
        $scope.cards = [
            {
                helloAngular: "I do not work!",
                BoardId: "1",
                Title: "Todo"
            },
            {
                helloAngular: "Iluul!",
                BoardId: "32",
                Title: "Test"
            },
            {
                helloAngular: "I do not work!",
                BoardId: "s",
                Title: "Done"
            },
            {
                helloAngular: "I do not work!",
                BoardId: "s",
                Title: "Extra"
            },
        ];
        console.log($scope.cards);
    }
}



// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
ProjectController.$inject = ['$scope'];