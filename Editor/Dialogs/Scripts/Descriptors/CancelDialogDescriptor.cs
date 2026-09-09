using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(CancelDialogNode))]
    public class CancelDialogDescriptor : UnitDescriptor<CancelDialogNode>
    {
        public CancelDialogDescriptor(CancelDialogNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This unit will cancel the current dialog sequence managed by the " +
                "target Dialog System. The sequence will be interrupted, even if it " +
                "hasn't yet received the final node in a dialog path.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "DialogSystem":
                    description.summary = "The dialog system that should cancel its current " +
                        "dialog sequence.";
                    break;
            }
        }
    }
}
