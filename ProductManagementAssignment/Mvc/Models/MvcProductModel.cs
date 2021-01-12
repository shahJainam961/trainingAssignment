using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class MvcProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "shortDescription is required")]
        public string shortDescription { get; set; }

        [Required(ErrorMessage = "longDescription is required")]
        public string longDescription { get; set; }
        public string smallImage { get; set; }
        public string longImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public HttpPostedFileBase ImageFile1 { get; set; }
    }
}