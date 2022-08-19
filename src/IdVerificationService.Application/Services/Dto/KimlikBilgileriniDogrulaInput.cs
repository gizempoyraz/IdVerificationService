using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerificationService.Services.Dto
{
    public class KimlikBilgileriniDogrulaInput
        {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int BirthYear { get; set; }

        [Required]
        public long CitizenId { get; set; }
    }

}
