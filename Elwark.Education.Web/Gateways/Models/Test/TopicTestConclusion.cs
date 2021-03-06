using System;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    public sealed record TopicTestConclusion(
        ConclusionStatus Status,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
