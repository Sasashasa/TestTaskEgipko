using UnityEngine;

public class ItemSOContainer : MonoBehaviour
{
	public static ItemSOContainer Instance { get; private set; }
	
	[SerializeField] private ItemSO[] _itemSOArray;

	private void Awake()
	{
		Instance = this;
	}

	public ItemSO GetItemSOByItemType(ItemType itemType)
	{
		foreach (ItemSO itemSO in _itemSOArray)
		{
			if (itemSO.ItemType == itemType)
			{
				return itemSO;
			}
		}
		
		Debug.LogError("There is no ItemSO with item type: " + itemType);

		return _itemSOArray[0];
	}
}