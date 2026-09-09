using Virtuademy.CreatorKit.Worlds.Core.Placeholders;

using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class MascotteNameSetCheckPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField] private string mascotteName;

        public string MascotteName { get => mascotteName; set => mascotteName = value; }
    }
}
