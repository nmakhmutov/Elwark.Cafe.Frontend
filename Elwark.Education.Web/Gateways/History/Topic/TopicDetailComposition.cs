using Elwark.Education.Web.Gateways.Models.Content;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    internal sealed record TopicDetailComposition(
        TopicDetail Topic,
        TopicTest Test,
        UserContentRating Rating,
        UserTopicProgress Progress,
        bool IsFavorite,
        UserTopicSummary[] RelatedTopics
    );
}
