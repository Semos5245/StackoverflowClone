namespace Stackoverflow.Website.Infrastructure
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string CompanyOwner = "CompanyOwner";

        public static string[] All() => new string[] { Admin, CompanyOwner };
    }
}
