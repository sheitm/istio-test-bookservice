using System;
using System.ComponentModel.DataAnnotations;

namespace Bookservice.Model
{
    //[Bind(Include = "Title, Author, PublishedDate, Description")]
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        [Display(Name = "Date Published")]
        [DataType(DataType.Date)]
        public DateTime? PublishedDate { get; set; }

        public string ImageUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string CreatedById { get; set; }
    }
}
