using UnityEngine;

public class InventorySaveLoadSystem : MonoBehaviour
{
	public static InventorySaveLoadSystem Instance { get; private set; }
	
	private const string InventoryPlayerPrefs = "InventoryPlayerPrefs";

	private void Awake()
	{
		Instance = this;
	}

	public bool HasInventorySave()
	{
		return PlayerPrefs.HasKey(InventoryPlayerPrefs);
	}
    
	public void SaveInventory(Inventory inventory)
	{
		string json = JsonUtility.ToJson(inventory);
		
		PlayerPrefs.SetString(InventoryPlayerPrefs, json);
		PlayerPrefs.Save();
	}

	
	public Inventory LoadInventory()
	{
		string json = PlayerPrefs.GetString(InventoryPlayerPrefs);
		
		Inventory inventory = JsonUtility.FromJson<Inventory>(json);

		return inventory;
	}
}