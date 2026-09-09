using System;

using UnityEngine;

namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// Ownership of the objects a multiplayer session keeps in step. One client at a time may drive
    /// a synced object; this is how a script asks for that right, gives it back, and finds out when
    /// it changed hands.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Objects are addressed by their <see cref="GameObject"/>. The platform's own synced-object
    /// component cannot cross this boundary, and every caller has the GameObject anyway — a script
    /// reaches one through the scene, not through a registry.
    /// </para>
    /// <para>
    /// Nothing here is meaningful outside a multiplayer session. <see cref="IsOwnedLocally"/>
    /// reports true in a single-player one, because there is nobody to contend with; the two
    /// request methods do nothing and no event fires.
    /// </para>
    /// </remarks>
    public interface ISyncApi
    {
        /// <summary>
        /// Whether the local client may drive <paramref name="syncedObject"/> right now.
        /// </summary>
        /// <remarks>
        /// True when the session is single-player, or the object is not networked, or the local
        /// client holds ownership — the same three cases the node treats as "yes".
        /// <para>Node: <c>Reflectis Synced Object: Is Owned Locally</c>.</para>
        /// </remarks>
        bool IsOwnedLocally(GameObject syncedObject);

        /// <summary>
        /// Asks for ownership of <paramref name="syncedObject"/>. The answer arrives as
        /// <see cref="OwnerChanged"/> or <see cref="OwnershipRequestFailed"/>, never as a return
        /// value: another client has to agree, and that takes a round trip.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Synced Object: Try Get Ownership</c>.</remarks>
        void RequestOwnership(GameObject syncedObject);

        /// <summary>
        /// Gives ownership back, so another client can take it. A script that grabbed ownership to
        /// animate something should release it when the animation ends.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Synced Object: Release Ownership</c>.</remarks>
        void ReleaseOwnership(GameObject syncedObject);

        /// <summary>
        /// Raised when the local client has taken ownership of an object, carrying that object.
        /// This is the success half of <see cref="RequestOwnership"/>.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Synced Object: On Owner Changed</c>.</remarks>
        event Action<GameObject> OwnerChanged;

        /// <summary>
        /// Raised when the local client no longer owns an object — it was taken, or the client left
        /// the shard. Anything a script was driving on that object should stop here.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Synced Object: On Owner Lost</c>.</remarks>
        event Action<GameObject> OwnerLost;

        /// <summary>Raised when a request for ownership was refused.</summary>
        /// <remarks>Node: <c>Reflectis Synced Object: On Owner Request Failed</c>.</remarks>
        event Action<GameObject> OwnershipRequestFailed;
    }
}
