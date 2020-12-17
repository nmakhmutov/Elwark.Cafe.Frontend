using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    internal sealed record StatisticsDetail(
        long PassedTests,
        TimeSpan ElapsedTime,
        Score Score,
        AnswerRatio AnswerRatio,
        Ranking<long> ScoreRanking,
        Ranking<TimeSpan> ElapsedTimeRanking
    ) : StatisticsSummary(PassedTests, ElapsedTime, Score, AnswerRatio);
}