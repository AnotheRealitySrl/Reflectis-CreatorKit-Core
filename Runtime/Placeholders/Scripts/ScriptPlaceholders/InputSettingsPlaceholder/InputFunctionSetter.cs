using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
{
    public class InputFunctionSetter : MonoBehaviour
    {
        public void SetDefaultInputs()
        {
            VirtuademyFramework.Current.ApplyDefaultInputSettings();
        }

        public void SetStaticCamera ()
        {
            VirtuademyFramework.Current.UseStaticCameraInput(false);
        }

        public void SetRotationCamera(bool constrainedRotation)
        {
            VirtuademyFramework.Current.UseDragRotationCameraInput(constrainedRotation);
        }
    }
}
