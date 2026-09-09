using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public interface IGeneralInventorySystem
    {
        public void SpawnInventories();

        public void DisplayAddedItem(Sprite sprite, string text, bool wearable);
    }
}
