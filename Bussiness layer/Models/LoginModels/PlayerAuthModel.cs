﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness_layer.Models.LoginModels
{
    public class PlayerAuthModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthenticationCode { get; set; }
    }
}
