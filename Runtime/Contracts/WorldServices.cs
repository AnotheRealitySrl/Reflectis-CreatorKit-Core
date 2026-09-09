using System;

namespace Virtuademy.CreatorKit.Worlds
{
    /// <summary>
    /// Supplies the world contracts. Implemented by the application that hosts the world.
    /// </summary>
    public interface IWorldServiceProvider
    {
        /// <summary>
        /// The implementation registered for <typeparamref name="T"/>, or null when nothing provides
        /// it. <typeparamref name="T"/> is a contract from this package or from
        /// <c>Virtuademy.SDK.Interface</c> — never a concrete system type, which is exactly what the
        /// caller must not be able to name.
        /// </summary>
        T Get<T>() where T : class;
    }

    /// <summary>
    /// How an authored world reaches the things the platform provides: a placeholder asking for the
    /// inventory, a Visual Scripting node asking for the localization table.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>This exists so that this package names no part of the system framework.</b> Until now
    /// every node and placeholder called <c>SM.GetSystem&lt;T&gt;()</c> — 77 sites across 56 files —
    /// which meant the authoring package depended on the framework that hosts the app, and
    /// therefore on a package §1 of the plan does not give creators. Now the package declares
    /// *what* it needs and the app decides *how* to answer: the contracts are interfaces, and the
    /// implementations that deal with systems live only in the main project.
    /// </para>
    /// <para>
    /// It lives in namespace <c>Virtuademy.CreatorKit.Worlds</c>, the common ancestor of every
    /// namespace in this package, so all 56 call sites resolve it by namespace walk-up with no
    /// <c>using</c> added and none of them names a framework type any more.
    /// </para>
    /// <para>
    /// <b>Failure modes, and how they differ from before.</b> With no provider installed, `Get`
    /// throws <see cref="InvalidOperationException"/> saying so — previously the same situation gave
    /// a <see cref="NullReferenceException"/> one line later, inside whatever the caller did with
    /// the result. With a provider installed but nothing registered for the contract, `Get` returns
    /// null, which is exactly what the framework's own lookup did; a node dereferencing it fails as it
    /// always has, and that is deliberate — a world authored against the old behaviour must not
    /// start behaving differently here.
    /// </para>
    /// </remarks>
    public static class WorldServices
    {
        private static IWorldServiceProvider provider;

        /// <summary>Whether a host application has provided the world contracts yet.</summary>
        public static bool IsInstalled => provider != null;

        /// <summary>
        /// Registers the host application as the provider. Called once at startup by the app; a
        /// world's own content never calls this.
        /// </summary>
        public static void Install(IWorldServiceProvider worldServiceProvider)
        {
            provider = worldServiceProvider ?? throw new ArgumentNullException(nameof(worldServiceProvider));
        }

        /// <summary>
        /// The implementation of <typeparamref name="T"/>, or null when the host provides none.
        /// </summary>
        /// <exception cref="InvalidOperationException">No host application has installed a provider.</exception>
        public static T Get<T>() where T : class
        {
            if (provider == null)
            {
                throw new InvalidOperationException(
                    $"No world service provider is installed, so {typeof(T).Name} cannot be resolved. " +
                    "A Virtuademy application installs one at startup; check WorldServices.IsInstalled " +
                    "if this code can run outside one.");
            }

            return provider.Get<T>();
        }
    }
}
