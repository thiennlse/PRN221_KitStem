using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Lab
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? KitId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public virtual KitStem? Kit { get; set; }
        [JsonIgnore]
        public virtual ICollection<Step> Steps { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserLab> UserLabs { get; set; }
    }
}
