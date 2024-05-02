using ObjectPool;
using Spin.Manager;
using Spin.View.Piece;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
namespace Spin.View
{
    public class SpinView : MonoBehaviour, ISpinView
    {

        [SerializeField] private Image _background;
        [SerializeField] private Image _indicator;
        [SerializeField] private Transform _pieceParent;

        private ICircularLayout _circularLayout;
        private IDataManager _dataManager;
        private IObjectPooler _objectPooler;
        private IPieceFactory _pieceFactory;
        private IGameManager _gameManager;
        private ISpriteAtlasManager _spriteAtlasManager;


        private List<WheelPiece> _wheelPieces;
        private List<int> _bombIndexes;


        private bool _hideUI;

        [Zenject.Inject]
        private void Constructor([Zenject.Inject] IGameManager gameManager, [Zenject.Inject] IDataManager dataManager, [Zenject.Inject] ISpriteAtlasManager spriteAtlasManager, [Zenject.Inject] IObjectPooler objectPooler)
        {
            _dataManager = dataManager;
            _objectPooler = objectPooler;
            _gameManager = gameManager;
            _spriteAtlasManager = spriteAtlasManager;
        }

        private void Start()
        {
            Initialize();

        }
        void Initialize()
        {
            _circularLayout = new CircularLayout();
            _pieceFactory = new PieceFactory();
            _objectPooler.InitializePool(_dataManager.GetSpinSettings().ElementPrefab, _dataManager.GetSpinSettings().NumberOfImages, GetWheelTransform());
            _circularLayout.Initialize(_pieceParent, _dataManager, _objectPooler);
            _wheelPieces = _circularLayout.Pieces();
            SetBombIndexes();
            UpdateWheel();
        }

        public void SpinWheel()
        {
            _hideUI = false;
        }
        public void HideUI(bool value)
        {
            if (_hideUI == value)
            {
                return;
            }
            _hideUI = value;
            foreach (WheelPiece piece in _wheelPieces)
            {
                piece.HideUI(value);

            }
        }
        public void UpdateWheel()
        {
            _pieceFactory.SetPieceData(_wheelPieces, _dataManager.GetWheelData(_gameManager.DecideReward()), _spriteAtlasManager);
            _spriteAtlasManager.AddSprite(_dataManager.GetWheelData(_gameManager.DecideReward()).BackgroundSprite.name, _background);
            _spriteAtlasManager.AddSprite(_dataManager.GetWheelData(_gameManager.DecideReward()).IndicatorSprite.name, _indicator);
            //_background.sprite = _dataManager.GetWheelData(_gameManager.DecideReward()).BackgroundSprite;
            //_indicator.sprite = _dataManager.GetWheelData(_gameManager.DecideReward()).IndicatorSprite;
            if (_bombIndexes.Count != _dataManager.GetWheelData(_gameManager.DecideReward()).BombCount)
                SetBombIndexes();
            foreach (int index in _bombIndexes)
            {
                _pieceFactory.SetSinglePieceData(_wheelPieces[index], _dataManager.GetTrapData().Bomb, _spriteAtlasManager);
            }
        }
        void SetBombIndexes()
        {
            _bombIndexes = new List<int>(_dataManager.GetWheelData(_gameManager.DecideReward()).BombCount);
            for (int i = 0; i < _bombIndexes.Capacity; i++)
            {
                int randomIndex = Random.Range(0, _dataManager.GetSpinSettings().NumberOfImages);
                if (_bombIndexes.Count < _dataManager.GetSpinSettings().NumberOfImages)
                {
                    while (_bombIndexes.Contains(randomIndex))
                    {
                        randomIndex = Random.Range(0, _dataManager.GetSpinSettings().NumberOfImages);
                    }
                }
                _bombIndexes.Add(randomIndex);
            }
            _gameManager.SetBombIndexes(_bombIndexes);
        }
        public Transform GetWheelTransform()
        {
            return transform.GetChild(0).transform;
        }
    }
}