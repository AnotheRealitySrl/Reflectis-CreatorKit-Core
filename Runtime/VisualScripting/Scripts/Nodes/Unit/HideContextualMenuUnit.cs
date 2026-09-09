using Virtuademy.CreatorKit.Worlds.Core.Interaction;

using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis ContextualMenu: Hide")]
    [UnitSurtitle("ContextualMenu")]
    [UnitShortTitle("Hide")]
    [UnitCategory("Reflectis\\Flow")]

    public class HideContextualMenuUnit : Unit
    {
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput InputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput OutputTrigger { get; private set; }

        protected override void Definition()
        {
            InputTrigger = ControlInput(nameof(InputTrigger), (f) =>
            {
                WorldServices.Get<IContextualMenuSystem>().HideContextualMenu();
                return OutputTrigger;
            });

            OutputTrigger = ControlOutput(nameof(OutputTrigger));

            Succession(InputTrigger, OutputTrigger);
        }


    }
}
