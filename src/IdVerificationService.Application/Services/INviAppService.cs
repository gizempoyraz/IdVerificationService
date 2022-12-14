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
        Task<string> KimlikBilgileriniDogrula(KimlikBilgileriniDogrulaInput input);
        PersonDto GetPersonByCitizenId(long citizenId);
        Task<bool> SendEmail(string email);
        Task<bool> SendPhoneMessage(string phoneNumber);
    }
}
