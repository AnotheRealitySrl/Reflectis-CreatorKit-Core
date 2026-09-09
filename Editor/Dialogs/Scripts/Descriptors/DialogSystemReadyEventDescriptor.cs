using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(DialogSystemReadyEventNode))]
    public class DialogSystemReadyEventDescriptor : EventUnitDescriptor<DialogSystemReadyEventNode>
    {
        public DialogSystemReadyEventDescriptor(DialogSystemReadyEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered right after the referenced Dialog System " +
                "is done with its initial setup.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
