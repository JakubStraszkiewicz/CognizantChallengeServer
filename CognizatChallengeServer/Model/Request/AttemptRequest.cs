
namespace CognizatChallengeServer
{
    public class AttemptRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Solution { get; set; }
        public bool IsSucceed { get; set; }
    }
}
