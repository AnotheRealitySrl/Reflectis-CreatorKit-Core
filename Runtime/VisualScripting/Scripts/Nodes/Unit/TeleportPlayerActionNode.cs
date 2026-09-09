using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Character: Teleport")]
    [UnitSurtitle("Character")]
    [UnitShortTitle("Teleport")]
    [UnitCategory("Reflectis\\Flow")]
    public class TeleportPlayerActionNode : Unit
    {
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput InputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput OutputTrigger { get; private set; }

        [NullMeansSelf]
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput TransformVal { get; private set; }

        private List<Flow> runningFlows = new List<Flow>();

        protected override void Definition()
        {
            TransformVal = ValueInput<Transform>(nameof(TransformVal));

            InputTrigger = ControlInputCoroutine(nameof(InputTrigger), TeleportPlayerCoroutine);

            OutputTrigger = ControlOutput(nameof(OutputTrigger));

            Succession(InputTrigger, OutputTrigger);
        }

        private IEnumerator TeleportPlayerCoroutine(Flow flow)
        {
            runningFlows.Add(flow);

            VirtuademyFramework.Current.FadeToBlack(() =>
            {
                VirtuademyFramework.Current.MovePlayer(new Pose(flow.GetValue<Transform>(TransformVal).position, flow.GetValue<Transform>(TransformVal).rotation));
                VirtuademyFramework.Current.FadeFromBlack(() => runningFlows.Remove(flow));
            });

            yield return new WaitUntil(() => !runningFlows.Contains(flow));

            yield return OutputTrigger;
        }
    }
}
