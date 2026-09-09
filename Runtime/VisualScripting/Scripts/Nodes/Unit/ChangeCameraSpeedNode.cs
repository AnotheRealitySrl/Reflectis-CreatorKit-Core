using Unity.VisualScripting;

namespace Virtuademy.SDK.Environments.VisualScripting
{
    [UnitTitle("Reflectis Camera: ChangeCameraSpeed")]
    [UnitSurtitle("Camera")]
    [UnitShortTitle("ChangeCameraSpeed")]
    [UnitCategory("Reflectis\\Flow")]
    public class ChangeCameraSpeedNode : Unit
    {
        [NullMeansSelf]
        public ValueInput XSpeed { get; private set; }

        [NullMeansSelf]
        public ValueInput YSpeed { get; private set; }

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput inputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput outputTrigger { get; private set; }

        protected override void Definition()
        {
            XSpeed = ValueInput<float>(nameof(XSpeed), 15f);
            YSpeed = ValueInput<float>(nameof(YSpeed), 15f);

            inputTrigger = ControlInput(nameof(inputTrigger), Output);
            outputTrigger = ControlOutput("outputTrigger");
            Succession(inputTrigger, outputTrigger);

        }

        private ControlOutput Output(Flow flow)
        {
            VirtuademyFramework.Current.ChangeCameraSpeed(flow.GetValue<float>(XSpeed), flow.GetValue<float>(YSpeed));
            return outputTrigger;
        }
    }
}
