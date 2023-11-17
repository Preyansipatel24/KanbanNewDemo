"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


//connection.on("ReceiveMessage", function (task, cartList) {
//    console.log(task, cartList);
//    debugger
//    /*window.location.href = url;*/
//    //var li = document.createElement("li");
//    //document.getElementById("messagesList").appendChild(li);
//    //// We can assign user-supplied strings to an element's textContent because it
//    //// is not interpreted as markup. If you're assigning in any other way, you
//    //// should be aware of possible script injection concerns.
//    //debugger
//    //li.textContent = `${task} says`;

//    var li = document.createElement("li");
//    li.load(cartList, function () {
//        document.getElementById("ToDoId").appendChild(li);
//    });

//    // Redirect to the URL
//    debugger
//   //window.location.href = url;
//});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
//connection.start().catch(function (err) {
//    return console.error(err.toString());
//});

//// Listen for the "ReceiveTask" method from the server
//connection.on("ReceiveMessage", function (task) {
//    debugger
//    var li = document.createElement("li");
//    li.textContent = task;
//    document.getElementById("lanes").appendChild(li);
//});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var task = document.getElementById("userInput").value;
    // var url = "https://localhost:7170/Project/Kanban?id=7";
    
    var url = $(location).attr('href');
    var ProjectId = /(\d+)$/.exec(url)[1];
  /*  var ProjectId = params.get("id"); */
    //var message = document.getElementById("messageInput").value;
    
    connection.invoke("SendMessage", task, ProjectId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});