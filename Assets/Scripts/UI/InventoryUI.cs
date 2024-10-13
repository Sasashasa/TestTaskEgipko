using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] private Transform _itemSlotContainer;
	[SerializeField] private GameObject _itemSlotUI;
	
	private void Start()
	{
		PlayerInventory.Instance.Inventory.OnItemsChanged += Inventory_OnItemsChanged;
		RefreshInventoryItems();
	}

	private void Inventory_OnItemsChanged(object sender, EventArgs e)
	{
		RefreshInventoryItems();
	}

	private void RefreshInventoryItems()
	{
		foreach (Transform child in _itemSlotContainer)
		{
			Destroy(child.gameObject);
		}
		
		foreach (InventoryItem item in PlayerInventory.Instance.Inventory.InventoryItems)
		{
			ItemSlotUI itemSlotUI = Instantiate(_itemSlotUI, _itemSlotContainer).GetComponent<ItemSlotUI>();
			
			itemSlotUI.gameObject.GetComponent<Button>().onClick.AddListener(() =>
			{
				PlayerInventory.Instance.UseItem(item);
			});
			
			itemSlotUI.Setup(item.GetSprite(), item.Amount);
		}
	}
}