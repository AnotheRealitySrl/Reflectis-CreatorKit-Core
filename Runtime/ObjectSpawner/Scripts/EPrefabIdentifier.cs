﻿
namespace Virtuademy.CreatorKit.Worlds.Core.ObjectSpawner
{
    /// <summary>
    /// The platform's own spawnable prefabs, named so a world can ask for one.
    /// </summary>
    /// <remarks>
    /// <b>It was nested inside <c>IObjectSpawnerSystem</c> until 2026-09-09.</b> That mattered
    /// because <c>Assets/_Project/ObjectSpawner/ScriptableObjects/ReflectisPrefabPool.asset</c>
    /// serializes its dictionary's key type by name and assembly, and the name it stored was
    /// <c>...ObjectSpawner.IObjectSpawnerSystem+EPrefabIdentifier, Virtuademy.CreatorKit.Worlds.Core</c>.
    /// Lifting the enum changed that string, so the asset was migrated in the same commit. The
    /// namespace and the assembly are deliberately unchanged, which is why the migration is one
    /// substitution and not a rewrite.
    /// <para>
    /// It stays in the authoring package while <c>IObjectSpawnerSystem</c> moved to the main
    /// project: this is a value a world is authored against, and the system that honours it is the
    /// application's.
    /// </para>
    /// </remarks>
    public enum EPrefabIdentifier
    {
        Downloaded3DModel,
        VideoPlayer,
        PresentationPlayer,
        ImagePlayer,
        BigScreen,
        DrawableBoard,
        Drawing,
        VideoChat,
        TextBox,
        GeneralContainer,
        AvatarStandard,
        AvatarXR,
        ChatBot,
        Quiz,
        Skybox
    }
}
