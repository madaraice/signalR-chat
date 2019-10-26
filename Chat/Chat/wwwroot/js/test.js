function getItems() {
    fetch('api/auth')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error)); 
}

function _displayItems(data) {
    var tBody = document.getElementById('values');
    tBody.innerHTML = '' + data;
}