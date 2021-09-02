using System;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class LevelSwitch : MonoBehaviour
    {
        [SerializeField] private int _maxLevelCount;
        [SerializeField] private Field _field;
        public Action OnLevelUpdate;
        public Action OnMaxLevelReached;
        
        private int _level = 1;

        private void Awake()
        {
            _field.OnWinCardFinded += NextLevel;
        }


        private void NextLevel()
        {
            if (_level < _maxLevelCount)
            {
                _level++;
                DOTween.CompleteAll();
                OnLevelUpdate?.Invoke();
            }
            else
            {
                OnMaxLevelReached?.Invoke();
            }
        }
    }
}