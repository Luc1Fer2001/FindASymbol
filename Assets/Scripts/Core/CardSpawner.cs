using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private CardBundleList _cardBundlelist;
        private CardBundleData _cardBundleData;
        [SerializeField] private Card _cardPrefab;
        [SerializeField] private string _currentIdToFind;
        
        private List<string> _allId = new List<string>();
        private List<Card> _cardsInField = new List<Card>();
        private List<string> _oldIdToWin = new List<string>();

        public Action<string> OnIdToFindChanged;
        public Action OnSpawnComplete;
        public List<Card> CardsInField => _cardsInField;

        private void SetIdToFind()
        {
            List<string> allIdInField = new List<string>();
            for (int i = 0; i < _cardsInField.Count; i++)
            {
                allIdInField.Add(_cardsInField[i].Id);
            }

            for (int i = 0; i < _oldIdToWin.Count; i++)
            {
                allIdInField.Remove(_oldIdToWin[i]);
            }
            
            _currentIdToFind = allIdInField[Random.Range(0, allIdInField.Count)];;
            _oldIdToWin.Add(_currentIdToFind);
            OnIdToFindChanged?.Invoke(_currentIdToFind);
        }

        
        private string GetId()
        {
            var id = _allId[Random.Range(0, _allId.Count)];
            _allId.Remove(id);
            return id;
        }

        private void FillIdList()
        {
            _cardBundleData = _cardBundlelist.cardBundleDatas[Random.Range(0, _cardBundlelist.cardBundleDatas.Count)];
            _allId.Clear();
            for (int i = 0; i < _cardBundleData.CardData.Length; i++)
            {
                _allId.Add(_cardBundleData.CardData[i].Id);
            }
        }
        
        public void SpawnCards(int count)
        {
            FillIdList();
            if (_cardsInField.Count != 0)
            {
                for (int i = 0; i < _cardsInField.Count; i++)
                {
                    var id = GetId();
                    _cardsInField[i].Init(id, _cardBundleData.GetSprite(id));
                }
            }
            
            for (int i = 0; i < count; i++)
            {
                var spawnedCard = Instantiate(_cardPrefab, transform);
                var id = GetId();
                spawnedCard.Init(id, _cardBundleData.GetSprite(id));
                _cardsInField.Add(spawnedCard);
            }
            OnSpawnComplete?.Invoke();
            SetIdToFind();
        }
    }
}