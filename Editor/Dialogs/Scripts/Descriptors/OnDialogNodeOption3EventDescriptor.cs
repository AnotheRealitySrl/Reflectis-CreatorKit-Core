using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeOption3EventNode))]
    public class OnDialogNodeOption3EventDescriptor : EventUnitDescriptor<OnDialogNodeOption3EventNode>
    {
        public OnDialogNodeOption3EventDescriptor(OnDialogNodeOption3EventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the Dialog System passes through " +
                "the Option 3 exit of the referenced Dialog Part.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
