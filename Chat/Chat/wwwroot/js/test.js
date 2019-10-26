function getItems() {
    fetch('https://localhost:44395/api/auth')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error)); 
    alert('adada');
}

function _displayItems(data) {
    var tBody = document.getElementById('values');
    tBody.innerHTML = '' + data.length;
    alert('adada2');
}