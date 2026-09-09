namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// Read-only facts about the session the world is running in. Nothing here mutates the session:
    /// a script may branch on what kind of session it is in, and may not change it.
    /// </summary>
    public interface ISessionApi
    {
        /// <summary>
        /// The id of the session, as the platform knows it. Empty outside a session — a world opened
        /// from the editor, for instance.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Networking: Get Local Player ID</c>, which reads the same value.</remarks>
        string SessionId { get; }

        /// <summary>Whether other people can be in this session at all.</summary>
        bool IsMultiplayer { get; }

        /// <summary>
        /// Whether this client is the one the others follow for authoritative decisions. False in a
        /// single-player session, where there is nobody to be master of — check
        /// <see cref="IsMultiplayer"/> first if the distinction matters.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Network: IsMaster</c>.</remarks>
        bool IsMasterClient { get; }

        /// <summary>How many players are currently connected, including this one.</summary>
        int PlayerCount { get; }

        /// <summary>
        /// A clock every client in the session agrees on, for anything that has to look
        /// simultaneous. Falls back to local time when the session is not multiplayer or the world
        /// is running offline, so it is always safe to read and only meaningful to *compare* between
        /// clients when <see cref="IsMultiplayer"/> is true.
        /// </summary>
        /// <remarks>Node: <c>Reflectis Networking: Get current network time</c>.</remarks>
        double NetworkTime { get; }
    }
}
