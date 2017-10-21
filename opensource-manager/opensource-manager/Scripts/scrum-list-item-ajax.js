$(document).ready(function () {

    var item = {
        Title: "423 Judy Road",
        FK_ProjectID: 3
    };

    $("#btn-addlist").click(function () {
        console.log("click");
        $.ajax({
            url: '/project/3/board',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(item),
            dataType: "json",
            success: function (recData) { alert('Success'); },
            error: function () { alert('A error'); }
        });
    });  
}); 