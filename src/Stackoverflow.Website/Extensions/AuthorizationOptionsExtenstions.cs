using Microsoft.AspNetCore.Authorization;
using Stackoverflow.Website.Infrastructure;

namespace Stackoverflow.Website.Extensions
{
    public static class AuthorizationOptionsExtenstions
    {
        public static void AddCustomPolicies(this AuthorizationOptions options)
        {
            // Add all custom policies
            options.AddPolicy(Policies.CompanyOwnerPolicy, builder =>
            {
                builder.RequireRole(Roles.CompanyOwner);
            });

            options.AddPolicy(Policies.AdminPolicy, builder =>
            {
                builder.RequireRole(Roles.Admin);
            });
        }
    }
}
