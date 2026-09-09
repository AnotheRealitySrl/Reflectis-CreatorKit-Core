using Virtuademy.SDK.Core.SystemFramework;
using Virtuademy.SDK.PlatformApi;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Virtuademy.CreatorKit.Worlds.Analytics
{
    /// <summary>
    /// Emitting analytics from a world.
    /// </summary>
    /// <remarks>
    /// <b>The three tables below are read-only, and that is a security property rather than
    /// tidiness.</b> They were <c>public static</c> mutable <c>Dictionary</c> fields on this
    /// interface, so any code in the process could replace one outright or edit an entry —
    /// including an authored Visual Scripting graph, which is the surface the assembly perimeter
    /// exists to contain.
    /// <para>
    /// <see cref="VerbsDTOs"/> is the one that matters: <c>AnalyticSendDataUnit</c> looks a verb up
    /// in it and hands the result to <c>Type.Instantiate()</c> and <c>GetRuntimeFields()</c>, then
    /// populates those fields from the node's inputs. A writable mapping therefore chose which type
    /// got reflectively constructed and filled — arbitrary instantiation reachable from a graph. As
    /// <c>static readonly IReadOnlyDictionary</c> the reference cannot be swapped and the entries
    /// cannot be edited.
    /// </para>
    /// <para>
    /// Measured before changing them: six read sites across the package and the app, and no writes
    /// anywhere. Nothing was using the mutability.
    /// </para>
    /// </remarks>
    public interface IAnalyticsSystem : ISystem
    {
        /// <summary>Which verbs belong to which kind of analytic.</summary>
        public static readonly IReadOnlyDictionary<EAnalyticType, IReadOnlyList<EAnalyticVerb>> VerbsTypes =
            new Dictionary<EAnalyticType, IReadOnlyList<EAnalyticVerb>>
            {
                {
                    EAnalyticType.Experience,
                    new List<EAnalyticVerb>
                    {
                        EAnalyticVerb.ExpJoin,
                        EAnalyticVerb.ExpStart,
                        EAnalyticVerb.ExpComplete,
                        EAnalyticVerb.StepStart,
                        EAnalyticVerb.StepComplete,
                        EAnalyticVerb.ExpTranscript
                    }
                }
            };

        /// <summary>
        /// The payload type each verb carries. Consumed by reflection — see the remarks on this
        /// interface for why it must not be writable.
        /// </summary>
        public static readonly IReadOnlyDictionary<EAnalyticVerb, Type> VerbsDTOs =
            new Dictionary<EAnalyticVerb, Type>
            {
                { EAnalyticVerb.ExpJoin, typeof(ExperienceJoinDTO) },
                { EAnalyticVerb.ExpStart, typeof(ExperienceStartDTO) },
                { EAnalyticVerb.ExpComplete, typeof(ExperienceCompleteDTO) },
                { EAnalyticVerb.StepStart, typeof(ExperienceStepStartDTO) },
                { EAnalyticVerb.StepComplete, typeof(ExperienceStepCompleteDTO) },
                { EAnalyticVerb.ExpTranscript, typeof(ExperienceTranscriptDTO) },
            };

        /// <summary>
        /// The content type behind each displayable kind. Reflectively instantiated in the same way
        /// as <see cref="VerbsDTOs"/>, and read-only for the same reason.
        /// </summary>
        public static readonly IReadOnlyDictionary<EAnalyticsDisplayableType, Type> DisplayableDataTypes =
            new Dictionary<EAnalyticsDisplayableType, Type>
            {
                { EAnalyticsDisplayableType.Dynamic, typeof(DynamicDisplayableContent) }
            };

        Task GenerateExperienceGUID(string key);

        string GenerateUniqueExperienceGUIDXPlayer(string key);

        void SendAnalytic(EAnalyticVerb verb, AnalyticDTO analytic);
    }
}
