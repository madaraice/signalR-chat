"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
var userName = document.cookie.substr(9);
document.getElementById("username").innerHTML += userName;

connection.on("ReceiveMessage", function (user, message) {
    // Создаем контейнер куда будем помещать элементы th и td
    var tr = document.createElement("tr");
    // Жирный текст с именем юзера
    var th = document.createElement("th");
    // Текст с сообщением
    var td = document.createElement("td");
    
    // Добавляем свойство "жирноты" для имени юзера
    th.scope = "row"; 
    var textUserName = document.createTextNode(user + ": ");
    th.appendChild(textUserName);
    tr.appendChild(th);

    // Сообщение юзера
    var textMessage = document.createTextNode(message);
    td.appendChild(textMessage);
    tr.appendChild(td);

    // Добавляем готовый контейнер с элементами
    document.getElementById("messagesList").appendChild(tr);
    document.getElementById("messageInput").value = "";
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", userName, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});