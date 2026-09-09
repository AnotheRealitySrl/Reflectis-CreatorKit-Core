using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class DrawableBoardPlaceholder : SceneComponentPlaceholderNetwork
    {
        [SerializeField] private Collider drawableArea;
        [SerializeField] private Transform drawingProjectionTransform;

        public Collider DrawableArea => drawableArea;
        public Transform DrawingProjectionTransform => drawingProjectionTransform;
    }
}

