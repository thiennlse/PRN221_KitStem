using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Step
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? LabId { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public virtual Lab? Lab { get; set; }
        [JsonIgnore]
        public virtual ICollection<HelpHistory> HelpHistories { get; set; }
    }
}
