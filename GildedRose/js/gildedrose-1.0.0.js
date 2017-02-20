'use strict'

window.GildedRose = window.GildedRose || (function () {
   var _module = {};
   var uriPrefix = 'api/';
   var itemApi = uriPrefix + 'item';

   _module.inventory = function (callback) {
      $.getJSON(itemApi).done(callback);
   }

   _module.buyItem = function (data) {
      $.ajax({
         url: itemApi + '/' + data.itemname + '/buy',
         headers: {
            "Authorization": "Basic " + btoa(data.username + ":" + data.password)
         },
         success: data.success,
         error: data.error
      });
   }

   return _module;
})();

