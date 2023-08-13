using System.Text.Json.Serialization;

namespace EventBooking.Domain.Entities
{
    public class Users
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
