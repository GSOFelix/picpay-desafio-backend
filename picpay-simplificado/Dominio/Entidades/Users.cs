using Dominio.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Dominio.Entidades
{
    public class Users
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(14)]
        public string Document { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public decimal Wallet { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType Type { get; set; }

        public string Password { get; set; } = string.Empty;

        public Users(string name, string lastName, string document, string email, decimal wallet, UserType type, string password)
        {
            Name = name;
            LastName = lastName;
            Document = document;
            Email = email;
            Wallet = wallet;
            Type = type;
            Password = password;
        }
    }
}
