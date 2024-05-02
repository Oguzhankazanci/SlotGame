using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spin.Manager;
using UnityEngine.U2D;

namespace Spin.View.Piece
{
    public class WheelPiece : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _slotText;

        private ISpriteAtlasManager _spriteAtlasManager;

        public void SetPiece(Sprite icon, int value, ISpriteAtlasManager spriteAtlasManager)
        {
            _spriteAtlasManager = spriteAtlasManager;
            _spriteAtlasManager.AddSprite(icon.name, _icon);
            _slotText.text = "x " + value.ToString();
        }
        public void HideUI(bool value)
        {
            if (value)
            {
                _icon.DOFade(0, 0.5f);
                _slotText.DOFade(0, 0.5f);
            }
            else
            {
                _icon.DOFade(1, 0.5f);
                _slotText.DOFade(1, 0.5f);
            }
        }
    }
}
