using Virtuademy.CreatorKit.Worlds.Placeholders;
using Virtuademy.SDK.Core.SystemFramework;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IToolSystem : ISystem
    {
        public void InstantiateInventory(ToolInventoryPlaceholder inventoryPlaceholder);

        public void SetInventoryAlpha(float value);

        public bool AddItemToInventory(ToolItemPlaceholder _placeholder);
    }
}
