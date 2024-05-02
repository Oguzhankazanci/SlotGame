using Spin.Data;
using Spin.Manager;
using Spin.Reward.Piece;

namespace Spin.Reward
{
    public class RewardFactory : IRewardFactory
    {
        public void SetRewardData(WheelData.ItemData data,RewardPiece piece, ISpriteAtlasManager spriteAtlasManager)
        {
            piece.SetPiece(data, spriteAtlasManager);
        }
    }
    public interface IRewardFactory
    {
        void SetRewardData(WheelData.ItemData data, RewardPiece piece, ISpriteAtlasManager spriteAtlasManager);
    }
}
