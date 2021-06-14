using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    public sealed record TopicTest(TestStatus Status, bool HasEasyTest, bool HasHardTest)
    {
        public IEnumerable<TestType> TestTypes
        {
            get
            {
                if (HasEasyTest)
                    yield return TestType.Easy;

                if (HasHardTest)
                    yield return TestType.Hard;
            }
        }
    }
}
