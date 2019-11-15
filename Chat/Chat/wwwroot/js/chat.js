"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
var userName = document.cookie.substr(9);
document.getElementById("username").innerHTML += userName;

connection.on("ReceiveMessage", function (user, message) {
    var tr = document.createElement("tr");

    var th = document.createElement("th");
    var td = document.createElement("td");
    th.scope = "row";
    var textUserName = document.createTextNode(userName + ": ");
    th.appendChild(textUserName);

    var text = document.createTextNode(message);
    td.appendChild(text);
    
    tr.appendChild(th);
    tr.appendChild(td);
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