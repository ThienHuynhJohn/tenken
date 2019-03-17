using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenkenWeb.Common;
using TenkenWeb.Models;
using TenkenWeb.Providers;

namespace TenkenWeb.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        SqlConnection connection = DBProvider.getDbConnection();
        [HttpGet("[action]")]
        public IList<Book> getBookList(int bookType)
        {
            IList<Book> result = BookProvider.getBookList(connection, bookType);
            return result;
        }

        [HttpGet("[action]")]
        public IList<BookType> getBookType()
        {
            IList<BookType> result = BookProvider.getBookType(connection);
            return result;
        }

        [HttpPost]
        public HttpResult insertBook([FromBody] Book book)
        {
            HttpResult result = BookProvider.book_insert(connection, book);
            return result;
        }

        [HttpPut]
        public HttpResult updateBook([FromBody] Book book)
        {
            HttpResult result = BookProvider.book_merge(connection, book);
            return result;
        }

        [HttpPost]
        public HttpResult insertBookType([FromBody] BookType book)
        {
            HttpResult result = BookProvider.book_type_insert(connection, book);
            return result;
        }

        [HttpPut]
        public HttpResult updateBookType([FromBody] BookType book)
        {
            HttpResult result = BookProvider.book_type_merge(connection, book);
            return result;
        }
    }
}
