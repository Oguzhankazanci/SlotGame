using ObjectPool;
using Spin.Data;
using Spin.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Spin.Reward.Piece
{
    public class RewardPiece : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _rewardText;

        private ItemType _itemType;

        private int _rewardValue;

        private ISpriteAtlasManager _spriteAtlasManager;


        public void SetPiece(WheelData.ItemData data, ISpriteAtlasManager spriteAtlasManager)
        {
            _spriteAtlasManager= spriteAtlasManager;
            _spriteAtlasManager.AddSprite(data.itemIcon.name,_icon);
            _rewardValue += data.itemValue;
            _rewardText.text = "x " + _rewardValue.ToString();
            _itemType = data.itemType;
        }
        public void ResetPiece()
        {
            _rewardValue = 0;
        }
        public ItemType GetItemType()
        {
            return _itemType;
        }
    }
}
