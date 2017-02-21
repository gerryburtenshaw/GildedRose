using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.Models
{
   public class Customer
   {
      private static readonly Customer[] customers = new Models.Customer[]
      {
            new Customer { Username = "Gerry", Password = "Gerry123"},
            new Customer { Username = "Dave", Password = "Dave123"}
      };

      public string Username { get; set; }
      public string Password { get; set; }

      // Checks that the password given for a specific username matches.
      public static bool HasValidCredentials(String username, String password)
      {
         bool result = false;

         // Get the customer object that has the given username
         Customer customer = customers.FirstOrDefault((p) => p.Username == username);

         if (customer != null)
         {
            result = customer.IsPasswordValid(password);
         }

         return result;
      }

      // Check if the given password is correct for this customer
      public bool IsPasswordValid(String password)
      {
         return Password.Equals(password);
      }
   }
}