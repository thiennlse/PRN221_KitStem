using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class CartItem : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int KitId { get; set; }
        [Required]
        public int? Quantity { get; set; }

        [JsonIgnore]
        public virtual KitStem? Kit { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
