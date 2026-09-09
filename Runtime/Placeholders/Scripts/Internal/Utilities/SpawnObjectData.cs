using Virtuademy.CreatorKit.Worlds.Core.ObjectSpawner;

using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class SpawnObjectData : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private SpawnPosition spawnPosition;

        public GameObject Prefab { get => prefab; }
        public SpawnPosition SpawnPosition { get => spawnPosition; }
    }
}
