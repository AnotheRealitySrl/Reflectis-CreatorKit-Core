using Virtuademy.SDK.Environments.Placeholders;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Virtuademy.SDK.Environments.Placeholders
{
    public class AddOpenHelpOnActionPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField]
        private InputActionReference vrInput;
        [SerializeField]
        private InputActionReference desktopInput;
        [SerializeField]
        private InputActionReference mobileInput;

        public InputActionReference VrInput { get => vrInput; set => vrInput = value; }
        public InputActionReference DesktopInput { get => desktopInput; set => desktopInput = value; }
        public InputActionReference MobileInput { get => mobileInput; set => mobileInput = value; }
    }
}
