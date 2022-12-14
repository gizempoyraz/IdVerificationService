using IdVerificationService.Debugging;

namespace IdVerificationService
{
    public class IdVerificationServiceConsts
    {
        public const string LocalizationSourceName = "IdVerificationService";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "4a1d854bf4474e75ba00d94ad23efd30";
    }
}
