namespace Spin.Reward
{
    public interface IRewardCalculationStrategy
    {
        int CalculateReward(float angle, int pieceCount);
    }

}