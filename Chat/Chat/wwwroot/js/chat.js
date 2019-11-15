"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;
const USERNAME = document.cookie.substr(9);
document.getElementById("username").innerHTML += USERNAME;

// Приветственное сообщение, когда приходит новый юзер
connection.on("GreetingMessage", function (user) {
    // Создаем контейнер куда будем помещать элементы th
    var tr = document.createElement("tr");
    // Жирный текст с именем юзера
    var th = document.createElement("th");
    // Добавляем свойство "жирноты" для имени юзера
    th.scope = "row"; 
    var greetingMsg = document.createTextNode(user + " присоединяется к нам!");
    th.appendChild(greetingMsg);
    tr.appendChild(th);
    document.getElementById("messagesList").appendChild(tr);
});

// Загружаем новому пользователю прошлые сообщения
connection.on("DownloadOtherMessages", function (messagesJson) {
    var messages = JSON.parse(messagesJson);

    for(var i = 0; i < messages.length; i++)
    {
        // Создаем контейнер куда будем помещать элементы th
        var tr = document.createElement("tr");  
        // Жирный текст с именем юзера
        var th = document.createElement("th");
        // Текст с сообщением
        var td = document.createElement("td");
        // Добавляем свойство "жирноты" для имени юзера
        th.scope = "row"; 
        
        var textUserName = document.createTextNode(messages[i].Name + ": ");
        th.appendChild(textUserName);
        tr.appendChild(th);
        
        var textMessage = document.createTextNode(messages[i].MessageText);
        td.appendChild(textMessage);
        tr.appendChild(td);
        
        document.getElementById("messagesList").appendChild(tr);
    }
});

// Срабатывает, когда пользователь отправляет сообщение в чат
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

// Срабатывает при подключении юзера в чат
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke("NewUser", USERNAME).catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

// Срабатывает, когда пользователь отправляет сообщение
document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", USERNAME, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});