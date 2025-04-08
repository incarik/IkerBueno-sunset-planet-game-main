using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinZone : MonoBehaviour, IInteractable
{
    public static event Action OnWin;

    public void Interact()
    {
        OnWin?.Invoke();
    }
}
