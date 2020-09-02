using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private SpriteRenderer _playerSprite;
    [SerializeField]private float speed;
    bool _faceRight = true;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _playerRB.velocity = Vector2.right * speed * Input.GetAxisRaw("Horizontal");
        }
        else
            _playerRB.velocity = Vector2.zero;

        if(Input.GetAxisRaw("Horizontal")< 0 && !_playerSprite.flipX)
        {
            _playerSprite.flipX = true;
        }    
        else if(Input.GetAxisRaw("Horizontal") > 0 && _playerSprite.flipX)
        {
            _playerSprite.flipX = false;
           
        }
    }
   

    void Update()
    {
        
    }
}
