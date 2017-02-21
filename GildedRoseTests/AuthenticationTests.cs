using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using GildedRose.Models;

namespace GildedRoseTests
{
   [TestClass]
   public class AuthenticationTests
   {
      /*[TestMethod]
      public void TestMethod1()
      {
      }*/

      [TestMethod]
      public void BasicAuthenticationTests()
      {         
         // Valid credentials
         Assert.IsTrue(Customer.HasValidCredentials("Dave","Dave123"));

         // Invalid username
         Assert.IsFalse(Customer.HasValidCredentials("bad name", "Dave123"));

         // Invalid password
         Assert.IsFalse(Customer.HasValidCredentials("Dave", "bad password"));
      }
   }
}
