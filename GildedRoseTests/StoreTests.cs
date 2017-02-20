using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Controllers;
using System.Web.Http;
using GildedRose.Models;

namespace GildedRoseTests
{
   /// <summary>
   /// Summary description for ItemControllerTests
   /// </summary>
   [TestClass]
   public class StoreTests
   {
      public StoreTests()
      {
      }


      #region Additional test attributes
      //
      // You can use the following additional attributes as you write your tests:
      //
      // Use ClassInitialize to run code before running the first test in the class
      // [ClassInitialize()]
      // public static void MyClassInitialize(TestContext testContext) { }
      //
      // Use ClassCleanup to run code after all tests in a class have run
      // [ClassCleanup()]
      // public static void MyClassCleanup() { }
      //
      // Use TestInitialize to run code before running each test 
      // [TestInitialize()]
      // public void MyTestInitialize() { }
      //
      // Use TestCleanup to run code after each test has run
      // [TestCleanup()]
      // public void MyTestCleanup() { }
      //
      #endregion

      [TestMethod]
      public void GetAllItemsTests()
      {
         var items = Store.Instance.GetAllItems();

         Assert.IsTrue(items is Item[]);
      }

      [TestMethod]
      public void GetItemTests()
      {
         Item item = Store.Instance.GetItem("Yo-yo");
         Assert.IsNotNull(item);

         item = Store.Instance.GetItem("blah");
         Assert.IsNull(item);
      }
   }
}
