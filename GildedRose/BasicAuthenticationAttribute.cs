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
   public class BasicAuthenticationAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
   {
      public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
      {

         try
         {
            if (actionContext.Request.Headers.Authorization == null)
            {
               actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
               var httpRequestHeader = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();

               string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
               string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
               
               string[] authenticationValues = decodedAuthenticationToken.Split(':');

               string username = authenticationValues[0];
               string password = authenticationValues[1];

               //if (username.Equals("joydip") && password.Equals("joydip123"))
               if (Customer.HasValidCredentials(username, password))
               {
                  Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Gerry"), null);
               }
               else
               {
                  actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
               }

               //if (!username.Equals("joydip") || !password.Equals("joydip123"))
               //   actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
         }
         catch (Exception)
         {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
         }

      }

   }
}