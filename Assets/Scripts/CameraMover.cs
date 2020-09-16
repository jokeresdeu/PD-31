using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    void Start()
    {
        _camera.m_Lens.OrthographicSize = 10;
    }
    // Update is called once per fram
}
