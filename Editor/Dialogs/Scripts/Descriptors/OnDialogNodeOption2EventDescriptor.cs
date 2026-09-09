using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeOption2EventNode))]
    public class OnDialogNodeOption2EventDescriptor : EventUnitDescriptor<OnDialogNodeOption2EventNode>
    {
        public OnDialogNodeOption2EventDescriptor(OnDialogNodeOption2EventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the Dialog System passes through " +
                "the Option 2 exit of the referenced Dialog Part.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
