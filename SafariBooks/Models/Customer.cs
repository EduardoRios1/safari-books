using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
namespace SafariBooks.Models
{
    public class Customer : IdentityUser
    {
        // This comment is to test GitHub because we almost have a working repo
        // **** ADD Data annotations for required and ADD regular expressions for email and Display names ****
        public string FName { get; set; }

      [StringLength(1, ErrorMessage = "Please use the first letter of your middle name.")]
        public string MI { get; set; }  
        public string LName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        //[CreditCard] ???
        public virtual List<CreditCard> CreditCards { get; set; }

    }
}