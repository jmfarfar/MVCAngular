app.service("crudAJService"), function ($http) {

    //get all books
    this.getBooks = function () {
        return $http.get("Home/GetAllBooks");
    }

    //get Book by bookid
    this.getBook() = function (bookid) {
        var response = $http({
            method: "post",
            url: "Home/GetBookById",
            params: {
                id: JSON.stringify(bookid)
            }
        });
        return response;
    }

    //Update Book
    this.updateBook = function (book) {
        var response = $http({
            method: "post",
            url: "Home/UpdateBook",
            data: JSON.stringify(book),
            datatype: "json"
        });
        return response;
    }

    //Add Book
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "Home/AddBook",
            data: JSON.stringify(book),
            datatype: "json"
        });
    }

    //Delete Book
    this.DeleteBook = function (bookid) {
        var response = $http({
            method: "post",
            url: "Home/DeleteBook",
            params: {
                bookid: JSON.stringify(bookid)
            }
        });
        return response;
    }
}