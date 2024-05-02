using Spin.Data;
using Spin.Manager;


namespace Spin.Reward
{
    public class RewardSystemService : IRewardSystemService
    {

        private readonly IRewardCalculationStrategy _rewardStrategy;
        private readonly IRewardView _rewardView;


        private IDataManager _dataManager;
        private IGameManager _gameManager;
        private WheelData _wheelData;

        bool result;

        public RewardSystemService(IRewardCalculationStrategy strategy, IRewardView rewardView, IDataManager dataManager, IGameManager gameManager)
        {
            _rewardStrategy = strategy;
            _rewardView = rewardView;
            _dataManager = dataManager;
            _gameManager = gameManager;


        }
        // managerden gelecez buraya
        public void CalculateReward(float angle, int pieceCount)
        {
            _wheelData = _dataManager.GetWheelData(_gameManager.DecideReward());
            int rewardIndex = _rewardStrategy.CalculateReward(angle, pieceCount);
            foreach (int bomb in _gameManager.GetBombIndexes())
            {
                if (bomb == rewardIndex)
                {
                    result = false;
                    return;
                }
            }
            for (int i = 0; i < _wheelData.Items.Length; i++)
            {
                if (i == rewardIndex)
                {
                    result = _rewardView.SetReward(_wheelData.Items[i], i);
                    return;
                }
            }
        }
        public bool GetResult()
        {
            return result;
        }
        public void ResetResult(bool value)
        {
            _rewardView.ClearRewards(value);
        }
       
    }
}
