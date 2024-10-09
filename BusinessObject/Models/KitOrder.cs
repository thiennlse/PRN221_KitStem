using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class KitOrder : BaseEntity
    {
        [Required]
        public int? OrderId { get; set; }
        [Required]
        public int? KitId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }
        [JsonIgnore]
        public virtual KitStem? Kit { get; set; }
        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
