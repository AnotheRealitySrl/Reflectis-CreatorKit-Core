using Virtuademy.SDK.Core;
using Virtuademy.SDK.Core.CharacterController;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class InputFunctionSetter : MonoBehaviour
    {
        public void SetDefaultInputs()
        {
            WorldServices.Get<ICharacterControllerSystem>().SetDefaultSettingsAsActive();
        }

        public void SetStaticCamera ()
        {
            InputSettings newInput = new InputSettings(false, false, false, false, false);
            WorldServices.Get<ICharacterControllerSystem>().DisableAllButCamera(newInput);
        }

        public void SetRotationCamera(bool constrainedRotation)
        {
            InputSettings newInput = new InputSettings(true, false, false, false, constrainedRotation);
            WorldServices.Get<ICharacterControllerSystem>().DisableAllButCamera(newInput);
        }
    }
}
