using Virtuademy.SDK.Environments.Placeholders;
using System.Threading.Tasks;
using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
{
    public interface IPickable
    {
        Task Init(SceneComponentPlaceholderBase placeholder);
        public string GetPickableName();
    }
}
