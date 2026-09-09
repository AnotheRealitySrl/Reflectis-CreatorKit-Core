using Virtuademy.SDK.Environments.Placeholders;

using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
{
    [RequireComponent(typeof(Camera))]
    public class MapCameraPlaceholder : SceneComponentPlaceholderBase
    {
        public Camera Cam => GetComponent<Camera>();

        private void Awake()
        {
            Cam.enabled = false;
        }
    }
}