using System.Collections.Generic;
using UnityEngine.Events;

namespace Virtuademy.CreatorKit.Worlds.Core.Localization
{
    public interface ILocalizationSystem
    {
        public UnityEvent<string> OnLanguageChanged { get; set; }
        public string GetCurrentLocalization();
        public string GetCurrentLanguageCode();
        public string GetPreviousLanguage();
        public string GetPreviousLanguageCode();
        public List<string> GetLanguagesList();
        public void LanguageChangedEvent();
        public void SetPreviousLanguage();
        public void SetLanguage(string value);
        public string GetStringFromExternalKey(string value);
    }
}
