using UnityEngine;

namespace Virtuademy.Environments.ScriptingApi
{
    /// <summary>
    /// The player's tools, and the feedback a world spawns to answer them.
    /// </summary>
    public interface IToolsApi
    {
        /// <summary>Sets the opacity of the tool inventory, 0 to 1.</summary>
        /// <remarks>Node: <c>Reflectis Tools: Set Alpha</c>.</remarks>
        void SetInventoryAlpha(float alpha);

        /// <summary>
        /// Spawns the right-or-wrong feedback at a point — the tick or the cross a quiz shows.
        /// </summary>
        /// <remarks>Node: <c>Reflectis general: Spawn Feedback</c>. WebGL only, as the node says.</remarks>
        void ShowAnswerFeedback(Transform where, bool correct);
    }
}
