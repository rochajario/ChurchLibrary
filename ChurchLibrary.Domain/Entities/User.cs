using Microsoft.AspNetCore.Identity;

namespace ChurchLibrary.Domain.Entities
{
    public class User : IdentityUser
    {
        public long? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? AddressComplement { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
