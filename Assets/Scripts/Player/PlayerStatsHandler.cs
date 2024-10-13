using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
	public static PlayerStatsHandler Instance { get; private set; }
	
	public event EventHandler<OnPlayerStatChangedEventArgs> OnPlayerStatChanged;
	public class OnPlayerStatChangedEventArgs : EventArgs
	{
		public PlayerStat PlayerStat;
		public int NewValue;
	}

	public int Strength => _playerStats[PlayerStat.Strength];
	public int Endurance => _playerStats[PlayerStat.Endurance];
	public int Wisdom => _playerStats[PlayerStat.Wisdom];

	[Range(0, 10)] [SerializeField] private int _startStrength;
	[Range(0, 10)] [SerializeField] private int _startEndurance;
	[Range(0, 10)] [SerializeField] private int _startWisdom;

	private Dictionary<PlayerStat, int> _playerStats;

	private void Awake()
	{
		Instance = this;

		_playerStats = new Dictionary<PlayerStat, int>
		{
			[PlayerStat.Strength] = _startStrength,
			[PlayerStat.Endurance] = _startEndurance,
			[PlayerStat.Wisdom] = _startWisdom,
		};
	}

	public void SetPlayerStat(PlayerStat stat, int newValue)
	{
		if (newValue < 0)
			return;

		_playerStats[stat] = newValue;
		
		OnPlayerStatChanged?.Invoke(this, new OnPlayerStatChangedEventArgs
		{
			PlayerStat = stat,
			NewValue = newValue,
		});
	}
}