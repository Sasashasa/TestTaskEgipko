using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJump _playerJump;
    
    private static readonly int _isWalking = Animator.StringToHash("IsWalking");
    private static readonly int _onGround = Animator.StringToHash("OnGround");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_isWalking, _playerMovement.IsWalking());
        _animator.SetBool(_onGround, _playerJump.OnGround);
    }
}