using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Kit9.Models;
using System.ComponentModel.DataAnnotations;

namespace Kit9.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Manufacture Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MfgDate { get; set; }

        [Required]
        public string Category { get; set; }
    }
}


