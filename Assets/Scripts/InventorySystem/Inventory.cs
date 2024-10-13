using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Inventory
{
	public event EventHandler OnItemsChanged;

	public List<InventoryItem> InventoryItems
	{
		get => _inventoryItems;
		private set => _inventoryItems = value;
	}
	
	[SerializeField] private List<InventoryItem> _inventoryItems;

	public Inventory()
	{
		InventoryItems = new List<InventoryItem>();
	}

	public void AddItem(WorldItem worldItem)
	{
		bool itemAlreadyInInventory = InventoryItems.Any(inventoryItem => inventoryItem.ItemType == worldItem.ItemType);

		if (worldItem.IsStackable() && itemAlreadyInInventory)
		{
			foreach (InventoryItem inventoryItem in InventoryItems)
			{
				if (inventoryItem.ItemType == worldItem.ItemType)
				{
					inventoryItem.Amount += worldItem.Amount;
					break;
				}
			}
		}
		else
		{
			InventoryItems.Add(new InventoryItem(worldItem));
		}
        
		InventorySaveLoadSystem.Instance.SaveInventory(this);
		OnItemsChanged?.Invoke(this, EventArgs.Empty);
	}
	
	public void RemoveItem(InventoryItem inventoryItem)
	{
		if (!InventoryItems.Contains(inventoryItem))
			return;

		if (!inventoryItem.IsStackable() || inventoryItem.Amount == 1)
		{
			InventoryItems.Remove(inventoryItem);
		}
		else
		{
			inventoryItem.Amount -= 1;
		}
        
		InventorySaveLoadSystem.Instance.SaveInventory(this);
		OnItemsChanged?.Invoke(this, EventArgs.Empty);
	}
}