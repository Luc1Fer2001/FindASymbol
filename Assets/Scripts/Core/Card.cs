using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core
{
    public class Card : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string _id;
        [SerializeField] private Image _image;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;

        private Action<Card> _onCardPressed;
        public event Action<Card> OnCardPressed
        {
            add => _onCardPressed = value;
            remove => _onCardPressed = null;
        }

        public string Id
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        public void Init(string id, Sprite sprite)
        {
            Id = id;
            _image.sprite = sprite;
            SetSpriteSize();
        }

        private void SetSpriteSize()
        {
            var sizeX = _image.sprite.bounds.size.x;
            var sizeY = _image.sprite.bounds.size.y;
            _aspectRatioFitter.aspectRatio = sizeX / sizeY;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _onCardPressed?.Invoke(this);
        }
    }
}