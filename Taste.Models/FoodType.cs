﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taste.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
