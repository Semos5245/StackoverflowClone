namespace Stackoverflow.Website.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBlocked { get; set; }
    }
}
