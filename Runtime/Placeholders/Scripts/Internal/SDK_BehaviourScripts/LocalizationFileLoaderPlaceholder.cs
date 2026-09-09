using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Core.Placeholders
{
    public class LocalizationFileLoaderPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField]
        private TextAsset localizationCSV;

        public TextAsset LocalizationCSV { get => localizationCSV; set => localizationCSV = value; }
    }
}
