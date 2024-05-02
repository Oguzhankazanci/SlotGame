using Spin.Data;

namespace Spin.Reward
{
	public interface IRewardView
	{
        bool SetReward(WheelData.ItemData data, int rewardIndex);
        void ClearRewards(bool win);

    }
}
