using ObjectPool;
using Spin.Data;
using Spin.Manager;
using Spin.Reward.Piece;
using System.Collections.Generic;
using UnityEngine;

namespace Spin.Reward
{
    public class RewardView : MonoBehaviour, IRewardView
    {
        [SerializeField] private GameObject rewardPrefab;
        [SerializeField] private int rewardPoolSize;

        private IGameManager _gameManager;
        private IUIManager _uiManager;
        private IObjectPooler _objectPooler;
        private IRewardFactory _rewardFactory;
        private ISpriteAtlasManager _spriteAtlasManager;

        private List<RewardPiece> _rewardPieces;

        [Zenject.Inject]
        private void Constructor([Zenject.Inject] IGameManager gameManager, [Zenject.Inject] IUIManager uiManager, [Zenject.Inject] IObjectPooler objectPooler,ISpriteAtlasManager spriteAtlasManager)
        {
            _gameManager = gameManager;
            _uiManager = uiManager;
            _objectPooler = objectPooler;
            _spriteAtlasManager = spriteAtlasManager;
        }

        private void Start()
        {
            Initialize();
        }
        void Initialize()
        {
            _objectPooler.InitializePool(rewardPrefab, rewardPoolSize, transform);
            _rewardPieces = new List<RewardPiece>();
            _rewardFactory = new RewardFactory();
        }
        public bool SetReward(WheelData.ItemData data, int rewardIndex)
        {
            if (data.itemType != ItemType.bomb)
            {
                bool rewardGived = false;
                foreach (RewardPiece item in _rewardPieces)
                {
                    if (item.GetItemType() == data.itemType)
                    {
                        rewardGived = true;
                        item.SetPiece(data, _spriteAtlasManager);
                    }
                }
                if (!rewardGived)
                {
                    GameObject newPiece = _objectPooler.GetPooledObject(rewardPrefab);
                    newPiece.transform.SetParent(transform);
                    newPiece.name = "ui_gameobject_spin_rewardPiece_" + _rewardPieces.Count;

                    _rewardPieces.Add(newPiece.GetComponent<RewardPiece>());
                    _rewardFactory.SetRewardData(data, newPiece.GetComponent<RewardPiece>(),_spriteAtlasManager);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ClearRewards(bool win)
        {
            if (win)
            {
                _uiManager.SetInfoText(true, "You Win Rewards");
                Invoke("ResetRewards", 2f);
            }
            else
            {
                _uiManager.SetInfoText(true, "You Lose Rewards");
                Invoke("ResetRewards", 2f);
            }
        }
        void ResetRewards()
        {
            foreach (RewardPiece item in _rewardPieces)
            {
                item.ResetPiece();
                _objectPooler.ReturnObjectToPool(item.gameObject);
            }
            _rewardPieces.Clear();
            _uiManager.SetInfoText(false, " ");


        }
    }

}
