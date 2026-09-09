using Virtuademy.SDK.Core;
using Virtuademy.SDK.Core.CharacterController;
using Virtuademy.SDK.Core.SystemFramework;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class InputFunctionSetter : MonoBehaviour
    {
        public void SetDefaultInputs()
        {
            SM.GetSystem<ICharacterControllerSystem>().SetDefaultSettingsAsActive();
        }

        public void SetStaticCamera ()
        {
            InputSettings newInput = new InputSettings(false, false, false, false, false);
            SM.GetSystem<ICharacterControllerSystem>().DisableAllButCamera(newInput);
        }

        public void SetRotationCamera(bool constrainedRotation)
        {
            InputSettings newInput = new InputSettings(true, false, false, false, constrainedRotation);
            SM.GetSystem<ICharacterControllerSystem>().DisableAllButCamera(newInput);
        }
    }
}
