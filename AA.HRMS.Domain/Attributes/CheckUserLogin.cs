using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.WebPages;
using AA.HRMS.Interfaces.ValueTypes;

namespace AA.HRMS.Domain.Attributes
{
    public sealed class CheckUserLogin : AuthorizeAttribute
        {
            private static ISessionStateProvider sessionStateProvider;
            private static ISessionStateService session;

            /// <summary>
            /// When overridden, provides an entry point for custom authorization checks.
            /// </summary>
            /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
            /// <returns>
            /// true if the user is authorized; otherwise, false.
            /// </returns>
            /// <exception cref="System.ArgumentNullException">httpContext</exception>
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (httpContext == null)
                {
                    throw new ArgumentNullException("httpContext");
                }

                sessionStateProvider = new SessionStateProvider();
                session = new SessionStateService(sessionStateProvider);

                var userId = (session.GetSessionValue(SessionKey.UserId) ?? "").ToString().AsInt();
                if (userId < 1)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Processes HTTP requests that fail authorization.
            /// </summary>
            /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute" />.
            ///  The <paramref name="filterContext" /> object contains the controller, HTTP context, request context, action result, and route data.
            /// </param>
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login",
                    returnUrl = url
                }));

                base.HandleUnauthorizedRequest(filterContext);
            }
        }
}
