using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeOption1EventNode))]
    public class OnDialogNodeOption1EventDescriptor : EventUnitDescriptor<OnDialogNodeOption1EventNode>
    {
        public OnDialogNodeOption1EventDescriptor(OnDialogNodeOption1EventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the Dialog System passes through " +
                "the Option 1 exit of the referenced Dialog Part.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
