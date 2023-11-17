const form = document.getElementById("todo-form");
const input = document.getElementById("todo-input");
const todoLane = document.getElementById("todo-lane");

form.addEventListener("submit", (e) => {
  e.preventDefault();
  const value = input.value;

  if (!value) return;

  const newTask = document.createElement("p");
  newTask.classList.add("task");
  newTask.setAttribute("draggable", "true");
    newTask.innerText = value;
    Addtask(value);
  
  newTask.addEventListener("dragstart", () => {
    newTask.classList.add("is-dragging");
  });

  newTask.addEventListener("dragend", () => {
    newTask.classList.remove("is-dragging");
  });

  todoLane.appendChild(newTask);

  input.value = "";
});
function Addtask(taskname) {
    
    var dataModel = {
        "ProjectId": 1,
        "Name": taskname,
      
    }
    $.ajax({
        type: 'Post',
        url: '/Project/AddCart',
        data: JSON.stringify(dataModel),
        cache: false,
        success: function (response) {


        },

    });
}