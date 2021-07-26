using System;

namespace CognizatChallengeServer
{
    public class ScoreResponse : IComparable<ScoreResponse>
    {
        public string Name { get; set; }
        public int SuccessSolutions { get; set; }
        public string TaskNames { get; set; }

        public int CompareTo(ScoreResponse other)
        {
            return this.SuccessSolutions < other.SuccessSolutions ? 1 : -1;
        }
    }
}
