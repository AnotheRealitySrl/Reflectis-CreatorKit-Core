using Virtuademy.CreatorKit.Worlds.Core.Placeholders;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    [RequireComponent(typeof(InteractablePlaceholder))]
    public abstract class InteractionBehaviourPlaceholder : SceneComponentPlaceholderBase
    {
        private InteractablePlaceholder interactionPlaceholder;
        protected InteractablePlaceholder InteractionPlaceholder
        {
            get
            {
                if (interactionPlaceholder == null)
                {
                    interactionPlaceholder = GetComponentInChildren<InteractablePlaceholder>(true);
                }
                return interactionPlaceholder;
            }
        }
    }
}
