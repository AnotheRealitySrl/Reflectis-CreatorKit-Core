using System;

using UnityEngine;

namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// The world around the script: its placeholders, the objects spawned into it, its transitions,
    /// and the way out of it.
    /// </summary>
    public interface ISceneApi
    {
        /// <summary>
        /// Resolves the placeholders on <paramref name="target"/> — turning the authored stand-ins
        /// into the real thing — optionally on its children too.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Placeholder: Initialize Placeholder</c>.</remarks>
        void InitializePlaceholders(GameObject target, bool includeChildren = false);

        /// <summary>
        /// Shows or hides the objects spawned into the world. <paramref name="except"/> is left
        /// alone, which is how a script keeps the object it is attached to visible.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Scene: Enable Spawned Objects</c>.</remarks>
        void ShowSpawnedObjects(bool visible, GameObject except = null);

        /// <summary>
        /// Runs the transition an object provides, entering it or leaving it. Which component
        /// provides a transition is the application's business.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Transition Provider: Do Transition</c>.</remarks>
        void RunTransition(GameObject target, bool enter);

        /// <summary>
        /// Leaves this world and returns to the lobby. Nothing after this call is guaranteed to
        /// run: the scene is on its way out.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Platform: Load Lobby</c>.</remarks>
        void ReturnToLobby();
    }
}
