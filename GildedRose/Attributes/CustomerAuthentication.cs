using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace GildedRose.Attributes
{
   public class CustomerAuthentication : System.Web.Http.Filters.AuthorizationFilterAttribute
   {
      // Assumes and validates HTTP Basic Authentication ONLY
      public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
      {
         try
         {
            // If the Request Header does not have an Authorization field, then return 401
            if (actionContext.Request.Headers.Authorization == null)
            {
               actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
               // Get the Authorization field from the Request Header
               var httpRequestHeader = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();

               // Decode it into it's username and password parts
               string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
               string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
               
               string[] authenticationValues = decodedAuthenticationToken.Split(':');

               string username = authenticationValues[0];
               string password = authenticationValues[1];

               // Check the validity of the given crendentials against our stored values
               if (!Customer.HasValidCredentials(username, password))
               {
                  actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
               }
            }
         }
         catch (Exception)
         {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
         }
      }
   }
}