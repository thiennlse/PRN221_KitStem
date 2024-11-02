using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class UserLab : BaseEntity
    {
        [Required]
        public int? UserId { get; set; }
        public string? Image {  get; set; }
        [Required]
        public int? LabId { get; set; }
        [JsonIgnore]
        public virtual Lab? Lab { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<HelpHistory> HelpHistories { get; set; }
    }
}
