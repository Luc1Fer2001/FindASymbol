using System;
using Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private int _cardCountInRow;
        [SerializeField] private int _startCardCount;
        [SerializeField] private int _cardPerLevel;
        
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private CardSpawner _cardSpawner;
        [SerializeField] private LevelSwitch _levelSwitch;

        [SerializeField] private string _currentIdToFind;
        public Action OnWinCardFinded;

        private void Awake()
        {
            _cardSpawner.OnIdToFindChanged += SetIdToFind;
            _cardSpawner.OnSpawnComplete += SetSizeField;
            _cardSpawner.OnSpawnComplete += Subscribe;
            _levelSwitch.OnLevelUpdate += SpawnAtNewLevel;
        }

        private void Start()
        {
            _cardSpawner.SpawnCards(_startCardCount);
        }

        private void SpawnAtNewLevel()
        {
            _cardSpawner.SpawnCards(_cardPerLevel);
        }

        private void SetIdToFind(string id)
        {
            _currentIdToFind = id;
        }

        private void Subscribe()
        {
            var cardsList = _cardSpawner.CardsInField;
            for (int i = 0; i < cardsList.Count; i++)
            {
                cardsList[i].OnCardPressed += CheckAnswer;
            }
        }

        private void SetSizeField()
        {
            var cellSizeX = _gridLayoutGroup.cellSize.x;
            var cellSizeY = _gridLayoutGroup.cellSize.y;
            
            var spacingX = _gridLayoutGroup.spacing.x;
            var spacingY = _gridLayoutGroup.spacing.y;
            
            var rowCount = _cardSpawner.CardsInField.Count / _cardCountInRow;
            
            var sizeX = (cellSizeX * _cardCountInRow) + (spacingX * (_startCardCount - 1)) + (_gridLayoutGroup.padding.left + _gridLayoutGroup.padding.right);
            var sizeY = (cellSizeY * rowCount) + (spacingY * rowCount) + (_gridLayoutGroup.padding.top + _gridLayoutGroup.padding.bottom);
            
            var rectTransform = transform as RectTransform;
            rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
            rectTransform.TransformPoint(0, 0, 0);
        }

        private void CheckAnswer(Card card)
        {
            if (card.Id == _currentIdToFind)
            {
                card.transform.PlayBounceToTop(() =>
                {
                    OnWinCardFinded?.Invoke();
                });
            }
            else
            {
                card.transform.PlaySideBounce();
            }
        }
    }
}