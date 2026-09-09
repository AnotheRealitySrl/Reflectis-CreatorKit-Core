using Virtuademy.SDK.Core.VisualScripting;

using System.Threading.Tasks;

using Unity.VisualScripting;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis Platform: Load Lobby")]
    [UnitSurtitle("Platform")]
    [UnitShortTitle("Load Lobby")]
    [UnitCategory("Reflectis\\Flow")]
    public class LoadDefaultEventNode : AwaitableUnit
    {
        protected override async Task AwaitableAction(Flow flow)
        {
            await VirtuademyFramework.Current.LoadLobby();
        }
    }
}
