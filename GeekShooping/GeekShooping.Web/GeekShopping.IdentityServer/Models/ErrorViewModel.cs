namespace GeekShopping.IdentityServer.Models
{
    public class ApplicationUser
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
