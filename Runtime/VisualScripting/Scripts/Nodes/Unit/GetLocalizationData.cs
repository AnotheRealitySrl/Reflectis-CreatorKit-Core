using Virtuademy.CreatorKit.Worlds.Core.ClientModels;
using Virtuademy.CreatorKit.Worlds.Core.Localization;
using Virtuademy.SDK.Core.VisualScripting;

using System.Collections.Generic;
using System.Threading.Tasks;

using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Localization: Get Localization Data")]
    [UnitSurtitle("LocalizationData")]
    [UnitShortTitle("Get LocalizationData")]
    [UnitCategory("Reflectis\\Get")]
    public class GetLocalizationData : Unit
    {
        public ValueOutput CurrentLanguage { get; private set; }
        public ValueOutput CurrentLanguageCode { get; private set; }
        public ValueOutput LanguageList { get; private set; }

        protected override void Definition()
        {
            CurrentLanguage = ValueOutput<string>(nameof(CurrentLanguage), (flow) => WorldServices.Get<ILocalizationSystem>().GetCurrentLocalization());
            CurrentLanguageCode = ValueOutput<string>(nameof(CurrentLanguageCode), (flow) => WorldServices.Get<ILocalizationSystem>().GetCurrentLanguageCode());
            LanguageList = ValueOutput<List<string>>(nameof(LanguageList), f => WorldServices.Get<ILocalizationSystem>().GetLanguagesList());
        }

    }
}
