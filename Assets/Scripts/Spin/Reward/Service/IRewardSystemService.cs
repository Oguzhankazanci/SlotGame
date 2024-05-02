namespace Spin.Reward
{
    public interface IRewardSystemService
    {
        void CalculateReward(float angle, int pieceCount);
        bool GetResult();
        void ResetResult(bool value);
    }
}
