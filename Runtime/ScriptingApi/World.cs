using System;

namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// The entry point an authored script uses to reach the world it runs in.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This assembly is the <b>only</b> first-party assembly an interpreted script may reference.
    /// The server-side whitelist (<c>policy.json</c> in <c>SPACS-Virtuademy/DllVerification</c>)
    /// allows the assembly name <c>Virtuademy.Environments.ScriptingApi</c> and the matching
    /// namespace prefix, and denies <c>Virtuademy.SDK</c>, <c>Virtuademy.CreatorKit</c>,
    /// <c>Virtuademy.Worlds</c>, <c>Virtuademy.Core</c> and <c>Virtuademy.ClientModels</c>
    /// outright. So whatever is not on this surface is not reachable from a script, and adding a
    /// member here is the only way to widen what scripts can do.
    /// </para>
    /// <para>
    /// <b>Nothing here introduces a capability the platform did not already grant.</b> Every member
    /// wraps something an authored Visual Scripting graph can already do through a shipped node —
    /// the graph and the script get the same reach, which is why this surface needs no separate
    /// capability review, only a review of the mechanism.
    /// </para>
    /// <para>
    /// <b>Three constraints the whitelist and the interpreter put on the shape of this API.</b>
    /// The policy denies the <c>System.Threading</c> prefix, so an interpreted script cannot name
    /// <c>Task</c> and cannot use <c>async</c>/<c>await</c> — anything asynchronous here takes a
    /// callback or is driven by a coroutine, never a <c>Task</c>. No type from another first-party
    /// assembly may appear in a signature, even indirectly: the surface is limited to primitives,
    /// types this namespace declares, and <c>UnityEngine</c> types. And there are no generic
    /// members, because a generic instantiated only from interpreted code has no AOT counterpart
    /// and fails at load rather than at compile time.
    /// </para>
    /// <para>
    /// <b>Availability.</b> The implementation is installed by the world runtime at startup, before
    /// the first scene loads. A script running in a project where that runtime is absent gets an
    /// <see cref="InvalidOperationException"/> naming the group it asked for, rather than a null
    /// reference. Each call resolves the system it needs at the moment it is made — exactly as the
    /// equivalent node does — so calling before the platform has finished booting fails the same
    /// way a graph would, and not more gracefully.
    /// </para>
    /// </remarks>
    public static class World
    {
        private static IWorldBackend backend;

        /// <summary>
        /// Whether the world runtime is present. False in a project that ships this scripting
        /// surface without the platform behind it.
        /// </summary>
        public static bool IsAvailable => backend != null;

        /// <summary>The local player: where they are, what they can do, what is visible.</summary>
        public static IPlayerApi Player
        {
            get
            {
                IPlayerApi api = backend?.Player;
                if (api == null)
                {
                    throw Unavailable(nameof(Player));
                }

                return api;
            }
        }

        /// <summary>The active language and the strings authored against it.</summary>
        public static ILocalizationApi Localization
        {
            get
            {
                ILocalizationApi api = backend?.Localization;
                if (api == null)
                {
                    throw Unavailable(nameof(Localization));
                }

                return api;
            }
        }

        /// <summary>Read-only facts about the session this world is running in.</summary>
        public static ISessionApi Session
        {
            get
            {
                ISessionApi api = backend?.Session;
                if (api == null)
                {
                    throw Unavailable(nameof(Session));
                }

                return api;
            }
        }

        /// <summary>
        /// Installs the implementation. Internal by design: a script can reference this assembly in
        /// full, so a public installer would let one script replace the surface every other script
        /// is calling. Only the world runtime can call it, and the compiler enforces that.
        /// </summary>
        internal static void Install(IWorldBackend implementation)
        {
            backend = implementation ?? throw new ArgumentNullException(nameof(implementation));
        }

        private static InvalidOperationException Unavailable(string group)
        {
            return new InvalidOperationException(
                $"World.{group} is not available: the Virtuademy world runtime is not present in " +
                "this project, or it has not finished starting up. Check World.IsAvailable first " +
                "if the script can run outside a world.");
        }
    }
}
