"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/registrationHub").build();

document.getElementById("registrationBut").disabled = true;

var ERRORemptySpace = document.getElementById("emptySpace");
var ERRORchangeOtherName = document.getElementById("changeOtherName");
var ERRORchangePassword = document.getElementById("changePassword");
var COMPLETEDregistrationCompleted = document.getElementById("registrationComplete");

connection.on("EmptySpace", function () {
    ERRORemptySpace.hidden = false;

    COMPLETEDregistrationCompleted.hidden = true;
    ERRORchangeOtherName.hidden = true;
    ERRORchangePassword.hidden = true;
});

connection.on("ChangeOtherName", function () {
    ERRORchangeOtherName.hidden = false;

    COMPLETEDregistrationCompleted.hidden = true;
    ERRORchangePassword.hidden = true;
    ERRORemptySpace.hidden = true;
});

connection.on("ChangePassword", function () {
    ERRORchangePassword.hidden = false;

    COMPLETEDregistrationCompleted.hidden = true;
    ERRORemptySpace.hidden = true;
    ERRORchangeOtherName.hidden = true;
});

connection.on("RegistrationComplete", function () {
    ERRORchangePassword.hidden = true;
    ERRORemptySpace.hidden = true;
    ERRORchangeOtherName.hidden = true;

    COMPLETEDregistrationCompleted.hidden = false;
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