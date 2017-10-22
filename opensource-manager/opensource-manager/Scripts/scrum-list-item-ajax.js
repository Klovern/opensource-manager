$(document).ready(function () {

    var item = {
        Title: "423 Judy Road",
        FK_ProjectID: 18
    };

    $("#btn-addlist").click(function () {
        console.log("click");
        $.ajax({
            url: '/project/18/board',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(item),
            dataType: "json",
            success: function (recData) { location.reload(); },
            error: function () { alert('A error'); }
        });
    });  
}); 