using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Order
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? StaffId { get; set; }
        [Required]
        public int? UserId { get; set; }
        public string? Phone { get; set; }
        [Required]
        public DateTime? CreateDay { get; set; }
        [Required]
        public DateTime? OrderDay { get; set; }
        [Required]
        public double? TotalPrice { get; set; } 
        public string? Image { get; set; }
        [Required]
        public int? Status { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<KitOrder> KitOrders { get; set; }
    }
}
