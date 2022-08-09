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
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public long CitizenId { get; set; }
    }

}
