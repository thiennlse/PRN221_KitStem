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
        [Required]
        public int? LabId { get; set; }
        [JsonIgnore]
        public DateTime? Deadline { get; set; }
        public string? ImageUrl { get; set; }
        public int? HelpRemaining { get; set; }

        public virtual Lab? Lab { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<HelpHistory> HelpHistories { get; set; }
    }
}
