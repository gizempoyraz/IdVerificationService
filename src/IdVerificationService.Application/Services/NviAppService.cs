using Abp.Domain.Repositories;
using IdVerificationService.EntityFrameworkCore;
using IdVerificationService.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdVerificationService.Services
{
    public class NviAppService: IdVerificationServiceAppServiceBase, INviAppService
    {
        private readonly IRepository<Person, int> _personRepository;

        public NviAppService(IRepository<Person, int> personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonDto GetPersonByCitizenId(long citizenId)
        {
            var person = _personRepository.FirstOrDefault(x => x.CitizenId == citizenId);

            return ObjectMapper.Map<PersonDto>(person);
        }

        public async Task<string> KimlikBilgileriniDogrula(KimlikBilgileriniDogrulaInput input)
        {
            try
            {

                ServiceNvi.KPSPublicSoapClient servis = new ServiceNvi.KPSPublicSoapClient(ServiceNvi.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                ServiceNvi.TCKimlikNoDogrulaResponse res = await servis.TCKimlikNoDogrulaAsync(input.CitizenId, input.Name, input.Surname,input.BirthYear);

                if (res.Body.TCKimlikNoDogrulaResult)
                {
                    string jsonData = JsonConvert.SerializeObject(input);

                    return HttpUtility.UrlEncode(Encrypt(jsonData));
                }

                return res.Body.TCKimlikNoDogrulaResult.ToString().ToLower();
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        private const int Keysize = 128;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
