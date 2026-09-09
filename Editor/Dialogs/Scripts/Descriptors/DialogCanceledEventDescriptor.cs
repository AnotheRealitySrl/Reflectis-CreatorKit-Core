using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(DialogCanceledEventNode))]
    public class DialogCanceledEventDescriptor : EventUnitDescriptor<DialogCanceledEventNode>
    {
        public DialogCanceledEventDescriptor(DialogCanceledEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when a dialog sequence on the " +
                "referenced Dialog System gets canceled.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
