using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class HelpHistory : BaseEntity
    {
        [Required]
        public int? UserLabId { get; set; }
        [Required]
        public int? StepId { get; set; }
        [JsonIgnore]
        public virtual Step? Step { get; set; }
        [JsonIgnore]
        public virtual UserLab? UserLab { get; set; }
    }
}
