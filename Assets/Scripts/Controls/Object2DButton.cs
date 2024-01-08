using System;
using UnityEngine;

public class Object2DButton : MonoBehaviour
{
    public event Action OnObjectClicked;

    public void OnClick()
    {
        OnObjectClicked?.Invoke();
    }
}