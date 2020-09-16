using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _timeStep;
    [SerializeField] private int _damage;
    private DateTime _enconterTime;
    PlayerController _player;
    
    private void OnTriggerEnter2D(Collider2D info)
    {
        if((DateTime.Now - _enconterTime).TotalSeconds < 0.02f)
        {
            return;
        }
        _enconterTime = DateTime.Now;
        _player = info.GetComponent<PlayerController>();
        if (_player != null)
            _player.ChangeHP(-_damage);
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        
        if (_player == info.GetComponent<PlayerController>())
        {
            _player = null;
        }
    }

    private void Update()
    {
        if(_player != null && (DateTime.Now - _enconterTime).TotalSeconds > _timeStep)
        {
            _player.ChangeHP(-_damage);
            _enconterTime = DateTime.Now;
        }
    }
}
