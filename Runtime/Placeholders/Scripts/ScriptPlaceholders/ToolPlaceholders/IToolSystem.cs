using Virtuademy.CreatorKit.Worlds.Placeholders;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IToolSystem
    {
        public void InstantiateInventory(ToolInventoryPlaceholder inventoryPlaceholder);

        public void SetInventoryAlpha(float value);

        public bool AddItemToInventory(ToolItemPlaceholder _placeholder);
    }
}
