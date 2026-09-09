using Virtuademy.SDK.Core.SystemFramework;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IGeneralInventorySystem : ISystem
    {
        public void SpawnInventories();

        public void DisplayAddedItem(Sprite sprite, string text, bool wearable);
    }
}
