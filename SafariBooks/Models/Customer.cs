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
        [Required]
      public String CustomerID { get; set; }

      // **** ADD Data annotations for required and ADD regular expressions for email and Display names ****
      public String FName { get; set; }

      [StringLength(1, ErrorMessage = "Please use the first letter of your middle name.")]
      public String MI{ get; set; }
      public String LName { get; set; }

      public String StreetAddress { get; set; }

      public String City { get; set; }

      [DataType(DataType.PostalCode)]
      public String Zip { get; set; }

      //[CreditCard] data annotation?
      public virtual List<CreditCard> CreditCards { get; set; }

    }
}