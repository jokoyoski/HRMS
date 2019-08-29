
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Extensions;
using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Collections.Specialized;
using MvcSiteMapProvider.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

//using SessionStateProvider = AA.Infrastructure.Providers.SessionStateProvider;

namespace AA.HRMS.Domain.Providers
{
    public class SiteMapNodeVisibilityProvider : ISiteMapNodeVisibilityProvider
    {
        private static ISessionStateProvider sessionStateProvider;
        private static ISessionStateService session;

        /// <summary>
        /// Determines whether the node is visible.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="sourceMetadata">The source metadata.</param>
        /// <returns>
        /// <c>true</c> if the specified node is visible; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">node</exception>
        public bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            sessionStateProvider = new SessionStateProvider();
            session = new SessionStateService(sessionStateProvider);

            //TODO: Uncomment below before deployment to prod.
            var isUserLoggedIn = (session.GetSessionValue(SessionKey.UserIsAuthenticated) ?? "").ToString().AsBoolean();
            if (!isUserLoggedIn && (node.Title != "Home"))
            {
                return false;
            }

            IRoleCollection roles = node.Roles;

            //if no role is associated to node - allow it to show
            if (!roles.Any())
            {
                return true;
            }

            var roleCollection = ((string[])session.GetSessionValue(SessionKey.UserRoles) ?? new[] { "" }).ToList();
            var roleCollectionToUpper = roleCollection.Select(role => role.ToUpper()).ToList();
            var isGranted = false;
            foreach (var role in roles)
            {
                isGranted = roleCollectionToUpper.Contains(role.ToUpper());
                if (isGranted)
                {
                    break;
                }
            }
            return isGranted;
        }

        /// <summary>
        /// Determines whether the provider instance matches the name
        /// </summary>
        /// <param name="providerName">The name of the visibility provider. This can be any string, but for backward compatibility the type name can be used.</param>
        /// <returns>
        /// True if the provider name matches.
        /// </returns>
        public bool AppliesTo(string providerName)
        {
            return this.GetType().ShortAssemblyQualifiedName().Equals(providerName, StringComparison.InvariantCulture);
        }
    }
}