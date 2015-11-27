using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class CreditCard
    {
        [Key]
        [Required]
        public string Digits { get; set; }

        public enum Type
        {
            MasterCard,
            Visa,
            AmericanExpress,
            Discover
        };

    }
}