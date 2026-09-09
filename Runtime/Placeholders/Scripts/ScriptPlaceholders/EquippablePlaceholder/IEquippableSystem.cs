using Virtuademy.SDK.Core.SystemFramework;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IEquippableSystem : ISystem
    {
        public bool AddItemToContainerInventory(PickablePlaceholder _pickable);

        public void DisplayFeedback(Transform spawnTransform, bool value);

        public void HoveredDetector();

        public void UnHoveredDetector();

        public void EquipItem(IPickable equippingPickable);

        public void RemoveItem(IPickable unequipPickable);
    }
}
