using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QuickLearnSpace.Localization
{
    public static class QuickLearnSpaceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QuickLearnSpaceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QuickLearnSpaceLocalizationConfigurer).GetAssembly(),
                        "QuickLearnSpace.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
