using Virtuademy.SDK.Environments.Placeholders;

using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
{
    public class ButtonOpenAppPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField] private string appLink;

        public string AppLink => appLink;
    }
}
