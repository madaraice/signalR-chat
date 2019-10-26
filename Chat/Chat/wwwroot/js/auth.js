"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/authHub").build();

document.getElementById("authBut").disabled = true;

connection.on("ErrorAuth", function (user, message) {
    document.getElementById("errorAlert").hidden = false;
});

connection.on("AccessAuth", function (user, message) {
    window.location.replace("/ChatRoom");
});

connection.start().then(function () {
    document.getElementById("authBut").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("authBut").addEventListener("click", function (event) {
    var user = document.getElementById("username").value;
    var message = document.getElementById("password").value;

    connection.invoke("Auth", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});