using Virtuademy.SDK.Environments.ObjectSpawner;

using UnityEngine;

namespace Virtuademy.SDK.Environments.Placeholders
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
