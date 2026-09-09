using Virtuademy.SDK.Environments.Placeholders;

using Unity.VisualScripting;
using UnityEngine;

namespace Virtuademy.SDK.Environments.VisualScripting
{
    [UnitTitle("Reflectis interactable: SetFocusedInteractable")]
    [UnitSurtitle("Interactable")]
    [UnitShortTitle("SetFocusedInteractable")]
    [UnitCategory("Reflectis\\Flow")]
    public class SetFocusedInteractableNode : Unit
    {
        [NullMeansSelf]
        public ValueInput Interactable { get; private set; }

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput inputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput outputTrigger { get; private set; }

        protected override void Definition()
        {
            inputTrigger = ControlInput(nameof(inputTrigger), Output);
            outputTrigger = ControlOutput("outputTrigger");
            Interactable = ValueInput<ManipulablePlaceholder>(nameof(Interactable), null).NullMeansSelf();

            Succession(inputTrigger, outputTrigger);
            Succession(inputTrigger, outputTrigger);

        }

        private ControlOutput Output(Flow flow)
        {
            //VirtuademyFramework.Current.ChangeCameraSpeed(flow.GetValue<ManipulablePlaceholder>(Interactable));
            return outputTrigger;
        }
    }
}
