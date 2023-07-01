﻿using System.ComponentModel.DataAnnotations;

namespace TA.Framework.Application.Model
{
#nullable disable
    public class BaseRequest
    {
        [Required]
        [StringLength(500)]
        [Display(Name = "id")]
        public string Id { get; set; }
    }
}
