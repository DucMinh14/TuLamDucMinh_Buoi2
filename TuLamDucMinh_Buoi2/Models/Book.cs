using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuLamDucMinh_Buoi2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image;
      

      
        public Book()
        {

        }

        public Book(int v1, string v2, string v3)
        {
        }

        public Book(int id, string title, string author, string image)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image = image;
        }
        public int Id
        {
            get { return id; }
            set { Id = value; }
        }
        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề sách không được vượt quá 250 ký tự")]
        [Display(Name= "Tiêu đề")]
        public string Title
        {
            get { return title; }
            set { Title = value; }
        }
        public string Author
        {
            set { Author = value; }
            get{return author;}
        }
        public string Image
        {
            get { return image; }
            set { Image = value; }
        }

       
    }
}