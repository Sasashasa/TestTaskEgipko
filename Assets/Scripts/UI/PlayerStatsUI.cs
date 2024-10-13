using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _strengthText;
	[SerializeField] private TextMeshProUGUI _enduranceText;
	[SerializeField] private TextMeshProUGUI _wisdomText;

	private Dictionary<PlayerStat, TextMeshProUGUI> _playerStatsTexts;

	private void Awake()
	{
		_playerStatsTexts = new Dictionary<PlayerStat, TextMeshProUGUI>
		{
			[PlayerStat.Strength] = _strengthText,
			[PlayerStat.Endurance] = _enduranceText,
			[PlayerStat.Wisdom] = _wisdomText,
		};
	}

	private void Start()
	{
		PlayerStatsHandler.Instance.OnPlayerStatChanged += PlayerStatsHandler_OnPlayerStatChanged;
		
		SetupTexts();
	}

	private void PlayerStatsHandler_OnPlayerStatChanged(object sender, PlayerStatsHandler.OnPlayerStatChangedEventArgs e)
	{
		_playerStatsTexts[e.PlayerStat].text = $"{e.PlayerStat}: {e.NewValue}";
	}

	private void SetupTexts()
	{
		_strengthText.text = $"{PlayerStat.Strength}: {PlayerStatsHandler.Instance.Strength}";
		_enduranceText.text = $"{PlayerStat.Endurance}: {PlayerStatsHandler.Instance.Endurance}";
		_wisdomText.text = $"{PlayerStat.Wisdom}: {PlayerStatsHandler.Instance.Wisdom}";
	}
}