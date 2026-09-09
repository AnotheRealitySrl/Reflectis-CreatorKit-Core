using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(SetDialogNode))]
    public class SetDialogDescriptor : UnitDescriptor<SetDialogNode>
    {
        public SetDialogDescriptor(SetDialogNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This unit will change the Dialog Part reference set on the target " +
                "Talkable component. This will change the dialog node that will be used as " +
                "starting point for the next dialog sequence with the target Talkable entity.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "Talkable":
                    description.summary = "The Talkable component on which the dialog part " +
                        "reference should be changed.";
                    break;
                case "NewDialogPart":
                    description.summary = "The dialog part that will be set on the Talkable component.";
                    break;
            }
        }
    }
}
