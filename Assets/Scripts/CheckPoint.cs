using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour, IInteractable
{
    public static event Action<Vector3> OnCheckPoint;

    private Vector3 _checkPointPosition;

    void Start()
    {
        _checkPointPosition = transform.position;
    }

    public void Interact()
    {
        OnCheckPoint(_checkPointPosition);
    }
}
