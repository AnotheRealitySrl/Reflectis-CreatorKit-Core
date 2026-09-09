using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeResetEventNode))]
    public class OnDialogNodeResetEventDescriptor : EventUnitDescriptor<OnDialogNodeResetEventNode>
    {
        public OnDialogNodeResetEventDescriptor(OnDialogNodeResetEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the referenced Dialog Part gets " +
                "its state reset to \"ToDo\" state. This happens whenever a dialogue " +
                "sequence involving this dialong part/node gets completed or canceled.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
