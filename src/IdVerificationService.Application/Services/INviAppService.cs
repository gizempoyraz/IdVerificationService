using IdVerificationService.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerificationService.Services
{
    public interface INviAppService
    {
        Task<bool> KimlikBilgileriniDogrula(KimlikBilgileriniDogrulaInput input);
    }
}
