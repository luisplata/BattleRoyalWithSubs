namespace Refactoring
{
    public class RockPaperAndScissors
    {
        private readonly IIPlayerGameRps _iPlayerGameRps;

        public RockPaperAndScissors(IIPlayerGameRps iPlayerGameRps)
        {
            _iPlayerGameRps = iPlayerGameRps;
        }

        public int GetResult()
        {
            return _iPlayerGameRps.GetRandom(0, 3);
        }
    }
}