function showAddBookModal() {
    document.getElementById('addBookModal').style.display = 'block';
    document.getElementById('addBookLink').style.display = 'none';
}

function hideAddBookModal() {
    document.getElementById('addBookModal').style.display = 'none';
    document.getElementById('addBookLink').style.display = 'inline';
}

document.getElementById('addBookLink').addEventListener('click', showAddBookModal);

function showAuthors() {
    document.getElementById('authorsTable').style.display = 'table';
    document.getElementById('genresTable').style.display = 'none';
    document.getElementById('booksTable').style.display = 'none';
    document.getElementById('addAuthorLink').style.display = 'block';
    document.getElementById('addBookLink').style.display = 'none';
}

function showGenres() {
    document.getElementById('genresTable').style.display = 'table';
    document.getElementById('authorsTable').style.display = 'none';
    document.getElementById('booksTable').style.display = 'none';
    document.getElementById('addAuthorLink').style.display = 'none';
    document.getElementById('addBookLink').style.display = 'none';
}

function showBooks() {
    document.getElementById('booksTable').style.display = 'table';
    document.getElementById('authorsTable').style.display = 'none';
    document.getElementById('genresTable').style.display = 'none';
    document.getElementById('addAuthorLink').style.display = 'none';
    document.getElementById('addBookLink').style.display = 'block';
}