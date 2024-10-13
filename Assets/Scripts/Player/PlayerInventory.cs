using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory Instance { get; private set; }

	public Inventory Inventory { get; private set; }
	
	
	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		bool hasInventorySave = InventorySaveLoadSystem.Instance.HasInventorySave();
		Inventory = hasInventorySave ? InventorySaveLoadSystem.Instance.LoadInventory() : new Inventory();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out WorldItem worldItem))
		{
			Inventory.AddItem(worldItem);
			Destroy(worldItem.gameObject);
		}
	}
	
	public void UseItem(InventoryItem inventoryItem)
	{
		if (!Inventory.InventoryItems.Contains(inventoryItem))
			return;
		
		switch (inventoryItem.ItemType)
		{
			case ItemType.HealthPotion:
				PlayerHealth.Instance.TakeHealth(50);
				break;
			case ItemType.SpeedPotion:
				PlayerStatsHandler.Instance.SetPlayerStat(PlayerStat.Endurance, PlayerStatsHandler.Instance.Endurance + 1);
				break;
			case ItemType.WisdomBook:
				PlayerStatsHandler.Instance.SetPlayerStat(PlayerStat.Wisdom, PlayerStatsHandler.Instance.Wisdom + 1);
				break;
			case ItemType.PowerHammer:
				PlayerStatsHandler.Instance.SetPlayerStat(PlayerStat.Strength, PlayerStatsHandler.Instance.Strength + 1);
				break;
			case ItemType.Poison:
				PlayerHealth.Instance.TakeDamage(50);
				break;
		}
		
		Inventory.RemoveItem(inventoryItem);
	}
}