using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeCompletedEventDescriptor))]
    public class OnDialogNodeCompletedEventDescriptor : EventUnitDescriptor<OnDialogNodeCompletedEventNode>
    {
        public OnDialogNodeCompletedEventDescriptor(OnDialogNodeCompletedEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the referenced Dialog Part gets " +
                "its state set to \"Completed\" state. This happens after a user " +
                "interaction that makes the dialog system leave the reference " +
                "Dialog Part/Node and enter one of the following connected parts (if one " +
                "is available).";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
