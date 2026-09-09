using System.Collections.Generic;

using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Networking: Get current network time")]
    [UnitSurtitle("NetworkTime")]
    [UnitShortTitle("Get Network Time")]
    [UnitCategory("Reflectis\\Get")]
    public class GetCurrentNetworkTime : Unit
    {
        [NullMeansSelf]
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput NetworkedTime { get; private set; }

        private List<Flow> runningFlows = new List<Flow>();

        protected override void Definition()
        {
            NetworkedTime = ValueOutput<double>(nameof(NetworkedTime), f => VirtuademyFramework.Current.SharedNetworkTime);
        }
    }
}
