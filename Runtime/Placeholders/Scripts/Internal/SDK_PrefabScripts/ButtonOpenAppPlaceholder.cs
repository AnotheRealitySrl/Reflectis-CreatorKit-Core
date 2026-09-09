using Virtuademy.CreatorKit.Worlds.Core.Placeholders;

using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class ButtonOpenAppPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField] private string appLink;

        public string AppLink => appLink;
    }
}
