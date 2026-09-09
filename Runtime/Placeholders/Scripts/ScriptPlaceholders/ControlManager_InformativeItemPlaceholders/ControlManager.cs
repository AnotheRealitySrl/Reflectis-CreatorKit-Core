using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Virtuademy.CreatorKit.Worlds.Placeholders
{
    public class ControlManager : MonoBehaviour
    {
        public List<InformativeItem_Abstract> informativeItems = new List<InformativeItem_Abstract>();

        public UnityEvent onControlEnd;

        public void StartTaskAtIndex(int i)
        {
            informativeItems[i].StartTask();
        }

        public void CallControlEnd()
        {
            onControlEnd?.Invoke();
        }
    }
}
