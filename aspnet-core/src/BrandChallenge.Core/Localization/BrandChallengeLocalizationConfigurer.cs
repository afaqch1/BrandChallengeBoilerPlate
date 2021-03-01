using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BrandChallenge.Localization
{
    public static class BrandChallengeLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BrandChallengeConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BrandChallengeLocalizationConfigurer).GetAssembly(),
                        "BrandChallenge.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
