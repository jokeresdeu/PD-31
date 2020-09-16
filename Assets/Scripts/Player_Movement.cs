using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private Animator _playerAnimator;
    [Header("Horizontal move")]
    [SerializeField]private float speed;

    [Header("Jumping")]
    [SerializeField]private float _jumpPower;
    [SerializeField] private float _radius;
    [SerializeField] private bool _airControll;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    bool _grounded;
    bool _secondJump;
    bool _checkJumpRange;

    [Header("Crawling")]
    [SerializeField] private float _crawlingSpeed;
    [SerializeField] private LayerMask _whatIsCell;
    [SerializeField] private Collider2D _headCollider;
    [SerializeField] private Transform _cellCheck;
    bool _canStand;
    float _jumpY;

    bool _faceRight = true;
   
    

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(_groundCheck.position, _radius, _whatIsGround))
        {
            _grounded = true;
            _secondJump = false;
        }
        else
            _grounded = false;

        _canStand = !Physics2D.OverlapCircle(_cellCheck.position, _radius, _whatIsCell);

        if(transform.position.y - _jumpY < 0.5f && _checkJumpRange)
        {
            _playerRB.velocity = new Vector2(_playerRB.velocity.x, 0);
            _checkJumpRange = false;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_cellCheck.position, _radius);
    }

    public void Move(float move,  bool crouch, bool jump)
    {
        #region Animation
        _playerAnimator.SetFloat("Speed", Mathf.Abs(move));
        _playerAnimator.SetBool("Jump", !_grounded);
        _playerAnimator.SetBool("Crouch", !_headCollider.enabled);
        #endregion 

        if (move != 0 && (_grounded || _airControll))
        {
            _playerRB.velocity = new Vector2(speed * move, _playerRB.velocity.y);
        }
        else if (move == 0 && _grounded)
            _playerRB.velocity = new Vector2(0, _playerRB.velocity.y);

        if (_faceRight && move < 0)
            Flip();
        else if (!_faceRight && move > 0)
            Flip();

        if (jump)
        {
            if(_grounded)
            {
                _playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpPower);
            }
            else if(!_secondJump)
            {
                _secondJump = true;
                _playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpPower);
            }
        }

        if (crouch)
        {
            _headCollider.enabled = false;
        }
        else if (!crouch && _canStand)
        {
            _headCollider.enabled = true;
        }

    }

    void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }


}
