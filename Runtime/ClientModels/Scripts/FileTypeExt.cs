﻿
namespace Virtuademy.CreatorKit.Worlds.Core.ClientModels
{
    /// <summary>
    /// What kind of file a platform resource is.
    /// </summary>
    /// <remarks>
    /// Stays in the authoring package while <c>IClientModelSystem</c> moves to the main project:
    /// <c>CMResource</c> carries one and the big-screen placeholder branches on it, so it is part
    /// of what a world is authored against. The namespace is unchanged so that no consumer's
    /// <c>using</c> moves.
    /// </remarks>
    public enum FileTypeExt
    {
        None = -1,
        Video = 1,
        Documents = 2,
        Images = 3,
        Asset3D = 4,
    }
}
