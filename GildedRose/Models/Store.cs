using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.Models
{
   public class Store
   {
      // Items a Store object has, for now hardcoded but could get data from elsewhere (ie: Db)
      private List<Item> items = new List<Item>();

      // Singleton pattern
      static private Store _instance = null;
      static public Store Instance
      {
         get { if (_instance == null) _instance = new Store(); return _instance; }
      }

      public Store()
      {
         // Initialize the Store
         AddItem(new Item { Name = "Tomato Soup", Description = "Groceries", Price = 1 });
         AddItem(new Item { Name = "Yo-yo", Description = "Round thing with string attached", Price = 3 });
         AddItem(new Item { Name = "First born", Description = "Hardware", Price = 16 });
         AddItem(new Item { Name = "Trov", Description = "On demand insurance", Price = 16 });
      }

      public Item[] GetAllItems()
      {
         return items.ToArray();
      }

      public Item GetItem(string name)
      {
         return items.FirstOrDefault((p) => p.Name == name);
      }

      public void AddItem(Item item)
      {
         if (item == null)
            throw new NullReferenceException();

         items.Add(item);
      }
   }
}