using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizatChallengeServer
{
    public class ChallengeService : IChallengeService
    {
        private const int AmountOfScores = 3;
        private WriteContext _context;
        public ChallengeService(WriteContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAttempt(AttemptRequest attemptRequest)
        {
            if(!_context.Users.Any(x => x.Name.Equals(attemptRequest.UserName)))
            {
                User newUser = new User
                {
                    Name = attemptRequest.UserName
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }

            var user = await _context.Users.Where(x => x.Name.Equals(attemptRequest.UserName)).FirstAsync();
            Attempt attempt = new Attempt
            {
                Solution = attemptRequest.Solution,
                TaskName = attemptRequest.Name,
                User = user,
                UserId = user.Guid
            };
            _context.Attempts.Add(attempt);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ScoreResponse>> GetLeaderBoard()
        {
            var statistics = await _context.Attempts.Where(x => x.IsSuccessful)
            .GroupBy(t => new { TaskName = t.TaskName, UserName = t.User.Name })
            .Select(g => new { TaskName = g.Key.TaskName, UserName = g.Key.UserName, Count = g.Count() }).ToListAsync();

            return statistics.GroupBy(x => x.UserName)
                .Select(g => new ScoreResponse { 
                    Name = g.Key, 
                    TaskNames = string.Join(',', g.Select(y => y.TaskName)), 
                    SuccessSolutions = g.Count() })
                .Where(x => x.SuccessSolutions > 0)
                .OrderByDescending(x => x.SuccessSolutions)
                .Take(AmountOfScores)
                .ToList();          
        }
    }
}
