using Microsoft.VisualStudio.TestTools.UnitTesting;
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
         // An item identified as "test" should not exist
         Item item = Store.Instance.GetItem("Test");
         Assert.IsNull(item);

         Item testItem = new Item();
         testItem.Name = "Test";

         Store.Instance.AddItem(testItem);
         item = Store.Instance.GetItem(testItem.Name);

         // Make sure an Item was returned and it is what we were expecting.
         Assert.IsNotNull(item);
         Assert.AreEqual(testItem.Name, item.Name);
      }
   }
}
