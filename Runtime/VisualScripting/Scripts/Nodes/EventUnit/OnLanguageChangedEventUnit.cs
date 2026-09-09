using Virtuademy.CreatorKit.Worlds.Core.Localization;
using Virtuademy.SDK.Core.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Localization: On Language Changed")]
    [UnitSurtitle("Localization")]
    [UnitShortTitle("On Language Changed")]
    [UnitCategory("Events\\Reflectis")]
    public class OnLanguageChangedEventUnit : UnityEventUnit<string, string>
    {

        public static string eventName = "OnLanguageChanged";
        //public static Dictionary<GraphReference, List<OnLanguageChangedEventUnit>> instances = new Dictionary<GraphReference, List<OnLanguageChangedEventUnit>>();

        protected override bool register => true;

        public ValueOutput CurrentLanguage { get; private set; }
        public ValueOutput CurrentLanguageCode { get; private set; }
        public ValueOutput PreviousLanguage { get; private set; }
        public ValueOutput PreviousLanguageCode { get; private set; }


        protected override void Definition()
        {
            base.Definition();

            CurrentLanguage = ValueOutput<string>(nameof(CurrentLanguage), (flow) => VirtuademyFramework.Current.CurrentLanguage);
            CurrentLanguageCode = ValueOutput<string>(nameof(CurrentLanguageCode), (flow) => VirtuademyFramework.Current.CurrentLanguageCode);
            PreviousLanguage = ValueOutput<string>(nameof(PreviousLanguage), (flow) => VirtuademyFramework.Current.PreviousLanguage);
            PreviousLanguageCode = ValueOutput<string>(nameof(PreviousLanguageCode), (flow) => VirtuademyFramework.Current.PreviousLanguageCode);
        }

        public override EventHook GetHook(GraphReference reference)
        {
            /*if (instances.TryGetValue(reference, out var value))
            {
                if (!value.Contains(this))
                {
                    value.Add(this);
                }
            }
            else
            {
                List<OnLanguageChangedEventUnit> variableList = new List<OnLanguageChangedEventUnit>
                {
                    this
                };

                instances.Add(reference, variableList);
            }*/

            //return new EventHook(eventName);
            Debug.LogError("EventHook, language change...");
            return new EventHook("lANGUAGEChange" + this.ToString().Split("EventUnit")[0]);
            //return VirtuademyFramework.Current.LanguageChanged;
        }

        protected override UnityEvent<string> GetEvent(GraphReference reference)
        {
            Debug.LogError("GET EVENT CALLED");
            if (VirtuademyFramework.Current.IsLocalizationAvailable)
            {
                Debug.LogError("The system is not null");
            }
            else
            {
                Debug.LogError("NULL");
            }
            return VirtuademyFramework.Current.LanguageChanged;
        }

        protected override string GetArguments(GraphReference reference, string data)
        {
            return "";
        }

        public override void Uninstantiate(GraphReference instance)
        {
            base.Uninstantiate(instance);
            //instances.Remove(instance);
        }
    }
}
