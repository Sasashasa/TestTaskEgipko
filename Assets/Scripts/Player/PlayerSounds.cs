using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private const float FOOTSTEP_TIMER_MAX = .1f;
    
    private PlayerMovement _playerMovement;
    private float _footstepTimer;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void Update()
    {
        _footstepTimer -= Time.deltaTime;

        if (_footstepTimer < 0f)
        {
            _footstepTimer = FOOTSTEP_TIMER_MAX;

            if (_playerMovement.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootstepsSound(_playerMovement.transform.position, volume);
            }
        }
    }
}