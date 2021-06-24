using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuLamDucMinh_Buoi2.Models;


namespace TuLamDucMinh_Buoi2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello teacher - university" + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete manual - Author name book 1");
            books.Add("HTNL5 &CSS Responsive web design cookbook - Author name book 2");
            books.Add("Professional ASP.Net MVC5 - Author name book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"Lich sử vạn vật", "/Content/Images/lich su van vat.png"));
            books.Add(new Book(2,"Nguồn gốc các loài", "/Content/Images/Nguon goc cac loai.png"));
            books.Add(new Book(3,"Thông điệp của nước", "/Content/Images/thong diep cua nuoc.png"));
                return View(books);
        }
        public ActionResult EditBook(int? id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Lich sử vạn vật", "/Content/Images/lich su van vat.png"));
            books.Add(new Book(2, "Nguồn gốc các loài", "/Content/Images/Nguon goc cac loai.png"));
            books.Add(new Book(3, "Thông điệp của nước", "/Content/Images/thong diep cua nuoc.png"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }    
            }    
            if(book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, String Image)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Lich sử vạn vật", "/Content/Images/lich su van vat.png"));
            books.Add(new Book(2, "Nguồn gốc các loài", "/Content/Images/Nguon goc cac loai.png"));
            books.Add(new Book(3, "Thông điệp của nước", "/Content/Images/thong diep cua nuoc.png"));
            if(id == null)
            {
                return HttpNotFound();
            }    
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image = Image;
                    break;
                }    
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, Image")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Lich sử vạn vật", "/Content/Images/lich su van vat.png"));
            books.Add(new Book(2, "Nguồn gốc các loài", "/Content/Images/Nguon goc cac loai.png"));
            books.Add(new Book(3, "Thông điệp của nước", "/Content/Images/thong diep cua nuoc.png"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }    
            }catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error save data");
            }
            return View("ListBookModel", books);
        }
    }
}