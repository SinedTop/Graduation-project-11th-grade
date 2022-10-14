using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public string _nameRU, _nameEN;
    public string _descriptionRU, _descriptionEN;
    public Sprite _image;
    public Rareness _rareType;
    public int _maxStack;

    public enum Rareness { Simple, Unusual, Rare, Epical, Legendary, Mythical }
}
