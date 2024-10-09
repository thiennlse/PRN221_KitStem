using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class User : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public int? Role { get; set; }
        public string? Description { get; set; }
        public DateTime? Dob { get; set; }
        [Required]
        public byte? Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserLab> UserLabs { get; set; }
    }
}
