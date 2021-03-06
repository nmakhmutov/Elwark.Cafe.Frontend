using System;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record TopicStatistics(
        TopicSummary Topic,
        TopicStatistics.TotalProgress Progress,
        TopicStatistics.Statistics EasyTest,
        TopicStatistics.Statistics HardTest
    )
    {
        public sealed record TotalProgress(uint Tests, ulong Score, uint Questions, TimeSpan TimeSpent);
        
        public sealed record Statistics(
            Score Score,
            AnswerRatio AnswerRatio,
            TimeSpan TimeSpent,
            NumberOfTests NumberOfTests,
            TopicTestConclusion[] Conclusions
        );
    }
}
