using ObjectPool;
using Spin.Data;
using Spin.Manager;
using Spin.View.Piece;
using System.Collections.Generic;
using UnityEngine;

namespace Spin.View
{
    public class CircularLayout : ICircularLayout
    {
        private IDataManager _dataManager;
        private IObjectPooler _objectPooler;
        private SpinSettings _settings;

        private List<WheelPiece> _wheelPiece;


        public void Initialize(Transform parent, IDataManager dataManager, IObjectPooler objectPooler)
        {
            _dataManager = dataManager;
            _objectPooler = objectPooler;
            _settings = _dataManager.GetSpinSettings();
            _wheelPiece = new List<WheelPiece>(_settings.NumberOfImages);
            GenerateCircularLayout(parent);
        }
        private void GenerateCircularLayout(Transform parent)
        {
            float angleStep = 360f / _settings.NumberOfImages;
            Vector3 centerPosition = parent.transform.position;

            RectTransform parentRectTransform = parent.GetComponent<RectTransform>();
            float parentWidth = parentRectTransform.rect.width;
            float parentHeight = parentRectTransform.rect.height;

            for (int i = 0; i < _settings.NumberOfImages; i++)
            {
                float angle = i * angleStep;
                float radianAngle = Mathf.Deg2Rad * -(angle - 90);

                float normalizedX = Mathf.Cos(radianAngle);
                float normalizedY = Mathf.Sin(radianAngle);

                float x = _settings.Radius * normalizedX;
                float y = _settings.Radius * normalizedY;

                GameObject piece = _objectPooler.GetPooledObject(_settings.ElementPrefab);

                RectTransform pieceRectTransform = piece.GetComponent<RectTransform>();
                pieceRectTransform.SetParent(parentRectTransform, false);

                Vector2 localPos = new Vector2(x, y);
                pieceRectTransform.anchoredPosition = localPos;

                float angleToCenter = Mathf.Atan2(localPos.y, localPos.x) * Mathf.Rad2Deg;
                pieceRectTransform.rotation = Quaternion.Euler(0f, 0f, angleToCenter + 270f);

                piece.name = "ui_gameobject_spin_piece_group_" + i.ToString();
                _wheelPiece.Add(piece.GetComponent<WheelPiece>());
            }
        }
     
        public List<WheelPiece> Pieces()
        {
            return _wheelPiece;
        }
    }

    interface ICircularLayout
    {
        void Initialize(Transform parent, IDataManager dataManager, IObjectPooler objectPooler);
        List<WheelPiece> Pieces();

    }
}