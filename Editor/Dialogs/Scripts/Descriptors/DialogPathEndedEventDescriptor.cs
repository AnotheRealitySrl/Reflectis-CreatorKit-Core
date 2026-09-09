using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(DialogPathEndedEventNode))]
    public class DialogPathEndedEventDescriptor : EventUnitDescriptor<DialogPathEndedEventNode>
    {
        public DialogPathEndedEventDescriptor(DialogPathEndedEventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the Dialog System completes " +
                "a dialog node that is at the end of a dialog sequence (i.e. a dialog " +
                "node that has no other nodes connected to it through one of its " +
                "exit ports).";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
