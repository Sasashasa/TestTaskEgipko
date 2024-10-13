using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private LayerMask _collisionLayer;
    
    private const float _minMovementInput = 0.5f;
    
    private bool _isWalking;
    private float _playerRadius;

    private void Awake()
    {
        Instance = this;
        
        _playerRadius = GetComponent<BoxCollider>().size.x;
    }

    private void Update()
    {
        HandleMovement();
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = _moveSpeed * Time.deltaTime;
        bool canMove = !Physics.BoxCast(transform.position, Vector3.one * _playerRadius, moveDir, Quaternion.identity, moveDistance, _collisionLayer);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = (moveDir.x < -_minMovementInput || moveDir.x > _minMovementInput) && !Physics.BoxCast(transform.position, Vector3.one * _playerRadius, moveDirX, Quaternion.identity, moveDistance, _collisionLayer);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = (moveDir.z < -_minMovementInput || moveDir.z > +_minMovementInput) && !Physics.BoxCast(transform.position, Vector3.one * _playerRadius, moveDirZ, Quaternion.identity, moveDistance, _collisionLayer);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        _isWalking = moveDir != Vector3.zero;
        
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);
    }
}