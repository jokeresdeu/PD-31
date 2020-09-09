using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    [SerializeField] private Player_Movement _playerMovement;
    private float _move;
    private bool _jump;
    private bool _crawling;

    private void FixedUpdate()
    {
        _playerMovement.Move(_move, _crawling, _jump);
        _jump = false;
    }
    // Update is called once per frame
    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonUp("Jump"))
        {
            _jump = true;
        }
        _crawling = Input.GetKey(KeyCode.C);
    }
}
