namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// What the world runtime hands to <see cref="World.Install"/>. Internal: a script may call the
    /// groups but may not supply them, and adding a group to the surface means adding a property
    /// here rather than changing an installer signature.
    /// </summary>
    internal interface IWorldBackend
    {
        IPlayerApi Player { get; }

        ILocalizationApi Localization { get; }

        ISessionApi Session { get; }
    }
}
