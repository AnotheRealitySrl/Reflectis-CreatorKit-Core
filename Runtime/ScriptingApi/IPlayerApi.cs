using UnityEngine;

namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// The local player. Every member here has a shipped Visual Scripting node behind it, named in
    /// the remarks so the two surfaces can be kept honest with each other.
    /// </summary>
    public interface IPlayerApi
    {
        /// <summary>
        /// The character's transform. Null before the avatar exists — early in a scene, or in a
        /// world the player has not been embodied into yet.
        /// </summary>
        /// <remarks>Node: <c>Reflectis CMUser: Get Character Transform</c>.</remarks>
        Transform Root { get; }

        /// <summary>The head transform, for anything that has to follow the player's gaze.</summary>
        /// <remarks>Node: <c>Reflectis CMUser: Get Character Head Transform</c>.</remarks>
        Transform Head { get; }

        /// <summary>The left interactor transform. Null on platforms with no hands.</summary>
        /// <remarks>Node: <c>Reflectis CMUser: Get Character Left Hand</c>.</remarks>
        Transform LeftHand { get; }

        /// <summary>The right interactor transform. Null on platforms with no hands.</summary>
        /// <remarks>Node: <c>Reflectis CMUser: Get Character Right Hand</c>.</remarks>
        Transform RightHand { get; }

        /// <summary>
        /// Moves the player to <paramref name="destination"/>, fading to black and back so the cut
        /// is not jarring. <paramref name="onArrived"/> runs once the fade has finished; the fade is
        /// why this is not instantaneous and why it reports completion instead of returning.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Character: Teleport</c>.</remarks>
        void Teleport(Transform destination, System.Action onArrived = null);

        /// <summary>
        /// Moves the player to an explicit pose, with the same fade as
        /// <see cref="Teleport(Transform, System.Action)"/>. For destinations a script computes
        /// rather than reads off a scene object.
        /// </summary>
        void Teleport(Vector3 position, Quaternion rotation, System.Action onArrived = null);

        /// <summary>
        /// Enables or disables the player's own movement input. Disabling it does not freeze the
        /// camera — use it for a cutscene the player watches from where they stand.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Character: Enable Movement</c>.</remarks>
        void EnableMovement(bool enable);

        /// <summary>
        /// Shows or hides the local player's own avatar meshes. Half-body avatars show hands only,
        /// so this is what a script uses to get the player's own body out of a close-up shot.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Character: Enable Mesh</c>.</remarks>
        void ShowOwnAvatar(bool visible);

        /// <summary>
        /// Shows or hides everybody else's avatars. Affects rendering only — the other players are
        /// still there and still hear the room.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Scene: Enable Other Players</c>.</remarks>
        void ShowOtherAvatars(bool visible);

        /// <summary>Switches to the first-person camera.</summary>
        /// <remarks>Node: <c>Reflectis Character: Set First Person Camera Mode</c>.</remarks>
        void SetFirstPersonCamera();

        /// <summary>Switches to the third-person camera.</summary>
        /// <remarks>Node: <c>Reflectis Character: Set Third Person Camera Mode</c>.</remarks>
        void SetThirdPersonCamera();
    }
}
