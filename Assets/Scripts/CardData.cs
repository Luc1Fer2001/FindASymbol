using UnityEngine;

[System.Serializable]
public class CardData
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _sprite;

    public string Id => _id;
    public Sprite Sprite => _sprite;
}