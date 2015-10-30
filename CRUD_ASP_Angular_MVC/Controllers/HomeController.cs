using CRUD_ASP_Angular_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ASP_Angular_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBooks()
        {
            using (BookDBContext objContext = new BookDBContext())
            {
                var booklist = objContext.book.ToList();
                return Json(booklist, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetBookById(string id)
        {
            using (BookDBContext objContext = new BookDBContext())
            {
                var bookId = Convert.ToInt32(id);
                var getBook = objContext.book.Find(bookId);

                return Json(getBook, JsonRequestBehavior.AllowGet);
            }
        }

        public string UpdateBook(Book book)
        {
            if (book != null)
            {
                using (BookDBContext objContext = new BookDBContext())
                {
                    var bookId = Convert.ToInt32(book.Id);
                    Book _book = objContext.book.Where(b => b.Id == bookId).FirstOrDefault();
                    _book.Title = book.Title;
                    _book.Publisher = book.Publisher;
                    _book.Isbn = book.Isbn;
                    _book.Author = book.Author;
                    objContext.SaveChanges();
                    return "Book record updated successfully";
                }
            }
            else
            {
                return "invalid book record";
            }
        }

        public string AddBook(Book book)
        {
            if (book != null)
            {
                using (BookDBContext objContext = new BookDBContext())
                {
                    objContext.book.Add(book);
                    objContext.SaveChanges();
                    return "Book record added Successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }

        public string DeleteBook(string bookid)
        {
            if (!String.IsNullOrEmpty(bookid))
            {
                try
                {
                    using (BookDBContext objContext = new BookDBContext())
                    {
                        int bookId = Int32.Parse(bookid);
                        var book = objContext.book.Find(bookid);
                        objContext.book.Remove(book);
                        objContext.SaveChanges();
                        return "Book record deleted successfully";
                    }

                }
                catch (Exception ex)
                {

                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }        
    }
}