using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdVerificationService.Localization
{
    public static class IdVerificationServiceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(IdVerificationServiceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IdVerificationServiceLocalizationConfigurer).GetAssembly(),
                        "IdVerificationService.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
