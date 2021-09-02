using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardBundleList", menuName = "ScriptableObjects/CardBundleList", order = 5)]
    public class CardBundleList : ScriptableObject
    {
        public List<CardBundleData> cardBundleDatas = new List<CardBundleData>();
    }
}