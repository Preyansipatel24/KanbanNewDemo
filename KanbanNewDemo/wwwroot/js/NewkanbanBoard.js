$(document).ready(function () {
    $(".draggable").draggable();
    $(".droppable").droppable({
        drop: function (event, ui) {
            var taskId = ui.draggable.data("id");
            var status = $(this).data("status");
            $.post("/Home/UpdateStatus", { id: taskId, status: status });
        }
    });
});