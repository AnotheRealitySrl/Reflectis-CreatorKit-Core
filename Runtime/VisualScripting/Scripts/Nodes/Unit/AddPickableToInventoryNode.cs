using Virtuademy.SDK.Environments.Placeholders;

using Unity.VisualScripting;
using UnityEngine;

namespace Virtuademy.SDK.Environments.VisualScripting
{
    [UnitTitle("Reflectis inventory: AddPickableToInventoryNode")]
    [UnitSurtitle("Inventory")]
    [UnitShortTitle("AddPickableToInventoryNode")]
    [UnitCategory("Reflectis\\Flow")]
    public class AddPickableToInventoryNode : Unit
    {
        [NullMeansSelf]
        public ValueInput Pickable { get; private set; }

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput inputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput outputTrigger { get; private set; }

        [NullMeansSelf]
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput Added { get; private set; }
        private bool _addedValue; // ? variabile di istanza per passare il valore

        protected override void Definition()
        {
            inputTrigger = ControlInput(nameof(inputTrigger), Output);
            outputTrigger = ControlOutput("outputTrigger");

            Pickable = ValueInput<PickablePlaceholder>(nameof(Pickable), null).NullMeansSelf();
            Added = ValueOutput<bool>(nameof(Added), (f) => _addedValue);

            Succession(inputTrigger, outputTrigger);
            Succession(inputTrigger, outputTrigger);

        }

        private ControlOutput Output(Flow flow)
        {
            _addedValue = VirtuademyFramework.Current.AddPickableToInventory(flow.GetValue<PickablePlaceholder>(Pickable));
            return outputTrigger;
        }
    }
}
