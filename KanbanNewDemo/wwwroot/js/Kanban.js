
$(document).ready(function () {
    // Add a reference to the SignalR library
    //let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();
    // Start the connection
    //connection.on("ReceiveMessage", function (task, cartList) {
    //    console.log(task, cartList);
    //    debugger
    //    var li = document.createElement("li");
    //    li.load(cartList, function () {
    //        document.getElementById("ToDoId").appendChild(li);
    //    });
    //});
    //connection.on("ReceiveMessage", function (task, cartList) {
    //    console.log(task, cartList);
    //    var ul = document.getElementById("ToDoId");

    //    cartList.forEach(function (cart) {
    //        var li = document.createElement("li");
    //        li.className = "card";
    //        li.id = "Cardid-" + cart.cartId;
    //        li.innerHTML = `
    //        <p class="draggable">
    //            ${cart.name}
    //            <div>
    //                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
    //                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
    //            </div>
    //            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
    //            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
    //            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
    //        </p>`;
    //        ul.appendChild(li);
    //    });
    //});


    // ADD And Edit connection 
    connection.on("ReceiveMessage", function (task, cartList) {
        var ul = document.getElementById("ToDoId");
        cartList.forEach(function (cart) {
            var li = document.getElementById("Cardid-" + cart.cartId);
            if (li) {
                // If the list item exists, update it
                li.innerHTML = `
        <p class="draggable">
            ${cart.name}
            <div>
                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
            </div>
            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
        </p>`;
            } else {
                // If the list item doesn't exist, create it
                li = document.createElement("li");
                li.className = "card";
                li.id = "Cardid-" + cart.cartId;
                li.innerHTML = `
        <p class="draggable">
            ${cart.name}
            <div>
                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
            </div>
            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
        </p>`;
                ul.appendChild(li);
            }
        });
    });


    // DragandDrop

    connection.on("DragandDropReceive", function (task, cartList) {
     
        $("#ToDoId").empty();
        $("#InProcessId").empty();
        $("#DoneId").empty();

        cartList.forEach(function (cart) {



            if (cart.statusNumber == 1) {
                var ul = document.getElementById("ToDoId");
                li = document.createElement("li");
                li.className = "card";
                li.id = "Cardid-" + cart.cartId;
                li.innerHTML = `
        <p class="draggable">
            ${cart.name}
            <div>
                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
            </div>
            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
        </p>`;
                ul.appendChild(li);


            }
            else if (cart.statusNumber == 2) {

                var ul = document.getElementById("InProcessId");
                li = document.createElement("li");
                li.className = "card";
                li.id = "Cardid-" + cart.cartId;
                li.innerHTML = `
        <p class="draggable">
            ${cart.name}
            <div>
                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
            </div>
            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
        </p>`;
                ul.appendChild(li);
            }
            else if (cart.statusNumber == 3) {

                var ul = document.getElementById("DoneId");
                li = document.createElement("li");
                li.className = "card";
                li.id = "Cardid-" + cart.cartId;
                li.innerHTML = `
        <p class="draggable">
            ${cart.name}
            <div>
                <a href="/Project/EditCart/${cart.cartId}" class="cart">Edit</a>
                <a href="/Project/DeleteCart/${cart.cartId}" class="cart">Delete</a>
            </div>
            <a href="~/Project/GoToNextLevel/${cart.cartId}" value="${cart.cartId}" id="nextlevelid"></a>
            <a href="~/Project/GoToNextLevel/${cart.statusNumber}" id="statusid" value="${cart.statusNumber}"></a>
            <a href="~/Project/GoToNextLevel/${cart.projectId}" id="ProjectId" value="${cart.projectId}"></a>
        </p>`;
                ul.appendChild(li);

            }
        });
    });

    // DragandDrop




















    connection.start().catch(function (err) {
        return console.error(err.toString());
    });



    $(".kanban-column-list").sortable({

        connectWith: ".kanban-column-list",
        placeholder: "kanban-item-placeholder",
        start: function (event, ui) {
            ui.item.addClass("kanban-item-dragging");
        },
        stop: function (event, ui) {

            var ProjectId = $('#ProjectId').attr('value');
            if (ui.item[0].id != "") {
                ui.item.removeClass("kanban-item-dragging");
                var cardname = ui.item[0].id; // cardid as per box 
                //var cardname = event.toElement.id; // cardid as per box 
                var ulid = $('#' + cardname).closest('ul').attr('id'); // ul id 
                var statusName = $('#' + ulid).attr('value'); // status value 
                var statusId;
                if (statusName == "ToDo") {
                    statusId = '1';
                }
                else if (statusName == "InProcess") {
                    statusId = '2';
                }
                else if (statusName == "Done") {
                    statusId = '3';
                }
                var nextlevelvalue = cardname.split('-')[1];
                var nextlevelid = nextlevelvalue;

                var oldStatusId = $('#statusid').attr('value');

                //databind(statusId, nextlevelid, ProjectId)
                if (statusId != oldStatusId) {
                    $.ajax({
                        url: '/Project/DragandDrop',
                        type: 'POST',
                        data: { id: parseInt(nextlevelid), statusId: parseInt(statusId), projectId: parseInt(ProjectId) },
                        success: function (response) {

                            connection.invoke("SendMessage", "Server", ProjectId).catch(function (err) {
                                return console.error(err.toString());
                            });
                            window.location = '/Project/Kanban/' + ProjectId;
                            // console.log(response);


                        },
                        Error: function (response) {
                            window.location = '/Project/Kanban/' + ProjectId;

                        }

                    });
                } else {
                    window.location = '/Project/Kanban/' + ProjectId;
                }
            }
            else {
                window.location = '/Project/Kanban/' + ProjectId;
            }
        }

    }).disableSelection();

});

//function databind(statusId, nextlevelid, ProjectId) {


//    $.ajax({
//        url: '/Project/DragandDrop',
//        type: 'POST',
//        data: { id: parseInt(nextlevelid), statusId: parseInt(statusId), projectId: parseInt(ProjectId) },
//        success: function (response) {


//        },

//    });

//}