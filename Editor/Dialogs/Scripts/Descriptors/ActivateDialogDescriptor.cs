using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(ActivateDialogNode))]
    public class ActivateDialogDescriptor : UnitDescriptor<ActivateDialogNode>
    {
        public ActivateDialogDescriptor(ActivateDialogNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This unit will activate a dialog sequence from the target Talkable " +
                "component.\n" +
                "The dialog sequence will start from the dialog part currently " +
                "referenced on the Talkable component.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "Talkable":
                    description.summary = "The Talkable component that will activate the dialog.";
                    break;
            }
        }
    }
}
