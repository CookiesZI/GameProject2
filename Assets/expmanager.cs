using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expmanager : MonoBehaviour
{
    public static expmanager instance;

    public delegate void ExpChangeHandler(int amount);
    public event ExpChangeHandler OnExpChange;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void AddExp(int amount)
    {
        OnExpChange?.Invoke(amount);
    }
}
