using UnityEngine;

namespace Spin.Data
{
    [CreateAssetMenu(menuName = "Spin/Data/Wheel Data")]
    public class WheelData : ScriptableObject
    {
        [SerializeField] private Sprite _backgroundSprite;
        public Sprite BackgroundSprite { get { return _backgroundSprite; } }

        [SerializeField] private Sprite _indicatorSprite;
        public Sprite IndicatorSprite { get { return _indicatorSprite; } }

        [SerializeField] private int _bombCount;
        public int BombCount { get { return _bombCount; } }

        [System.Serializable]
        public struct ItemData
        {
            public Sprite itemIcon;
            public int itemValue;
            public ItemType itemType;
        }
        [SerializeField] private ItemData[] _items;
        public ItemData[] Items { get { return _items; } }


    }
    public enum ItemType
    {
        redBox,
        yellowBox,
        money,
        coin,
        bomb
    }
}