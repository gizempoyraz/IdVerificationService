using IdVerificationService.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerificationService.Services
{
    public class NviAppService: IdVerificationServiceAppServiceBase, INviAppService
    {
        public NviAppService()
        {

        }
        public async Task<bool> KimlikBilgileriniDogrula(KimlikBilgileriniDogrulaInput input)
        {
            try
            {

                ServiceNvi.KPSPublicSoapClient servis = new ServiceNvi.KPSPublicSoapClient(ServiceNvi.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                ServiceNvi.TCKimlikNoDogrulaResponse res = await servis.TCKimlikNoDogrulaAsync(input.CitizenId, input.Name, input.Surname,input.BirthYear);
                return res.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
