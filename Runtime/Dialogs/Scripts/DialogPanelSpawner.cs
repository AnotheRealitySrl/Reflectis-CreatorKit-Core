using Virtuademy.SDK.Dialogs;
using UnityEngine;

namespace Virtuademy.SDK.Environments.Dialogs
{
    public class DialogPanelSpawner : MonoBehaviour
    {
        public float charactersPerSecond;
        public float interpunctuationDelay;
        public bool enableSkip;
        public bool quickSkip;
        public int skipSpeedup;
        public bool showPlayerNickname;
        public bool useReflectisNickname;
        public bool showNpcNickname;
        public bool useReflectisAvatar;
        public bool showPlayerAvatarContainer;
        public bool showNpcAvatarContainer;

        private async void Awake()
        {
            // Instantiates dialog panel as addressable item.
            GameObject go = await VirtuademyFramework.Current.SpawnProjectAsset("DialogPanel", this.transform);
            DialogPanelControllerGeneric dialogPanelController = go.GetComponent<DialogPanelControllerGeneric>();
            // Applies setting values and initializes dialog panel.
            dialogPanelController.SetSettings(
                charactersPerSecond,
                interpunctuationDelay,
                enableSkip,
                quickSkip,
                skipSpeedup,
                showPlayerNickname,
                showNpcNickname,
                showPlayerAvatarContainer,
                showNpcAvatarContainer,
                useReflectisNickname,
                useReflectisAvatar);
            dialogPanelController.Init();
        }

    }
}
