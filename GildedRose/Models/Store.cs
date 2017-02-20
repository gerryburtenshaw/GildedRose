using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GildedRose.Models
{
   public class Store
   {
      // Items a Store object has, for now hardcoded but could get data from elsewhere (ie: Db)
      private readonly Item[] items = new Models.Item[]
      {
            new Item { Name = "Tomato Soup", Description = "Groceries", Price = 1 },
            new Item { Name = "Yo-yo", Description = "Round thing with string attached", Price = 3 },
            new Item { Name = "First born", Description = "Hardware", Price = 16 },
            new Item { Name = "Trov", Description = "On demand insurance", Price = 16 }
      };

      // Singleton pattern
      static private Store _instance = null;
      static public Store Instance
      {
         get { if (_instance == null) _instance = new Store(); return _instance; }
      }

      public Item[] GetAllItems()
      {
         return items;
      }

      public Item GetItem(string name)
      {
         return items.FirstOrDefault((p) => p.Name == name);
      }
   }
}