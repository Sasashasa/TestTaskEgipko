using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
	public ItemType ItemType
	{
		get => _itemType;
		private set => _itemType = value;
	}

	public int Amount
	{
		get => _amount;
		set
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException();
			
			_amount = value;
		}
	}
	
	[SerializeField] private ItemType _itemType;
	[SerializeField] private int _amount;

	public InventoryItem(WorldItem worldItem)
	{
		ItemType = worldItem.ItemType;
		Amount = worldItem.Amount;
	}

	public Sprite GetSprite()
	{
		return ItemSOContainer.Instance.GetItemSOByItemType(ItemType).Sprite;
	}

	public bool IsStackable()
	{
		return ItemSOContainer.Instance.GetItemSOByItemType(ItemType).IsStackable;
	}
}