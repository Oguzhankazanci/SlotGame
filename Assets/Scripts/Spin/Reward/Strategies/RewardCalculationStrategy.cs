namespace Spin.Reward
{
    public class RewardCalculationStrategy : IRewardCalculationStrategy
    {
        public int CalculateReward(float angle, int pieceCount)
        {
            float angleStep = 360f / pieceCount;

            return (int)(angle / angleStep) % pieceCount;

        }
    }
}
