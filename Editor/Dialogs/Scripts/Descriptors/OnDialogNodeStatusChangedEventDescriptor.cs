using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeStatusChangedEventNode))]
    public class OnDialogNodeStatusChangedEventDescriptor : EventUnitDescriptor<OnDialogNodeStatusChangedEventNode>
    {
        public OnDialogNodeStatusChangedEventDescriptor(OnDialogNodeStatusChangedEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered whenever the referenced Dialog Part gets " +
                "its state changed.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "DialogPartReference":
                    description.summary = "Dialog Part that should be checked for any " +
                        "status change.";
                    break;
                case "OldDialogStatus":
                    description.summary = "Status of the Dialog Part/Node before this change.";
                    break;
                case "NewDialogStatus":
                    description.summary = "Current status.";
                    break;
            }
        }
    }
}
