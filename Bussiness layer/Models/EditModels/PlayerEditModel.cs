using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bussiness_layer.Models.EditModels
{
    public class PlayerEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthenticationCode { get; set; }
        public int TournamentsPlayed { get; set; }
        public int RankListPoints { get; set; }
        public bool IsMainOrNormalPlayer { get; set; }
    }
}
