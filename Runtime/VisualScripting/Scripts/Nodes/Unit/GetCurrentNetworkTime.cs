using Virtuademy.CreatorKit.Worlds.Core.ApplicationManagement;
using Virtuademy.CreatorKit.Worlds.Core.ClientModels;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

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
            NetworkedTime = ValueOutput<double>(nameof(NetworkedTime), f =>
            {
                if (IReflectisApplicationManager.Instance.State == SDK.Core.ApplicationManagement.EApplicationState.Online
                && VirtuademyFramework.Current.IsCurrentSessionMultiplayer)
                {
                    return VirtuademyFramework.Current.SharedNetworkTime;
                }
                return Time.time;
            });

        }
    }
}


