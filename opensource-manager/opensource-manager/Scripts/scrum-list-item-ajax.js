$(document).ready(function () {
    console.log("HEllo");
    $("#btn-addlist").click(function() {
        $.ajax({
            type: "POST",
            url: '@Url.Action("CreateScrumListItem", "ProjectController")',
            contentType: "application/json; charset=utf-8",
            data: { Title: "ThisIsTitle", FK_ProjectID: 4 },
            dataType: "json",
            success: function (recData) { alert('Success'); },
            error: function () { alert('A error'); }
        });
    });  
}); 