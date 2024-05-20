document.addEventListener('DOMContentLoaded', () => {
    fetchData();
});

function fetchData() {
    fetch('/api/data')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            // Atualize o DOM com os dados recebidos
            const content = document.getElementById('content');
            content.innerHTML += `<pre>${JSON.stringify(data, null, 2)}</pre>`;
        })
        .catch(error => console.error('Erro ao buscar dados:', error));
}
