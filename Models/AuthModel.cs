namespace ApiCreateUserAndAssignPermissionsNotRole.Models
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        //we must send role with token
        public List<string> Roles { get; set; }

        public List<string>? Permissions { get; set; }

        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
