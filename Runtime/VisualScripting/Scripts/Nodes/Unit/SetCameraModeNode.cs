

using System.Collections.Generic;

using Unity.VisualScripting;
using System;
using System.Reflection;
using System.Linq;

namespace Virtuademy.SDK.Environments.VisualScripting
{
    [UnitTitle("Reflectis Camera: Set camera mode")]
    [UnitSurtitle("SetCameraMode")]
    [UnitShortTitle("Set Camera Mode")]
    [UnitCategory("Reflectis\\Flow")]
    public class SetCameraModeNode : Unit
    {
        [NullMeansSelf]
        [DoNotSerialize]
        public ValueInput ConstrainedRotation { get; private set; }

        [NullMeansSelf]
        [DoNotSerialize]
        public ValueInput StaticCamera { get; private set; }


        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput InputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput OutputTrigger { get; private set; }

        protected override void Definition()
        {
            ConstrainedRotation = ValueInput<bool>(nameof(ConstrainedRotation),false).NullMeansSelf();
            StaticCamera = ValueInput<bool>(nameof(StaticCamera), false).NullMeansSelf();
            InputTrigger = ControlInput(nameof(InputTrigger), (f) =>
            {               
                    bool constrainRotation = f.GetValue<bool>(ConstrainedRotation);
                    if (f.GetValue<bool>(StaticCamera))
                    {
                        VirtuademyFramework.Current.UseStaticCameraInput(constrainRotation);
                    }
                    else
                    {
                        VirtuademyFramework.Current.UseFreeCameraInput(constrainRotation);
                    }
                    return OutputTrigger;
            });
           

            OutputTrigger = ControlOutput(nameof(OutputTrigger));

            Succession(InputTrigger, OutputTrigger);
        }

    }
}
