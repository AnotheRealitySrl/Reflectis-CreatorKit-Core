using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeInProgressEventNode))]
    public class OnDialogNodeInProgressEventDescriptor : EventUnitDescriptor<OnDialogNodeInProgressEventNode>
    {
        public OnDialogNodeInProgressEventDescriptor(OnDialogNodeInProgressEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the referenced Dialog Part gets " +
                "its state set to \"InProgress\" state. This happens whenever a " +
                "dialogue sequence reaches that part/node, and its content it's about " +
                "to be shown on the dialog UI.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
