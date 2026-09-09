using Virtuademy.CreatorKit.Worlds.Core.Placeholders;

using UnityEngine;
using UnityEngine.Serialization;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class SceneComponentPlaceholderNetwork : SceneComponentPlaceholderBase, INetworkPlaceholder
    {
        [field: SerializeField, FormerlySerializedAs("isNetworked")] public bool IsNetworked { get; set; }
    }
}
