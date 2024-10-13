using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public ItemType ItemType => _itemType;
    public Sprite Sprite => _sprite;
    public bool IsStackable => _isStackable;
    
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isStackable;
}