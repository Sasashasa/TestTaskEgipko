using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
	public ItemType ItemType;
	public int Amount;

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