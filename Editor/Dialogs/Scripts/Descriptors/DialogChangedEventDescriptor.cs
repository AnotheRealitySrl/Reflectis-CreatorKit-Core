using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(DialogChangedEventNode))]
    public class DialogChangedEventDescriptor : EventUnitDescriptor<DialogChangedEventNode>
    {
        public DialogChangedEventDescriptor(DialogChangedEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered any time a node from the referenced " +
                "dialog system changes status. Returns as output the node that just " +
                "changed status.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "DialogSystemReference":
                    description.summary = "Dialog System that should be checked for any " +
                        "status change on one of its nodes.";
                    break;
                case "ChangedDialogNode":
                    description.summary = "Reference to the DialogNode that just changed status.";
                    break;
            }
        }
    }
}
