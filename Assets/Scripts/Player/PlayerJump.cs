using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
	public bool OnGround { get; private set; }
	
	[SerializeField] private float _jumpForce = 3f;
	[SerializeField] private Transform _groundChecker;
	[SerializeField] private LayerMask _groundLayer;
	[SerializeField] private float _groundCheckerRadius = 0.05f;
	
	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	private void Start()
	{
		GameInput.Instance.OnJumpAction += GameInput_OnJumpAction;
	}

	private void Update()
	{
		OnGround = Physics.OverlapSphere(_groundChecker.position, _groundCheckerRadius, _groundLayer).Length > 0;
	}
	
	private void GameInput_OnJumpAction(object sender, EventArgs e)
	{
		if (!OnGround)
			return;
        
		_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
	}
}