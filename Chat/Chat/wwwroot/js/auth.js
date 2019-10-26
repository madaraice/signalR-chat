"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/authHub").build();

document.getElementById("authBut").disabled = true;

connection.on("ErrorAuth", function () {
    document.getElementById("errorAlert").hidden = false;
});

connection.on("AccessAuth", function () {
    window.location.replace("/ChatRoom");
});

connection.start().then(function () {
    document.getElementById("authBut").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("authBut").addEventListener("click", function (event) {
    var user = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    connection.invoke("Auth", user, password).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});