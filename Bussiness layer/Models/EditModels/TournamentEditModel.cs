using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness_layer.Models.EditModels
{
    public class TournamentEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string TournamentName { get; set; }
        public int Award { get; set; }
        public string Country { get; set; }
    }
}
