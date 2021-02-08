using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookshop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Published")]
        [Required]
        public DateTime PublishDate { get; set; }
    }
}