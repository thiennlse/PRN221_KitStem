﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Favorite
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? KitId { get; set; }
        [JsonIgnore]
        public virtual KitStem? Kit { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
