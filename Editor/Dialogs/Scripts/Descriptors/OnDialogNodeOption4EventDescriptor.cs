using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(OnDialogNodeOption4EventNode))]
    public class OnDialogNodeOption4EventDescriptor : EventUnitDescriptor<OnDialogNodeOption4EventNode>
    {
        public OnDialogNodeOption4EventDescriptor(OnDialogNodeOption4EventNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This event will be triggered when the Dialog System passes through " +
                "the Option 4 exit of the referenced Dialog Part.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
        }
    }
}
