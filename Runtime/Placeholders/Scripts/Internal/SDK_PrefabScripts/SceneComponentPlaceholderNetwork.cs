using Virtuademy.SDK.Environments.Placeholders;

using UnityEngine;
using UnityEngine.Serialization;

namespace Virtuademy.SDK.Environments.Placeholders
{
    public class SceneComponentPlaceholderNetwork : SceneComponentPlaceholderBase, INetworkPlaceholder
    {
        [field: SerializeField, FormerlySerializedAs("isNetworked")] public bool IsNetworked { get; set; }
    }
}
