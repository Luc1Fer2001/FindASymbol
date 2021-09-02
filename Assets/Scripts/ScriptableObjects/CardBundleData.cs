using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewCardBundleData", menuName = "ScriptableObjects/CardBundleData", order = 5)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardData;
        private Sprite _defaultSprite;
        private readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

        public CardData[] CardData => _cardData;

        public Sprite GetSprite(string id)
        {
            if (_sprites.TryGetValue(id, out Sprite sprite))
            {
                return sprite;
            }
            
            for (int i = 0; i < _cardData.Length; i++)
            {
                if (_cardData[i].Id == id)
                {
                    _sprites.Add(_cardData[i].Id, _cardData[i].Sprite);
                    return _cardData[i].Sprite;
                }
            }
            
            return _defaultSprite;
        }
    }
}