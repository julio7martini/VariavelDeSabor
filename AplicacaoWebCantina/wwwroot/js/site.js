// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Função que de Criar usando uma tecla
document.addEventListener('keydown', function (event) {
    // Verifique se a tecla pressionada é a "Enter" (código 13)
    if (event.key === 'Enter') {
        // Clique no botão
        document.getElementById('addButton').click();
    }
});