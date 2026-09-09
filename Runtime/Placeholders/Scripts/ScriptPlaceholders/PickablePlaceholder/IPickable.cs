using Virtuademy.CreatorKit.Worlds.Core.Placeholders;
using System.Threading.Tasks;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IPickable
    {
        Task Init(SceneComponentPlaceholderBase placeholder);
        public string GetPickableName();
    }
}
