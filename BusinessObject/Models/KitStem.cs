using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class KitStem : BaseEntity
    {
        public string? Attribute { get; set; }
        public string? Image { get; set; }
        [Required]
        public int? Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public virtual ICollection<KitOrder> KitOrders { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lab> Labs { get; set; }
    }
}
