﻿using GildedRose.Attributes;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GildedRose.Controllers
{
   [RoutePrefix("api/item")]
   public class ItemController : ApiController
   {
      
      [Route("")]
      [System.Web.Http.HttpGet]
      public IEnumerable<Item> GetAllItems()
      {
         return Store.Instance.GetAllItems();
      }
      
      [Route("{name}")]
      [System.Web.Http.HttpGet]
      public IHttpActionResult GetItem(string name)      
      {
         var item = Store.Instance.GetItem(name);

         if (item == null)
         {
            return NotFound();
         }
         return Ok(item);
      }

      [Route("{name}/buy")]
      [System.Web.Http.HttpGet]
      [CustomerAuthentication]
      public IHttpActionResult BuyItem(string name)
      {
         var item = Store.Instance.GetItem(name);
         if (item == null)
         {
            return NotFound();
         }

         return Ok(item);
      }
   }
}
