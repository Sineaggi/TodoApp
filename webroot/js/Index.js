function CreateTask() {
    var contents = "Example task...";
    var payload = JSON.stringify({Contents: contents});
    
    $.ajax({
        method: "POST",
        url: "/api/todo",
        contentType: "application/json",
        data: payload
    }).done(function(msg) {
        console.log( "Data Saved: " + console.dir(msg));
        $("#ahh").val(msg);
    });
}

function EditTask() {
    var contents = "Example task...";
    var payload = JSON.stringify({Contents: contents});
    
    $.ajax({
        method: "PUT",
        url: "/api/todo",
        contentType: "application/json",
        data: payload
    }).done(function(msg) {
        console.log( "Data Saved: " + console.dir(msg));
        $("#ahh").val(msg);
    });
}

function DeleteTask() {
    var contents = "Example task...";
    var payload = JSON.stringify({Contents: contents});
    
    $.ajax({
        method: "POST",
        url: "/api/todo",
        contentType: "application/json",
        data: payload
    }).done(function(msg) {
        console.log( "Data Saved: " + console.dir(msg));
        $("#ahh").val(msg);
    });
}