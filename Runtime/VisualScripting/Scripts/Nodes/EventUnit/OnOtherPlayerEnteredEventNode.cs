using Virtuademy.SDK.Core;
using Virtuademy.SDK.Core.VisualScripting;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace Virtuademy.SDK.Environments.VisualScripting
{
    [UnitTitle("Reflectis Networking: On Other Player Entered")]
    [UnitSurtitle("Networking")]
    [UnitShortTitle("On Other Player Entered")]
    [UnitCategory("Events\\Reflectis")]
    public class OnOtherPlayerEnteredEventNode : UnityEventUnit<(int, string), PlayerData>
    {
        public static string eventName = "NetworkingOnOtherPlayerEntered";

        [DoNotSerialize]
        public ValueOutput UserId { get; private set; }
        [DoNotSerialize]
        public ValueOutput SessionId { get; private set; }
        protected override bool register => true;

        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(eventName);
        }

        protected override void Definition()
        {
            base.Definition();
            UserId = ValueOutput<int>(nameof(UserId));
            SessionId = ValueOutput<string>(nameof(SessionId));
        }

        protected override void AssignArguments(Flow flow, (int, string) args)
        {
            flow.SetValue(UserId, args.Item1);
            flow.SetValue(SessionId, args.Item2);
        }


        protected override UnityEvent<PlayerData> GetEvent(GraphReference reference)
        {
            return VirtuademyFramework.Current.OtherPlayerEntered;
        }

        protected override (int, string) GetArguments(GraphReference reference, PlayerData playerData)
        {
            return (playerData.UserId, playerData.SessionId);
        }
    }
}
