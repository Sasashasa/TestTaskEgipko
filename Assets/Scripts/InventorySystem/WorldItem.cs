using TMPro;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
	public ItemType ItemType => _itemType;
	public int Amount => _amount;

	[SerializeField] private ItemType _itemType;
	[Range(1, 100)] [SerializeField] private int _amount;
	[SerializeField] private TextMeshPro _amountText;

	private void Awake()
	{
		_amountText.text = Amount.ToString();
		_amountText.gameObject.SetActive(Amount > 1);
	}

	public bool IsStackable()
	{
		return ItemSOContainer.Instance.GetItemSOByItemType(ItemType).IsStackable;
	}
}