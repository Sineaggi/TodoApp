function CreateTask(item) {
    var contents = $("#task-create-input").val();
    
    if (!contents) {
        console.log("Empty task!");
        return;
    }
    var payload = JSON.stringify({Contents: contents});
    
    $.ajax({
        method: "POST",
        url: "/api/todo",
        contentType: "application/json",
        data: payload
    }).done(function(msg) {
        console.log( "Data Saved: " + console.dir(msg));
        /*
        $("#task-list-group").append(
            $("<li>").attr(
                "class", "list-group-item").attr(
                    "id", msg.Key).append(
                        $("<a>").attr("href", "#").attr("onclick", "EditTask()").append(
                            
                        msg.Contents
                        )
        ));
        */
        var newtask = $("#task").html();
        console.log("b4 id " + $(newtask).attr("id"));
        $(newtask).attr("id", ("ass" + msg.Key));
        console.log("aftr id " + $(newtask).attr("id"));
        var s = $(newtask).find("#task-link");
        
        $("#task-list-group").append($(newtask));
        $(s).text(msg.Contents);
        console.log($(s).text());
        //$("#task-list-group").append($("task").html());
        // Clear input on successful post
        $("#task-create-input").val("");
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

function RemoveTask() {
    var contents = "Example task...";
    var payload = JSON.stringify({Contents: contents});
    
    console.log("wut" + $(this).attr("id"));
    
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