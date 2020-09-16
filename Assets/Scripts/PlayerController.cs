using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;

    void Start()
    {
        _currentHp = _maxHp;
    }

    public void ChangeHP(int value)
    {
        _currentHp += value;
        Debug.Log("Change = " + value);
        Debug.Log("Current HP = " + _currentHp);
        if(_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
        else if(_currentHp<=0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
