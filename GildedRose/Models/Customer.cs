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

      public static bool HasValidCredentials(String username, String password)
      {
         bool result = false;
         Customer customer = customers.FirstOrDefault((p) => p.Username == username);

         if (customer != null)
         {
            result = customer.IsPasswordValid(password);
         }

         return result;
      }

      public bool IsPasswordValid(String password)
      {
         return Password.Equals(password);
      }
   }
}