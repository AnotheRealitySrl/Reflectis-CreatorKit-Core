using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.Dialogs.Editor
{
    [Descriptor(typeof(ContinueDialogNode))]
    public class ContinueDialogDescriptor : UnitDescriptor<ContinueDialogNode>
    {
        public ContinueDialogDescriptor(ContinueDialogNode unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This unit will make a dialog sequence step into the next node, by " +
                "following a specific dialog option.";
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);

            switch (port.key)
            {
                case "DialogSystem":
                    description.summary = "The dialog system that should advance in its current " +
                        "dialog sequence.";
                    break;
                case "DialogOption":
                    description.summary = "The dialog option that should be followed to get to " +
                        "the next dialog node. \"0\" and \"1\" are equivalent and will both make " +
                        "the sequence go through the first option.";
                    break;
            }
        }
    }
}
