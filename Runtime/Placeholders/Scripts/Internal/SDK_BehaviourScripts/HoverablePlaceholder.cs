using Virtuademy.SDK.Environments.Placeholders;

using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
{
    [RequireComponent(typeof(Collider))]
    public class HoverablePlaceholder : SceneComponentPlaceholderBase
    {
        private string hoverActionName = "TriggerHoverEvent";
        private string unhoverActionName = "TriggerUnhoverEvent";

        public string HoverActionName => hoverActionName;
        public string UnhoverActionName => unhoverActionName;
    }
}
