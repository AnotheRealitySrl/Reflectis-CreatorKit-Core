using Virtuademy.SDK.Core.CharacterController;

using Unity.VisualScripting;
using Virtuademy.SDK.Core;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Character: Enable Movement")]
    [UnitSurtitle("Character")]
    [UnitShortTitle("Enable Movement")]
    [UnitCategory("Reflectis\\Flow")]
    public class EnableCharacterMovementNode : Unit
    {
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput InputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput OutputTrigger { get; private set; }

        [NullMeansSelf]
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput Enable { get; private set; }

        protected override void Definition()
        {
            Enable = ValueInput<bool>(nameof(Enable));

            InputTrigger = ControlInput(nameof(InputTrigger), (f) =>
            {
                InputSettings currentUserSettings = WorldServices.Get<ICharacterControllerSystem>().GetCurrentSettings();

                WorldServices.Get<ICharacterControllerSystem>().EnableCharacterMovement(f.GetValue<bool>(Enable), currentUserSettings);
                return OutputTrigger;
            });

            OutputTrigger = ControlOutput(nameof(OutputTrigger));

            Succession(InputTrigger, OutputTrigger);
        }
    }
}
