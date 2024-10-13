using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
	[SerializeField] private Image _itemImage;
	[SerializeField] private TextMeshProUGUI _amountText;

	public void Setup(Sprite itemSprite, int itemAmount)
	{
		_itemImage.sprite = itemSprite;
		_amountText.text = itemAmount.ToString();
		
		_amountText.gameObject.SetActive(itemAmount > 1);
	}
}