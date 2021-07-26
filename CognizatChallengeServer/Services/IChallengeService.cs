using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizatChallengeServer
{
    public interface IChallengeService
    {
        Task<int> SaveAttempt(AttemptRequest task);
        Task<List<ScoreResponse>> GetLeaderBoard();
    }
}
