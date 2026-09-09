using Virtuademy.SDK.Core;
using Virtuademy.SDK.Core.CharacterController;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class InputFunctionSetter : MonoBehaviour
    {
        public void SetDefaultInputs()
        {
            VirtuademyFramework.Current.ApplyDefaultInputSettings();
        }

        public void SetStaticCamera ()
        {
            InputSettings newInput = new InputSettings(false, false, false, false, false);
            VirtuademyFramework.Current.DisableAllInputButCamera(newInput);
        }

        public void SetRotationCamera(bool constrainedRotation)
        {
            InputSettings newInput = new InputSettings(true, false, false, false, constrainedRotation);
            VirtuademyFramework.Current.DisableAllInputButCamera(newInput);
        }
    }
}
