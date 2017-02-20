using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

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
      public void BasicAuthenticationTest()
      {
         string username = Convert.ToBase64String(Encoding.UTF8.GetBytes("joydip"));
         string password = Convert.ToBase64String(Encoding.UTF8.GetBytes("joydip123"));

         HttpClient client = new HttpClient();

         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", username + ":" + password);

         //var result = client.GetAsync(new Uri("http://localhost/IDG/api/default/")).Result;
         var result = client.GetAsync(new Uri("http://localhost:50171/api/item/Yo-yo/buy")).Result;

         Assert.IsTrue(result.IsSuccessStatusCode);
      }
   }
}
