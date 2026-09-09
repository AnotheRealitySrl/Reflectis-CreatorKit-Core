using System;

using UnityEngine;

namespace Virtuademy.SDK.Environments.ClientModels
{
    [Serializable]
    public class CMPermission
    {
        public enum EFacetIdentifier
        {
            Unknown = 0,
            MuteOthers = 1,
            KickOthers = 2,
            UseTools = 3,
            SpawnFiles = 7,
            SendGlobalAndShardMessages = 12,
            SendAnnouncementMessages = 14,
            ManageMyExperiencesAndSessions = 15,
            EnableSpeaker = 16,
            UseAuthoringTool = 17,
            InteractWithAllObjects = 18,
            UseVoiceChat = 19,
            ManageMyEvents = 20,
            ManageMySessions = 21,
            ManageMyAuthoredExperiences = 22,
            ShowCatalogTab = 23,
            // Plural, because the platform's identifier is. As ShowLeaderboard this never matched
            // the string the server sends, so ClientModelSystem logged "Invalid facet identifier:
            // ShowLeaderboards" and dropped it on every boot — the permission has never once been
            // granted to a Unity client.
            ShowLeaderboards = 24,
            UseEmotes = 25,
            ShowLogo = 26,
            ShowTutorialButton = 27,
            EnableDoubleUserConnection = 28,
            ShowCompleteName = 29,
            UploadAssetsFolders = 30,
            ReadSharedAssetsFolders = 31,
            ManageSharedAssetsFolders = 32,
            GenerateAI3DAssets = 33
        }


        [SerializeField] private int tagId;
        [SerializeField] private int facetId;
        [SerializeField] private string facetLabel;
        [SerializeField] private EFacetIdentifier facetIdentifier;
        [SerializeField] private string facetGroup;
        [SerializeField] private bool overridableInEvent;
        [SerializeField] private bool isEnabled;

        public int TagId { get => tagId; set => tagId = value; }
        public int FacetId { get => facetId; set => facetId = value; }
        public string FacetLabel { get => facetLabel; set => facetLabel = value; }
        public EFacetIdentifier FacetIdentifier { get => facetIdentifier; set => facetIdentifier = value; }
        public string FacetGroup { get => facetGroup; set => facetGroup = value; }
        public bool OverridableInEvent { get => overridableInEvent; set => overridableInEvent = value; }
        public bool IsEnabled { get => isEnabled; set => isEnabled = value; }
    }
}
