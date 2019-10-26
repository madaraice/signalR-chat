"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/registrationHub").build();

document.getElementById("registrationBut").disabled = true;

connection.on("ErrorAuth", function (user, message) {
    document.getElementById("errorAlert").hidden = false;
});

connection.on("EmptySpace", function (user, message) {
    document.getElementById("errorAlert").hidden = false;
});

connection.on("registration", function (user, message) {
    window.location.replace("/ChatRoom");
});

connection.start().then(function () {
    document.getElementById("registrationBut").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("registrationBut").addEventListener("click", function (event) {
    var user = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var againPassword = document.getElementById("againPassword").value;

    connection.invoke("Registration", user, password, againPassword).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});