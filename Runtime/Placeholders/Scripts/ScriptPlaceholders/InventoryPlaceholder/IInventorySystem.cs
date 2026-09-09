using Virtuademy.SDK.Core.SystemFramework;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IInventorySystem : ISystem
    {
        public void Spawn();
        public void Spawn(Transform container);

        public void CreateItemSlots(int value);

        public void DisplayItemCount(bool value);

        public void ShowInventory(bool value);
    }
}
